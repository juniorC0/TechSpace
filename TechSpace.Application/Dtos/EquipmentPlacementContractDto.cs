using System.ComponentModel.DataAnnotations;
using TechSpace.Domain;

namespace TechSpace.Application.Dtos
{
    public class EquipmentPlacementContractDto
    {
        [Required]
        public ProductionPremise ProductionPremise { get; set; }
        [Required]
        public TypeOfTechnologicalEquipment TypeOfTechnologicalEquipment { get; set; }

        public int NumberOfEquipmentUnits { get; set; }
    }
}
