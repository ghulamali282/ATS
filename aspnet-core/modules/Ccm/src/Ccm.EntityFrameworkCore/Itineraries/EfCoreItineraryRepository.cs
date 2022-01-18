using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Ccm.EntityFrameworkCore;

namespace Ccm.Itineraries
{
    public class EfCoreItineraryRepository : EfCoreRepository<CcmDbContext, Itinerary, Guid>, IItineraryRepository
    {
        public EfCoreItineraryRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<ItineraryWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Itinerary.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<ItineraryWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string itineraryNameString = null,
            string itineraryCode = null,
            string googleMapLink = null,
            int? durationMin = null,
            int? durationMax = null,
            bool? extendedItinerary = null,
            Guid? marina = null,
            string embarcationLatitude = null,
            string embarcationLongitude = null,
            string disembarkationLatitude = null,
            string disembarkationLongitude = null,
            string checkInTime = null,
            string checkOutTime = null,
            bool? transferIncluded = null,
            string video = null,
            int? requestDurationMin = null,
            int? requestDurationMax = null,
            int? optionDurationMin = null,
            int? optionDurationMax = null,
            Guid? operatorName = null,
            Guid? themes = null,
            Guid? boarding = null,
            Guid? agePolicyId = null,
            Guid? embarcationPort = null,
            Guid? disembarkationPort = null,
            Guid? cancellationPolicy = null,
            Guid? paymentPolicy = null,
            Guid? itineraryName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, itineraryNameString, itineraryCode, googleMapLink, durationMin, durationMax, extendedItinerary, marina, embarcationLatitude, embarcationLongitude, disembarkationLatitude, disembarkationLongitude, checkInTime, checkOutTime, transferIncluded, video, requestDurationMin, requestDurationMax, optionDurationMin, optionDurationMax, operatorName, themes, boarding, agePolicyId, embarcationPort, disembarkationPort, cancellationPolicy, paymentPolicy, itineraryName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ItineraryConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<ItineraryWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from itinerary in (await GetDbSetAsync())
                   join partner in (await GetDbContextAsync()).Partners on itinerary.OperatorName equals partner.Id into partners
                   from partner in partners.DefaultIfEmpty()
                   join masterData in (await GetDbContextAsync()).MasterDatas on itinerary.Themes equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()
                   join masterData1 in (await GetDbContextAsync()).MasterDatas on itinerary.Boarding equals masterData1.Id into masterDatas1
                   from masterData1 in masterDatas1.DefaultIfEmpty()
                   join agePolicy in (await GetDbContextAsync()).AgePolicies on itinerary.AgePolicyId equals agePolicy.Id into agePolicies
                   from agePolicy in agePolicies.DefaultIfEmpty()
                   join destination in (await GetDbContextAsync()).Destinations on itinerary.EmbarcationPort equals destination.Id into destinations
                   from destination in destinations.DefaultIfEmpty()
                   join destination1 in (await GetDbContextAsync()).Destinations on itinerary.DisembarkationPort equals destination1.Id into destinations1
                   from destination1 in destinations1.DefaultIfEmpty()
                   join cancellationPolicy in (await GetDbContextAsync()).CancellationPolicies on itinerary.CancellationPolicy equals cancellationPolicy.Id into cancellationPolicies
                   from cancellationPolicy in cancellationPolicies.DefaultIfEmpty()
                   join paymentPolicy in (await GetDbContextAsync()).PaymentPolicies on itinerary.PaymentPolicy equals paymentPolicy.Id into paymentPolicies
                   from paymentPolicy in paymentPolicies.DefaultIfEmpty()
                   join masterData2 in (await GetDbContextAsync()).MasterDatas on itinerary.ItineraryName equals masterData2.Id into masterDatas2
                   from masterData2 in masterDatas2.DefaultIfEmpty()

                   select new ItineraryWithNavigationProperties
                   {
                       Itinerary = itinerary,
                       Partner = partner,
                       MasterData = masterData,
                       MasterData1 = masterData1,
                       AgePolicy = agePolicy,
                       Destination = destination,
                       Destination1 = destination1,
                       CancellationPolicy = cancellationPolicy,
                       PaymentPolicy = paymentPolicy,
                       MasterData2 = masterData2
                   };
        }

