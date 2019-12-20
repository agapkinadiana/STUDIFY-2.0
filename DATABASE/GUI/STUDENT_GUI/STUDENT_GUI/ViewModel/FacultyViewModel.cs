using STUDENT_GUI.DB;
using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.ViewModel
{
    class FacultyViewModel
    {
        EFFacultyRepository efFacultyRepository = new EFFacultyRepository();

        ObservableCollection<FACULTY> tmpFaculties = new ObservableCollection<FACULTY>();
        List<string> facultyNames = new List<string>();
        ObservableCollection<PROFESSION> tmpProfessions = new ObservableCollection<PROFESSION>();
        List<string> professionNames = new List<string>();

        public FacultyViewModel()
        {
            GetFacultiesName();
            GetProfessionsName();
        }

        public List<string> FacultyNames
        {
            get { return facultyNames; }
        }

        public List<string> ProfessionNames
        {
            get { return professionNames; }
        }

        public void GetFacultiesName()
        {
            foreach (var item in efFacultyRepository.GetFaculties())
            {
                facultyNames.Add(item.FACULTY_NAME);
            }
        }

        public void GetProfessionsName()
        {
            foreach (var item in efFacultyRepository.GetProfessions())
            {
                professionNames.Add(item.PROFESSION_NAME);
            }
        }
    }
}
