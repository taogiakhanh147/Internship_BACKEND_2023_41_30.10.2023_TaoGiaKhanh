using FlightDocsSystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightDocsSystem.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string? UserName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool Status { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }

        [ForeignKey("Group")]
        public int GroupID { get; set; }

        [JsonIgnore]
        public Group Group { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }

        [JsonIgnore]
        public ICollection<Setting> Settings { get; set; }

        [JsonIgnore]
        public ICollection<Flight> flights { get; set; }

        [JsonIgnore]
        public ICollection<Document> documents { get; set; }

        /*[JsonIgnore]
        public ICollection<Document> documents { get; set; }*/
    }

    public class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}