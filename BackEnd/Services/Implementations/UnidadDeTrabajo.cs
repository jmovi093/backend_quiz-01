using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IEmpleadoDAL EmpleadoDAL { get; }
        private readonly QuizContext context;

        public UnidadDeTrabajo(IEmpleadoDAL empleadoDAL, QuizContext dbContext)
        {
            EmpleadoDAL = empleadoDAL ?? throw new ArgumentNullException(nameof(empleadoDAL));
            context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
