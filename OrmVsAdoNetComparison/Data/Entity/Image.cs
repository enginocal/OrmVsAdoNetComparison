using System.ComponentModel.DataAnnotations.Schema;

namespace OrmVsAdoNetComparison.Data.Entity
{
    [Table("images")]
    public class Image
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
    }
}
