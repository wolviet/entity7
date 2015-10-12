using System;

namespace ConsoleApp
{
	public class Program
	{
		public void Main(string[] args)
		{
			//Console.WriteLine("Hello DNX");
			
			using (var db = new BloggingContext())
			{
				db.Blogs.Add(new Blog { Url = "http://Blogs.msdn.com/adonet"});
				var count = db.SaveChanges();
				Console.WriteLine("{0} records saved to database", count);
				
				Console.WriteLine();
				Console.WriteLine("All blogs in Database:");
				foreach (var blog in db.Blogs)
				{
					Console.WriteLine(" - {0}", blog.Url);
				}
			}
		}
	}
	
	
}