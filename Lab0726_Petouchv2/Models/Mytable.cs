using System;
using System.Collections.Generic;

namespace Lab0726_Petouchv2.Models;

public partial class Mytable
{
    public int Id { get; set; }

    public string 縣市 { get; set; } = null!;

    public string 字號 { get; set; } = null!;

    public string 執照類別 { get; set; } = null!;

    public string 狀態 { get; set; } = null!;

    public string 機構名稱 { get; set; } = null!;

    public string 負責獸醫 { get; set; } = null!;

    public string? 機構電話 { get; set; }

    public DateTime? 發照日期 { get; set; }

    public string 機構地址 { get; set; } = null!;

    public virtual ICollection<HospitalCaseStatus> HospitalCaseStatuses { get; set; } = new List<HospitalCaseStatus>();
}
