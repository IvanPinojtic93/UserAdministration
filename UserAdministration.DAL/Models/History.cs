using System.ComponentModel.DataAnnotations.Schema;

namespace UserAdministration.DAL.Models
{
    public class History
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public required string Browser { get; set; }
        public required int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
