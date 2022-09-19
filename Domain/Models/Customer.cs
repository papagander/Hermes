using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class Customer
{
    public int CustomerId;
    public string Name;
    public virtual List<Report> Reports { get; set; }
}
