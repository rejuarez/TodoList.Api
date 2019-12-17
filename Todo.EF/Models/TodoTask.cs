using System;

namespace Todo.Core.Models
{
    public class TodoTask
    {
        public int TodoTaskID { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public virtual Category Category { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public byte[] FileContent { get; set; }
        public bool IsActive { get; set; }

    }
}
