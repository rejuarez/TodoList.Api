using Microsoft.AspNetCore.Http;
using System;

namespace Todo.Api.Resources
{
    public class TodoTaskResource
    {
        public int? TodoTaskID { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public IFormFile Document { get; set; }
        public bool IsActive { get; set; }
        public byte[] FileContent { get; set; }
        public string FileContentType { get; set; }
        public string FileName { get; set; }
    }
}
