using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrmVsAdoNetComparison.Data.Entity
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }

        public virtual  ICollection<Image> Images { get; set; }
    }
}
