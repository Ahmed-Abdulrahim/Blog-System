using Blog.BLL.Interface;
using Blog.DAL;
using Blog.DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Repo
{
    public class CommentsRepo : IRepoType<Comment>
    {
        private readonly BlogDbContext blogDbContext;

        public CommentsRepo(BlogDbContext _blogDbContext)
        {
            blogDbContext = _blogDbContext;
        }
        public void Add(Comment model) => blogDbContext.Comments.Add(model);



        public void Delete(Comment model) => blogDbContext.Comments.Remove(model);


        public Comment Get(int id) => blogDbContext.Comments.FirstOrDefault(b => b.Id == id);


        public IEnumerable<Comment> GetAll() => blogDbContext.Comments.ToList();


        public async Task<int> Save() => await blogDbContext.SaveChangesAsync();


        public void Update(Comment model) => blogDbContext.Comments.Update(model);
    }
}
