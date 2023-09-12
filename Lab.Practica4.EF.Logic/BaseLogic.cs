using Lab.Practica4.EF.Data;

namespace Lab.Practica4.EF.Logic
    { 
    public abstract class BaseLogic
    {
        protected readonly NorthwindContext context;
        public BaseLogic()
        {
            context = new NorthwindContext();
        }

    }

    
    }
