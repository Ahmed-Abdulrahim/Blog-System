using Blog.BLL.Interface;
using Blog.DAL;
using Blog.DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Repo
{
    public class BlogpostRepo : IRepoType<BlogPost>
    {
        private readonly BlogDbContext blogDbContext;

        public BlogpostRepo(BlogDbContext _blogDbContext)
        {
            blogDbContext = _blogDbContext;
        }
        public void Add(BlogPost model)=>blogDbContext.BlogPosts.Add(model);
        
       

        public void Delete(BlogPost model)=>blogDbContext.BlogPosts.Remove(model);


        public BlogPost Get(int id) => blogDbContext.BlogPosts.Include(c => c.Comments).Include(u=>u.Users).FirstOrDefault(b => b.Id == id);
       

        public IEnumerable<BlogPost> GetAll()=>blogDbContext.BlogPosts.Include(u=>u.Users).Include(c=>c.Comments).ToList();
        

        public async Task<int> Save()=>await blogDbContext.SaveChangesAsync();
       

        public void Update(BlogPost model)=>blogDbContext.BlogPosts.Update(model);
        
    }
}
