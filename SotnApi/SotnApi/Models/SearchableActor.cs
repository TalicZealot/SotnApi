namespace SotnApi.Models
{
    public sealed class SearchableActor
    {
        public string Name { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int Hp { get; set; }
        public int AiId { get; set; }
        public int Palette { get; set; }
        public int Damage { get; set; }
        public int HitboxWidth { get; set; }
        public int HitboxHeight { get; set; }
    }
}
