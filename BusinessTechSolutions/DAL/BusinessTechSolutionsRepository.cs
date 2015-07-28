using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using BusinessTechSolutions.Models;
using System.Data;


namespace BusinessTechSolutions.DAL
{
    public class BusinessTechSolutionsRepository : IBusinessTechSolutionsRepository
    {
        private ApplicationDBConnection _dbConnection;
        public BusinessTechSolutionsRepository(ApplicationDBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            return _dbConnection.Connection.Query<Customers>("Customers_GetAll", commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<ApplicationUser> Users_GetAllUsers()
        {
            return _dbConnection.Connection.Query<ApplicationUser>("AspNetUsers_SelectAllUsers", commandType: CommandType.StoredProcedure);
        }
        public Customers Customers_GetCustomerByCustomerId(int Id)
        {
            return _dbConnection.Connection.Query<Customers>("Customers_GetCustomerByCustomerId", new { CustomerId = Id }, commandType: CommandType.StoredProcedure).Single();
        }

        public ProfileInformation BTSMember_GetMemberById(string id)
        {
            return _dbConnection.Connection.Query<ProfileInformation>("BTSMembers_DisplayProfile", new { MemberId = id }, commandType: CommandType.StoredProcedure).Single();
        }
        public ApplicationUser AspNetUser_GetUserById(string id)
        {
            return _dbConnection.Connection.Query<ApplicationUser>("AspNetUser_GetUserById", new { Id = id }, commandType: CommandType.StoredProcedure).Single();
        }

        public bool Customer_CreateCustomer(Customers customer)
        {
            var p = new DynamicParameters();
            p.Add("CustomerName", customer.CustomerName);
            p.Add("CustomerContactPerson", customer.CustomerContactPerson);
            p.Add("CustomerAddress", customer.CustomerAddress);
            p.Add("CustomerEmail", customer.CustomerEmail);
            p.Add("CustomerPhone", customer.CustomerPhone);
            p.Add("InsertedBy", customer.InsertedBy);
            return _dbConnection.Connection.Execute("Customer_Insert", p, commandType: CommandType.StoredProcedure) > 0;
        }
        public bool Customer_UpdateInformation(Customers customer)
        {
            var p = new DynamicParameters();
            p.Add("CustomerID", customer.CustomerId);
            p.Add("CustomerName", customer.CustomerName);
            p.Add("CustomerContactPerson", customer.CustomerContactPerson);
            p.Add("CustomerAddress", customer.CustomerAddress);
            p.Add("CustomerEmail", customer.CustomerEmail);
            p.Add("CustomerPhone", customer.CustomerPhone);
            p.Add("InsertedBy", customer.InsertedBy);
            return _dbConnection.Connection.Execute("Customer_UpdateCustomerInformation", p, commandType: CommandType.StoredProcedure) > 0;
        }
        public bool Customer_Delete (Customers customer)
        {
            var p = new DynamicParameters();
            p.Add("CustomerId", customer.CustomerId);
            return _dbConnection.Connection.Execute("Customer_Delete", p, commandType: CommandType.StoredProcedure) > 0;
        }
        public  bool AspNetUser_Update(ApplicationUser user)
        {
            var p = new DynamicParameters();
            user.Member = true;
            p.Add("Id", user.Id);
            p.Add("Member", user.Member);
            return _dbConnection.Connection.Execute("AspNetUsers_Update", p, commandType: CommandType.StoredProcedure) > 0;
        }
        public  bool BTSMember_InsertProfileInformation(ProfileInformation profile, string Id)
        {
            var p = new DynamicParameters();
            p.Add("FirstName", profile.FirstName);
            p.Add("LastName", profile.LastName);
            p.Add("MemberId", Id);
            p.Add("Major", profile.Major);
            p.Add("Status", profile.Status);
            profile.JoinDate = DateTime.Now;
            p.Add("JoinDate", profile.JoinDate);
            p.Add("GraduationDate", profile.GraduationDate);
            return _dbConnection.Connection.Execute("BTSMember_InsertProfileInformation", p, commandType: CommandType.StoredProcedure) > 0;
        }
        public bool BTSMember_InsertMemberId(ProfileInformation profile, string Id)
        {
            var p = new DynamicParameters();
            p.Add("MemberId", Id);
            return _dbConnection.Connection.Execute("BTSMember_InsertMemberId", p, commandType: CommandType.StoredProcedure) > 0;
        }
        public bool BTSMember_UpdateProfileInformation(ProfileInformation profile, string Id)
        {
            var p = new DynamicParameters();
            p.Add("FirstName", profile.FirstName);
            p.Add("LastName", profile.LastName);
            p.Add("MemberId", Id);
            p.Add("Major", profile.Major);
            p.Add("Status", profile.Status);
            profile.JoinDate = DateTime.Now;
            p.Add("JoinDate", profile.JoinDate);
            p.Add("GraduationDate", profile.GraduationDate);
            return _dbConnection.Connection.Execute("BTSMember_UpdateProfileInformation", p, commandType: CommandType.StoredProcedure) > 0;
        }
        
    }
}