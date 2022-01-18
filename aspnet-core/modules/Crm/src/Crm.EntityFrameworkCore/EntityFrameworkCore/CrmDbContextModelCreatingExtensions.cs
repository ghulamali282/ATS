using Crm.Passengers;
using Crm.Clients;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Crm.Contracts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Crm.EntityFrameworkCore
{
    public static class CrmDbContextModelCreatingExtensions
    {
        public static void ConfigureCrm(
            this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(CrmDbProperties.DbTablePrefix + "Questions", CrmDbProperties.DbSchema);

                b.ConfigureByConvention();

                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */

            builder.Entity<Contract>(b =>
    {
        b.ToTable(CrmDbProperties.DbTablePrefix + "Contracts", CrmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Contract.TenantId));
        b.Property(x => x.OperatorName).HasColumnName(nameof(Contract.OperatorName)).IsRequired();
        b.Property(x => x.Season).HasColumnName(nameof(Contract.Season)).IsRequired();
        b.Property(x => x.IsEnabledAgent).HasColumnName(nameof(Contract.IsEnabledAgent)).IsRequired();
        b.Property(x => x.IsEnabledOperator).HasColumnName(nameof(Contract.IsEnabledOperator)).IsRequired();
    });
            builder.Entity<Client>(b =>
    {
        b.ToTable(CrmDbProperties.DbTablePrefix + "Clients", CrmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Client.TenantId));
        b.Property(x => x.Title).HasColumnName(nameof(Client.Title));
        b.Property(x => x.FirstName).HasColumnName(nameof(Client.FirstName)).IsRequired().HasMaxLength(ClientConsts.FirstNameMaxLength);
        b.Property(x => x.SecondName).HasColumnName(nameof(Client.SecondName)).IsRequired().HasMaxLength(ClientConsts.SecondNameMaxLength);
        b.Property(x => x.Gender).HasColumnName(nameof(Client.Gender));
        b.Property(x => x.ClientDOB).HasColumnName(nameof(Client.ClientDOB));
        b.Property(x => x.AgePolicy).HasColumnName(nameof(Client.AgePolicy));
        b.Property(x => x.Email).HasColumnName(nameof(Client.Email)).HasMaxLength(ClientConsts.EmailMaxLength);
        b.Property(x => x.EmailConfirmed).HasColumnName(nameof(Client.EmailConfirmed));
        b.Property(x => x.Country).HasColumnName(nameof(Client.Country)).HasMaxLength(ClientConsts.CountryMaxLength);
        b.Property(x => x.Nacionality).HasColumnName(nameof(Client.Nacionality)).HasMaxLength(ClientConsts.NacionalityMaxLength);
        b.Property(x => x.State).HasColumnName(nameof(Client.State)).HasMaxLength(ClientConsts.StateMaxLength);
        b.Property(x => x.ZipCode).HasColumnName(nameof(Client.ZipCode)).HasMaxLength(ClientConsts.ZipCodeMaxLength);
        b.Property(x => x.City).HasColumnName(nameof(Client.City)).HasMaxLength(ClientConsts.CityMaxLength);
        b.Property(x => x.CellPhone).HasColumnName(nameof(Client.CellPhone)).HasMaxLength(ClientConsts.CellPhoneMaxLength);
        b.Property(x => x.CellPhoneConfirmed).HasColumnName(nameof(Client.CellPhoneConfirmed));
        b.Property(x => x.DocumentType).HasColumnName(nameof(Client.DocumentType));
        b.Property(x => x.DocumentNo).HasColumnName(nameof(Client.DocumentNo)).HasMaxLength(ClientConsts.DocumentNoMaxLength);
        b.Property(x => x.IssueDate).HasColumnName(nameof(Client.IssueDate));
        b.Property(x => x.Expiration).HasColumnName(nameof(Client.Expiration));
        b.Property(x => x.MailingList).HasColumnName(nameof(Client.MailingList)).IsRequired();
    });
            builder.Entity<Passenger>(b =>
    {
        b.ToTable(CrmDbProperties.DbTablePrefix + "Passengers", CrmDbProperties.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.TenantId).HasColumnName(nameof(Passenger.TenantId));
        b.Property(x => x.Reservation).HasColumnName(nameof(Passenger.Reservation)).IsRequired();
        b.Property(x => x.ReservationDetail).HasColumnName(nameof(Passenger.ReservationDetail)).IsRequired();
        b.Property(x => x.ReservationHolder).HasColumnName(nameof(Passenger.ReservationHolder)).IsRequired();
        b.Property(x => x.Title).HasColumnName(nameof(Passenger.Title));
        b.Property(x => x.FirstName).HasColumnName(nameof(Passenger.FirstName)).IsRequired().HasMaxLength(PassengerConsts.FirstNameMaxLength);
        b.Property(x => x.LastName).HasColumnName(nameof(Passenger.LastName)).IsRequired().HasMaxLength(PassengerConsts.LastNameMaxLength);
        b.Property(x => x.Country).HasColumnName(nameof(Passenger.Country)).HasMaxLength(PassengerConsts.CountryMaxLength);
        b.Property(x => x.AgePolicyDetail).HasColumnName(nameof(Passenger.AgePolicyDetail)).IsRequired();
        b.Property(x => x.PassengerDOB).HasColumnName(nameof(Passenger.PassengerDOB));
        b.Property(x => x.DocumentType).HasColumnName(nameof(Passenger.DocumentType));
        b.Property(x => x.DocumentNo).HasColumnName(nameof(Passenger.DocumentNo)).HasMaxLength(PassengerConsts.DocumentNoMaxLength);
        b.Property(x => x.IssueDate).HasColumnName(nameof(Passenger.IssueDate));
        b.Property(x => x.Expiration).HasColumnName(nameof(Passenger.Expiration));
        b.Property(x => x.PassengerNote).HasColumnName(nameof(Passenger.PassengerNote));
        b.Property(x => x.ClientNo).HasColumnName(nameof(Passenger.ClientNo)).IsRequired();
        b.Property(x => x.Reduction).HasColumnName(nameof(Passenger.Reduction)).IsRequired();
    });
        }
    }
}