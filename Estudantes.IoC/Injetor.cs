using Estudantes.Interfaces;
using Estudantes.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace Estudantes.IoC
{
    public static class Injetor
    {
        public static void RegistrarInjecaoDeDepedencia(this IServiceCollection services)
        {
            services.AddScoped<IEstudantesRepositorio, EstudantesRepositorio>();
        }
    }
}
