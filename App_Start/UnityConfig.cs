using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using RetoTecnico.Data;
using RetoTecnico.Interfaces;
using RetoTecnico.Servicios;

namespace RetoTecnico
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // DbContext
            container.RegisterType<BibliotecaContext>();

            // Servicios
            container.RegisterType<IAutorService, AutorService>();
            container.RegisterType<ILibroService, LibroService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
