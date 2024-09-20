namespace ITI_Final_Project.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
 