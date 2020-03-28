using System;
using System.Collections.Generic;

namespace MartialApp.Models
{
    public partial class Payment
    {
        public Payment()
        {
            TrainerPayment = new HashSet<TrainerPayment>();
        }

        public int PaimentId { get; set; }
        public DateTime Paid { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<TrainerPayment> TrainerPayment { get; set; }
    }
}
