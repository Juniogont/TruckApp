using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Truck.Domain.Validators;

namespace Truck.Domain.Entities
{
    public class Caminhao : BaseEntity
    {
        [StringLength(7)]
        public string Placa { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(10)]
        [Modelo]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [AnoFabricacao]
        [Display(Name = "Ano Fabricacao")]
        public int AnoFabricacao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Ano Modelo")]
        [AnoModelo]
        public int AnoModelo { get; set; }
    }
}
