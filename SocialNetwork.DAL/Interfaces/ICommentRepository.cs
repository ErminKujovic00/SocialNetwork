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
        public IEnumerable<Comment> GetAllComments();

        public Comment? GetSingleComment(Guid id);

        public Comment AddSingleComment(String text, DateTime vrijemeObjave, Guid postID, Guid userID, int brojLajkova);

        public Comment? UpdateSingleComment(Guid commentID, String text, DateTime vrijemeObjave, Guid postID, Guid userID, int brojLajkova);

        public Comment? DeleteSingleComment(Guid id);
    }
}
