using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class Adoption
{
    public int AdId { get; set; }

    public string? AdCaseId { get; set; }

    public int? MemberId { get; set; }

    public string? PetName { get; set; }

    public string? PetBreed { get; set; }

    public string? PetType { get; set; }

    public string Gender { get; set; } = null!;

    public string PetSize { get; set; } = null!;

    public string PetAge { get; set; } = null!;

    public string Ligation { get; set; } = null!;

    public string? Feature { get; set; }

    public string? Location { get; set; }

    public string? Note { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<AdoptCaseStatus> AdoptCaseStatuses { get; set; } = new List<AdoptCaseStatus>();

    public virtual Membership? Member { get; set; }
}
