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

        CommentDTO GetComment(Guid id);

        CommentDTO AddComment(String text, DateTime vrijemeObjave, Guid postID, Guid userID, int brojLajkova); // mozda sve pojedinacno

        CommentDTO? UpdateComment(Guid commentID, String text, DateTime vrijemeObjave, Guid postID, Guid userID, int brojLajkova); // mozda sve pojedinacno

        CommentDTO? DeleteComment(Guid id);

    }
}
