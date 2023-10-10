using RankingApp.Dto;
using System.ComponentModel.DataAnnotations;

namespace RankingApp.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static User FromDto(UserDto dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };
        }
    }
}
