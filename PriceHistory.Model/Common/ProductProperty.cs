using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHistory.Model.Common
{
    public class ProductProperty
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public required string Name { get; set; }

        public virtual ICollection<PropertyValue>? PropertyValues { get; set; }
    }
}
