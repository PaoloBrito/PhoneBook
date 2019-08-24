
namespace MVCPhone.Models
{
    using System.Data.Entity;

    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<MVCPhone.Models.Phone> Phones { get; set; }
    }
}