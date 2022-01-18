using System;
using System.ComponentModel.DataAnnotations;

namespace Crm.Clients
{
    public class ClientCreateDto
    {
        public Guid? Title { get; set; }
        [Required]
        [StringLength(ClientConsts.FirstNameMaxLength)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(ClientConsts.SecondNameMaxLength)]
        public string SecondName { get; set; }
        public Guid? Gender { get; set; }
        public DateTime? ClientDOB { get; set; }
        public Guid? AgePolicy { get; set; }
        [StringLength(ClientConsts.EmailMaxLength)]
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        [StringLength(ClientConsts.CountryMaxLength)]
        public string Country { get; set; }
        [StringLength(ClientConsts.NacionalityMaxLength)]
        public string Nacionality { get; set; }
        [StringLength(ClientConsts.StateMaxLength)]
        public string State { get; set; }
        [StringLength(ClientConsts.ZipCodeMaxLength)]
        public string ZipCode { get; set; }
        [StringLength(ClientConsts.CityMaxLength)]
        public string City { get; set; }
        [StringLength(ClientConsts.CellPhoneMaxLength)]
        public string CellPhone { get; set; }
        public bool? CellPhoneConfirmed { get; set; }
        public Guid? DocumentType { get; set; }
        [StringLength(ClientConsts.DocumentNoMaxLength)]
        public string DocumentNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? Expiration { get; set; }
        [Required]
        public bool MailingList { get; set; }
    }
}