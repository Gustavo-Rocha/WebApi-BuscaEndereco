using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BuscaEndereco.Models
{
    public class Endereco
    {
        
        [Required]
        [StringLength(8, MinimumLength = 8)]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage ="CEP Inválido")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Cep { get; set; }
        public string Rua { get; set; }

        [Required]
        [Range(0,int.MaxValue,ErrorMessage = "Insira um número valido")]
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Boolean ValidaEndereco( Endereco endereco)
        {
            if ((endereco.Cep == "" || endereco.Cep == null) & (endereco.Numero.Equals("")))
            {

                return false;

            }

            return true;
 
        }

    }
    

}
