
using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Entities.Clients;

public sealed class Client
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    public bool isMale { get; set; }

    public string Address { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public string PasportSeriaNumber { get; set; } = string.Empty;


    public string Describtion { get; set; } = string.Empty;

}
