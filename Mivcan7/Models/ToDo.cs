namespace Mivcan7.Models
{
    public class ToDo
    {
        public int ?Id { get; set; }
        public string task { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
    }
}
