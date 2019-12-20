using ADMIN_GUI.DB;
using ADMIN_GUI.ErrorMessage;
using ADMIN_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADMIN_GUI.ViewModel
{
    class SubjectViewModel
    {
        EFAdminRepository efAdminRepository = new EFAdminRepository();
        EFSubjectRepository eFSubjectRepository = new EFSubjectRepository();

        public SubjectViewModel() { }

        ObservableCollection<SUBJECT> subjectsForProfession = new ObservableCollection<SUBJECT>();
        List<string> subjectNames = new List<string>();
        private string subjectName;

        public ObservableCollection<SUBJECT> SubjectsForProfession
        {
            get { return subjectsForProfession; }
        }

        public void GetSubjectsForProfession(string name)
        {
            subjectsForProfession.Clear();
            foreach (SUBJECT item in eFSubjectRepository.GetSubjects(name))
            {
                subjectsForProfession.Add(item);
            }
        }

        public List<string> SubjectNames
        {
            get { return subjectNames; }
        }

        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        public void GetSubjectsName(string profession_name)
        {
            foreach (var item in efAdminRepository.GetSubjects(profession_name))
            {
                subjectNames.Add(item.SUBJECT_NAME);
            }
        }

        public void AddSubject(string name, string faculty_name, string profession_name)
        {
            SubjectName = name;
            if (!String.IsNullOrEmpty(SubjectName))
            {
                eFSubjectRepository.AddSubject(faculty_name, profession_name, name); 
            }
            else
            {
                MyMessageBox.Show("Enter data!", MessageBoxButton.OK);
            }
        }

        public void DeleteSubject(int subject_id)
        {
            eFSubjectRepository.DeleteSubject(subject_id);
        }
    }
}
