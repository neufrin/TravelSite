//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Place
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Place()
        {
            this.COMMENT = new HashSet<COMMENT>();
            this.User1 = new HashSet<User>();
            this.Ranking1 = new HashSet<Ranking>();
            this.Travels = new HashSet<Travels>();
        }
    
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Photo_URI { get; set; }
        public int CountryId { get; set; }
        public int UserId { get; set; }
        public bool IsAccepted { get; set; }
        public Nullable<int> Ranking { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT> COMMENT { get; set; }
        public virtual Country Country { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ranking> Ranking1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Travels> Travels { get; set; }
    }
}
