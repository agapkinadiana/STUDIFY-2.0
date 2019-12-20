using ADMIN_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN_GUI.DB
{
    class EFStudentRepository
    {
        STUDIFY2Entities context;

        public EFStudentRepository()
        {
            context = new STUDIFY2Entities();
        }

        public ObjectResult<STUDENT> GetStudents()
        {
            return context.getStudentsForAdmin();
        }

        public void DeleteStudent(int student_id)
        {
            context.deleteStudent(student_id);
        }
    }
}
