﻿namespace Airport.DAL.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Airport.Models.DomainModels.Entities;

    public class AircraftMap: EntityTypeConfiguration<Aircraft>
    {
        public AircraftMap()
        {
        }
    }
}