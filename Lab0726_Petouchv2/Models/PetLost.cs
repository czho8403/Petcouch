using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class PetLost
{
    public int LoId { get; set; }

    public string? LostId { get; set; }

    public int? UserId { get; set; }

    public string? PetName { get; set; }

    public string? PetBreed { get; set; }

    public string? PetType { get; set; }

    public string Gender { get; set; } = null!;

    public string PetSize { get; set; } = null!;

    public string PetAge { get; set; } = null!;

    public DateTime? LostTime { get; set; }

    public string? LostLocation { get; set; }

    public string? Feature { get; set; }

    public string? Note { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<LostCaseStatus> LostCaseStatuses { get; set; } = new List<LostCaseStatus>();

    public virtual Membership? User { get; set; }
}
