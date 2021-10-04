using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string Conexao = "Data Source=DESKTOP-9THVDDP\SQLEXPRESS; initial catalog=inLock;";
        public void AtualizarIdUrl(int idJogo, JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryUptadeIdBody = "UPDATE Jogo SET idEstudio = @IdEstudio, nomeJogo = @nomeJogo, dataLan = @dataLan, valor = @valor, descricao = @descricao WHERE idJogo = @idJogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUptadeIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", jogoAtualizado.idEstudio);
                    cmd.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@dataLan", jogoAtualizado.dataLan);
                    cmd.Parameters.AddWithValue("@valor", jogoAtualizado.valor);
                    cmd.Parameters.AddWithValue("@descricao", jogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySearchById = "SELECT idJogo, E.idEstudio, nomeJogo, dataLan, valor, descricao, E.nomeEstudio FROM Jogo INNER JOIN Estudio E ON Jogo.idEstudio = E.idEstudio WHERE idJogo = @idJogo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idjogo", idJogo);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogoProcurado = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),
                            idEstudio = Convert.ToInt32(rdr[1]),
                            nomeJogo = rdr[2].ToString(),
                            dataLan = Convert.ToDateTime(rdr[3]),
                            valor = Convert.ToDouble(rdr[4]),
                            descricao = rdr[5].ToString(),

                            estudio = new EstudioDomain()
                            {
                                nomeEstudio = rdr[6].ToString(),
                            }
                        };
                        return jogoProcurado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = "INSERT INTO Jogo (idEstudio, nomeJogo, dataLan, valor, descricao) VALUES(@idEstudio, @nomeJogo, @dataLan, @valor, @descricao)";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@dataLan", novoJogo.dataLan);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE idJogo = @idJogo";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectAll = "SELECT idJogo, E.idEstudio, nomeJogo, dataLan, valor, descricao, E.nomeEstudio FROM Jogo INNER JOIN Estudio E ON Jogo.idEstudio = E.idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),
                            idEstudio = Convert.ToInt32(rdr[1]),
                            nomeJogo = rdr[2].ToString(),
                            dataLan = Convert.ToDateTime(rdr[3]),
                            valor = Convert.ToDouble(rdr[4]),
                            descricao = rdr[5].ToString(),

                            estudio = new EstudioDomain()
                            {
                                idEstudio = Convert.ToInt32(rdr[1]),
                                nomeEstudio = rdr[6].ToString(),
                            }
                        };

                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }
    }
}
