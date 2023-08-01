using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class Contact
{
    public int? UserId { get; set; }

    public string? Ctperson { get; set; }

    public string? Ctphone { get; set; }

    public string? Ctemail { get; set; }

    public string? Ctpicture1 { get; set; }

    public string? Ctpicture2 { get; set; }

    public string? Ctpicture3 { get; set; }

    public virtual Membership? User { get; set; }
}
