namespace ITI_Final_Project.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public int Quantitiy { get; set; }
        public string? ImagePath { get; set; }
        //Forigen Key
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
