

using Estudantes.Models.DTO;
using Estudantes.Models.Entidades;

namespace Estudantes.Interfaces
{
    public interface IEstudantesRepositorio
    {
        public List<Estudante> SelecionarTodosOsCemPrimeirosEstudantesEmOrdemAscendentePeloStudentId();
        public EstudanteComInformacoesRelacionaisDTO? BuscarInformacoiesRelacionaisEstudantePorId(int studentId);
        public Estudante? BuscarPorId(int id);
        public void Adicionar(Estudante estudante);
        public void Atualizar(Estudante estudante);
        public void Deletar(int id);
    }
}
