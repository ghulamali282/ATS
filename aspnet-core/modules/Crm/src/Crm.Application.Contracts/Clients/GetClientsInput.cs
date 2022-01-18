using Volo.Abp.Application.Dtos;
using System;

namespace Crm.Clients
{
    public class GetClientsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public Guid? Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Guid? Gender { get; set; }
        public DateTime? ClientDOBMin { get; set; }
        public DateTime? ClientDOBMax { get; set; }
        public Guid? AgePolicy { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public string Country { get; set; }
        public string Nacionality { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string CellPhone { get; set; }
        public bool? CellPhoneConfirmed { get; set; }
        public Guid? DocumentType { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? IssueDateMin { get; set; }
        public DateTime? IssueDateMax { get; set; }
        public DateTime? ExpirationMin { get; set; }
        public DateTime? ExpirationMax { get; set; }
        public bool? MailingList { get; set; }

        public GetClientsInput()
        {

        }
    }
}