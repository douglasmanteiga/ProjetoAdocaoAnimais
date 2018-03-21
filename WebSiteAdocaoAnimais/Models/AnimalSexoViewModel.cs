using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteAdocaoAnimais.Models
{
    public enum AnimalSexoViewModelEnum
    {
        Macho = 1,
        Femea = 2
    }

    public class AnimalSexoViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int SexoId { get; set; }
        public string Sexo { get; set; }
    }
}