using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessTechSolutions.Models;

namespace BusinessTechSolutions.DAL
{
    interface IBusinessTechSolutionsRepository
    {
        IEnumerable<Customers> GetAllCustomers();
        IEnumerable<ApplicationUser> Users_GetAllUsers();

        Customers Customers_GetCustomerByCustomerId(int Id);
        ApplicationUser AspNetUser_GetUserById(string id);
        ProfileInformation BTSMember_GetMemberById(string id);
        bool Customer_CreateCustomer(Customers customer);
        bool Customer_UpdateInformation(Customers customer);
        bool Customer_Delete (Customers customer);
        bool AspNetUser_Update(ApplicationUser user);
        bool BTSMember_InsertProfileInformation(ProfileInformation profile, string Id);
        bool BTSMember_InsertMemberId(ProfileInformation profile, string Id);
        bool BTSMember_UpdateProfileInformation(ProfileInformation profile, string Id);
    }
}
