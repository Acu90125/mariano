using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logeo.entidades
{
    public class Logout
    {
        string _logout;
  

        public string LogoutMembers
        {
            get { return _logout; }

            set
            {
                _logout = value;
            
            }
        }

        string _logoutPatient;


        public string LogoutPatient
        {
            get { return _logoutPatient; }

            set
            {
                _logoutPatient = value;

            }
        }

    }
}