using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektsystem.Model
{
    public class Company
    {
        public Guid Id { get; set; }
        public Guid AdminUserId { get; set; }
       
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool External { get; set; }
        public string TelNumber { get; set; } = string.Empty;
        public string MarkDownText { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string ContactNumber { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

       // public virtual List<Project> Projects { get; set; }


    }
}
