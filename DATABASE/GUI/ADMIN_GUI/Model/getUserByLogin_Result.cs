//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADMIN_GUI.Model
{
    using System;
    
    public partial class getUserByLogin_Result
    {
        public int ID { get; set; }
        public string STUDENT_NAME { get; set; }
        public byte[] PHOTO { get; set; }
        public string LOGIN { get; set; }
        public byte[] PASSWORD { get; set; }
        public int ROLE_ID { get; set; }
        public Nullable<int> GROUP_ID { get; set; }
        public Nullable<int> SUBGROUP_ID { get; set; }
    }
}
