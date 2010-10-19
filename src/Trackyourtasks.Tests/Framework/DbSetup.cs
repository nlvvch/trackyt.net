﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trackyourtasks.Core.DAL.DataModel;
using System.Transactions;

namespace Trackyourtasks.Core.Tests.Framework
{
    public class DbSetup : IDisposable
    {
        private TrackyDataContext _model = new TrackyDataContext();
        private TransactionScope _transaction = new TransactionScope();
 
        public DbSetup()
        {
            Init();
        }

        public TrackyDataContext Context { get { return _model; } }

        private void Init()
        {
            AddTestUser();
        }

        private void AddTestUser()
        {
            var user = new User()
            {
                Email = "exists@test.com",
                //SecretPhrase = "bla-bla",
                Password = "test_pass2"
            };

            _model.Users.InsertOnSubmit(user);
            _model.SubmitChanges();
        }

        #region IDisposable Members

        public void Dispose()
        {
            _transaction.Dispose();
            _transaction = null;
        }

        #endregion
    }
}
