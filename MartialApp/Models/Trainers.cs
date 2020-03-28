using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MartialApp.Models
{
    public partial class Trainers
    {
        public Trainers()
        {
            TrainerPayment = new HashSet<TrainerPayment>();
        }

        public int TrainerId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        [Display(Name = "School")]
        public int? SchoolId { get; set; }
        [Display(Name = "Belt")]
        public int? BeltId { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
        public DateTime? Created { get; set; }
        public string Tarifa { get; set; }
        public double? Importe { get; set; }

        public virtual ICollection<TrainerPayment> TrainerPayment { get; set; }
        public Guid UserGuid { get; set; }
    }
}
