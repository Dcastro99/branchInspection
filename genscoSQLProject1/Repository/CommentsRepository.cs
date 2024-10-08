using genscoSQLProject1.Data;
using genscoSQLProject1.Interfaces;
using genscoSQLProject1.Models;

namespace genscoSQLProject1.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        DataContext _context;

        public CommentsRepository(DataContext context)
        {
            _context = context;
        }
        public bool CommentExists(int commentId)
        {
            return _context.Comments.Any(c => c.CommentId == commentId);
        }

        public bool CreateComment(Comments comment)
        {
            _context.Comments.Add(comment);
            return Save();
        }

        public bool DeleteComment(Comments comment)
        {
            _context.Comments.Remove(comment);
            return Save();
        }

        public Comments GetComment(int commentId)
        {
            return _context.Comments.FirstOrDefault(c => c.CommentId == commentId);
        }

        public ICollection<Comments> GetCommentByCategory(int categoryId)
        {
            return _context.Comments.Where(c => c.CategoryId == categoryId).ToList();
        }

        public ICollection<Comments> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateComment(Comments comment)
        {
            _context.Comments.Update(comment);
            return Save();
        }
    }
}
