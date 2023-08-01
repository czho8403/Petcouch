using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class ShelterCaseStatus
{
    public int StatusId { get; set; }

    public int? UserId { get; set; }

    public int? Sid { get; set; }

    public bool? Collection { get; set; }

    public bool? CloseCase { get; set; }

    public virtual Shelter? SidNavigation { get; set; }

    public virtual Membership? User { get; set; }
}
