using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class HospitalCaseStatus
{
    public int StatusId { get; set; }

    public int? UserId { get; set; }

    public int? HospitalId { get; set; }

    public bool? Collection { get; set; }

    public bool? CloseCase { get; set; }

    public virtual Mytable? Hospital { get; set; }

    public virtual Membership? User { get; set; }
}
