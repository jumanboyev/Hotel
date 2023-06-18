
using System.ComponentModel.DataAnnotations;
using System;

namespace Hotel.Entities.Employees;

public class Employee
{
    public long PositionId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    public bool isMale { get; set; }

    public string Address { get; set; } = string.Empty;

    [MaxLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    [MaxLength(9)]
    public string PasportSeriaNumber { get; set; } = string.Empty;

    public float Price { get; set; }

    public DateTime BirthDate { get; set; }

    public string Describtion { get; set; } = string.Empty;

}
