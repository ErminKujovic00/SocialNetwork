using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/<PostController> getAllPosts
        [HttpGet]
        public IEnumerable<PostDTO> GetAll()
        {
            return _postService.GetPosts();
        }

        // GET api/<PostController>/5 getSinglePost
        [HttpGet("{id}")]
        public PostDTO Get(Guid id)
        {
            return _postService.GetPost(id);
        }

        // POST api/<PostController> postPost
        [HttpPost]
        public PostDTO Post(DateTime postDate, string postText, string postPhoto, int postLikes, int postComments)
        {
            return _postService.AddPost(postDate, postText, postPhoto, postLikes, postComments);
        }

        // PUT api/<PostController>/5 fixPost
        [HttpPut("{id}")]
        public PostDTO? Put(Guid id, DateTime postDate, string postText, string postPhoto, int postLikes, int postComments)
        {
            return _postService.UpdatePost(id, postDate, postText, postPhoto, postLikes, postComments);
        }

        // DELETE api/<PostController>/5 deletePost
        [HttpDelete("{id}")]
        public PostDTO? Delete(Guid id)
        {
            return _postService.DeletePost(id);
        }
    }
}
