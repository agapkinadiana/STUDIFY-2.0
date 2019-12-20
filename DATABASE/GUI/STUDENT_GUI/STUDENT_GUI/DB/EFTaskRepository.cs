using STUDENT_GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_GUI.DB
{
    class EFTaskRepository
    {
        STUDIFY2Entities context;

        public EFTaskRepository()
        {
            context = new STUDIFY2Entities();
        }

        public void AddTask(int student_id, DateTime deadline, string subject, string content)
        {
            context.addTask(student_id, deadline, subject, content);
        }

        public ObjectResult<TASK> GetTasks(int student_id)
        {
            return context.getTasksForStudent(student_id);
        }

        public ObjectResult<TASK> GetTasksBySubject(int student_id, string subject)
        {
            return context.getTasksBySubject(student_id, subject);
        }

        public void ChangeTrue(int task_id)
        {
            context.changeCompliteTrue(task_id);
        }

        public void ChangeFalse(int task_id)
        {
            context.changeCompliteFalse(task_id);
        }

        public ObjectResult<TASK> GetSatisfiedTasks(int student_id)
        {
            return context.getSatisfiedTasks(student_id);
        }

        public ObjectResult<TASK> GetUnsatisfiedTasks(int student_id)
        {
            return context.getUnsatisfiedTasks(student_id);
        }

        public void RemoveTaskById(int task_id)
        {
            context.deleteTask(task_id);
        }
    }
}
