using SocialNetwork.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDTO> GetPosts();

        PostDTO GetPost(Guid id);

        PostDTO AddPost(Guid userId, DateTime postDate, string postText, string postPhoto, int postLikes, int postComments); // mozda sve pojedinacno

        //mozda dodati kolonu kao updateDate
        PostDTO? UpdatePost(Guid postId, DateTime postDate, string postText, string postPhoto, int postLikes, int postComments); // mozda sve pojedinacno

        PostDTO? DeletePost(Guid id);

    }
}
