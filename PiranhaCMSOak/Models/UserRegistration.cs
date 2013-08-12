using Oak;
using PiranhaCMSOak.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PiranhaCMSOak.Models
{
    public class UserRegistration : DynamicModel
    {
        Users users = new Users();

        public UserRegistration()
            : this(new { })
        {
        }

        public UserRegistration(object entity)
            : base(entity)
        {
        }

        internal bool checkEmailUniqueness = true;

        public IEnumerable<dynamic> Validates()
        {
            yield return
            new Presence("Login");

            yield return
            new Presence("Email");

            yield return
            new Presence("FirstName");

            yield return
            new Presence("LastName");

            yield return
            new Format("Email")
            {
                With = @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$"
            };

            if (checkEmailUniqueness)
                yield return
                new Uniqueness("Email", users) { ErrorMessage = "Email is unavailable." };


            yield return
            new Presence("Password") { ErrorMessage = "Password is required." };

            yield return
            new Confirmation("Password") { ErrorMessage = "Passwords do not match." };
        }

        public void Register()
        {
            _.Password = Encrypt(_.Password);

            users.Insert(this.Exclude("PasswordConfirmation", "Login"));
        }

        public void Save()
        {
            _.Password = Encrypt(_.Password);

            users.Save(this.Exclude("PasswordConfirmation", "Company"));
        }

        public static string Encrypt(string password)
        {
            //create new instance of sha1
            SHA1 sha1 = SHA1.Create();

            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(password));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();

        }
    }
}
