using genscoSQLProject1.Models;

namespace genscoSQLProject1.Interfaces
{
    public interface ICommentsRepository
    {
        ICollection<Comments> GetComments();
        Comments GetComment(int commentId);
        ICollection<Comments> GetCommentByCategory(int categoryId);
        bool CommentExists(int commentId);
        bool CreateComment(Comments comment);
        bool UpdateComment(Comments comment);
        bool DeleteComment(Comments comment);
        bool Save();
    }
}
