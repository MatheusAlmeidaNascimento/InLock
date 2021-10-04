using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) TipoUsuario
    /// </summary>
    public class TipoUserDomain
    {
        public int idTipoUser { get; set; }

        public string titulo { get; set; }
    }
}
