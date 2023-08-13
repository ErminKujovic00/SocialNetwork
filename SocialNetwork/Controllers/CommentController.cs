using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.BLL.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        // GET: api/<CommentController> getAllComments
        [HttpGet]
        public IEnumerable<CommentDTO> GetComments()
        {
            return _commentService.GetComments();
        }

        // GET api/<CommentController>/5 getComment
        [HttpGet("{id}")]
        public CommentDTO Get(Guid id)
        {
            return _commentService.GetComment(id);
        }

        // POST api/<CommentController> postComment
        [HttpPost]
        public CommentDTO Post(string text, DateTime vrijemeObjave, Guid postID, Guid userID, int brojLajkova)
        {
            return _commentService.AddComment(text, vrijemeObjave, postID, userID, brojLajkova);
        }

        // PUT api/<CommentController>/5 fixComment
        [HttpPut("{id}")]
        public CommentDTO? Put(Guid CommentId, string text, DateTime vrijemeObjave, Guid postID, Guid userID, int brojLajkova)
        {
            return _commentService.UpdateComment(CommentId, text, vrijemeObjave, postID, userID, brojLajkova);
        }


        // DELETE api/<CommentController>/5 deleteAllComments
        [HttpDelete]
        public CommentDTO? Delete(Guid id)
        {
            CommentDTO? deletedComment = _commentService.DeleteComment(id);
            if (deletedComment == null)
            {
                throw new Exception();
            }
            return deletedComment;
        }
    }
}
