using Demo.Core.Contracts;
using Demo.Core.Entities;
using Demo.InfraStructure.EF;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Infrastructure.Data
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DemoContext Context;
        public CommentRepository(DemoContext Context)
        {
            this.Context = Context;
        }
        public List<Comment> GetComments()
        {
            return Context.Comments.ToList();
        }
        public void AddComment(Comment comment)
        {
            Context.Comments.Add(comment);
            Context.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            Context.Comments.Remove(new Comment() { CommentId = id });
            Context.SaveChanges();
        }
    }
}
