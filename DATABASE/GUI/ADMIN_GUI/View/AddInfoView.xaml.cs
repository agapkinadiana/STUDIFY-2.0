using ADMIN_GUI.DB;
using ADMIN_GUI.ErrorMessage;
using ADMIN_GUI.Model;
using ADMIN_GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Xml;
using System.Xml.Linq;

namespace ADMIN_GUI.View
{
    /// <summary>
    /// Логика взаимодействия для AddInfoView.xaml
    /// </summary>
    public partial class AddInfoView : Page
    {
        FacultyViewModel facultyViewModel = new FacultyViewModel();
        GroupViewModel groupViewModel = new GroupViewModel();
        SubjectViewModel subjectViewModel = new SubjectViewModel();
        EFAdminRepository EFAdmin = new EFAdminRepository();

        public AddInfoView()
        {
            InitializeComponent();
        }

        private void AddFaculty_Click(object sender, RoutedEventArgs e)
        {
            facultyViewModel.AddFaculty(facultyName.Text);
            facultyName.Clear();
        }

        private void Faculty_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> facultyList = new List<string>();
            facultyList.AddRange(facultyViewModel.FacultyNames);
            Faculty.ItemsSource = facultyList;
            Faculty1.ItemsSource = facultyList;
            Faculty2.ItemsSource = facultyList;
        }

        private void Profession_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> professionList = new List<string>();
            professionList.AddRange(facultyViewModel.ProfessionNames);
            Profession.ItemsSource = professionList;
            Profession1.ItemsSource = professionList;
            Profession2.ItemsSource = professionList;
        }

        private void AddProfession_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(professionName.Text) && Faculty.SelectedIndex > -1)
            {
                facultyViewModel.AddProfession(professionName.Text, Faculty.SelectedValue.ToString());
                professionName.Clear();
            }
            else
            {
                MyMessageBox.Show("Enter data!", MessageBoxButton.OK);
            }
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(gCourse.Text) && !String.IsNullOrEmpty(gGroup.Text) && Faculty1.SelectedIndex > -1 && Profession.SelectedIndex > -1)
            {
                groupViewModel.AddGoup(Faculty1.SelectedValue.ToString(), Profession.SelectedValue.ToString(), int.Parse(gCourse.Text), int.Parse(gGroup.Text));
                gCourse.Clear();
                gGroup.Clear();
            }
            else
            {
                MyMessageBox.Show("Enter data!", MessageBoxButton.OK);
            }
        }

        private void AddSubject_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(subjectName.Text) && Faculty1.SelectedIndex > -1 && Profession.SelectedIndex > -1)
            {
                subjectViewModel.AddSubject(subjectName.Text, Faculty1.SelectedValue.ToString(), Profession.SelectedValue.ToString());
                subjectName.Clear();
            }
            else
            {
                MyMessageBox.Show("Enter data!", MessageBoxButton.OK);
            }
        }

        private void SelectFaculties_Click(object sender, RoutedEventArgs e)
        {
            FacultyList.Visibility = Visibility.Visible;
            ProfessionList.Visibility = Visibility.Hidden;
            GroupList.Visibility = Visibility.Hidden;
            SubjectList.Visibility = Visibility.Hidden;
            FacultyList.ItemsSource = facultyViewModel.Faculties;
        }

        private void SelectProfessions_Click(object sender, RoutedEventArgs e)
        {
            FacultyList.Visibility = Visibility.Hidden;
            ProfessionList.Visibility = Visibility.Visible;
            GroupList.Visibility = Visibility.Hidden;
            SubjectList.Visibility = Visibility.Hidden;
            if (Faculty2.SelectedValue != null)
            {
                facultyViewModel.GetProfessionsForFaculty(Faculty2.SelectedValue.ToString());
                ProfessionList.ItemsSource = facultyViewModel.ProfessionsForFaculty;
            }
            else
            {
                MyMessageBox.Show("Choose faculty!", MessageBoxButton.OK);
            }
        }

        private void SelectGroups_Click(object sender, RoutedEventArgs e)
        {
            FacultyList.Visibility = Visibility.Hidden;
            ProfessionList.Visibility = Visibility.Hidden;
            GroupList.Visibility = Visibility.Visible;
            SubjectList.Visibility = Visibility.Hidden;
            if (Profession1.SelectedValue != null)
            {
                groupViewModel.GetGroupsForFaculty(Profession1.SelectedValue.ToString());
                GroupList.ItemsSource = groupViewModel.GroupsForProfession;
            }
            else
            {
                MyMessageBox.Show("Choose profession!", MessageBoxButton.OK);
            }
        }

        private void SelectSubjects_Click(object sender, RoutedEventArgs e)
        {
            FacultyList.Visibility = Visibility.Hidden;
            ProfessionList.Visibility = Visibility.Hidden;
            GroupList.Visibility = Visibility.Hidden;
            SubjectList.Visibility = Visibility.Visible;
            if (Profession2.SelectedValue != null)
            {
                subjectViewModel.GetSubjectsForProfession(Profession2.SelectedValue.ToString());
                SubjectList.ItemsSource = subjectViewModel.SubjectsForProfession;
            }
            else
            {
                MyMessageBox.Show("Choose profession!", MessageBoxButton.OK);
            }
        }

        private void DeleteFaculty_Click(object sender, RoutedEventArgs e)
        {
            FACULTY faculty = (FacultyList.SelectedItem as FACULTY);
            facultyViewModel.DeleteFaculty(faculty.ID);
            FacultyList.ItemsSource = facultyViewModel.Faculties;
        }

        private void DeleteProfession_Click(object sender, RoutedEventArgs e)
        {
            PROFESSION profession = (ProfessionList.SelectedItem as PROFESSION);
            facultyViewModel.DeleteProfession(profession.ID);
            facultyViewModel.GetProfessionsForFaculty(Faculty2.SelectedValue.ToString());
            ProfessionList.ItemsSource = facultyViewModel.ProfessionsForFaculty;
        }

        private void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            GROUP group = (GroupList.SelectedItem as GROUP);
            groupViewModel.DeleteGroup(group.ID);
            groupViewModel.GetGroupsForFaculty(Profession1.SelectedValue.ToString());
            GroupList.ItemsSource = groupViewModel.GroupsForProfession;
        }

        private void DeleteSubject_Click(object sender, RoutedEventArgs e)
        {
            SUBJECT subject = (SubjectList.SelectedItem as SUBJECT);
            subjectViewModel.DeleteSubject(subject.ID);
            subjectViewModel.GetSubjectsForProfession(Profession2.SelectedValue.ToString());
            SubjectList.ItemsSource = subjectViewModel.SubjectsForProfession;

        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            EFAdmin.ImportToXML(); 
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            using (STUDIFY2Entities context = new STUDIFY2Entities())
            {
                const string EXPORT_TESTS_PROCEDURE_NAME = "exportToXML";
                using (SqlConnection connection = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    connection.Open();
                    try
                    {
                        SqlCommand exportTestsCommand = new SqlCommand(EXPORT_TESTS_PROCEDURE_NAME, connection);
                        exportTestsCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        // Выполняем запрос и получаем объект для чтения из xml
                        using (XmlReader xmlReader = exportTestsCommand.ExecuteXmlReader())
                        {
                            XDocument xml = XDocument.Load(xmlReader);

                            const string EXPORT_FILE_NAME = "FACULTY2.xml";

                            // Сохраняем файл на рабочий стол
                            xml.Save("C:/DATABASE" + " / " + EXPORT_FILE_NAME);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }
        }
    }
}