        protected virtual IQueryable<ItineraryWithNavigationProperties> ApplyFilter(
            IQueryable<ItineraryWithNavigationProperties> query,
            string filterText,
            string itineraryNameString = null,
            string itineraryCode = null,
            string googleMapLink = null,
            int? durationMin = null,
            int? durationMax = null,
            bool? extendedItinerary = null,
            Guid? marina = null,
            string embarcationLatitude = null,
            string embarcationLongitude = null,
            string disembarkationLatitude = null,
            string disembarkationLongitude = null,
            string checkInTime = null,
            string checkOutTime = null,
            bool? transferIncluded = null,
            string video = null,
            int? requestDurationMin = null,
            int? requestDurationMax = null,
            int? optionDurationMin = null,
            int? optionDurationMax = null,
            Guid? operatorName = null,
            Guid? themes = null,
            Guid? boarding = null,
            Guid? agePolicyId = null,
            Guid? embarcationPort = null,
            Guid? disembarkationPort = null,
            Guid? cancellationPolicy = null,
            Guid? paymentPolicy = null,
            Guid? itineraryName = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Itinerary.ItineraryNameString.Contains(filterText) || e.Itinerary.ItineraryCode.Contains(filterText) || e.Itinerary.GoogleMapLink.Contains(filterText) || e.Itinerary.EmbarcationLatitude.Contains(filterText) || e.Itinerary.EmbarcationLongitude.Contains(filterText) || e.Itinerary.DisembarkationLatitude.Contains(filterText) || e.Itinerary.DisembarkationLongitude.Contains(filterText) || e.Itinerary.CheckInTime.Contains(filterText) || e.Itinerary.CheckOutTime.Contains(filterText) || e.Itinerary.Video.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(itineraryNameString), e => e.Itinerary.ItineraryNameString.Contains(itineraryNameString))
                    .WhereIf(!string.IsNullOrWhiteSpace(itineraryCode), e => e.Itinerary.ItineraryCode.Contains(itineraryCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(googleMapLink), e => e.Itinerary.GoogleMapLink.Contains(googleMapLink))
                    .WhereIf(durationMin.HasValue, e => e.Itinerary.Duration >= durationMin.Value)
                    .WhereIf(durationMax.HasValue, e => e.Itinerary.Duration <= durationMax.Value)
                    .WhereIf(extendedItinerary.HasValue, e => e.Itinerary.ExtendedItinerary == extendedItinerary)
                    .WhereIf(marina.HasValue, e => e.Itinerary.Marina == marina)
                    .WhereIf(!string.IsNullOrWhiteSpace(embarcationLatitude), e => e.Itinerary.EmbarcationLatitude.Contains(embarcationLatitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(embarcationLongitude), e => e.Itinerary.EmbarcationLongitude.Contains(embarcationLongitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(disembarkationLatitude), e => e.Itinerary.DisembarkationLatitude.Contains(disembarkationLatitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(disembarkationLongitude), e => e.Itinerary.DisembarkationLongitude.Contains(disembarkationLongitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(checkInTime), e => e.Itinerary.CheckInTime.Contains(checkInTime))
                    .WhereIf(!string.IsNullOrWhiteSpace(checkOutTime), e => e.Itinerary.CheckOutTime.Contains(checkOutTime))
                    .WhereIf(transferIncluded.HasValue, e => e.Itinerary.TransferIncluded == transferIncluded)
                    .WhereIf(!string.IsNullOrWhiteSpace(video), e => e.Itinerary.Video.Contains(video))
                    .WhereIf(requestDurationMin.HasValue, e => e.Itinerary.RequestDuration >= requestDurationMin.Value)
                    .WhereIf(requestDurationMax.HasValue, e => e.Itinerary.RequestDuration <= requestDurationMax.Value)
                    .WhereIf(optionDurationMin.HasValue, e => e.Itinerary.OptionDuration >= optionDurationMin.Value)
                    .WhereIf(optionDurationMax.HasValue, e => e.Itinerary.OptionDuration <= optionDurationMax.Value)
                    .WhereIf(operatorName != null && operatorName != Guid.Empty, e => e.Partner != null && e.Partner.Id == operatorName)
                    .WhereIf(themes != null && themes != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == themes)
                    .WhereIf(boarding != null && boarding != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == boarding)
                    .WhereIf(agePolicyId != null && agePolicyId != Guid.Empty, e => e.AgePolicy != null && e.AgePolicy.Id == agePolicyId)
                    .WhereIf(embarcationPort != null && embarcationPort != Guid.Empty, e => e.Destination != null && e.Destination.Id == embarcationPort)
                    .WhereIf(disembarkationPort != null && disembarkationPort != Guid.Empty, e => e.Destination != null && e.Destination.Id == disembarkationPort)
                    .WhereIf(cancellationPolicy != null && cancellationPolicy != Guid.Empty, e => e.CancellationPolicy != null && e.CancellationPolicy.Id == cancellationPolicy)
                    .WhereIf(paymentPolicy != null && paymentPolicy != Guid.Empty, e => e.PaymentPolicy != null && e.PaymentPolicy.Id == paymentPolicy)
                    .WhereIf(itineraryName != null && itineraryName != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == itineraryName);
        }

        public async Task<List<Itinerary>> GetListAsync(
            string filterText = null,
            string itineraryNameString = null,
            string itineraryCode = null,
            string googleMapLink = null,
            int? durationMin = null,
            int? durationMax = null,
            bool? extendedItinerary = null,
            Guid? marina = null,
            string embarcationLatitude = null,
            string embarcationLongitude = null,
            string disembarkationLatitude = null,
            string disembarkationLongitude = null,
            string checkInTime = null,
            string checkOutTime = null,
            bool? transferIncluded = null,
            string video = null,
            int? requestDurationMin = null,
            int? requestDurationMax = null,
            int? optionDurationMin = null,
            int? optionDurationMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, itineraryNameString, itineraryCode, googleMapLink, durationMin, durationMax, extendedItinerary, marina, embarcationLatitude, embarcationLongitude, disembarkationLatitude, disembarkationLongitude, checkInTime, checkOutTime, transferIncluded, video, requestDurationMin, requestDurationMax, optionDurationMin, optionDurationMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ItineraryConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string itineraryNameString = null,
            string itineraryCode = null,
            string googleMapLink = null,
            int? durationMin = null,
            int? durationMax = null,
            bool? extendedItinerary = null,
            Guid? marina = null,
            string embarcationLatitude = null,
            string embarcationLongitude = null,
            string disembarkationLatitude = null,
            string disembarkationLongitude = null,
            string checkInTime = null,
            string checkOutTime = null,
            bool? transferIncluded = null,
            string video = null,
            int? requestDurationMin = null,
            int? requestDurationMax = null,
            int? optionDurationMin = null,
            int? optionDurationMax = null,
            Guid? operatorName = null,
            Guid? themes = null,
            Guid? boarding = null,
            Guid? agePolicyId = null,
            Guid? embarcationPort = null,
            Guid? disembarkationPort = null,
            Guid? cancellationPolicy = null,
            Guid? paymentPolicy = null,
            Guid? itineraryName = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, itineraryNameString, itineraryCode, googleMapLink, durationMin, durationMax, extendedItinerary, marina, embarcationLatitude, embarcationLongitude, disembarkationLatitude, disembarkationLongitude, checkInTime, checkOutTime, transferIncluded, video, requestDurationMin, requestDurationMax, optionDurationMin, optionDurationMax, operatorName, themes, boarding, agePolicyId, embarcationPort, disembarkationPort, cancellationPolicy, paymentPolicy, itineraryName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Itinerary> ApplyFilter(
            IQueryable<Itinerary> query,
            string filterText,
            string itineraryNameString = null,
            string itineraryCode = null,
            string googleMapLink = null,
            int? durationMin = null,
            int? durationMax = null,
            bool? extendedItinerary = null,
            Guid? marina = null,
            string embarcationLatitude = null,
            string embarcationLongitude = null,
            string disembarkationLatitude = null,
            string disembarkationLongitude = null,
            string checkInTime = null,
            string checkOutTime = null,
            bool? transferIncluded = null,
            string video = null,
            int? requestDurationMin = null,
            int? requestDurationMax = null,
            int? optionDurationMin = null,
            int? optionDurationMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ItineraryNameString.Contains(filterText) || e.ItineraryCode.Contains(filterText) || e.GoogleMapLink.Contains(filterText) || e.EmbarcationLatitude.Contains(filterText) || e.EmbarcationLongitude.Contains(filterText) || e.DisembarkationLatitude.Contains(filterText) || e.DisembarkationLongitude.Contains(filterText) || e.CheckInTime.Contains(filterText) || e.CheckOutTime.Contains(filterText) || e.Video.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(itineraryNameString), e => e.ItineraryNameString.Contains(itineraryNameString))
                    .WhereIf(!string.IsNullOrWhiteSpace(itineraryCode), e => e.ItineraryCode.Contains(itineraryCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(googleMapLink), e => e.GoogleMapLink.Contains(googleMapLink))
                    .WhereIf(durationMin.HasValue, e => e.Duration >= durationMin.Value)
                    .WhereIf(durationMax.HasValue, e => e.Duration <= durationMax.Value)
                    .WhereIf(extendedItinerary.HasValue, e => e.ExtendedItinerary == extendedItinerary)
                    .WhereIf(marina.HasValue, e => e.Marina == marina)
                    .WhereIf(!string.IsNullOrWhiteSpace(embarcationLatitude), e => e.EmbarcationLatitude.Contains(embarcationLatitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(embarcationLongitude), e => e.EmbarcationLongitude.Contains(embarcationLongitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(disembarkationLatitude), e => e.DisembarkationLatitude.Contains(disembarkationLatitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(disembarkationLongitude), e => e.DisembarkationLongitude.Contains(disembarkationLongitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(checkInTime), e => e.CheckInTime.Contains(checkInTime))
                    .WhereIf(!string.IsNullOrWhiteSpace(checkOutTime), e => e.CheckOutTime.Contains(checkOutTime))
                    .WhereIf(transferIncluded.HasValue, e => e.TransferIncluded == transferIncluded)
                    .WhereIf(!string.IsNullOrWhiteSpace(video), e => e.Video.Contains(video))
                    .WhereIf(requestDurationMin.HasValue, e => e.RequestDuration >= requestDurationMin.Value)
                    .WhereIf(requestDurationMax.HasValue, e => e.RequestDuration <= requestDurationMax.Value)
                    .WhereIf(optionDurationMin.HasValue, e => e.OptionDuration >= optionDurationMin.Value)
                    .WhereIf(optionDurationMax.HasValue, e => e.OptionDuration <= optionDurationMax.Value);
        }
    }
}