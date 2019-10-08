using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interop.QBFC13;
using IndiaHouse.Core.Helpers;
using IndiaHouseSalesOrder.Repositories;

namespace IndiaHouseSalesOrder
{
    public partial class CustomerEmail : Form
    {
        private List<string> _emailsToDelete = EmailsToDelete.emailList;
        public CustomerEmail()
        {
            InitializeComponent();
        }
        private QBSessionManager _MySessionManager;
  
        private void editCustomer_Click(object sender, EventArgs e)
        {
            _MySessionManager = SessionManager.NewQBSession();

            IMsgSetRequest requestMsgSet = _MySessionManager.CreateMsgSetRequest("US", 13, 0);

            ICustomerQuery Query = requestMsgSet.AppendCustomerQueryRq();

            IMsgSetResponse responseMsgSet = _MySessionManager.DoRequests(requestMsgSet);

            IResponseList rsList = responseMsgSet.ResponseList;

            IResponse response = rsList.GetAt(0);

            ICustomerRetList CustomerList = (ICustomerRetList)response.Detail;

            if (CustomerList == null)
            {
                throw new Exception("Sorry, no customers found.");
            }

            for (int i = 0; i <= CustomerList.Count - 1; i++)
            {
                ICustomerRet QBCustomer = CustomerList.GetAt(i);

                //string CustomerName = QBCustomer.Name.GetValue().ToString();
                //string listID = QBCustomer.ListID.GetValue();
                //string editSequence = QBCustomer.EditSequence.GetValue();
                if (QBCustomer.Email != null)
                {
                    string email = QBCustomer.Email.GetValue();

                    if (_emailsToDelete.Contains(email))
                        modifyCustomer(QBCustomer);
                }

            }
        }

        private void modifyCustomer(ICustomerRet QBCustomer)
        {
            Console.WriteLine(QBCustomer.Name.GetValue() + ": " + QBCustomer.Email.GetValue());

            IMsgSetRequest requestMsgSet = _MySessionManager.CreateMsgSetRequest("US", 13, 0);

            ICustomerMod Query = requestMsgSet.AppendCustomerModRq();

            Query.ListID.SetValue(QBCustomer.ListID.GetValue());
            Query.EditSequence.SetValue(QBCustomer.EditSequence.GetValue());
            Query.Email.SetValue("");
            
            IMsgSetResponse responseMsgSet = _MySessionManager.DoRequests(requestMsgSet);

            //IResponseList rsList = responseMsgSet.ResponseList;
            //IResponse response = rsList.GetAt(0);

            //ICustomerRet QBCustomer = (ICustomerRet)response.Detail;

            //if (QBCustomer == null)
            //{
            //    throw new Exception("Sorry, sales order not found.");
            //}

            //string CustomerName = QBCustomer.Name.GetValue().ToString();
            ////string email = QBCustomer.Email.GetValue();

            //Console.WriteLine(CustomerName);
        }
        
        
    }
}
