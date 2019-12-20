using ADMIN_GUI.DB;
using ADMIN_GUI.ErrorMessage;
using ADMIN_GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADMIN_GUI.ViewModel
{
    class AuthorizationViewModel
    {
        EFAdminRepository efAdmin = new EFAdminRepository();

        string login;
        string password;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool СompareDataOfAdmin(string login, string password)
        {
            Login = login;
            Password = password;
            if (!String.IsNullOrEmpty(Login) && !String.IsNullOrEmpty(Password))
            {
                string result = efAdmin.СompareDataOfAdmin(Login, Password);
                STUDENT tmp = efAdmin.GetAdminByLogin(Login);

                if (result == "true" && tmp.ROLE.TYPE == "Admin")
                    return true;
                else
                {
                    MyMessageBox.Show("No rights!", MessageBoxButton.OK);
                    return false;
                }
            }
            else
            {
                MyMessageBox.Show("Enter data!", MessageBoxButton.OK);
                return false;
            }
        }

        public STUDENT SetAdmin()
        {
            STUDENT tmp = efAdmin.GetAdminByLogin(Login);
            if (tmp != null)
            {
                STUDENT.CurrentUser = tmp;
                return tmp;
            }
            else
                return null;
        }
    }
}
