using System;
using Volo.Abp.Application.Dtos;

namespace Crm.Passengers
{
    public class PassengerDto : EntityDto<Guid>
    {
        public Guid Reservation { get; set; }
        public Guid ReservationDetail { get; set; }
        public bool ReservationHolder { get; set; }
        public Guid? Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public Guid AgePolicyDetail { get; set; }
        public DateTime? PassengerDOB { get; set; }
        public Guid? DocumentType { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? Expiration { get; set; }
        public string PassengerNote { get; set; }
        public int ClientNo { get; set; }
        public Guid Reduction { get; set; }
    }
}