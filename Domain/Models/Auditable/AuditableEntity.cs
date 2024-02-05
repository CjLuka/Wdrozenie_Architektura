using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auditable
{
    public class AuditableEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; } //zezwala na null, ponieważ podczas dodania rekordu nie było modyfikacji
        public bool Status { get; set; }
    }
}
