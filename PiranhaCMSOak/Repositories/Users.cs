using Massive;
using PiranhaCMSOak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiranhaCMSOak.Repositories
{
    public class Users : DynamicRepository
    {
        public Users()
        {
            Projection = d => new User(d);
        }

        public dynamic ForEmail(string email)
        {
            return SingleWhere("Email = @0", email);
        }
    }
}
