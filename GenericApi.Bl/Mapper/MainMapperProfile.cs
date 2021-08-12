using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericApi.Bl.Mapper
{
    public class MainMapperProfile : Profile
    {
        public MainMapperProfile()
        {
            #region Document

            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentDto, Document>();

            #endregion

            #region User

            CreateMap<User, UserDto>()
                .ForMember(dto => dto.PhotoFileName, config => config.MapFrom(entity => entity.Photo.FileName))
                .ForMember(dto => dto.Signature, config => config.MapFrom(entity => $"{entity.Name.FirstOrDefault()}{entity.LastName.FirstOrDefault()}"))
                .ForMember(dto => dto.FullName, config => config.MapFrom(entity => $"{entity.Name} {entity.LastName}"))
                .ForMember(dto => dto.Password, config => config.Ignore());
            CreateMap<UserDto, User>();

            #endregion

            #region WorkShop

            CreateMap<WorkShop, WorkShopDto>();
            CreateMap<WorkShopDto, WorkShop>();

            #endregion

            #region WorkShopMember

            CreateMap<WorkShopMember, WorkShopMemberDto>();
            CreateMap<WorkShopMemberDto, WorkShopMember>();

            #endregion

            #region WorkShopDay

            CreateMap<WorkShopDay, WorkShopDayDto>();
            CreateMap<WorkShopDayDto, WorkShopDay>();

            #endregion

        }
    }
}
