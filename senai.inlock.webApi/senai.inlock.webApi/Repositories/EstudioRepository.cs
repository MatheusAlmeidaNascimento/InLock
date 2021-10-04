using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string Conexao = "Data Source=DESKTOP-9THVDDP\SQLEXPRESS; initial catalog=inLock;";
        public void AtualizarIdUrl(int idEstudio, EstudioDomain estudioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryUptadeIdBody = "UPDATE Estudio SET nomeEstudio = @nomeEstudio WHERE idEstudio = @idEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUptadeIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudio", estudioAtualizado.nomeEstudio);
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EstudioDomain BuscarPorId(int idEstudio)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySearchById = "SELECT * FROM Estudio WHERE idEstudio = @idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudioDomain estudioProcurado = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),
                            nomeEstudio = rdr[1].ToString(),
                        };
                        return estudioProcurado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = "INSERT INTO Estudio (nomeEstudio) VALUES(@nomeEstudio)";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudio", novoEstudio.nomeEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idEstudio)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "DELETE FROM Estudio WHERE idEstudio = @idEstudio";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectAll = "SELECT * FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),
                            nomeEstudio = rdr[1].ToString(),
                        };

                        listaEstudios.Add(estudio);
                    }
                }
            }
            return listaEstudios;
        }
    }
}
