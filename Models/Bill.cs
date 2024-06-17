using System;
using System.Collections.Generic;

namespace PetShopManagementSystem.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int CustId { get; set; }

    public int EmpId { get; set; }

    public DateOnly BillDate { get; set; }

    public string CustName { get; set; } = null!;

    public string EmpName { get; set; } = null!;

    public int Amt { get; set; }

    public virtual Customer Cust { get; set; } = null!;

    public virtual Employee Emp { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
