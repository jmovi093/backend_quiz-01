using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public EmpleadoService(IUnidadDeTrabajo unidad)
        {
            _unidadDeTrabajo = unidad;
        }

        private EmpleadoDTO Convertir(Empleado empleado)
        {
            return new EmpleadoDTO
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
        }

        private Empleado Convertir(EmpleadoDTO empleado, bool isNew = false)
        {
            return new Empleado
            {
                EmpleadoId = isNew ? 0 : empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
        }

        public EmpleadoDTO AddEmpleado(EmpleadoDTO empleado)
        {
            _unidadDeTrabajo.EmpleadoDAL.Add(Convertir(empleado, true));
            _unidadDeTrabajo.Complete();
            return empleado;
        }

        public EmpleadoDTO DeleteEmpleado(int id)
        {
            var empleado = new Empleado { EmpleadoId = id };
            _unidadDeTrabajo.EmpleadoDAL.Remove(empleado);
            _unidadDeTrabajo.Complete();
            return Convertir(empleado);
        }

        public List<EmpleadoDTO> GetEmpleados()
        {
            var empleados = _unidadDeTrabajo.EmpleadoDAL.Get();
            List<EmpleadoDTO> empleadoDTOs = new List<EmpleadoDTO>();
            foreach (var empleado in empleados)
            {
                empleadoDTOs.Add(Convertir(empleado));
            }
            return empleadoDTOs;
        }

        public EmpleadoDTO GetEmpleadoById(int id)
        {
            var result = _unidadDeTrabajo.EmpleadoDAL.FindById(id);
            return Convertir(result);
        }

        public EmpleadoDTO UpdateEmpleado(EmpleadoDTO empleado)
        {
            var entity = Convertir(empleado);
            _unidadDeTrabajo.EmpleadoDAL.Update(entity);
            _unidadDeTrabajo.Complete();
            return empleado;
        }
    }
}