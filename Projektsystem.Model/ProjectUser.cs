using System;
namespace Projektsystem.Model
{
	public class ProjectUser
	{
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public bool Archived { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public string MarkdownText { get; set; } = string.Empty;
    }
}

