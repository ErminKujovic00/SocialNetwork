using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Data
{
    public class CommentDTO
    {
        public string CommentText { get; set; } = string.Empty;
        public DateTime CommentDate { get; set; }
        public int NumberOfLikes { get; set; }
    }
}
