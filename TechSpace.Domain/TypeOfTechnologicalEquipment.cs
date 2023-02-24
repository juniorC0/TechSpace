namespace TechSpace.Domain
{
    public class TypeOfTechnologicalEquipment : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int AreaOccupiedByEquipment { get; set; }

        public ICollection<EquipmentPlacementContract>? EquipmentPlacementContracts { get; set; }
    }
}
