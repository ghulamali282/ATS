using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Crm.EntityFrameworkCore;

namespace Crm.Clients
{
    public class EfCoreClientRepository : EfCoreRepository<CrmDbContext, Client, Guid>, IClientRepository
    {
        public EfCoreClientRepository(IDbContextProvider<CrmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Client>> GetListAsync(
            string filterText = null,
            Guid? title = null,
            string firstName = null,
            string secondName = null,
            Guid? gender = null,
            DateTime? clientDOBMin = null,
            DateTime? clientDOBMax = null,
            Guid? agePolicy = null,
            string email = null,
            bool? emailConfirmed = null,
            string country = null,
            string nacionality = null,
            string state = null,
            string zipCode = null,
            string city = null,
            string cellPhone = null,
            bool? cellPhoneConfirmed = null,
            Guid? documentType = null,
            string documentNo = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expirationMin = null,
            DateTime? expirationMax = null,
            bool? mailingList = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, title, firstName, secondName, gender, clientDOBMin, clientDOBMax, agePolicy, email, emailConfirmed, country, nacionality, state, zipCode, city, cellPhone, cellPhoneConfirmed, documentType, documentNo, issueDateMin, issueDateMax, expirationMin, expirationMax, mailingList);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ClientConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? title = null,
            string firstName = null,
            string secondName = null,
            Guid? gender = null,
            DateTime? clientDOBMin = null,
            DateTime? clientDOBMax = null,
            Guid? agePolicy = null,
            string email = null,
            bool? emailConfirmed = null,
            string country = null,
            string nacionality = null,
            string state = null,
            string zipCode = null,
            string city = null,
            string cellPhone = null,
            bool? cellPhoneConfirmed = null,
            Guid? documentType = null,
            string documentNo = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expirationMin = null,
            DateTime? expirationMax = null,
            bool? mailingList = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, title, firstName, secondName, gender, clientDOBMin, clientDOBMax, agePolicy, email, emailConfirmed, country, nacionality, state, zipCode, city, cellPhone, cellPhoneConfirmed, documentType, documentNo, issueDateMin, issueDateMax, expirationMin, expirationMax, mailingList);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Client> ApplyFilter(
            IQueryable<Client> query,
            string filterText,
            Guid? title = null,
            string firstName = null,
            string secondName = null,
            Guid? gender = null,
            DateTime? clientDOBMin = null,
            DateTime? clientDOBMax = null,
            Guid? agePolicy = null,
            string email = null,
            bool? emailConfirmed = null,
            string country = null,
            string nacionality = null,
            string state = null,
            string zipCode = null,
            string city = null,
            string cellPhone = null,
            bool? cellPhoneConfirmed = null,
            Guid? documentType = null,
            string documentNo = null,
            DateTime? issueDateMin = null,
            DateTime? issueDateMax = null,
            DateTime? expirationMin = null,
            DateTime? expirationMax = null,
            bool? mailingList = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.FirstName.Contains(filterText) || e.SecondName.Contains(filterText) || e.Email.Contains(filterText) || e.Country.Contains(filterText) || e.Nacionality.Contains(filterText) || e.State.Contains(filterText) || e.ZipCode.Contains(filterText) || e.City.Contains(filterText) || e.CellPhone.Contains(filterText) || e.DocumentNo.Contains(filterText))
                    .WhereIf(title.HasValue, e => e.Title == title)
                    .WhereIf(!string.IsNullOrWhiteSpace(firstName), e => e.FirstName.Contains(firstName))
                    .WhereIf(!string.IsNullOrWhiteSpace(secondName), e => e.SecondName.Contains(secondName))
                    .WhereIf(gender.HasValue, e => e.Gender == gender)
                    .WhereIf(clientDOBMin.HasValue, e => e.ClientDOB >= clientDOBMin.Value)
                    .WhereIf(clientDOBMax.HasValue, e => e.ClientDOB <= clientDOBMax.Value)
                    .WhereIf(agePolicy.HasValue, e => e.AgePolicy == agePolicy)
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.Contains(email))
                    .WhereIf(emailConfirmed.HasValue, e => e.EmailConfirmed == emailConfirmed)
                    .WhereIf(!string.IsNullOrWhiteSpace(country), e => e.Country.Contains(country))
                    .WhereIf(!string.IsNullOrWhiteSpace(nacionality), e => e.Nacionality.Contains(nacionality))
                    .WhereIf(!string.IsNullOrWhiteSpace(state), e => e.State.Contains(state))
                    .WhereIf(!string.IsNullOrWhiteSpace(zipCode), e => e.ZipCode.Contains(zipCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(city), e => e.City.Contains(city))
                    .WhereIf(!string.IsNullOrWhiteSpace(cellPhone), e => e.CellPhone.Contains(cellPhone))
                    .WhereIf(cellPhoneConfirmed.HasValue, e => e.CellPhoneConfirmed == cellPhoneConfirmed)
                    .WhereIf(documentType.HasValue, e => e.DocumentType == documentType)
                    .WhereIf(!string.IsNullOrWhiteSpace(documentNo), e => e.DocumentNo.Contains(documentNo))
                    .WhereIf(issueDateMin.HasValue, e => e.IssueDate >= issueDateMin.Value)
                    .WhereIf(issueDateMax.HasValue, e => e.IssueDate <= issueDateMax.Value)
                    .WhereIf(expirationMin.HasValue, e => e.Expiration >= expirationMin.Value)
                    .WhereIf(expirationMax.HasValue, e => e.Expiration <= expirationMax.Value)
                    .WhereIf(mailingList.HasValue, e => e.MailingList == mailingList);
        }
    }
}