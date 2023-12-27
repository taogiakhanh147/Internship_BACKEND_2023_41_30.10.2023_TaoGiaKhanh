using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightDocsSystem.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        public string? RoleName { get; set; }

        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
