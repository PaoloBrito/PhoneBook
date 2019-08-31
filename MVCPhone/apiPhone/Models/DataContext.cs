

namespace apiPhone.Models
{
    using System.Data.Entity;

    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<apiPhone.Models.Phone> Phones { get; set; }
    }
}