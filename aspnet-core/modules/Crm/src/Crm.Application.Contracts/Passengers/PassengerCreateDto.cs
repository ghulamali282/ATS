using System;
using System.ComponentModel.DataAnnotations;

namespace Crm.Passengers
{
    public class PassengerCreateDto
    {
        [Required]
        public Guid Reservation { get; set; }
        [Required]
        public Guid ReservationDetail { get; set; }
        [Required]
        public bool ReservationHolder { get; set; }
        public Guid? Title { get; set; }
        [Required]
        [StringLength(PassengerConsts.FirstNameMaxLength)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(PassengerConsts.LastNameMaxLength)]
        public string LastName { get; set; }
        [StringLength(PassengerConsts.CountryMaxLength)]
        public string Country { get; set; }
        [Required]
        public Guid AgePolicyDetail { get; set; }
        public DateTime? PassengerDOB { get; set; }
        public Guid? DocumentType { get; set; }
        [StringLength(PassengerConsts.DocumentNoMaxLength)]
        public string DocumentNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? Expiration { get; set; }
        public string PassengerNote { get; set; }
        [Required]
        public int ClientNo { get; set; }
        [Required]
        public Guid Reduction { get; set; }
    }
}