using System.ComponentModel.DataAnnotations;

namespace TechSpace.Application.Dtos
{
    public class EquipmentPlacementContractDto
    {
        [Required]
        public string ProductionPremiseCode { get; set; }
        [Required]
        public string TypeOfTechnologicalEquipmentCode { get; set; }

        public int NumberOfEquipmentUnits { get; set; }
    }
}
