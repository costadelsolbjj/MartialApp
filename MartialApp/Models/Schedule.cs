using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartialApp.Models
{
    public class Schedule
    {
        public Schedule()
        {
            ScheduleTrainer = new HashSet<ScheduleTrainer>();
        }
        public int SheduleId { get; set; }
        public DateTime SheduleStart { get; set; }
        public DateTime SheduleEnd { get; set; }
        public int LessonId { get; set; }

        public virtual ICollection<ScheduleTrainer> ScheduleTrainer { get; set; }
    }
}
