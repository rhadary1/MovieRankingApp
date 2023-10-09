using RankingApp.Enums;

namespace RankingApp.Model
{
    public class Item
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public string Title { get; set; }
        public int Ranking { get; set; }
        public ItemType Type { get; set; }
    }
}
