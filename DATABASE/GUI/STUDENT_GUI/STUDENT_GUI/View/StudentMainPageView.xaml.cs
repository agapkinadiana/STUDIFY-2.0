using STUDENT_GUI.DB;
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
    /// Логика взаимодействия для StudentMainPageView.xaml
    /// </summary>
    public partial class StudentMainPageView : Window
    {
        STUDENT currentStudent = STUDENT.CurrentUser;
        StudentViewModel studentViewModel = new StudentViewModel();
        EFAdsRepository eFAds = new EFAdsRepository();

        public StudentMainPageView()
        {
            InitializeComponent();

            Choose_Theme_Unchecked(this, new RoutedEventArgs());

            if (!studentViewModel.IsHeadman(currentStudent.ID))
            {
                Group_list.Visibility = Visibility.Hidden;
            }

            DataContext = this;
            MainPage.Content = new StartPage();
            Count_Message.Badge = eFAds.CountMessage();

            AddRemindersToAutorun();
        }

        private void AddRemindersToAutorun()
        {
            // открываем нужную ветку в реестре   
            // @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\"  

            Microsoft.Win32.RegistryKey Key =
                Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\", true);

            string path = System.IO.Path.GetFullPath(@"REMINDER\REMINDER.exe");
            //добавляем первый параметр - название ключа  
            // Второй параметр - это путь к   
            // исполняемому файлу программы.  
            Key.SetValue("NtOrg", "\"" + path + "\"");
            Key.Close();
        }

        private void MaxsizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.MaxHeight = SystemParameters.WorkArea.Height;
            if (WindowState != WindowState.Maximized)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void Roll_Up_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Choose_Theme_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,/Themes/Dark.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void Choose_Theme_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,/Themes/Light.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void Exit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
            AuthorizationView authorization = new AuthorizationView();
            authorization.Show();
        }

        private void Group_list_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new StudentsListView();
        }

        private void TimeTable_List_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new TimeTableView();
        }

        private void ListView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new StudentInfo();
        }

        private void Message_List_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new AdsView();
            Count_Message.Badge = eFAds.CountMessage();
        }

        private void Progress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new ProgressView();
        }

        private void ListView_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new TaskView();
        }
    }
}
