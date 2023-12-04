namespace Wad.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public int EmployeeId { get; set; }

        public string? Photo { get; set; }

        public Order? Order { get; set; }

        public Category? Category { get; set; }

        public Brand? Brand { get; set; }   

        public Employee? Employee { get; set; }

        public ICollection<Bid>? Bids { get; set; }



    }
}
