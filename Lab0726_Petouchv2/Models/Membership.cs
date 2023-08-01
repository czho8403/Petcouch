using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class Membership
{
    public int UserId { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? UserName { get; set; }

    public int? TraceCount { get; set; }

    public int? AdoptCount { get; set; }

    public string? Sex { get; set; }

    public DateTime? Birth { get; set; }

    public string? Address { get; set; }

    public string? NickName { get; set; }

    public string? NickNameV2 { get; set; }

    public string? ChkEmailCode { get; set; }

    public DateTime? ChkEmailCodeTimeout { get; set; }

    public virtual ICollection<AdoptCaseStatus> AdoptCaseStatuses { get; set; } = new List<AdoptCaseStatus>();

    public virtual ICollection<Adoption> Adoptions { get; set; } = new List<Adoption>();

    public virtual ICollection<HospitalCaseStatus> HospitalCaseStatuses { get; set; } = new List<HospitalCaseStatus>();

    public virtual ICollection<LostCaseStatus> LostCaseStatuses { get; set; } = new List<LostCaseStatus>();

    public virtual ICollection<PetLost> PetLosts { get; set; } = new List<PetLost>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();

    public virtual ICollection<ShelterCaseStatus> ShelterCaseStatuses { get; set; } = new List<ShelterCaseStatus>();
}
