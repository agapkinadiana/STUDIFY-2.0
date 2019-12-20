using STUDENT_GUI.DB;
using STUDENT_GUI.ErrorMessage;
using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace STUDENT_GUI.ViewModel
{
    class AuthorizationViewModel
    {
        EFStudentRepository efStudent = new EFStudentRepository();
        EFFacultyRepository efFaculty = new EFFacultyRepository();
        EFGroupRepository efGroup = new EFGroupRepository();

        string login;
        int numStudCard;
        string name;
        string reg_login;
        string password;
        string reg_password;
        string db_password;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public int NumStudCard
        {
            get { return numStudCard; }
            set { numStudCard = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Reg_Login
        {
            get { return reg_login; }
            set { reg_login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Reg_Password
        {
            get { return reg_password; }
            set { reg_password = value; }
        }

        public string Db_Password
        {
            get { return db_password; }
            set { db_password = value; }
        }

        public bool СompareDataOfStudent(string login, string password)
        {
            Login = login;
            Password = password;

            if (!String.IsNullOrEmpty(Login) && !String.IsNullOrEmpty(Password))
            {
                string result = efStudent.СompareDataOfStudent(Login, Password);
                STUDENT tmp = efStudent.GetStudentByLogin(Login);

                if (result == "true" && tmp.ROLE.TYPE != "Admin")
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

        public bool Registration(string password1, string password2, int group, int course, int subgroup, string faculty, string profession)
        {
            Reg_Password = password1;
            Db_Password = password2;
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Reg_Login) && !String.IsNullOrEmpty(Reg_Password) && !String.IsNullOrEmpty(Db_Password))
            {
                if (NumStudCard.ToString().Length == 8)
                {
                    if (password1.Equals(password2))
                    {
                        STUDENT tmp1 = efStudent.GetStudentByLogin(Login);
                        STUDENT tmp2 = efStudent.GetStudentByCard(NumStudCard);
                        if (tmp2 == null)
                        {
                            if (tmp1 == null)
                            {
                                int faculty_id = efFaculty.GetIdFaculty(faculty);

                                efStudent.AddStudent(NumStudCard, Name, Reg_Login, Reg_Password, efGroup.GetIdGroup(course, group, efFaculty.GetIdFaculty(faculty), efFaculty.GetIdProfession(profession)), efGroup.GetIdSubroup(subgroup));
                                return true;
                            }
                            else
                            {
                                MyMessageBox.Show("User with this login already exists!", MessageBoxButton.OK);
                                return false;
                            }
                        }
                        else
                        {
                            MyMessageBox.Show("A user with that student card number is already there!", MessageBoxButton.OK);
                            return false;
                        }
                    }
                    else
                    {
                        MyMessageBox.Show("Passwords must match!", MessageBoxButton.OK);
                        return false;
                    }
                }
                else
                {
                    MyMessageBox.Show("Student card number must contain 8 digits!", MessageBoxButton.OK);
                    return false;
                }
            }
            else
            {
                MyMessageBox.Show("Check entered data!", MessageBoxButton.OK);
                return false;
            }
        }

        public STUDENT SetUser()
        {
            STUDENT tmp = efStudent.GetStudentByLogin(Login);
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
