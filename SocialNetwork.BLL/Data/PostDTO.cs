using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Data
{
    public class PostDTO
    {
        public DateTime PostDate { get; set; }
        public string PostText { get; set; } = string.Empty;
        public string PostPhoto { get; set; } = string.Empty;
        public int PostLikes { get; set; }
        public int PostComments { get; set; }

    }
}
