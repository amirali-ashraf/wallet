using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using IdentitySample.Models;
using Wallet.Models.WalletModels;
using System.Data.Entity;

using AutoMapper;
using Wallet.Models.DTOs;


namespace Wallet.Controllers.APIs
{
    public class ReportsByTransactionDateController : ApiController
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public ReportsByTransactionDateController()
        {            
            _unitOfWork = new UnitOfWork(new WalletDbContext());
        }

        public static DateTime DateConvertorFromString(string date)
        {
            return DateTime.Parse(date);
        }
        
               
        [HttpGet]
        public IEnumerable<ReportListDto> GetReport(string from, string to)
        {
            return _unitOfWork.Report
                .GetReport(DateConvertorFromString(from), DateConvertorFromString(to))
                .Select(Mapper.Map<Transaction, ReportListDto>);
        }


        [HttpGet]
        public IEnumerable<ReportListDto> GetReport(string from, string to, int type)
        {

            return _unitOfWork.Report
                .GetReport(DateConvertorFromString(from), DateConvertorFromString(to), type)
                .Select(Mapper.Map<Transaction, ReportListDto>);
        }


        [HttpGet]
        public IEnumerable<ReportListDto> GetReport(string from, string to, int type, int categoryId)
        {

            return _unitOfWork.Report
                .GetReport(DateConvertorFromString(from), DateConvertorFromString(to), type, categoryId)
                .Select(Mapper.Map<Transaction, ReportListDto>);
        }

        [HttpGet]
        public IEnumerable<ReportListDto> GetReport(string from, string to, int type, int categoryId, int subcategoryId)
        {
            
            return _unitOfWork.Report
                .GetReport(DateConvertorFromString(from), DateConvertorFromString(to), type,categoryId,subcategoryId)
                .Select(Mapper.Map<Transaction, ReportListDto>);
        }        
    }
}
