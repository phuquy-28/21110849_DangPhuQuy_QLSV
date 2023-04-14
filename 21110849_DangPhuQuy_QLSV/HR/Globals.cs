using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21110849_DangPhuQuy_QLSV
{
    internal class Globals
    {
        public static int GlobalUserId { get; private set; }
        public static void SetGlobalUserId(int userID)
        {
            GlobalUserId = userID;
        }
    }
}
