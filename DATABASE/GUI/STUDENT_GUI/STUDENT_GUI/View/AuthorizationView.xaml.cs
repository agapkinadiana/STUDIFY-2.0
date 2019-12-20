using STUDENT_GUI.ErrorMessage;
using STUDENT_GUI.Model;
using STUDENT_GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace STUDENT_GUI.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationView.xaml
    /// </summary>
    public partial class AuthorizationView : Window
    {
        AuthorizationViewModel authorizationViewModel;
        FacultyViewModel facultyViewModel;
        GroupViewModel groupViewModel;

        public AuthorizationView()
        {
            InitializeComponent();

            authorizationViewModel = new AuthorizationViewModel();
            facultyViewModel = new FacultyViewModel();
            groupViewModel = new GroupViewModel();

            DataContext = authorizationViewModel;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Roll_Up_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void To_Sign_Up_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Login.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Hidden;
            Sign_In.Visibility = Visibility.Hidden;
            Fox.Visibility = Visibility.Hidden;

            NumStudCard.Visibility = Visibility.Visible;
            Course.Visibility = Visibility.Visible;
            Faculty.Visibility = Visibility.Visible;
            Profession.Visibility = Visibility.Visible;
            Group.Visibility = Visibility.Visible;
            Subgroup.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            Reg_Login.Visibility = Visibility.Visible;
            Reg_Password.Visibility = Visibility.Visible;
            Db_Password.Visibility = Visibility.Visible;
            Sign_Up.Visibility = Visibility.Visible;
        }

        private void To_Sign_In_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Login.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Visible;
            Sign_In.Visibility = Visibility.Visible;
            Fox.Visibility = Visibility.Visible;

            NumStudCard.Visibility = Visibility.Hidden;
            Course.Visibility = Visibility.Hidden;
            Faculty.Visibility = Visibility.Hidden;
            Profession.Visibility = Visibility.Hidden;
            Group.Visibility = Visibility.Hidden;
            Subgroup.Visibility = Visibility.Hidden;
            Name.Visibility = Visibility.Hidden;
            Reg_Login.Visibility = Visibility.Hidden;
            Reg_Password.Visibility = Visibility.Hidden;
            Db_Password.Visibility = Visibility.Hidden;
            Sign_Up.Visibility = Visibility.Hidden;
        }

        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            if (authorizationViewModel.СompareDataOfStudent(Login.Text, Password.Password))
            {
                Hide();
                STUDENT currentUser = authorizationViewModel.SetUser();
                STUDENT.CurrentUser = currentUser;
                StudentMainPageView studentMainPageView = new StudentMainPageView();
                studentMainPageView.Show();
            }
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            if (Faculty.SelectedIndex > -1 && Profession.SelectedIndex > -1 && Course.SelectedIndex > -1 && Group.SelectedIndex > -1 && Subgroup.SelectedIndex > -1)
            {
                if (authorizationViewModel.Registration(Reg_Password.Password, Db_Password.Password, (int)Group.SelectedValue, (int)Course.SelectedValue, (int)Subgroup.SelectedValue, Faculty.SelectedValue.ToString(), Profession.SelectedValue.ToString()))
                {
                    MyMessageBox.Show("Registration completed successfully!", MessageBoxButton.OK);
                }
            }
            else
            {
                MyMessageBox.Show("Enter data!", MessageBoxButton.OK);
            }
        }

        private void Faculty_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> facultyList = new List<string>();
            facultyList.AddRange(facultyViewModel.FacultyNames);
            Faculty.ItemsSource = facultyList;
        }

        private void Profession_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> professionList = new List<string>();
            professionList.AddRange(facultyViewModel.ProfessionNames);
            Profession.ItemsSource = professionList;
        }

        private void Course_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> courseList = new List<int>();
            courseList.AddRange(groupViewModel.CourseNumbers);
            Course.ItemsSource = courseList;
        }

        private void Group_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> groupList = new List<int>();
            groupList.AddRange(groupViewModel.GroupNumbers);
            Group.ItemsSource = groupList;
        }

        private void Subgroup_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> subgroupList = new List<int>();
            subgroupList.AddRange(groupViewModel.SubgroupNumbers);
            Subgroup.ItemsSource = subgroupList;
        }
    }
}
