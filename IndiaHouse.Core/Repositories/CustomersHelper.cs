using System.Collections.Generic;
using Interop.QBFC13;
using System.Linq;
using System;
using IndiaHouse.Core.Models;
using IndiaHouse.Core.Helpers;

namespace IndiaHouse.Core.Repositories
{
    public class CustomersHelper
    {
        private readonly List<Customer> _customers;
        private QBSessionManager _MySessionManager;

        public CustomersHelper(QBSessionManager MySessionManager)
        {
            _MySessionManager = MySessionManager;
            _customers = new List<Customer>();
        }

        public List<Customer> getAllCustomers()
        {
            //Item Request
            IMsgSetRequest customerRequestset = _MySessionManager.CreateMsgSetRequest("US", 13, 0);

            ICustomerQuery customerQuery = customerRequestset.AppendCustomerQueryRq();
            
            IMsgSetResponse responseCustomerRq = _MySessionManager.DoRequests(customerRequestset);

            IResponseList customerResponseList = responseCustomerRq.ResponseList;

            IResponse customerResponse = customerResponseList.GetAt(0);

            //ENResponseType responseType = (ENResponseType)customerResponse.Type.GetValue();
            ICustomerRetList customerList = (ICustomerRetList)customerResponse.Detail;

            for (int i = 0; i <= customerList.Count - 1; i++)
            {
                ICustomerRet qbCustomer = customerList.GetAt(i);

                Address address = new Address();

                Customer customer = new Customer();
                customer.AccountNumber = qbCustomer.AccountNumber != null? qbCustomer.AccountNumber.GetValue(): null;
                customer.Name = qbCustomer.Name.GetValue();
                customer.Address = address.getAddress(qbCustomer.BillAddress);
                customer.Email = qbCustomer.Email != null ? qbCustomer.Email.GetValue() : null;
                customer.Phone = qbCustomer.Phone != null ? qbCustomer.Phone.GetValue() : null;

                _customers.Add(customer);
            }

            return _customers;
        } 
    }
}
