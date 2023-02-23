namespace TechSpace.Domain
{
    public class EquipmentPlacementContract
    {
        public int Id { get; set; }
        public ProductionPremise ProductionPremises { get; set; }
        public TypeOfTechnologicalEquipment TypeOfTechnologicalEquipment { get; set; }
        public int NumberOfEquipmentUnits { get; set; }
    }
}
