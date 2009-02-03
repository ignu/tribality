using System;
using System.Text;
using System.Security.Cryptography;

namespace Tribality.Models
{
    public class Language : Entity<int>
    {
        public string Name { get; set; }
    }

    public class User : Entity<int>
    {        
        public User()
        {
        }

        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;            
        }

        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; protected set; }
        public virtual DateTime LastLoginDate { get; set; }

        public virtual void SetPassword(string newPassword)
        {
            Password = encryptPassword(newPassword);
        }

        public virtual bool VerifyPassword(string passwordToVerify)
        {
            string encryptedPasswordToVerify = encryptPassword(passwordToVerify);
            return Password.Equals(encryptedPasswordToVerify);
        }

        private string encryptPassword(string unencryptedPassword)
        {
            byte[] data = Encoding.Unicode.GetBytes(unencryptedPassword);
            byte[] result;

            SHA1 sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);

            return Convert.ToBase64String(result);
        }

        public override string ToString()
        {
            return UserName.ToString();
        }
    }
}
