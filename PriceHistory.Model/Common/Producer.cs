using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.Model.Common
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public required string Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        [MaxLength(40)]
        public string? LogoName { get; set; }

        public virtual required ICollection<ConcreteModel> Models { get; set; }
    }
}
