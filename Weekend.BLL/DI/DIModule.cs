using System;
using System.Collections.Generic;
using System.Text;
using Weekend.DAL.Context;

namespace Weekend.BLL.DI
{
    public class DIModule
    {
        readonly WeekendContext context;
        public DIModule()
        {
             context = new WeekendContext();
        }

        public WeekendContext ConfigureContext()
        {
            return context;
        }
    }
}
