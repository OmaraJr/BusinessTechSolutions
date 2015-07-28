using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessTechSolutions.DAL;
using BusinessTechSolutions.Models;

namespace BusinessTechSolutions.DAL
{
    public class GeneralUserRepository : IGeneralUserRepository
    {
        private ApplicationDBConnection _dbConnection;
        public GeneralUserRepository(ApplicationDBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
    }
}

