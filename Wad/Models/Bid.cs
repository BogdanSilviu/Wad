namespace Wad.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string UserId { get; set; }

        public int Price { get; set; }

        public Item? Item { get; set; }

    }
}
