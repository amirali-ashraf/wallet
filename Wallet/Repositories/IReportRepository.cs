using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;
using Wallet.Models.WalletModels;

namespace Wallet.Repositories
{
    public interface IReportRepository
    {
        /// <summary>
        /// returns alll the data without any filtering
        /// </summary>
        /// <returns></returns>
        IEnumerable<Transaction> GetReport();

        /// <summary>
        /// This Report filter the data by receiving two dates
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        IEnumerable<Transaction> GetReport(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// This Report filter the data by receiving two dates and the type of the categories
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<Transaction> GetReport(DateTime fromDate, DateTime toDate, int type);

        /// <summary>
        /// Two Dates, type and the category Id to filter the data
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="type"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IEnumerable<Transaction> GetReport(DateTime fromDate, DateTime toDate, int type, int categoryId);

        /// <summary>
        /// Two dates, type, categoryId and the subcategoryId to filter the data
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="type"></param>
        /// <param name="categoryId"></param>
        /// <param name="subcategoryId"></param>
        /// <returns></returns>
        IEnumerable<Transaction> GetReport(DateTime fromDate, DateTime toDate, int type, int categoryId,
            int subcategoryId);


    }
}