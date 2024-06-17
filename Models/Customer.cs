using System;
using System.Collections.Generic;

namespace PetShopManagementSystem.Models;

public partial class Customer
{
    public int CustId { get; set; }

    public string CustName { get; set; } = null!;

    public string CustAddress { get; set; } = null!;

    public string CustPhone { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
