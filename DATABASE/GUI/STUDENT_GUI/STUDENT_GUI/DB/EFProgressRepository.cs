using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.DB
{
    class EFProgressRepository
    {
        STUDIFY2Entities context;

        public EFProgressRepository()
        {
            context = new STUDIFY2Entities();
        }

        public ObjectResult<PROGRESS> GetProgress(int student_id)
        {
            return context.getProgress(student_id);
        }

        public void AddProgress(int student_id, string subject_name)
        {
            context.addProgress(student_id, subject_name);
        }

        public void DeleteProgress(int id_progress)
        {
            context.deleteProgress(id_progress);
        }

        public void UpdateProgress(int complited, int needed, int id_progress)
        {
            context.updateProgress(complited, needed, id_progress);
        }
    }
}
