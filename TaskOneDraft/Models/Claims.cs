using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskOneDraft.Models
{
    public class Claims
    {
        // Columns you want in the claims table
        public int ID { get; set; }
        [Required]
        public string? LecturerID { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime ClaimsPeriodStart { get; set; }
        [Required]
        public DateTime ClaimsPeriodEnd { get; set; }


        public double HoursWorked { get; set; }
        public double RatePerHour { get; set; }
        public double TotalAmount { get; set; }
        public string? DescriptionOfWork { get; set; }


        //Mark
        [NotMapped]
        public List<IFormFile>? SupportingDocuments { get; set; }

    }
}
