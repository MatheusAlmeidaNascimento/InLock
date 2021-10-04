using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class EstudioDomain
    {
        /// <summary>
        /// Classe que representa a entidade (tabela) Estudio
        /// </summary>
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "Por favor informe o nome do estúdio")]
        [StringLength(50, ErrorMessage = "O campo senha precisa ter no máximo 50 caracteres")]
        public string nomeEstudio { get; set; }
    }
}
