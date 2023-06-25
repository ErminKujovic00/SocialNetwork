using Microsoft.EntityFrameworkCore;
using SocialNetwork.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL
{
    public class SocialNetworkDBContext : DbContext
    {
        public SocialNetworkDBContext(DbContextOptions<SocialNetworkDBContext> options) : base(options){
        
        }

        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
