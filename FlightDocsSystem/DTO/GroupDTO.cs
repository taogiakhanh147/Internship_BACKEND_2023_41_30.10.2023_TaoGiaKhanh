using FlightDocsSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.DTO
{
    public class GroupDTO
    {
        [Required]
        public string GroupName { get; set; }

        public string Note { get; set; }

/*        [Required]
        public string Email { get; set; }*/

        [Required]
        public int PermissionID { get; set; }
    }
}
