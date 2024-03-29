using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;


namespace ConsoleApp
{
	public class BloggingContext : DbContext
	{
		public DbSet<Blog> Blogs {get; set;}
		public DbSet<Post> Posts {get; set;}
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var appEnv = CallContextServiceLocator.Locator.ServiceProvider.GetRequiredService<IApplicationEnvironment>();
			optionsBuilder.UseSqlite($"Data Source={ appEnv.ApplicationBasePath }/blog.db");
		}
	}
	
	public class Blog
	{
		public int BlogId { get; set;}
		public string Url { get; set;}
		public string Name { get; set;}
		
		public List<Post> Posts{ get; set;}
	}
	
	public class Post
	{
		public int PostId { get; set;}
		public string Title { get; set;}
		public string Content { get; set;}
		
		public int BlogId {get; set;}
		public Blog Blog { get; set;}
	}
}
	
