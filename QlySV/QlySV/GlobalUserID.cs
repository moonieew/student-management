using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlySV
{
    public static class GlobalUserID
    {
        public static int UserID { get; private set; }

        public static void SetGlobalUserID(int userID)
        {
            UserID = userID;
        }
    }
}
