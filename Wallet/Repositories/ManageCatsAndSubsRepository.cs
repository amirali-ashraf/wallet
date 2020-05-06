using System;
using System.Collections.Generic;
using System.Linq;
using IdentitySample.Models;
using Wallet.Models.WalletModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Security;

namespace Wallet.Repositories
{
    class ManageCatsAndSubsRepository : IManageCatsAndSubsRepository
    {
        private readonly WalletDbContext _context;

        public ManageCatsAndSubsRepository(WalletDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            //todo use a lambda expression to add some conditions
            return _context.Categories.ToList();
        }

        public IEnumerable<Subcategory> GetSubcategories()
        {
            //todo use a lambda expression to add some conditions
            return _context.Subcategories.ToList();
        }

        public void AddCategory(string categoryName, int type, string userId)
        {
            Category category = new Category()
            {
                Name = categoryName,
                TypeOfCategory = (Category.Type)type,
                UserId = userId
        };                    
            _context.Categories.Add(category);
        }

        public void AddSubcategory(string subcategoryName, int categoryId, string userId)
        {
            Subcategory subcategory = new Subcategory();
            subcategory.Name = subcategoryName;
            subcategory.CategoryId = categoryId;
            subcategory.UserId = userId;
            _context.Subcategories.Add(subcategory);
        }

        public Category FindCategory(int categoryId)
        {
            return _context.Categories.Find(categoryId);            
        }

        public void RemoveCategory(int categoryId)
        {
            var categoryToRemove = FindCategory(categoryId);
            _context.Categories.Remove(categoryToRemove);
        }

        public Subcategory FindSubcategory(int subcategoryId)
        {
            return _context.Subcategories.Find(subcategoryId);
        }

        public void RemoveSubcategory(int subcategoryId)
        {
            var subcategoryToRemove = FindSubcategory(subcategoryId);
            _context.Subcategories.Remove(subcategoryToRemove);
        }

        public void EditCategory(int categoryId, string categoryNewName, string userId)
        {
            var selectedCategory = _context.Categories.FirstOrDefault(c => c.Id == categoryId && c.UserId == userId);
            if (selectedCategory != null)
            {
                selectedCategory.Name = categoryNewName;
                //todo: add the color to the category item
            }
        }

        public void EditSubcategory(int subcategoryId, string subcategoryNewName, string userId)
        {

            //todo: add the color to the subcategory items
            var selectedSubcategory =
                _context.Subcategories.FirstOrDefault(s => s.Id == subcategoryId && s.UserId == userId);
            if (selectedSubcategory != null)
            {
                selectedSubcategory.Name = subcategoryNewName;
            }           
        }

        public Category.Type GetTypeByCategory(int categoryId)
        {
            return _context.Categories.Where(c => c.Id == categoryId).Select(c => c.TypeOfCategory).SingleOrDefault();
        }

        public Category.Type GetTypeBySubcategory(int subcategoryId)
        {
            return _context.Subcategories.Where(s => s.Id == subcategoryId).Select(c => c.Category.TypeOfCategory).SingleOrDefault();
        }
       
    }
}