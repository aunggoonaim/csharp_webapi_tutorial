using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tutorial1.Models;
using tutorial1.Services.Interface;

using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace tutorial1.Controllers
{
    [Route("api/UserInfo")]
    public class UserInfoController : Controller
    {
        private readonly IUserInfo _userInfoService;
        public UserInfoController(IUserInfo userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet]
        [Route("getAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _userInfoService.GetQueryUserList());
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] user_info user)
        {
            return Ok(await _userInfoService.CreateUserInfo(user));
        }

        [HttpPost]
        [Route("file")]
        public IActionResult Files()
        {
            byte[] encryptedBytes = null;
            byte[] saltBytes = new byte[] { 0x10, 0xa0, 0x03, 0x11, 0x20, 0x09, 0x23, 0xf0 };

            var passwordBytes = Encoding.Unicode.GetBytes("Ilove@cat");
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    byte[] bytesToBeEncrypted = System.IO.File.ReadAllBytes("filename.xls");

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();

                    System.IO.File.WriteAllBytes("filename.xls", encryptedBytes);
                }
            }

            return Ok();
        }

        public IActionResult FilesOut()
        {
            byte[] encryptedBytes = null;
            byte[] saltBytes = new byte[] { 0x10, 0xa0, 0x03, 0x11, 0x20, 0x09, 0x23, 0xf0 };

            var passwordBytes = Encoding.Unicode.GetBytes("Ilove@cat");
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    byte[] bytesToBeEncrypted = System.IO.File.ReadAllBytes("filename.xls");

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();

                    System.IO.File.WriteAllBytes("filename.xls", encryptedBytes);
                }
            }
            return Ok();
        }
    }
}
