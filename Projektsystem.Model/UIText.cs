using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektsystem.Model
{
    public class UIText
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string UIkey { get; set; } = string.Empty;
        public string UIvalue { get; set; } = string.Empty;
    }
}
