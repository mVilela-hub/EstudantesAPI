using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudantes.Repositorio.Utilidade
{
    public class BaseRepositorio
    {
        protected SqlConnection Db { get; set; }
        private string connectionString { get; } = "Data Source=DESKTOP-75EA65P;Initial Catalog=Students;Integrated Security=True";
        public BaseRepositorio()
        {
            Db = new SqlConnection(connectionString);
        }
    }
}
