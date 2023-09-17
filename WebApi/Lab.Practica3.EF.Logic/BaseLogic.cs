using Lab.Practica3.EF.Data;

namespace Lab.Practica3.EF.Logic
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
