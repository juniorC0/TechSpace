namespace TechSpace.Domain
{
    public class EquipmentPlacementContract : BaseEntity
    {
        public ProductionPremise ProductionPremise { get; set; }
        public TypeOfTechnologicalEquipment TypeOfTechnologicalEquipment { get; set; }

        public int NumberOfEquipmentUnits { get; set; }
    }
}
