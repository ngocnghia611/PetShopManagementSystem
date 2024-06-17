using System;
using System.Collections.Generic;

namespace PetShopManagementSystem.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string EmpAddress { get; set; } = null!;

    public DateOnly EmpDob { get; set; }

    public string EmpPhone { get; set; } = null!;

    public string EmpPass { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
