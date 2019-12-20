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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STUDENT_GUI.View
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

            LoadGroupsId();
            if (studentViewModel.IsHeadman(currentStudent.ID))
            {
                LoadTimeTableIfEmpty();
            }
        }

        private void LoadGroupsId()
        {
            if (studentViewModel.IsHeadman(currentStudent.ID))
            {
                Set_Time.IsReadOnly = false;
                Set_Auditorium.IsReadOnly = false;
                Set_LessonType.IsReadOnly = false;
                Subject.Visibility = Visibility.Visible;
                Choose_course.Visibility = Visibility.Hidden;
                Choose_group.Visibility = Visibility.Hidden;
                Choose_subgroup.Visibility = Visibility.Visible;
            }
            else
            {
                Set_Time.IsReadOnly = true;
                Set_Auditorium.IsReadOnly = true;
                Set_LessonType.IsReadOnly = true;
                Subject.Visibility = Visibility.Hidden;
                Choose_course.Visibility = Visibility.Hidden;
                Choose_group.Visibility = Visibility.Hidden;
                Choose_subgroup.Visibility = Visibility.Hidden;
            }
            Choose_subgroup.ItemsSource = groupViewModel.SubgroupNumbers;
            Choose_subgroup.SelectedValue = currentStudent.SUBGROUP.SUBGROUP_NUMBER;
        }

        private void UpdateTT(string week)
        {
            if (studentViewModel.IsHeadman(currentStudent.ID))
            {
                int subgroup = Convert.ToInt32(Choose_subgroup.SelectedValue);
                timeTableViewModel.GetByWeekAdmin(week, currentStudent.GROUP.COURSE, currentStudent.GROUP.GROUP_NUMBER, subgroup);
                DataContext = new TimeTableViewModel(currentStudent.GROUP.COURSE, currentStudent.GROUP.GROUP_NUMBER, subgroup, week);
            }

            else
            {
                timeTableViewModel.GetByWeek(week, (int)currentStudent.GROUP_ID, (int)currentStudent.SUBGROUP_ID);
                DataContext = new TimeTableViewModel((int)currentStudent.GROUP_ID, (int)currentStudent.SUBGROUP_ID, week);
            }

            //else
            //{
            //    int course = Convert.ToInt32(Choose_course.SelectedValue);
            //    int group = Convert.ToInt32(Choose_group.SelectedValue);
            //    int subgroup = Convert.ToInt32(Choose_subgroup.SelectedValue);
            //    timeTableViewModel.GetByWeekAdmin(week, course, group, subgroup);
            //    DataContext = new TimeTableViewModel(course, group, subgroup, week);
            //}
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

        private void LoadTimeTableIfEmpty()
        {
            timeTableViewModel.LoadTT();
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
