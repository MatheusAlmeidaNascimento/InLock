using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        EstudioDomain BuscarPorId(int idEstudio);

        void Cadastrar(EstudioDomain novoEstudio);

        void AtualizarIdUrl(int idEstudio, EstudioDomain EstudioAtualizado);

        void Deletar(int idEstudio);
    }
}
