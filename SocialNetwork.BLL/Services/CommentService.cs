using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class CommentService : ICommentService
    {
        public IEnumerable<CommentDTO> GetComments()
        {
            throw new NotImplementedException();
        }

        public CommentDTO GetComment(int id)
        {
            throw new NotImplementedException();
        }
        public CommentDTO AddComment(CommentDTO commentDTO)
        {
            throw new NotImplementedException();
        }
        public CommentDTO UpdateComment(CommentDTO commentDTO)
        {
            throw new NotImplementedException();
        }

        public CommentDTO DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

    }
}
