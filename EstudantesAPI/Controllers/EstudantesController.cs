using Estudantes.Interfaces;
using Estudantes.Models.DTO;
using Estudantes.Models.Entidades;
using EstudantesAPI.Controllers.Utulidade;
using Microsoft.AspNetCore.Mvc;

namespace EstudantesAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class EstudantesController : BaseController
    {
        private IEstudantesRepositorio _estudanteRepositorio;

        public EstudantesController(IEstudantesRepositorio estudanteRepositorio)
        {
            _estudanteRepositorio = estudanteRepositorio;
        }

        [HttpGet("estudantes/listar-cem-estudantes-pelo-id")]
        public IActionResult SelecionarTodosOsCemPrimeirosEstudantesEmOrdemAscendentePeloStudentId()
        {
            List<Estudante> listaEstudante = new();

            listaEstudante = _estudanteRepositorio.SelecionarTodosOsCemPrimeirosEstudantesEmOrdemAscendentePeloStudentId();

            return Ok(listaEstudante);
        }

        [HttpGet("estudante/buscar-por-id-todas-informacoes-relacionais/{studentId}")]
        public IActionResult BuscarPorIdInformacoesCompletas(int studentId)
        {
            EstudanteComInformacoesRelacionaisDTO? Estudante = new();

            Estudante = _estudanteRepositorio.BuscarInformacoiesRelacionaisEstudantePorId(studentId);

            return Ok(Estudante);
        }

        [HttpGet("estudante/buscar-por-id/{studentId}")]
        public IActionResult BuscarPorId(int studentId)
        {
            Estudante? Estudante = new();

            Estudante = _estudanteRepositorio.BuscarPorId(studentId);

            return Ok(Estudante);
        }

        [HttpPost("estudante/cadastro")]
        public IActionResult Adicionar(Estudante aluno)
        {

            try
            {
                _estudanteRepositorio.Adicionar(aluno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"Adicionado com sucesso, o id gerado para conferir o cadastro é {aluno.StudentId}");
        }

        [HttpPut("estudante/atualiza")]
        public IActionResult Atualiza(Estudante estudanteCadastro)
        {
            try
            {
                _estudanteRepositorio.Atualizar(estudanteCadastro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Atualizado com sucesso !");
        }

        [HttpDelete("estudante/delete/{studentId}")]
        public IActionResult Delete(int studentId)
        {
            try
            {
                _estudanteRepositorio.Deletar(studentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Deletado com sucesso !");
        }
    }
}