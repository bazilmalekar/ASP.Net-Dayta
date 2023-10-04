using System;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Core_Hello_world_MVC.Data 
{
	public class Hello_world_MVC : DbContext
	{
		public Hello_world_MVC(DbContextOptions<Hello_world_MVC> options) : base(options)
        {

		}
	}
}

