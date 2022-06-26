using Demo.Core.Contracts;
using Demo.Core.Entities;
using System.Collections.Generic;

namespace Demo.Core.ApplicationService
{
    public class CommentFacade : ICommentFacade
    {
        ICommentRepository commentRepository;
        public CommentFacade(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        public IEnumerable<Comment> GetComments()
        {
            return commentRepository.GetComments();
        }
        public void AddComment(Comment comment)
        {
            commentRepository.AddComment(comment);
        }
        public void DeleteComment(int id)
        {
            commentRepository.DeleteComment(id);
        }
    }
}
