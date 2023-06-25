using SocialNetwork.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPosts();

        Post? GetSinglePost(Guid id);

        Post AddSinglePost(DateTime postDate, string postText, string postPhoto, int postLikes, int postComments); 
        
        Post? UpdateSinglePost(Guid postId, DateTime postDate, string postText, string postPhoto, int postLikes, int postComments); 

        Post? DeleteSinglePost(Guid id);

    }
}
