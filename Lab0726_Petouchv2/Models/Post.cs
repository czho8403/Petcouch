using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime PublishTime { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();

    public virtual Membership? User { get; set; }
}
