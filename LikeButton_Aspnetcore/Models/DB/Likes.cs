using System;
using System.Collections.Generic;

namespace LikeButton_Aspnetcore.Models.DB
{
    public partial class Likes
    {
        public long Id { get; set; }
        public long? TotalLikes { get; set; }
    }
}
