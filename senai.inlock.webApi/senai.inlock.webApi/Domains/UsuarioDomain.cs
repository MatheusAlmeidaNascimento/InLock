using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) Usuario
    /// </summary>
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        public int idTipoUser { get; set; }

        [Required(ErrorMessage = "Por favor informe o e-mail")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O campo senha precisa ter no mínimo 10 caracteres e máximo 200")]
        public string email { get; set; }

        [Required(ErrorMessage = "Por favor informe a senha")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no mínimo 3 e no máximo 10 caracteres")]
        public string senha { get; set; }

        public TipoUserDomain tipoUser { get; set; }
    }
}
