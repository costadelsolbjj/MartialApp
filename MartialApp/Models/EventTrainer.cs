namespace MartialApp.Models
{
    public class EventTrainer
    {
        public int EventTrainerId { get; set; }
        public int? TrainerId { get; set; }
        public int? EventId { get; set; }

        public virtual Trainers Trainers { get; set; }
        public virtual Event Event { get; set; }
    }
}