using SmartService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.Domain.Abstractions
{
    public interface IUserListCategoryRepository
    {
        Task<IEnumerable<(int UserID, byte ListCategoryID)>> UserListCategoriesAsync(short tenantID);
    }
}
