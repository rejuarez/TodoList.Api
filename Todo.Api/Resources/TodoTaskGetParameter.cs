namespace Todo.Api.Resources
{
    public class TodoTaskGetParameter
    {
        public int? CategoryID { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
