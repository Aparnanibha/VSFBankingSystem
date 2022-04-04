using System;
using System.Collections.Generic;

namespace VSFBankingSystem.Models
{
    public partial class ValidLogin
    {
        public decimal CustomerId { get; set; }
        public string? Passwordd { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
