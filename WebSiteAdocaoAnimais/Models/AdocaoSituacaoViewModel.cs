using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteAdocaoAnimais.Models
{
    public enum AdocaoSituacaoViewModelEnum
    {
        Adotado = 1,
        Devolvido = 2
    }
    public class AdocaoSituacaoViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int AdocaoSituacaoId { get; set; }
        public string Descricao { get; set; }
    }
}