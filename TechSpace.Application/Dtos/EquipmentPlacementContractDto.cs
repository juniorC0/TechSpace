using System.ComponentModel.DataAnnotations;

namespace TechSpace.Application.Dtos
{
    public class EquipmentPlacementContractDto
    {
        public string ProductionPremiseCode { get; set; }
        public string TypeOfTechnologicalEquipmentCode { get; set; }

        public int NumberOfEquipmentUnits { get; set; }
    }
}
