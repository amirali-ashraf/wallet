using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Models.WalletModels;

namespace Wallet.Repositories
{
    public interface IManageCatsAndSubsRepository
    {
        /// <summary>
        /// This method returns a list of categories
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetCategories();

        /// <summary>
        /// This returns a list of subcategories
        /// </summary>
        /// <returns></returns>
        IEnumerable<Subcategory> GetSubcategories();

        /// <summary>
        /// This method receives the name of the new category and its type
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="type"></param>
        /// <param name="userId"></param>
        void AddCategory(string categoryName, int type, string userId);

        /// <summary>
        /// This method receives the name of the new subcategory and its categoryId 
        /// </summary>
        /// <param name="subcategoryName"></param>
        /// <param name="categoryId"></param>
        /// <param name="userId"></param>
        void AddSubcategory(string subcategoryName, int categoryId, string userId);

        /// <summary>
        /// find the category by Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Category FindCategory(int categoryId);

        /// <summary>
        /// This method deletes the category
        /// </summary>
        /// <param name="categoryId"></param>
        void RemoveCategory(int categoryId);

        Subcategory FindSubcategory(int subcategoryId);

        /// <summary>
        /// This method deletes the subcategory
        /// </summary>
        /// <param name="subcategoryId"></param>
        void RemoveSubcategory(int subcategoryId);

        /// <summary>
        /// this method edits the category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="categoryNewName"></param>
        /// <param name="typeId"></param>
        /// <param name="userId"></param>
        void EditCategory(int categoryId, string categoryNewName,string userId);


        /// <summary>
        /// this method edits the subcategory
        /// </summary>
        /// <param name="subcategoryId"></param>
        /// <param name="subcategoryNewName"></param>
        /// <param name="categoryId"></param>
        /// <param name="userId"></param>
        void EditSubcategory(int subcategoryId, string subcategoryNewName, string userId);

        /// <summary>
        /// Get the type of category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Category.Type GetTypeByCategory(int categoryId);

        /// <summary>
        /// Get the type of the subcategory
        /// </summary>
        /// <param name="subcategoryId"></param>
        /// <returns></returns>
        Category.Type GetTypeBySubcategory(int subcategoryId);

      

    }
}
