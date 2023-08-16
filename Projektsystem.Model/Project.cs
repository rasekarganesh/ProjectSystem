using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projektsystem.Model
{
    public class Project
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public Guid FolderId { get; set; }

        public Guid ForCompanyId { get; set; }
     //   public virtual Company ForCompnay { get; set; }

        public string ForCompanyName { get; set; } = string.Empty;

        public Guid ByCompanyId { get; set; }
      //  public virtual Company ByCompnay { get; set; }
        public string ByCompanyName { get; set; } = string.Empty;

        public bool IsOpen { get; set; }
        public string MarkdownText { get; set; } = string.Empty;
        public Status Status { get; set; }
       // public virtual List<User> Users { get; set; }
        //public virtual Budget Budget { get; set; }
    }

   public enum Status
    {
        New,
        Plan,
        Open,
        Paused,
        Closed,
        Hidden
    }

}