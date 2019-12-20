using ADMIN_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN_GUI.DB
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

        public ObjectResult<PROFESSION> GetProfessionByFacultyName(string faculty_name)
        {
            return context.getProfessionByFacultyName(faculty_name);
        }

        public int GetIdProfession(string profession_name)
        {
            return context.getProfessionIdByName(profession_name).FirstOrDefault().Value;
        }

        public void AddFaculty(string faculty_name)
        {
            context.insertFaculty(faculty_name);
        }

        public void AddProfession(string faculty_name, string profession_name)
        {
            context.insertProfession(profession_name, GetIdFaculty(faculty_name));
        }

        public void DeleteFaculty(int faculty_id)
        {
            context.deleteFaculty(faculty_id);
        }

        public void DeleteProfession(int profession_id)
        {
            context.deleteProfession(profession_id);
        }
    }
}
