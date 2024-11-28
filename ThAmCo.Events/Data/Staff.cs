namespace ThAmCo.Events.Data
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool IsFirstAider { get; set; }

        public ICollection<Staffing> Staffings { get; set; } = new List<Staffing>();
    }
}