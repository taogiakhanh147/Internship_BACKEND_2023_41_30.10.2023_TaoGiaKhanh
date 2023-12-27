using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightDocsSystem.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int GroupID { get; set; }

        public string? GroupName { get; set; }

        public string? Note { get; set; }

        public string? Email { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        [ForeignKey("Permission")]
        public int PermissionID { get; set; }

        [JsonIgnore]
        public Permission Permission { get; set; }

        [JsonIgnore]
        public ICollection<User> users { get; set; }
    }
}
