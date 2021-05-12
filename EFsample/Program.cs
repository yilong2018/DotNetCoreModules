using System;
using System.Linq;


//https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/
//https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli

namespace EFsample
{
    class Program
    {
        private readonly BloggingContext _context;
        public Program(BloggingContext context){
            _context = context;
        }
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //Create
                Console.WriteLine("Insert a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                //Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                //Update
                Console.WriteLine("updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    }
                );
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
            }

        }
    }
    // public void ConfigureServices(IServiceCollection services)
    // {
    //     services.AddControllers();

    //     services.AddDbContext<ApplicationDbContext>(
    //         options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
    // }
}
