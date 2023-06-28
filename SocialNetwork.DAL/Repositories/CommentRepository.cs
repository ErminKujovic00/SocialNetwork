using Azure;
using SocialNetwork.DAL.Data;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        private readonly SocialNetworkDBContext _dbContext;

        public CommentRepository(SocialNetworkDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _dbContext.Comment.AsQueryable();
        }

        public Comment? GetSingleComment(Guid id)
        {
            return _dbContext.Comment.Where(x => x.CommentId == id).FirstOrDefault();
        }

        public Comment AddSingleComment(string text, DateTime vrijemeObjave, Guid postID, Guid userID, int brojLajkova)
        {
            Comment newComment = new Comment
            {
                CommentId = new Guid(),
                CommentText = text,
                CommentDate = vrijemeObjave,
                NumberOfLikes = brojLajkova,
                PostId = postID,
                UserId = userID
            };
            _dbContext.Comment.Add(newComment);
            _dbContext.SaveChanges();
            return newComment;
        }

        public Comment? DeleteSingleComment(Guid id)
        {
            Comment? removeComment = _dbContext.Comment.Where(x => x.CommentId.Equals(id)).FirstOrDefault();
            if (removeComment != null)
            {
                _dbContext.Comment.Remove(removeComment);
                _dbContext.SaveChanges();
            }

            return removeComment;
        }

        public Comment? UpdateSingleComment(Guid commentId, string text, DateTime vrijemeObjave, Guid postID, Guid userID, int brojLajkova)
        {
            Comment? modifiedComment = _dbContext.Comment.Where(x => x.CommentId.Equals(commentId)).FirstOrDefault();
            if (modifiedComment != null)
            {
                modifiedComment.CommentDate = vrijemeObjave;
                modifiedComment.CommentText = text;
                modifiedComment.CommentDate = vrijemeObjave;
                modifiedComment.NumberOfLikes = brojLajkova;
                modifiedComment.PostId = postID;
                modifiedComment.UserId = userID;
                try
                {
                    _dbContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw new Exception();
                }
            }
            return modifiedComment;
        }
    }
}
