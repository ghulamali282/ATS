using Crm.Passengers;
using Crm.Clients;
using System;
using Crm.Shared;
using Volo.Abp.AutoMapper;
using Crm.Contracts;
using AutoMapper;

namespace Crm
{
    public class CrmApplicationAutoMapperProfile : Profile
    {
        public CrmApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<ContractCreateDto, Contract>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<ContractUpdateDto, Contract>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Contract, ContractDto>();

            CreateMap<ClientCreateDto, Client>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<ClientUpdateDto, Client>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Client, ClientDto>();

            CreateMap<PassengerCreateDto, Passenger>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<PassengerUpdateDto, Passenger>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<Passenger, PassengerDto>();
        }
    }
}