﻿using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, GetListModelListResponse>()
            .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
            .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
            .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
            .ReverseMap();
        CreateMap<Model, GetListByDynamicModelListResponse>()
            .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
            .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
            .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
            .ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListModelListResponse>>().ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListResponse>>().ReverseMap();
    }
}
