using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core_Proje_api.Entity;

namespace Core_Proje_api.ApiContext
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=LAPTOP-FPTE8E0E\\SQLEXPRESS;database=CoreprojeDB2;integrated security=true");
		}

		public DbSet<Category> Categories { get; set; }
	}
}
