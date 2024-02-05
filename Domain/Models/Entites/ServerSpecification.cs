using Domain.Models.Auditable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entites
{
    public class ServerSpecification : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumberOfCores { get; set; }
        [Required]
        public int NumberOfRam { get; set; }
        [Required]
        public int DiskSizeInGB { get; set; }
        [Required]
        public string IpAddress { get; set; }
        [Required]
        public string DomainName { get; set; }
    }
}
