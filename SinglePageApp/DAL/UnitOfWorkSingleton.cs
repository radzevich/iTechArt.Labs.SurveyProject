using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinglePageApp.DAL
{
    public class UnitOfWorkSingleton : UnitOfWork
    {
        private static UnitOfWorkSingleton _instance;

        private UnitOfWorkSingleton()
        { }

        public static UnitOfWorkSingleton Instance()
        {
            if (_instance == null)
                _instance = new UnitOfWorkSingleton();
            return _instance;
        }
    }
}