using BapKids.Service.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BapKids.Service.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategory(ProductRequestModel productRequestModel);

        Task DeleteCategory(long productId);

        Task UpdateCategory(long productId, ProductRequestModel productRequestModel);

    }
}
