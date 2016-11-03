using AwSales.Modelo;
using System.Data.Entity;
using System;
using AwSales.Modelo.HumanResources;

namespace AwSales.Repositorio.Impl
{
    public class HumanResourcesRepositorio : IDisposable
    {
        private readonly DbContext bd;

        private readonly RepositorioGenerico<Department> _departamentos;
        private readonly RepositorioGenerico<Employee> _empleados;
        private readonly RepositorioGenerico<EmployeeDepartmentHistory> _escalafon;
        private readonly RepositorioGenerico<EmployeePayHistory> _pagosEmpleado;
        private readonly RepositorioGenerico<JobCandidate> _candidatos;
        private readonly RepositorioGenerico<Shift> _rotaciones;

        public HumanResourcesRepositorio(DbContext bd)
        {
            this.bd = bd;
            _departamentos = new RepositorioGenerico<Department>(bd);
            _empleados = new RepositorioGenerico<Employee>(bd);
            _escalafon = new RepositorioGenerico<EmployeeDepartmentHistory>(bd);
            _pagosEmpleado = new RepositorioGenerico<EmployeePayHistory>(bd);
            _candidatos = new RepositorioGenerico<JobCandidate>(bd);
            _rotaciones = new RepositorioGenerico<Shift>(bd);
        }

        public RepositorioGenerico<Department> Departamentos { get { return _departamentos; } }
        public RepositorioGenerico<Employee> Empleados { get { return _empleados; } }
        public RepositorioGenerico<EmployeeDepartmentHistory> Escalafon { get { return _escalafon; } }
        public RepositorioGenerico<EmployeePayHistory> PagosEmpleado { get { return _pagosEmpleado; } }
        public RepositorioGenerico<JobCandidate> Candidatos { get { return _candidatos; } }
        public RepositorioGenerico<Shift> Rotaciones { get { return _rotaciones; } }

        public void Commit()
        {
            bd.SaveChanges();
        }

        public void Dispose()
        {
            bd.Dispose();
        }
    }
}