using System;
using System.Collections.Generic;
using System.Text;

namespace RQCore.Users.Dto
{
    public class resetPasswordInput
    {
        public string userName { get; set; }

        public string currentPassword { get; set; }

        public string newPassword { get; set; }
    }


    public class resetPasswordWithout
    {
        public string userName { get; set; }
          
        public string newPassword { get; set; }
    }


    
}
