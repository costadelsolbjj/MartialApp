using System;
using System.Collections.Generic;

namespace MartialApp.Models
{
    public partial class ScheduleTrainer
    {
        public int ScheduleTrainerId { get; set; }
        public int? TrainerId { get; set; }
        public int? ScheduleId { get; set; }

        public virtual Trainers Trainers { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
