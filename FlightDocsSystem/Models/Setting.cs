using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightDocsSystem.Models
{
    [Table("Setting")]
    public class Setting
    {
        [Key]
        public int SettingID { get; set; }

        public string? LogoName { get; set; }

        public string? Logo { get; set; }

        /*public bool? Captcha { get; set; }*/

        [ForeignKey("User")]
        public int UserID { get; set; }

        [JsonIgnore]        
        public User User { get; set; }
    }
}
