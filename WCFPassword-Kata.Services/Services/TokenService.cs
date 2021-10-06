using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFPassword_Kata.Domain.Models;

namespace WCFPassword_Kata.Services.Services {
    public class TokenService : ITokenService {
        public string GenerateToken(User user) {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            byte[] userName = Encoding.ASCII.GetBytes(user.UserName);
            return Convert.ToBase64String(time.Concat(key).Concat(userName).ToArray());
        }
        public bool CheckToken(string token) {
            byte[] data = Convert.FromBase64String(token);
            return DateTime.FromBinary(BitConverter.ToInt64(data, 0)) < DateTime.UtcNow.AddHours(-1);
        }
    }
}
