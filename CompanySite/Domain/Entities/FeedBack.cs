using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySite.Domain.Entities
{
    public class FeedBack
    {
        [Required]
        public virtual Guid id { get; set; }

        [Display(Name = "Имя")]
        public virtual string Name { get; set; }

        [Display(Name = "Телефон")]
        public virtual string PhoneNumber { get; set; }
    }
}
