using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IEmpleadoService
    {
        List<EmpleadoDTO> GetEmpleados();
        EmpleadoDTO GetEmpleadoById(int id);
        EmpleadoDTO AddEmpleado(EmpleadoDTO empleado);
        EmpleadoDTO UpdateEmpleado(EmpleadoDTO empleado);
        EmpleadoDTO DeleteEmpleado(int id);
    }
}