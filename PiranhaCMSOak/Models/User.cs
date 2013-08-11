using Oak;
using PiranhaCMSOak.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiranhaCMSOak.Models
{
    public class User : DynamicModel
    {
        Users users = new Users();

        public User(object dto)
            : base(dto)
        {
        }

        public IEnumerable<dynamic> Validates()
        {
            yield return
            new Format("Email") { With = "^[\\S]*$", ErrorMessage = "Your email can't contain any spaces." };

            yield return
            new Exclusion("Email") { In = new[] { "@emailless" }, ErrorMessage = "You did not specify a handle." };

            yield return
            new Format("Email") { With = "[a-zA-Z0-9]+", ErrorMessage = "You did not specify a handle." };

            yield return
            new Uniqueness("Email", users) { ErrorMessage = "The email is already taken." };
        }

    }
}
