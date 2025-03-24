using ApiEmpleadosMultiplesRutas.Data;
using NugetApiModelsDrl;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleadosMultiplesRutas.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado> FindEmpleadoAsync
            (int idEmpleado)
        {
            return await this.context.Empleados
                .FirstOrDefaultAsync(z => z.IdEmpleado == idEmpleado);
        }

        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
        {
            return await this.context.Empleados
                .Where(e => e.Oficio == oficio)
                .ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosSalarioAsync(int salario, int idDepartamento)
        {
            return await this.context.Empleados
                .Where(e => e.Salario >= salario
                && e.Departamento == idDepartamento)
                .ToListAsync();
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();

            return await consulta.ToListAsync();
        }
    }


}
