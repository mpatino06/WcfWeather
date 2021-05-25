using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWeather.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public IEnumerable<UserModel> GetUsers()
        {
            return new List<UserModel>() { new UserModel { Id = 1, UserName = "mpatino", Name = "Miguel Patino", EmailId = "mpatino@hotmail.com", Password = "123456" } };
        }
    }
}
