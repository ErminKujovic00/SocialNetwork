using SocialNetwork.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments();

        Comment GetSingleComment(int id);

        Comment AddSingleComment(Comment commentDTO); // mozda sve pojedinacno

        Comment UpdateComment(Comment commentDTO); // mozda sve pojedinacno

        Comment DeleteSingleComment(int id);
    }
}
