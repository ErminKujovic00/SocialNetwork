using SocialNetwork.DAL.Data;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly SocialNetworkDBContext _dbContext;

        public PostRepository(SocialNetworkDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _dbContext.Post.AsQueryable();
        }

        public Post? GetSinglePost(Guid id)
        {
            return _dbContext.Post.Where(x => x.PostId == id).FirstOrDefault();
        }

        public Post AddSinglePost(Guid userId, DateTime postDate, string postText, string postPhoto, int postLikes, int postComments)
        {
            Post post = new Post { 
                PostId = new Guid(),
                PostText = postText,
                PostPhoto = postPhoto,
                PostLikes = postLikes,
                PostComments = postComments,
                UserId = userId //mora bit neki pravi user
            };
            _dbContext.Post.Add(post);
            _dbContext.SaveChanges();
            return post;
        }
        public Post? UpdateSinglePost(Guid postId, DateTime postDate, string postText, string postPhoto, int postLikes, int postComments)
        {
            Post? modifiedPost = _dbContext.Post.Where(x => x.PostId.Equals(postId)).FirstOrDefault();
            if (modifiedPost != null)
            {
                modifiedPost.PostText = postText;
                modifiedPost.PostPhoto = postPhoto;
                modifiedPost.PostLikes = postLikes;
                modifiedPost.PostComments = postComments;
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
            return modifiedPost;
        }

        public Post? DeleteSinglePost(Guid id)
        {
            Post? removePost = _dbContext.Post.Where(x => x.PostId.Equals(id)).FirstOrDefault();
            if (removePost != null)
            {
                _dbContext.Post.Remove(removePost);
                _dbContext.SaveChanges();
            }
            return removePost;
        }

    }
}
