using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.DB
{
    class EFStudentRepository
    {
        STUDIFY2Entities context;

        public EFStudentRepository()
        {
            context = new STUDIFY2Entities();
        }

        public void AddStudent(int num_card, string name, string login, string password, int group_id, int subgroup_id)
        {
            context.registerStudent(num_card, name, login, password, group_id, subgroup_id);
        }

        public STUDENT GetStudentByLogin(string login)
        {
            return context.getUserByLogin(login).FirstOrDefault(x => x.LOGIN == login);
        }

        public STUDENT GetStudentByCard(int card_number)
        {
            return context.getStudentByCard(card_number).FirstOrDefault(x => x.ID == card_number);
        }

        //public ObjectResult<STUDENT> GetStudents()
        //{
        //    return context.
        //}

        public ObjectResult<STUDENT> GetStudentsForHeadman(int course, int group, int faculty_id, int profession_id)
        {
            return context.getStudentsForHeadman(course, group, faculty_id, profession_id);
        }

        public string IsHeadman(int student_id)
        {
            ObjectParameter output = new ObjectParameter("role", "nvarchar(256)");

            context.checkRole(student_id, output);
            string res = output.Value.ToString();

            return res;
        }

        public string СompareDataOfStudent(string login, string password)
        {
            ObjectParameter output = new ObjectParameter("result", "nvarchar(256)");

            context.checkStudentData(login, password, output);
            string res = output.Value.ToString();

            return res;
        }

        public void SetPhoto(int student_id, byte[] image)
        {
            context.setPhoto(student_id, image);
        }
    }
}
