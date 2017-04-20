using MamaJennsPizza.Data;
using MamaJennsPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamaJennsPizza.Infrastructure
{
    public class UserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //grabs the current user
        public IQueryable<ApplicationUser> GetUser(string name)
        {
            return from u in _db.Users
                   where u.UserName == name
                   select u;
        }

    }
}
