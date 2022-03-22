using AutoMapper;
using LFR.Core.Dtos;
using LFR.Core.ViewModel;
using LFR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Infrastructure.AutoMapper
{
   public class AutoMapperProfile : Profile
    {
 public AutoMapperProfile()
 {
            CreateMap<User, UserViewModel>().ForMember(x => x.UserType, x => x.MapFrom(x => x.UserType.ToString()));
            CreateMap<CreateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<User, UpdateUserDto>().ForMember(x => x.Image, x => x.Ignore());


            CreateMap<Category, CategoryViewModel>().ForMember(x => x.CategoryType, x => x.MapFrom(x => x.CategoryType.ToString())); 
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();
            
            CreateMap<LawyerCharge, LawyerChargeViewModel>().ForMember(x => x.CurrencyType, x => x.MapFrom(x => x.CurrencyType.ToString()));
            CreateMap<CreateLawyerChargeDto, LawyerCharge>();
            CreateMap<UpdateLawyerChargeDto, LawyerCharge>();
            CreateMap<LawyerCharge, UpdateLawyerChargeDto>();

            CreateMap<Contract, ContractViewModel>();
            CreateMap<CreateContractDto, Contract>().ForMember(x => x.LawyerCharge, x => x.Ignore()).ForMember(x => x.ImageUrl, x => x.Ignore()); 
            CreateMap<UpdateContractDto, Contract>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<Contract, UpdateContractDto>().ForMember(x => x.Image, x => x.Ignore());

            CreateMap<CourtFee, CourtFeeViewModel>().ForMember(x => x.CurrencyType, x => x.MapFrom(x => x.CurrencyType.ToString()));
            CreateMap<CreateCourtFeeDto, CourtFee>();
            CreateMap<UpdateCourtFeeDto, CourtFee>();
            CreateMap<CourtFee, UpdateCourtFeeDto>();

            CreateMap<Session, SessionViewModel>();
            CreateMap<CreateSessionDto, Session>();
            CreateMap<UpdateSessionDto, Session>();
            CreateMap<Session, UpdateSessionDto>();

            CreateMap<CourtRequest, CourtRequestViewModel>();
            CreateMap<CreateCourtRequestDto, CourtRequest>().ForMember(x => x.ImageUrl, x => x.Ignore()); 
            CreateMap<UpdateCourtRequestDto, CourtRequest>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<CourtRequest, UpdateCourtRequestDto>().ForMember(x => x.Image, x => x.Ignore());

            CreateMap<Issue, IssueViewModel>().ForMember(x => x.CourtType, x => x.MapFrom(x => x.CourtType.ToString()));
            CreateMap<CreateIssueDto, Issue>().ForMember(x => x.IssueClient, x => x.Ignore());
            CreateMap<UpdateIssueDto, Issue>();
            CreateMap<Issue, UpdateIssueDto>();





        }


    }
}
