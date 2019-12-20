using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.DB
{
    class EFSubjectRepository
    {
        STUDIFY2Entities context;

        public EFSubjectRepository()
        {
            context = new STUDIFY2Entities();
        }

        public ObjectResult<SUBJECT> GetSubjects(string profession_name)
        {
            return context.getSubjectByFacultyProfessionName(profession_name);
        }
    }
}
