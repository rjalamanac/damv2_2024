using RestAPI.Models.Entity;

namespace ApiPelicula.Models.DTOs.UserDto
{
    public class UserLoginResponseDto
    {
        public AppUser User { get; set; }
        public string Token { get; set; }

    }
}
