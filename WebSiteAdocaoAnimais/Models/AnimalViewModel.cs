using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteAdocaoAnimais.Models
{
    public class AnimalViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150, ErrorMessage = "Máximo 250 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Nome { get; set; }
        [Display(Name = "Raça")]
        [Required(ErrorMessage = "Preencha o campo raça")]
        public string Raca { get; set; }
        [Required(ErrorMessage = "Preencha o campo cor")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "Preencha o campo sexo")]
        [Display(Name = "Sexo")]
        public int SexoId { get; set; }
        public virtual AnimalSexoViewModel AnimalSexo { get; set; }
        [Required(ErrorMessage = "Preencha o campo peso")]
        public string Peso { get; set; }
        [Display(Name = "Data de Entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Required(ErrorMessage = "Preencha o campo Data de Entrada")]
        public DateTime DataEntrada { get; set; }
    }
}