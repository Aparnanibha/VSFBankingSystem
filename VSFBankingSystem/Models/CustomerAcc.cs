using System;
using System.Collections.Generic;

namespace VSFBankingSystem.Models
{
    public partial class CustomerAcc
    {
        public CustomerAcc()
        {
            AddPayees = new HashSet<AddPayee>();
            Bankings = new HashSet<Banking>();
            TransactionDetails = new HashSet<TransactionDetail>();
        }

        public decimal AccountNumber { get; set; }
        public decimal? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<AddPayee> AddPayees { get; set; }
        public virtual ICollection<Banking> Bankings { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
