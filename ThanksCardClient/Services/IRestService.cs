using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;

namespace ThanksCardClient.Services
{
    interface IRestService
    {
        // Logon REST API Client
        Task<User> LogonAsync(User user);

        // DepartmentUsers REST API Client
        Task<List<User>> GetDepartmentUsersAsync(long? DepartmentChildrenId);
        Task<List<User>> GetDepartmentChildrenUsersAsync(long? DepartmentChildrenId);

        // User REST API Client
        Task<List<User>> GetUsersAsync();
        Task<User> PostUserAsync(User user);
        Task<User> PutUserAsync(User user);
        Task<User> DeleteUserAsync(long Id);

        // Department REST API Client
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> PostDepartmentAsync(Department department);
        Task<Department> PutDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(long Id);

        // TanksCard REST API Client
        Task<List<ThanksCard>> GetThanksCardsAsync();
        Task<DepartmentChildren> LogonAsync(DepartmentChildren departmentChildren);
        Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard);
        Task<ThanksCard> PutThanksCardAsync(ThanksCard thanksCard);
        Task<ThanksCard> DeleteThanksCardAsync(long Id);

        // Tag REST API Client
        Task<List<Tag>> GetTagsAsync();
        Task<Tag> PostTagAsync(Tag tag);
        Task<Tag> PutTagAsync(Tag tag);
        Task<Tag> DeleteTagAsync(long Id);

        // DepartmentChildren REST API Client
        Task<List<DepartmentChildren>> GetDepartmentChildrensAsync();
        Task<DepartmentChildren> PostDepartmentChildrenAsync(DepartmentChildren departmentChildren);
        Task<DepartmentChildren> PutDepartmentChildrenAsync(DepartmentChildren departmentChildren);
        Task<DepartmentChildren> DeleteDepartmentChildrenAsync(long Id);
        Task<List<DepartmentChildren>> GetDepartmentDepartmentChildrensAsync(long? departmentChildrenId);
        
    }
}
