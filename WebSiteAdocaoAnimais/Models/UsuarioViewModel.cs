using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteAdocaoAnimais.Models
{
    public class UsuarioViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int UsuarioId { get; set; }
        [MaxLength(250, ErrorMessage = "Máximo 250 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        [Required(ErrorMessage = "Preencha o campo login")]
        public string Login { get; set; }
        [MaxLength(250, ErrorMessage = "Máximo 250 caracteres")]
        [MinLength(6, ErrorMessage = "Mínimo de 6 caracteres")]
        [Required(ErrorMessage = "Preencha o campo o campo senha")]
        public string Senha { get; set; }
    }
}