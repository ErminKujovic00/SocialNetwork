using AutoMapper;
using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.DAL.Data;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class CommentService : ICommentService
    {

        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public IEnumerable<CommentDTO> GetComments()
        {
            IEnumerable<Comment> comments = _commentRepository.GetAllComments();
            return _mapper.Map<List<CommentDTO>>(comments);
        }

        public CommentDTO GetComment(Guid id)
        {
            Comment? comment = _commentRepository.GetSingleComment(id);
            return _mapper.Map<CommentDTO>(comment);
        }

        public CommentDTO AddComment(string text, DateTime vrijemeObjave, Guid postID, Guid userID, int brojLajkova)
        {
            Comment comment = _commentRepository.AddSingleComment(text, vrijemeObjave, postID, userID, brojLajkova);
            return _mapper.Map<CommentDTO>(comment);
        }

        public CommentDTO? UpdateComment(Guid commentID, string text, DateTime vrijemeObjave, Guid postID, Guid userID, int brojLajkova)
        {
            Comment? comment = _commentRepository.UpdateSingleComment(commentID, text, vrijemeObjave, postID, userID, brojLajkova);
            return _mapper.Map<CommentDTO>(comment);
        }

        public CommentDTO? DeleteComment(Guid id)
        {
            Comment? comment = _commentRepository.DeleteSingleComment(id);
            return _mapper.Map<CommentDTO>(comment);
        }
    }
}
