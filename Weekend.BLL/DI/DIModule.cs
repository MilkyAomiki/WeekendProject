using System;
using System.Collections.Generic;
using System.Text;
using Weekend.DAL.Context;

namespace Weekend.BLL.DI
{
    public class DIModule
    {
        public WeekendContext ConfigureContext(string connection)
        {
            var context = new WeekendContext(connection);
            return context;
        }
    }
}
