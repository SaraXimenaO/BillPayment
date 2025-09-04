﻿using System.ComponentModel.DataAnnotations;

namespace BillPayment.Domain.Entities;

public class DomainEntity
{
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}

