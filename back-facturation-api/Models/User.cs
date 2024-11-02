using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace back_facturation_api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        [JsonIgnore]
        public string Password { get; set; } = String.Empty;
    }
}
