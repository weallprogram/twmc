using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW_Mission_Control
{
    public class User
    {
        public int uid = 0;
        public int world = 0;

        public string userName = "";
        public string userPass = "";

        public Boolean aangemeld = false;

        public Boolean isLoggedIn(){
            return aangemeld;
        }
        
    }
}
