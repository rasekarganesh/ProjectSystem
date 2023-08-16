using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektsystem.Model
{
    public class Budget
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public bool Archived { get; set; }
        public decimal EarlyCostEstimate { get; set; }
        public decimal CostEstimate { get; set; }
        public decimal ActualCost { get; set; }
        public string MarkdownText { get; set; } = string.Empty;
        //public virtual Project Project { get; set; }
    }
}
