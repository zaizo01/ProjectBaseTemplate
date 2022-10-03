using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectBase.Domain.Common;
using ProjectBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBase.Persistence.EntitiesConfigurations
{
    public class BaseEntityConfig : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> modelBuilder)
        {
            modelBuilder.Property(p => p.IsActive)
                .HasDefaultValue(true);
        }
    }
}
