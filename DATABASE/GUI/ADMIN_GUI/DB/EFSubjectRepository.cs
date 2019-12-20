using ADMIN_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN_GUI.DB
{
    class EFSubjectRepository
    {
        STUDIFY2Entities context;

        EFFacultyRepository efFacultyRepository = new EFFacultyRepository();

        public EFSubjectRepository()
        {
            context = new STUDIFY2Entities();
        }

        public ObjectResult<SUBJECT> GetSubjects(string profession_name)
        {
            return context.getSubjectByFacultyProfessionName(profession_name);
        }

        public ObjectResult<SUBJECT> GetSubjectsForAdmin()
        {
            return context.getSubjects();
        }


        public void AddSubject(string faculty_name, string profession_name, string subject_name)
        {
            context.insertSubject(efFacultyRepository.GetIdProfession(profession_name), efFacultyRepository.GetIdFaculty(faculty_name), subject_name);
        }

        public void DeleteSubject(int subject_id)
        {
            context.deleteSubject(subject_id);
        }
    }
}
