using Interop.QBFC13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaHouseSalesOrder.Repositories
{
    class SessionManager
    {
        public static QBSessionManager _MySessionManager;
        public static QBSessionManager NewQBSession()
        {
            try
            {
                if (_MySessionManager == null)
                {
                    _MySessionManager = new QBSessionManager();
                    _MySessionManager.OpenConnection2("", "India House Quickbooks Companion", ENConnectionType.ctLocalQBD);
                    _MySessionManager.BeginSession("", ENOpenMode.omDontCare);
                }

                return _MySessionManager;
            }
            catch (Exception)
            {
                throw new Exception("Failed to connect to QuickBooks. Please make sure QuickBooks is running and logged in.");
            }

        }
    }
}
