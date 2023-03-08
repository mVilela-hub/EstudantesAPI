using Dapper;
using Estudantes.Interfaces;
using Estudantes.Models.DTO;
using Estudantes.Models.Entidades;
using Estudantes.Repositorio.Utilidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudantes.Repositorio
{
    public class EstudantesRepositorio: BaseRepositorio, IEstudantesRepositorio
    {
        public void Adicionar(Estudante estudante)
        {
            string comandoSql = @"INSERT INTO Students 
                                (FirstName, MiddleName, LastName, Gender, StreetAddress, City, State, ZipCode, Telephone, email, DateOfBirth, DegreePursued, ClassStandingCode, StudentStatus, EnrollmentTerm)
                                OUTPUT INSERTED.StudentId
                        VALUES (@FirstName, @MiddleName, @LastName, @Gender, @StreetAddress, @City, @State, @ZipCode, @Telephone, @email, @DateOfBirth, @DegreePursued, @ClassStandingCode, @StudentStatus, @EnrollmentTerm)";
            Db.Open();
            estudante.StudentId = Db.QuerySingle<int>(comandoSql, estudante);
        }

        public void Atualizar(Estudante estudante)
        {
            var comandoSql = @"UPDATE Students SET 
                            FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Gender = @Gender, StreetAddress = @StreetAddress,
                            City = @City, State = @State, ZipCode = @ZipCode, Telephone = @Telephone, email = @email, DateOfBirth = @DateOfBirth, 
                            DegreePursued = @DegreePursued, ClassStandingCode = @ClassStandingCode, StudentStatus = @StudentStatus,
                            EnrollmentTerm = @EnrollmentTerm WHERE StudentId = @StudentId";
            Db.Open();
            Db.Execute(comandoSql, estudante);
        }

        public Estudante? BuscarPorId(int studentId)
        {
            Estudante estudante = new();

            string comandoSql = @"SELECT [StudentId]
                                  ,[FirstName]
                                  ,[MiddleName]
                                  ,[LastName]
                                  ,[Gender]
                                  ,[StreetAddress]
                                  ,[City]
                                  ,[State]
                                  ,[ZipCode]
                                  ,[Telephone]
                                  ,[email]
                                  ,[DateOfBirth]
                                  ,[DegreePursued]
                                  ,[ClassStandingCode]
                                  ,[StudentStatus]
                                  ,[EnrollmentTerm]
                              FROM [Students].[dbo].[Students] WHERE StudentId = @id";

            estudante = Db.QueryFirstOrDefault<Estudante>(comandoSql, new { id = studentId });

            return estudante;
        }

        public EstudanteComInformacoesRelacionaisDTO? BuscarInformacoiesRelacionaisEstudantePorId(int studentId)
        {
            EstudanteComInformacoesRelacionaisDTO estudante = new();

            string comandoSql = @"SELECT stu.[StudentId]
                                  ,stu.[FirstName]
                                  ,stu.[MiddleName]
                                  ,stu.[LastName]
                                  ,stu.[Gender]
                                  ,stu.[StreetAddress]
                                  ,stu.[City]
                                  ,stu.[State]
                                  ,stu.[ZipCode]
                                  ,stu.[Telephone]
                                  ,stu.[email]
                                  ,stu.[DateOfBirth]
                                  ,stu.[DegreePursued]
                                  ,stu.[ClassStandingCode]
                                  ,stu.[StudentStatus]
                                  ,stu.[EnrollmentTerm]
								  ,dgre.[DegreeName]
								  ,clss.[ClassStandingName]
								  ,tr.[SessionCode]
								  ,tr.[Year]
                                FROM Students stu
                                LEFT JOIN [Degrees] dgre on dgre.DegreeId = stu.StudentId
                                LEFT JOIN [ClassStandings] clss on clss.ClassStandingCode = stu.ClassStandingCode
                                LEFT JOIN [Terms] tr on tr.TermCode = stu.EnrollmentTerm
                                WHERE [StudentId] = 2;";


            estudante = Db.QueryFirstOrDefault<EstudanteComInformacoesRelacionaisDTO>(comandoSql, new { id = studentId });

            return estudante;
        }

        public void Deletar(int studentId)
        {
            string comandoSQL = "DELETE FROM Students WHERE StudentId = @StudentId";

            Db.Open();
            Db.Execute(comandoSQL, new { StudentId = studentId });
        }

        public List<Estudante> SelecionarTodosOsCemPrimeirosEstudantesEmOrdemAscendentePeloStudentId()
        {
            List<Estudante> listaEstudantes = new();

            string sql = @"SELECT TOP (100) [StudentId]
                          ,[FirstName]
                          ,[MiddleName]
                          ,[LastName]
                          ,[Gender]
                          ,[StreetAddress]
                          ,[City]
                          ,[State]
                          ,[ZipCode]
                          ,[Telephone]
                          ,[email]
                          ,[DateOfBirth]
                          ,[DegreePursued]
                          ,[ClassStandingCode]
                          ,[StudentStatus]
                          ,[EnrollmentTerm]
                      FROM [Students].[dbo].[Students] ORDER BY StudentId";

            listaEstudantes = Db.Query<Estudante>(sql).ToList();

            return listaEstudantes;
        }
    }
}
