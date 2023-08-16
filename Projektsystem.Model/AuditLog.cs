using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektsystem.Model
{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public DateTime EventTime { get; set; } = DateTime.Now;
        public LogEventType EventEnum { get; set; }
        public Guid ForId { get; set; }
        public string ForName { get; set; }
        public string Source { get; set; } = string.Empty;
        public string InTable { get; set; } = string.Empty;
        public string MarkdownText { get; set; } = string.Empty;
    }
}
