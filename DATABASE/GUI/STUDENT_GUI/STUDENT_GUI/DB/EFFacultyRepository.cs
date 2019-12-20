using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.DB
{
    class EFFacultyRepository
    {
        STUDIFY2Entities context;

        public EFFacultyRepository()
        {
            context = new STUDIFY2Entities();
        }

        public ObjectResult<FACULTY> GetFaculties()
        {
            return context.getFaculties();
        }

        public ObjectResult<PROFESSION> GetProfessions()
        {
            return context.getProfessions();
        }

        public int GetIdFaculty(string faculty_name)
        {
            return context.getFacultyIdByName(faculty_name).FirstOrDefault().Value;
        }

        public int GetIdProfession(string profession_name)
        {
            return context.getProfessionIdByName(profession_name).FirstOrDefault().Value;
        }
    }
}
