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
    using System.Collections.Generic;
    
    public partial class PROFESSION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROFESSION()
        {
            this.GROUP = new HashSet<GROUP>();
            this.SUBJECT = new HashSet<SUBJECT>();
        }
    
        public int ID { get; set; }
        public string PROFESSION_NAME { get; set; }
        public int FACULTY_ID { get; set; }
    
        public virtual FACULTY FACULTY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GROUP> GROUP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBJECT> SUBJECT { get; set; }
    }
}
