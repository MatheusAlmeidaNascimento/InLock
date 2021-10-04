using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) Jogo
    /// </summary>
    public class JogoDomain
    {
        public int idJogo { get; set; }

        public int idEstudio { get; set; }

        [Required(ErrorMessage = "Por favor informe o nome do jogo")]
        [StringLength(50, ErrorMessage = "O campo senha precisa ter no máximo 50 caracteres")]
        public string nomeJogo { get; set; }

        [Required(ErrorMessage = "Por favor informe a data de lançamento do jogo")]
        [DataType(DataType.Date)]
        public DateTime dataLan { get; set; }

        [Required(ErrorMessage = "Por favor informe o valor do jogo")]
        public double valor { get; set; }

        [Required(ErrorMessage = "Por favor informe a descrição do Jogo")]
        [StringLength(250, ErrorMessage = "O campo senha precisa ter no máximo 250 caracteres")]
        public string descricao { get; set; }

        public EstudioDomain estudio { get; set; }
    }
}
