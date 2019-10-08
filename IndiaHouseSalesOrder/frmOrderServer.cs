using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IndiaHouseSalesOrder.Repositories;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using IndiaHouse.Core.Models;
using IndiaHouse.Core.Repositories;
using IndiaHouseSalesOrder.Properties;

namespace IndiaHouseSalesOrder
{
    public partial class frmOrderServer : Form
    {
        public static List<InventoryItem> _items;
        public static List<Customer> _customers;

        public frmOrderServer()
        {
            InitializeComponent();
        }

        private void frmOrderServer_Load(object sender, EventArgs e)
        {
            if (Settings.Default.CachedItems != null)
                _items = Settings.Default.CachedItems;

            if (Settings.Default.CachedCustomers != null)
                _customers = Settings.Default.CachedCustomers;
        }

        // State object for reading client data asynchronously  
        public class StateObject
        {
            // Client  socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 1024;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();
        }

        // Thread signal.  
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        private async void btnHostConnection_Click(object sender, EventArgs e)
        {
            if (Settings.Default.CachedItems == null)
            {
                InventoryHelper2 inventoryHelper = new InventoryHelper2(SessionManager.NewQBSession());
                _items = inventoryHelper.getAllItems();

                Settings.Default.CachedItems = _items;
                Settings.Default.Save();
            }

            if (Settings.Default.CachedCustomers == null)
            {
                CustomersHelper customerHelper = new CustomersHelper(SessionManager.NewQBSession());
                _customers = customerHelper.getAllCustomers();

                Settings.Default.CachedCustomers = _customers;
                Settings.Default.Save();
            }

           await Task.Run(() => this.StartListening());
        }

        public void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // The DNS name of the computer  
            // running the listener is "host.contoso.com".  
            IPHostEntry ipHostInfo = Dns.GetHostEntry("192.168.0.154");
            IPAddress ipAddress = Dns.Resolve(Dns.GetHostName()).AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.  
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.  
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.  
                    allDone.WaitOne();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            allDone.Set();

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read   
                // more data.  
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the   
                    // client. Display it on the console.  
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                    // Echo the data back to the client.  
                    Send(handler, content);
                }
                else
                {
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private static void Send(Socket handler, String data)
        {
            data = data.Replace("<EOF>", "");

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();


            List<InventoryItem> _sendItems;
            List<Customer> _sendCustomers;

            if (data.StartsWith("<ItemSearch>"))
            {
                _sendItems = _items.Where(i => i.MPN.Contains(data.Replace("<ItemSearch>", ""))).ToList();
                bf.Serialize(ms, _sendItems);
            }
            else if (data.StartsWith("<CustomerSearch>"))
            {
                _sendCustomers = _customers.Where(i => i.Name.ToLower().Contains(data.Replace("<CustomerSearch>", "").ToLower())).ToList();
                bf.Serialize(ms, _sendCustomers);
            }

            byte[] itemByte = ms.ToArray();

            handler.Send(itemByte);
            //code to send async
            //handler.BeginSend(itemByte, 0, itemByte.Length, 0, new AsyncCallback(SendCallback), handler);

            //Original Example code
            //// Convert the string data to byte data using ASCII encoding.  
            //byte[] byteData = Encoding.ASCII.GetBytes(data);

            //// Begin sending the data to the remote device.  
            //handler.BeginSend(byteData, 0, byteData.Length, 0,
            //new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double result = await Task.Run(() => this.SlowDivision(3, 4));
                this.label2.Text = result.ToString();
            }
            catch (Exception ex)
            {
                this.txtStatus.Text = ex.ToString();
            } 
        }

        private double SlowDivision(double a, double b)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            return a * b;
        }
    }
}
