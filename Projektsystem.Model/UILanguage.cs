using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektsystem.Model
{
    public class UILanguage
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CultureName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }
}
