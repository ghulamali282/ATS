using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Crm.Clients
{
    public class Client : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid? Title { get; set; }

        [NotNull]
        public virtual string FirstName { get; set; }

        [NotNull]
        public virtual string SecondName { get; set; }

        public virtual Guid? Gender { get; set; }

        public virtual DateTime? ClientDOB { get; set; }

        public virtual Guid? AgePolicy { get; set; }

        [CanBeNull]
        public virtual string Email { get; set; }

        public virtual bool? EmailConfirmed { get; set; }

        [CanBeNull]
        public virtual string Country { get; set; }

        [CanBeNull]
        public virtual string Nacionality { get; set; }

        [CanBeNull]
        public virtual string State { get; set; }

        [CanBeNull]
        public virtual string ZipCode { get; set; }

        [CanBeNull]
        public virtual string City { get; set; }

        [CanBeNull]
        public virtual string CellPhone { get; set; }

        public virtual bool? CellPhoneConfirmed { get; set; }

        public virtual Guid? DocumentType { get; set; }

        [CanBeNull]
        public virtual string DocumentNo { get; set; }

        public virtual DateTime? IssueDate { get; set; }

        public virtual DateTime? Expiration { get; set; }

        public virtual bool MailingList { get; set; }

        public Client()
        {

        }

        public Client(Guid id, string firstName, string secondName, bool mailingList, Guid? title = null, Guid? gender = null, DateTime? clientDOB = null, Guid? agePolicy = null, string email = null, bool? emailConfirmed = null, string country = null, string nacionality = null, string state = null, string zipCode = null, string city = null, string cellPhone = null, bool? cellPhoneConfirmed = null, Guid? documentType = null, string documentNo = null, DateTime? issueDate = null, DateTime? expiration = null)
        {
            Id = id;
            Check.NotNull(firstName, nameof(firstName));
            Check.Length(firstName, nameof(firstName), ClientConsts.FirstNameMaxLength, 0);
            Check.NotNull(secondName, nameof(secondName));
            Check.Length(secondName, nameof(secondName), ClientConsts.SecondNameMaxLength, 0);
            Check.Length(email, nameof(email), ClientConsts.EmailMaxLength, 0);
            Check.Length(country, nameof(country), ClientConsts.CountryMaxLength, 0);
            Check.Length(nacionality, nameof(nacionality), ClientConsts.NacionalityMaxLength, 0);
            Check.Length(state, nameof(state), ClientConsts.StateMaxLength, 0);
            Check.Length(zipCode, nameof(zipCode), ClientConsts.ZipCodeMaxLength, 0);
            Check.Length(city, nameof(city), ClientConsts.CityMaxLength, 0);
            Check.Length(cellPhone, nameof(cellPhone), ClientConsts.CellPhoneMaxLength, 0);
            Check.Length(documentNo, nameof(documentNo), ClientConsts.DocumentNoMaxLength, 0);
            FirstName = firstName;
            SecondName = secondName;
            MailingList = mailingList;
            Title = title;
            Gender = gender;
            ClientDOB = clientDOB;
            AgePolicy = agePolicy;
            Email = email;
            EmailConfirmed = emailConfirmed;
            Country = country;
            Nacionality = nacionality;
            State = state;
            ZipCode = zipCode;
            City = city;
            CellPhone = cellPhone;
            CellPhoneConfirmed = cellPhoneConfirmed;
            DocumentType = documentType;
            DocumentNo = documentNo;
            IssueDate = issueDate;
            Expiration = expiration;
        }
    }
}