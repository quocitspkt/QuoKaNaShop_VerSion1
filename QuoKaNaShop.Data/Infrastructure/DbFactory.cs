﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoKaNaShop.Data.Infrastructure
{
    public class DbFactory:Disposable,IDbFactory
    {
        private QuoKaNaDBContext dbContext;

        public QuoKaNaDBContext Init()
        {
            return dbContext ?? (dbContext = new QuoKaNaDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
