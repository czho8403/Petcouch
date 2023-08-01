using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class Shelter
{
    public int Sid { get; set; }

    public string? SpetBreed { get; set; }

    public string? SpetType { get; set; }

    public string Sgender { get; set; } = null!;

    public string SpetSize { get; set; } = null!;

    public string? SpetColour { get; set; }

    public string SpetAge { get; set; } = null!;

    public string Slocation { get; set; } = null!;

    public string Sphone { get; set; } = null!;

    public string Saddress { get; set; } = null!;

    public string? Spicture { get; set; }

    public virtual ICollection<ShelterCaseStatus> ShelterCaseStatuses { get; set; } = new List<ShelterCaseStatus>();
}
