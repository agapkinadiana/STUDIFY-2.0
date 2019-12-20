using ADMIN_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN_GUI.DB
{
    class EFAdminRepository
    {
        STUDIFY2Entities context;

        public EFAdminRepository()
        {
            context = new STUDIFY2Entities();
        }

        public ObjectResult<SUBJECT> GetSubjects(string profession_name)
        {
            return context.getSubjectByFacultyProfessionName(profession_name);
        }

        public STUDENT GetAdminByLogin(string login)
        {
            return context.getUserByLogin(login).FirstOrDefault(x => x.LOGIN == login);
        }

        public string СompareDataOfAdmin(string login, string password)
        {
            ObjectParameter output = new ObjectParameter("result", "nvarchar(256)");

            context.checkAdminData(login, password, output);
            string res = output.Value.ToString();

            return res;
        }

        public void SetHedman(int student_id)
        {
            context.setHeadman(student_id);
        }

        public void ImportToXML()
        {
            context.importToXML();
        }
    }
}
