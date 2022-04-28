using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using IPLVotingSystem.Models;
using Amazon.CognitoSync.Model;

namespace IPLVotingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> users { get; set; }
        public DbSet<Admins> admins { get; set; }
        public DbSet<UserRoles> userRoles { get; set; }
        public DbSet<Questionary> questionaries { get; set; }
        public DbSet<Responces> responces { set; get; }
        public DbSet<Options> options { get; set; }




    }
}
