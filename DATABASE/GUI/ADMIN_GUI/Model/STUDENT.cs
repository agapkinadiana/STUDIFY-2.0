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

    public partial class STUDENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STUDENT()
        {
            this.ADS = new HashSet<ADS>();
            this.PROGRESS = new HashSet<PROGRESS>();
            this.TASK = new HashSet<TASK>();
        }

        public int ID { get; set; }
        public string STUDENT_NAME { get; set; }
        public byte[] PHOTO { get; set; }
        public string LOGIN { get; set; }
        public byte[] PASSWORD { get; set; }
        public int ROLE_ID { get; set; }
        public Nullable<int> GROUP_ID { get; set; }
        public Nullable<int> SUBGROUP_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADS> ADS { get; set; }
        public virtual GROUP GROUP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROGRESS> PROGRESS { get; set; }
        public virtual ROLE ROLE { get; set; }
        public virtual SUBGROUP SUBGROUP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TASK> TASK { get; set; }

        private static STUDENT currentUser;

        public static STUDENT CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (value != null)
                    currentUser = value;
            }
        }
    }
}
