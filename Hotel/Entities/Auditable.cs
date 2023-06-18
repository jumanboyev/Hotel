
using Hotel.Helper;
using System;

namespace Hotel.Entities;

public abstract class Auditable:BaseEntity
{
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public Auditable()
    {
        CreateAt=TimeHelper.GetDateTime();
        UpdateAt=TimeHelper.GetDateTime();
    }

}
