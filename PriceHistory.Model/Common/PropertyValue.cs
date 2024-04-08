using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.Model.Common
{
    public class PropertyValue
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(120)]
        public string? Value { get; set; }

        public int ConcreteModelId { get; set; }
        public virtual required ConcreteModel ConcreteModel { get; set; }

        public int ProductPropertyId { get; set; }
        public virtual required ProductProperty Property { get; set; }

    }
}
