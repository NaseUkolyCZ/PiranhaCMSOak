using Oak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiranhaCMSOak.Support
{
    public class Schema
    {
        public string CreateUserTable(Seed seed)
        {
            return seed.CreateTable("Users",
                new { Id = "int", Identity = true, PrimaryKey = true },
                new { Email = "nvarchar(max)" },
                new { FirstName = "nvarchar(max)" },
                new { LastName = "nvarchar(max)" },
                new { Password = "nvarchar(max)" }
            );
        }
    }
}
