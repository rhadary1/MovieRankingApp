using RankingApp.Dto;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RankingApp.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
