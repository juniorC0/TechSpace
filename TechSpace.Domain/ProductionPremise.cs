﻿namespace TechSpace.Domain
{
    public class ProductionPremise : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int StandardAreaForEquipment { get; set; }
    }
}
