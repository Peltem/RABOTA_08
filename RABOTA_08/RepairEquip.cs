using System;
using System.Runtime.InteropServices.JavaScript;

namespace RABOTA_08;

public class RepairEquip
{
    public int Id { get; set; }
    public int Applic { get; set; }
    public int Staff { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public int Matetial { get; set; }
    public int Money { get; set; }
    public string Reason { get; set; }
}