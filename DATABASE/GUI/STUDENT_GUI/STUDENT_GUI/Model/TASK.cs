//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STUDENT_GUI.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TASK
    {
        public int ID { get; set; }
        public string CONTENT { get; set; }
        public System.DateTime DUEDATE { get; set; }
        public bool IS_COMPLITE { get; set; }
        public int SUBJECT_ID { get; set; }
        public int STUDENT_ID { get; set; }

        public string DATE
        {
            get { return DUEDATE.Day + "/" + DUEDATE.Month + "/" + DUEDATE.Year; }
        }

        public virtual STUDENT STUDENT { get; set; }
        public virtual SUBJECT SUBJECT { get; set; }
    }
}
