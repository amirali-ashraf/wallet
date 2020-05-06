using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wallet.Models;
using Wallet.Models.WalletModels;
using Wallet.Models.DBViewModels;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using Microsoft.AspNet.Identity;
using Wallet;

namespace WalletIdentity.Controllers
{
    public class ManageCatsAndSubsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManageCatsAndSubsController()
        {
            _unitOfWork = new UnitOfWork(new WalletDbContext());
        }

        [Authorize]
        public ActionResult CategoriesManagement()
        {
            
            var user = User.Identity;
            var userId = user.GetUserId();
            var CMVM = new CategoriesManagementViewModel
            {
                ExpenditureCategories =
                    _unitOfWork.ManageCatsAndSubsRepository.GetCategories().Where(x => x.TypeOfCategory == Category.Type.Expenditure && x.UserId == user.GetUserId()).ToList(),

                IncomeCategories =
                    _unitOfWork.ManageCatsAndSubsRepository.GetCategories().Where(x => x.TypeOfCategory == Category.Type.Income && x.UserId == user.GetUserId()).ToList(),

                Subcategories =
                    _unitOfWork.ManageCatsAndSubsRepository.GetSubcategories().Where(s=>s.UserId== userId).ToList()
            };


            
            return View(CMVM);
        }
        public ActionResult GroupsExpenditureList()
        {
            ViewBag.SubCats = _unitOfWork.ManageCatsAndSubsRepository.GetSubcategories();
            return View();
        }

        [HttpPost]
        [Authorize]
        public void CreateSubcategory(int categoryId, string subcategoryName, string subcategoryColor)
        {
            //todo: add the color to subcategory
            var user = User.Identity;
            if (user.IsAuthenticated)
            {
                _unitOfWork.ManageCatsAndSubsRepository.AddSubcategory(subcategoryName, categoryId, user.GetUserId());
            }

            _unitOfWork.Complete();
        }


        [HttpPost]
        [Authorize]
        public void EditSubcategory(int subcategoryId, string subcategoryNewName, string subcategoryNewColor)
        {
            //todo: add the color to the subcategory
            //todo check the null problem and how to tell to return the result to the user
            var user = User.Identity;
            var selectedSubcategory = _unitOfWork.ManageCatsAndSubsRepository.FindSubcategory(subcategoryId);
            if (selectedSubcategory.UserId == user.GetUserId())
            {
                _unitOfWork.ManageCatsAndSubsRepository.EditSubcategory(subcategoryId, subcategoryNewName, user.GetUserId());            
            }
            _unitOfWork.Complete();
        }


        [HttpDelete]
        [Authorize]
        public void DeleteSubcategory(int subcategoryId)
        {
            var user = User.Identity;
            var subcategoryToDelete = _unitOfWork.ManageCatsAndSubsRepository.FindSubcategory(subcategoryId);
            if (user.GetUserId() == subcategoryToDelete.UserId)
            {
                _unitOfWork.ManageCatsAndSubsRepository.RemoveSubcategory(subcategoryId);
            }

            _unitOfWork.Complete();
        }


        [HttpPost]
        [Authorize]
        public void CreateCategory(int typeId, string categoryName, string categoryColor)
        {
            //todo: add color to the category
            var user = User.Identity;
            _unitOfWork.ManageCatsAndSubsRepository.AddCategory(categoryName, typeId, user.GetUserId());

            _unitOfWork.Complete();
        }

        [HttpPut]
        public void EditCategory(int categoryId, string categoryNewName, string categoryNewColor)
        {
            //todo: add the color to the subcategory
            //todo check the null problem and how to tell to return the result to the user
            var user = User.Identity;
            var selectedCategory = _unitOfWork.ManageCatsAndSubsRepository.FindCategory(categoryId);
            if (selectedCategory.UserId == user.GetUserId())
            {
                _unitOfWork.ManageCatsAndSubsRepository.EditCategory(categoryId, categoryNewName, user.GetUserId());
                _unitOfWork.Complete();

            }
        }


        public void DeleteCategory(int categoryId)
        {
            var user = User.Identity;
            var selectedCategory = _unitOfWork.ManageCatsAndSubsRepository.FindCategory(categoryId);
            if (selectedCategory.UserId == user.GetUserId())
            {
                _unitOfWork.ManageCatsAndSubsRepository.RemoveCategory(categoryId);
            }
            _unitOfWork.Complete();

        }
        ////Group Settings Are Available Here
        //public ActionResult AddGroup()
        //{
        //    return View();
        //}
        //public ActionResult DeleteGroup()
        //{
        //    return View();
        //}
        //public ActionResult EditGroup()
        //{
        //    return View();
        //}

        //// Sub-Group Settings Are Available Here
        //public ActionResult AddSubgroup()
        //{
        //    return View();
        //}

        //public ActionResult DeleteSubgroup()
        //{
        //    return View();
        //}

        //public ActionResult EditSubgroup()
        //{
        //    return View();
        //}


    }
}