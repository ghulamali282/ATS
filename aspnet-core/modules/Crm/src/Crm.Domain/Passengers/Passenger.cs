using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Crm.Passengers
{
    public class Passenger : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid Reservation { get; set; }

        public virtual Guid ReservationDetail { get; set; }

        public virtual bool ReservationHolder { get; set; }

        public virtual Guid? Title { get; set; }

        [NotNull]
        public virtual string FirstName { get; set; }

        [NotNull]
        public virtual string LastName { get; set; }

        [CanBeNull]
        public virtual string Country { get; set; }

        public virtual Guid AgePolicyDetail { get; set; }

        public virtual DateTime? PassengerDOB { get; set; }

        public virtual Guid? DocumentType { get; set; }

        [CanBeNull]
        public virtual string DocumentNo { get; set; }

        public virtual DateTime? IssueDate { get; set; }

        public virtual DateTime? Expiration { get; set; }

        [CanBeNull]
        public virtual string PassengerNote { get; set; }

        public virtual int ClientNo { get; set; }

        public virtual Guid Reduction { get; set; }

        public Passenger()
        {

        }

        public Passenger(Guid id, Guid reservation, Guid reservationDetail, bool reservationHolder, string firstName, string lastName, Guid agePolicyDetail, int clientNo, Guid reduction, Guid? title = null, string country = null, DateTime? passengerDOB = null, Guid? documentType = null, string documentNo = null, DateTime? issueDate = null, DateTime? expiration = null, string passengerNote = null)
        {
            Id = id;
            Check.NotNull(firstName, nameof(firstName));
            Check.Length(firstName, nameof(firstName), PassengerConsts.FirstNameMaxLength, 0);
            Check.NotNull(lastName, nameof(lastName));
            Check.Length(lastName, nameof(lastName), PassengerConsts.LastNameMaxLength, 0);
            Check.Length(country, nameof(country), PassengerConsts.CountryMaxLength, 0);
            Check.Length(documentNo, nameof(documentNo), PassengerConsts.DocumentNoMaxLength, 0);
            Reservation = reservation;
            ReservationDetail = reservationDetail;
            ReservationHolder = reservationHolder;
            FirstName = firstName;
            LastName = lastName;
            AgePolicyDetail = agePolicyDetail;
            ClientNo = clientNo;
            Reduction = reduction;
            Title = title;
            Country = country;
            PassengerDOB = passengerDOB;
            DocumentType = documentType;
            DocumentNo = documentNo;
            IssueDate = issueDate;
            Expiration = expiration;
            PassengerNote = passengerNote;
        }
    }
}