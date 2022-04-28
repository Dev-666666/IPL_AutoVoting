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
    public class AddDbcon :DbContext
    {
        public AddDbcon(DbContextOptions<AddDbcon> options):base(options)
        {

        }
      //  public DbSet<Userlist> userlists { get; set; }
    }
}
