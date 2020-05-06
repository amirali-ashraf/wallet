using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Wallet.Models.DTOs;
using Wallet.Models.WalletModels;

namespace IdentitySample
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Transaction, ReportListDto>();
            Mapper.CreateMap<ReportListDto, Transaction>();
        }
    }
}