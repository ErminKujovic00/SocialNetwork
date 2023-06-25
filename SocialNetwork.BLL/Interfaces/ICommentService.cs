using SocialNetwork.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetComments();

        CommentDTO GetComment(int id);

        CommentDTO AddComment(CommentDTO commentDTO); // mozda sve pojedinacno

        CommentDTO UpdateComment(CommentDTO commentDTO); // mozda sve pojedinacno

        CommentDTO DeleteComment(int id);

    }
}
