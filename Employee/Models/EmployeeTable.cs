using System;
using System.Collections.Generic;

namespace Employee.Models;

public partial class EmployeeTable
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Salary { get; set; }

    public string? Email { get; set; }
}
