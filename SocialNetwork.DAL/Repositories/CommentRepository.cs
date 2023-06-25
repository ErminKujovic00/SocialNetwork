using SocialNetwork.DAL.Data;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public Comment AddSingleComment(Comment commentDTO)
        {
            throw new NotImplementedException();
        }

        public Comment DeleteSingleComment(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public Comment GetSingleComment(int id)
        {
            throw new NotImplementedException();
        }

        public Comment UpdateComment(Comment commentDTO)
        {
            throw new NotImplementedException();
        }
    }
}
