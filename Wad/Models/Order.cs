namespace Wad.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string? UserId { get; set; }

       

        public Item? Item { get; set; }
    }
}
