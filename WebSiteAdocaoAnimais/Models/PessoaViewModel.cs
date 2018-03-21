using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteAdocaoAnimais.Models
{
    public class PessoaViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int PessoaId { get; set; }
        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(500, ErrorMessage = "Máximo 500 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Preencha o campo e-mail")]
        [MaxLength(250, ErrorMessage = "Máximo 250 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        public string Email { get; set; }
        [Display(Name = "Data/Hora Cadastro")]
        [Required(ErrorMessage = "Preencha o campo data/hora cadastro")]
        public DateTime DataHoraCadastro { get; set; }
    }
}