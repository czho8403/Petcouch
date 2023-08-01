using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class Reply
{
    public int ReplyId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime PublishTime { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual Membership User { get; set; } = null!;
}
