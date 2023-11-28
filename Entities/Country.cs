using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
  /// <summary>
  /// Domain Model for Country
  /// </summary>
  public class Country
  {
    [Key]
    public Guid CountryID { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<Person>? Persons { get; set; }

        public static explicit operator Country(EntityEntry<Country> v)
        {
            throw new NotImplementedException();
        }
    }
}
