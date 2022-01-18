using Volo.Abp.Application.Dtos;
using System;

namespace Crm.Passengers
{
    public class GetPassengersInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public Guid? Reservation { get; set; }
        public Guid? ReservationDetail { get; set; }
        public bool? ReservationHolder { get; set; }
        public Guid? Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public Guid? AgePolicyDetail { get; set; }
        public DateTime? PassengerDOBMin { get; set; }
        public DateTime? PassengerDOBMax { get; set; }
        public Guid? DocumentType { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? IssueDateMin { get; set; }
        public DateTime? IssueDateMax { get; set; }
        public DateTime? ExpirationMin { get; set; }
        public DateTime? ExpirationMax { get; set; }
        public string PassengerNote { get; set; }
        public int? ClientNoMin { get; set; }
        public int? ClientNoMax { get; set; }
        public Guid? Reduction { get; set; }

        public GetPassengersInput()
        {

        }
    }
}