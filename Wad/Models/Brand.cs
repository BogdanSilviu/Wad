namespace Wad.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Item>? Items { get; set; }
    }
}
