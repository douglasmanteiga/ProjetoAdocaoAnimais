using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteAdocaoAnimais.Models
{
    public class AdocaoViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int AdocaoId { get; set; }
        [Display(Name = "Data de Adoção")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Required(ErrorMessage = "Preencha o campo Data de Adoção")]
        public DateTime DataAdocao { get; set; }
        [Display(Name = "Data/Hora Cadastro")]
        [Required(ErrorMessage = "Preencha o campo data/hora cadastro")]
        public DateTime DataHoraCadastro { get; set; }
        [Display(Name = "Situação")]
        [Required(ErrorMessage = "Preencha o campo situação")]
        public int AdocaoSituacaoId { get; set; }
        public virtual AdocaoSituacaoViewModel AdocaoSituacao { get; set; }
        [Display(Name = "Pessoa")]
        [Required(ErrorMessage = "Preencha o campo pessoa")]
        public int PessoaId { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        [Display(Name = "Animal")]
        [Required(ErrorMessage = "Preencha o campo animal")]
        public int AnimalId { get; set; }
        public virtual AnimalViewModel Animal { get; set; }
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Preencha o campo usuário")]
        public int UsuarioId { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
    }
}