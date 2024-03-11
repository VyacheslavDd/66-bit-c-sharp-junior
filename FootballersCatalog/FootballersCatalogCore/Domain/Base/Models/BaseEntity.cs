using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballersCatalogCore.Domain.Base.Models
{
    public class BaseEntity<T>
    {
        public required T Id { get; set; }
    }
}
