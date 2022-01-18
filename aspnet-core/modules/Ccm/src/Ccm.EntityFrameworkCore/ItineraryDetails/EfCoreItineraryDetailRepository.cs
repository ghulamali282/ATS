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

namespace Ccm.ItineraryDetails
{
    public class EfCoreItineraryDetailRepository : EfCoreRepository<CcmDbContext, ItineraryDetail, Guid>, IItineraryDetailRepository
    {
        public EfCoreItineraryDetailRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ItineraryDetail>> GetListAsync(
            string filterText = null,
            Guid? itinerary = null,
            Guid? name = null,
            int? dayMin = null,
            int? dayMax = null,
            string ports = null,
            string alternativePorts = null,
            bool? welcomeDrink = null,
            bool? welcomeSnack = null,
            bool? breakfast = null,
            bool? brunch = null,
            bool? lunch = null,
            bool? afternoonSnack = null,
            bool? dinner = null,
            bool? captainDinner = null,
            bool? liveMusic = null,
            bool? wineTasting = null,
            bool? overnightOnAnchor = null,
            bool? overnightAtMarina = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, itinerary, name, dayMin, dayMax, ports, alternativePorts, welcomeDrink, welcomeSnack, breakfast, brunch, lunch, afternoonSnack, dinner, captainDinner, liveMusic, wineTasting, overnightOnAnchor, overnightAtMarina);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ItineraryDetailConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? itinerary = null,
            Guid? name = null,
            int? dayMin = null,
            int? dayMax = null,
            string ports = null,
            string alternativePorts = null,
            bool? welcomeDrink = null,
            bool? welcomeSnack = null,
            bool? breakfast = null,
            bool? brunch = null,
            bool? lunch = null,
            bool? afternoonSnack = null,
            bool? dinner = null,
            bool? captainDinner = null,
            bool? liveMusic = null,
            bool? wineTasting = null,
            bool? overnightOnAnchor = null,
            bool? overnightAtMarina = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, itinerary, name, dayMin, dayMax, ports, alternativePorts, welcomeDrink, welcomeSnack, breakfast, brunch, lunch, afternoonSnack, dinner, captainDinner, liveMusic, wineTasting, overnightOnAnchor, overnightAtMarina);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ItineraryDetail> ApplyFilter(
            IQueryable<ItineraryDetail> query,
            string filterText,
            Guid? itinerary = null,
            Guid? name = null,
            int? dayMin = null,
            int? dayMax = null,
            string ports = null,
            string alternativePorts = null,
            bool? welcomeDrink = null,
            bool? welcomeSnack = null,
            bool? breakfast = null,
            bool? brunch = null,
            bool? lunch = null,
            bool? afternoonSnack = null,
            bool? dinner = null,
            bool? captainDinner = null,
            bool? liveMusic = null,
            bool? wineTasting = null,
            bool? overnightOnAnchor = null,
            bool? overnightAtMarina = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Ports.Contains(filterText) || e.AlternativePorts.Contains(filterText))
                    .WhereIf(itinerary.HasValue, e => e.Itinerary == itinerary)
                    .WhereIf(name.HasValue, e => e.Name == name)
                    .WhereIf(dayMin.HasValue, e => e.Day >= dayMin.Value)
                    .WhereIf(dayMax.HasValue, e => e.Day <= dayMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(ports), e => e.Ports.Contains(ports))
                    .WhereIf(!string.IsNullOrWhiteSpace(alternativePorts), e => e.AlternativePorts.Contains(alternativePorts))
                    .WhereIf(welcomeDrink.HasValue, e => e.WelcomeDrink == welcomeDrink)
                    .WhereIf(welcomeSnack.HasValue, e => e.WelcomeSnack == welcomeSnack)
                    .WhereIf(breakfast.HasValue, e => e.Breakfast == breakfast)
                    .WhereIf(brunch.HasValue, e => e.Brunch == brunch)
                    .WhereIf(lunch.HasValue, e => e.Lunch == lunch)
                    .WhereIf(afternoonSnack.HasValue, e => e.AfternoonSnack == afternoonSnack)
                    .WhereIf(dinner.HasValue, e => e.Dinner == dinner)
                    .WhereIf(captainDinner.HasValue, e => e.CaptainDinner == captainDinner)
                    .WhereIf(liveMusic.HasValue, e => e.LiveMusic == liveMusic)
                    .WhereIf(wineTasting.HasValue, e => e.WineTasting == wineTasting)
                    .WhereIf(overnightOnAnchor.HasValue, e => e.OvernightOnAnchor == overnightOnAnchor)
                    .WhereIf(overnightAtMarina.HasValue, e => e.OvernightAtMarina == overnightAtMarina);
        }
    }
}