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
    class FacultyViewModel
    {
        EFFacultyRepository efFacultyRepository = new EFFacultyRepository();

        ObservableCollection<FACULTY> tmpFaculties = new ObservableCollection<FACULTY>();
        List<string> facultyNames = new List<string>();
        ObservableCollection<PROFESSION> tmpProfessions = new ObservableCollection<PROFESSION>();
        List<string> professionNames = new List<string>();

        ObservableCollection<PROFESSION> professionsForFaculty = new ObservableCollection<PROFESSION>();

        string facultyName;
        string pFacultyName;
        string professionName;

        public FacultyViewModel()
        {
            GetFaculties();
            GetProfessions();
            GetFacultiesName();
            GetProfessionsName();
        }


        public ObservableCollection<FACULTY> Faculties
        {
            get { return tmpFaculties; }
        }

        public ObservableCollection<PROFESSION> ProfessionsForFaculty
        {
            get { return professionsForFaculty; }
        }

        public List<string> FacultyNames
        {
            get { return facultyNames; }
        }

        public string FacultyName
        {
            get { return facultyName; }
            set { facultyName = value; }
        }

        public string PFacultyName
        {
            get { return pFacultyName; }
            set { pFacultyName = value; }
        }

        public string ProfessionName
        {
            get { return professionName; }
            set { professionName = value; }
        }

        public ObservableCollection<PROFESSION> Professions
        {
            get { return tmpProfessions; }
        }

        public List<string> ProfessionNames
        {
            get { return professionNames; }
        }

        public void GetFaculties()
        {
            foreach (FACULTY item in efFacultyRepository.GetFaculties())
            {
                tmpFaculties.Add(item);
            }
        }

        public void GetFacultiesName()
        {
            foreach (var item in efFacultyRepository.GetFaculties())
            {
                facultyNames.Add(item.FACULTY_NAME);
            }
        }

        public void GetProfessions()
        {
            foreach (PROFESSION item in efFacultyRepository.GetProfessions())
            {
                tmpProfessions.Add(item);
            }
        }

        public void GetProfessionsName()
        {
            foreach (var item in efFacultyRepository.GetProfessions())
            {
                professionNames.Add(item.PROFESSION_NAME);
            }
        }

        public void GetProfessionsForFaculty(string name)
        {
            professionsForFaculty.Clear();
            foreach (PROFESSION item in efFacultyRepository.GetProfessionByFacultyName(name))
            {
                professionsForFaculty.Add(item);
            }
        }

        public void AddFaculty(string name)
        {
            FacultyName = name;
            if (!String.IsNullOrEmpty(FacultyName))
            {
                efFacultyRepository.AddFaculty(FacultyName);
            }
            else
            {
                MyMessageBox.Show("Enter data!", MessageBoxButton.OK);
            }
        }

        public void AddProfession(string profession_name, string faculty_name)
        {
            ProfessionName = profession_name;
            PFacultyName = faculty_name;
            if (!String.IsNullOrEmpty(ProfessionName) && !String.IsNullOrEmpty(PFacultyName))
            {
                efFacultyRepository.AddProfession(PFacultyName, ProfessionName);
            }
            else
            {
                MyMessageBox.Show("Enter data!", MessageBoxButton.OK);
            }
        }

        public void DeleteFaculty(int faculty_id)
        {
            efFacultyRepository.DeleteFaculty(faculty_id);
        }

        public void DeleteProfession(int profession_id)
        {
            efFacultyRepository.DeleteProfession(profession_id);
        }
    }
}
