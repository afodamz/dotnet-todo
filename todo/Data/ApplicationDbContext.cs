using System;
using Microsoft.EntityFrameworkCore;
using todo.Models;

namespace todo.Data
{
	public class ApplicationDbContext : DbContext
	{
		// get data fromapp settings
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Todo> Todos { get; set; }
	}
}

