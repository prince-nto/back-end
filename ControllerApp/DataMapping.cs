using AutoMapper;
using ControllerApp.Domains.Users;
using ControllerApp.Dto;
using ControllerApp.Dto.Users;
using ControllerApp.TempModels.Users;
using System;
using TenderSystem.Models;

namespace ControllerApp
{
    public static class DataMapping
    {
        private static IMapper _mapper;

        public static IMapper CreateMappers()
        {
            if (_mapper != null) return _mapper;

            var config = new MapperConfiguration(cfg =>
            {
                UserMappings(cfg);
                TenderBidSubmissioMappings(cfg);
                StateOrganMappings(cfg);
                ProductMappings(cfg);
                CompanyMappings(cfg);
            });

            _mapper = config.CreateMapper();

            return _mapper;
        }

        private static void CompanyMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CompanyDto, Company>()
                .ReverseMap()
                .ForMember(dest => dest.ContactPersons, opt => opt.Ignore());

            cfg.CreateMap<CompanyUserDto, CompanyUser>()
                .ReverseMap()
                .ForMember(dest => dest.Company, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }

        private static void ProductMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ProductDto, Product>()
                .ReverseMap();
        }

        private static void StateOrganMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<StateOrganDto, StateOrgan>()
                .ReverseMap();
        }

        private static void TenderBidSubmissioMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Tender, TenderDto>()
                .ReverseMap()
                .ForMember(dest => dest.CloseDate, opt => opt.Ignore())
                .ForMember(dest => dest.OpenDate, opt => opt.Ignore());

            cfg.CreateMap<TenderBidSubmission, TenderBidSubmissionDto>()
                .ForMember(dest => dest.SumittedBy, opt => opt.Ignore())
                .ForMember(dest => dest.TenderBidSubmissionProducts, opt => opt.Ignore())
                .ForMember(dest => dest.DateSubmitted, opt => opt.Ignore());


            cfg.CreateMap<TenderBidSubmissionProduct, TenderBidSubmissionProductDto>()
                .ReverseMap()
                .ForMember(dest => dest.TenderBidSubmission, opt => opt.Ignore());
        }

        private static void UserMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserTypeDto, UserType>()
                .ReverseMap();

            cfg.CreateMap<UserDto, User>()
                .ForMember(db => db.DateUserWasAdded, opt => opt.Ignore())
                .ForMember(db => db.UserType, opt => opt.Ignore())
                .ReverseMap()
                 .ForMember(db => db.UserType, opt => opt.MapFrom(d => d.UserType));
        }
    }
}
