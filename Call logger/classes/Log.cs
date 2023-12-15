using System.ComponentModel.DataAnnotations;

namespace Call_logger.classes
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string Unumber { get; set; }
        public string Description { get; set; }
        public string CallDuration { get; set; }

    }
}