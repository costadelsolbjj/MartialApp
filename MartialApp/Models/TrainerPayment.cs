using System;
using System.Collections.Generic;

namespace MartialApp.Models
{
    public partial class TrainerPayment
    {
        public int TrainerPaymentId { get; set; }
        public int? TrainerId { get; set; }
        public int? PaymentId { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual Trainers Trainer { get; set; }
    }
}
