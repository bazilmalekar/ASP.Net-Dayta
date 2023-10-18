using System;
using Asp.net_Core_Hello_world_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Core_Hello_world_MVC.Data 
{
	public class Hello_world_MVCDbContext : DbContext
	{
		public Hello_world_MVCDbContext(DbContextOptions<Hello_world_MVCDbContext> options) : base(options)
        {

		}
		// "HelloWorld" is Model name
		public DbSet<HelloWorld> Helloworldtb { get; set; }
		// "HelloWorld" is Model name
		public DbSet<Asp.net_Core_Hello_world_MVC.Models.States> States { get; set; } = default!;
	}
}

