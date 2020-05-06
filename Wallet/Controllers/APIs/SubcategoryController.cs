using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using Wallet.Models.WalletModels;

namespace Wallet.Controllers.APIs
{
    public class SubcategoryController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubcategoryController()
        {
            _unitOfWork = new UnitOfWork(new WalletDbContext());
        }

        //public class SubcategoryAddRequest

        //{
        //    public string subcategoryName { get; set; }
        //    public int categoryId { get; set; }
        //    public int subcategoryColor { get; set; }
        //}

        //[HttpPost]
        //public HttpResponseMessage CreateSubcategory(SubcategoryAddRequest smth)
        //{
        //    //todo: add the color to subcategory
        //    var subcategoryName = smth.subcategoryName;
        //    var categoryId = smth.categoryId;
        //    var subcategoryColor = smth.subcategoryColor;


        //    var user = User.Identity;
        //    if (user.IsAuthenticated)
        //    {
        //        _unitOfWork.ManageCatsAndSubsRepository.AddSubcategory(subcategoryName, categoryId, user.GetUserId());
        //        return Request.CreateResponse(HttpStatusCode.OK, "Success...");
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, "Success...");
        //}

        [HttpPost]
        public void CreateSubcategory(int categoryId, string subcategoryName, string subcategoryColor)
        {
            //todo: add the color to subcategory
            var user = User.Identity;
            if (user.IsAuthenticated)
            {
                _unitOfWork.ManageCatsAndSubsRepository.AddSubcategory(subcategoryName, categoryId, user.GetUserId());
                //return Ok();
            }
            //return Ok();
        }
        [HttpPut]
        public IHttpActionResult EditSubcategory(int subcategoryId, string subcategoryName, string subcategoryColor)
        {
            //todo: add the color to subcategory
            var subcategory = _unitOfWork.ManageCatsAndSubsRepository.FindSubcategory(subcategoryId);
            var user = User.Identity;
            if (subcategory != null && user.IsAuthenticated)
            {
                _unitOfWork.ManageCatsAndSubsRepository.EditSubcategory(subcategory.Id, subcategoryName,
                    user.GetUserId());
                return Ok();
            }
            return Ok();
        }
    }
}
