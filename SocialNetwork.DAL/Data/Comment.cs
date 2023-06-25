using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Data
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime CommentDate { get; set; }
        public int NumberOfLikes { get; set; }
    }
}
