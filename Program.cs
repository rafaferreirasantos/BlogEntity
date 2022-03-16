using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var ctx = new BlogDataContext())
            {
                // ctx.Users.Add(new User()
                // {
                //     Bio = "Nascido e criado na Vila Vivaldi.",
                //     Email = "mckaka@gmail.com",
                //     Image = "http://www.uol.com.br",
                //     Name = "Ricardo MC",
                //     PasswordHash = "123mudar",
                //     Slug = "mc-kaka"
                // });
                // ctx.SaveChanges();
                var user = ctx.Users!
                    .Include(x => x.Roles)
                    .Include(x => x.Posts!)
                    .ThenInclude(x => x.Category)
                    .First(x => x.Slug == "mc-kaka");
                Console.WriteLine(user);
                foreach (Role role in user.Roles!)
                    Console.WriteLine($"  {role}");

                foreach (Post post in user.Posts!)
                    Console.WriteLine($"  {post}");
                // Post post = new Post()
                // {
                //     Author = user,
                //     Body = "Aqui estou mais um dia, sob o olhar sanguinário do vigia...",
                //     Category = new Category()
                //     {
                //         Name = "Letas de RAP",
                //         Slug = "letras-de-rap"
                //     },
                //     CreateDate = System.DateTime.UtcNow,
                //     Slug = "dirario-de-um-detento",
                //     Summary = "Letra da poesia do Mano Brown",
                //     Title = "Diário de um detento"
                // };
                // ctx.Posts.Add(post);
                // ctx.SaveChanges();
            }
        }
    }
}