﻿using Dotnet.Data.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Dotnet.Ef
{
    public class EfActiveTransactionProvider: IActiveTransactionProvider
    {
        private readonly IDbContext _dbContext;

        public EfActiveTransactionProvider(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbTransaction GetActiveTransaction(ActiveTransactionProviderArgs args)
        {
            //return GetActiveConnection(args).BeginTransaction();
            return null;
        }

        public IDbConnection GetActiveConnection(ActiveTransactionProviderArgs args)
        {
            return GetDbContext(args).Database.GetDbConnection();
        }

        public DbContext GetDbContext(ActiveTransactionProviderArgs args)
        {
            DbContext dbContext = (DbContext)_dbContext;
            return dbContext;
        }
    }
}
