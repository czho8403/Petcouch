using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class LostCaseStatus
{
    public int StatusId { get; set; }

    public int? UserId { get; set; }

    public int? LoId { get; set; }

    public bool? Collection { get; set; }

    public bool? CloseCase { get; set; }

    public virtual PetLost? Lo { get; set; }

    public virtual Membership? User { get; set; }
}
