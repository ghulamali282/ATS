using System;
using Volo.Abp.Application.Dtos;

namespace Crm.Clients
{
    public class ClientDto : EntityDto<Guid>
    {
        public Guid? Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Guid? Gender { get; set; }
        public DateTime? ClientDOB { get; set; }
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
        public DateTime? IssueDate { get; set; }
        public DateTime? Expiration { get; set; }
        public bool MailingList { get; set; }
    }
}