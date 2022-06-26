using Demo.Core.Entities;
using System.Collections.Generic;

namespace Demo.Core.Contracts
{
    public interface ICommentRepository
    {
        List<Comment> GetComments();
        void AddComment(Comment comment);
        void DeleteComment(int id);
    }
}
