using SocialNetwork.BLL.Data;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNetwork.DAL.Data;

namespace SocialNetwork.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public IEnumerable<PostDTO> GetPosts()
        {
            IEnumerable<Post> posts = _postRepository.GetAllPosts();
            return _mapper.Map<List<PostDTO>>(posts);

        }
        public PostDTO GetPost(Guid id)
        {
            Post? post = _postRepository.GetSinglePost(id);
            return _mapper.Map<PostDTO>(post);
        }

        public PostDTO AddPost(DateTime postDate, string postText, string postPhoto, int postLikes, int postComments)
        {
            Post? post = _postRepository.AddSinglePost(postDate, postText, postPhoto, postLikes, postComments);
            return _mapper.Map<PostDTO>(post);
        }

        public PostDTO? UpdatePost(Guid postId, DateTime postDate, string postText, string postPhoto, int postLikes, int postComments)
        {
            Post? post = _postRepository.UpdateSinglePost(postId, postDate, postText, postPhoto, postLikes, postComments);
            return _mapper.Map<PostDTO>(post);
        }
        public PostDTO? DeletePost(Guid id)
        {
            Post? post = _postRepository.DeleteSinglePost(id);
            return _mapper.Map<PostDTO>(post);
        }
    }
}
