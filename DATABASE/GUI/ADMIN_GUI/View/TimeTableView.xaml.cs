using ADMIN_GUI.ErrorMessage;
using ADMIN_GUI.Model;
using ADMIN_GUI.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADMIN_GUI.View
{
    /// <summary>
    /// Логика взаимодействия для TimeTableView.xaml
    /// </summary>
    public partial class TimeTableView : Page
    {
        STUDENT currentStudent = STUDENT.CurrentUser;

        GroupViewModel groupViewModel = new GroupViewModel();
        StudentViewModel studentViewModel = new StudentViewModel();
        TimeTableViewModel timeTableViewModel;

        public TimeTableView()
        {
            InitializeComponent();
            timeTableViewModel = new TimeTableViewModel();

            LoadFromAdmin();
        }

        private void LoadFromAdmin()
        {
            Choose_course.Visibility = Visibility.Visible;
            Choose_group.Visibility = Visibility.Visible;
            Choose_subgroup.Visibility = Visibility.Visible;

            Choose_course.ItemsSource = groupViewModel.CourseNumbers;
            Choose_group.ItemsSource = groupViewModel.GroupNumbers;
            Choose_subgroup.ItemsSource = groupViewModel.SubgroupNumbers;
        }

        private void UpdateTT(string week)
        {
            int course = Convert.ToInt32(Choose_course.SelectedValue);
            int group = Convert.ToInt32(Choose_group.SelectedValue);
            int subgroup = Convert.ToInt32(Choose_subgroup.SelectedValue);
            timeTableViewModel.GetByWeekAdmin(week, course, group, subgroup);
            DataContext = new TimeTableViewModel(course, group, subgroup, week);
        }

        private void Stud_Week_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTT(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString());
        }

        private void Stud_Week_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var el in Stud_Week.Items)
            {
                if ((el is ComboBoxItem))
                {
                    if ((el as ComboBoxItem).Content.ToString() == timeTableViewModel.CurrentWeek())
                    {
                        (el as ComboBoxItem).IsSelected = true;
                        break;
                    }
                }
            }
        }

        private void Subject_Loaded(object sender, RoutedEventArgs e)
        {
            Subject.ItemsSource = timeTableViewModel.Subjects;
        }

        private void Subject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            timeTableViewModel.SelectedTimeTable = (LESSON)Lessons.SelectedItem;
            try
            {
                if (Subject.SelectedItem.ToString() == "CLEAR")
                {
                    timeTableViewModel.UpdateSubject(" ", Convert.ToInt32(timeTableViewModel.SelectedTimeTable.ID));
                }
                else
                {
                    timeTableViewModel.UpdateSubject(Subject.SelectedItem.ToString(), Convert.ToInt32(timeTableViewModel.SelectedTimeTable.ID));
                }
            }
            catch (Exception)
            {
                MyMessageBox.Show("Choose timetable to subject!", MessageBoxButton.OK);
            }
        }
    }
}
