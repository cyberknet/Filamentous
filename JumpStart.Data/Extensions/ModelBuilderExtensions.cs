using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JumpStart.Data.Entities.Base;
using JumpStart.Data.Entities;

namespace Microsoft.EntityFrameworkCore;
public static class ModelBuilderExtensions
{
    public static void RegisterAuditEntityRelationships(this ModelBuilder builder)
    {
        foreach (var type in builder.Model.GetEntityTypes())
        {
            if (typeof(IAuditableEntity).IsAssignableFrom(type.ClrType))
            {
                ConfigureRelationshipForProperty(builder, type, nameof(IAuditableEntity.CreatedBy));
                ConfigureRelationshipForProperty(builder, type, nameof(IAuditableEntity.UpdatedBy));
                ConfigureRelationshipForProperty(builder, type, nameof(IAuditableEntity.DeletedBy));
            }
        }
    }

    public static void SetTableNamesToEntityNames(this ModelBuilder builder)
    {
        // find every entity in the model
        foreach(IMutableEntityType entityType in builder.Model.GetEntityTypes())
        {
            // if it is one of our entities (i.e. not from AspNet Identity)
            if (typeof(Entity).IsAssignableFrom(entityType.ClrType))
            {
                // get the assigned table name
                string? currentTableName = entityType.GetTableName();
                // get the entity type name
                string newTableName = entityType.ClrType.Name;

                // if there is no assigned table name, 
                // or if the entity type name and the assigned table name don't match
                if (string.IsNullOrWhiteSpace(currentTableName) || currentTableName != newTableName)
                    // update the assigned table name to the entity type name
                    entityType.SetTableName(entityType.ClrType.Name);
            }
        }
    }

    private static void ConfigureRelationshipForProperty(ModelBuilder builder, IMutableEntityType entityType, string propertyName)
    {
        var navigationProperty = entityType.ClrType.GetProperty(propertyName);

        if (navigationProperty != null)
        {
            builder.Entity(entityType.ClrType)
                .HasOne(navigationProperty.PropertyType, propertyName)
                .WithMany()
                .HasForeignKey($"{propertyName}Id")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
