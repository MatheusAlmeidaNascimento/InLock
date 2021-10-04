using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string Conexao = "Data Source=DESKTOP-9THVDDP\SQLEXPRESS; initial catalog=inLock;";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelect = "SELECT idUsuario, T.idTipoUser, email, T.titulo FROM Usuario INNER JOIN TipoUsuario T ON T.idTipoUser = Usuario.idTipoUser WHERE Email = @email AND Senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            idTipoUser = Convert.ToInt32(rdr["idTipoUser"]),
                            email = rdr["email"].ToString(),
                            tipoUser = new TipoUserDomain()
                            {
                                idTipoUser = Convert.ToInt32(rdr["idTipoUser"]),
                                titulo = rdr["titulo"].ToString()
                            }
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
