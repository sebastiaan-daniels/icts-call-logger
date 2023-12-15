using System.ComponentModel.DataAnnotations;

namespace Call_logger.classes
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Unumber { get; set; }
        public bool PaymentStatus { get; set; }

    }
}