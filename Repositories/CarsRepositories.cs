using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Davinci.Repositories
{
    public class CarsRepositories
    {
        private readonly IDbConnection _cr;

        public CarsRepositories(IDbConnection cr)
        {
            _cr = cr;
        }

    
    }
}