using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightDocsSystem.Models
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; }

        public string? PermissionName { get; set; }

        [JsonIgnore]
        public ICollection<Group> Groups { get; set; }
    }
}
