using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Common.EFCoreToolkit
{
    public static class EntityFrameworkCoreModelBuilderExtensions
    {
        public static void SetDecimalPrecision(this ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
                                                              .SelectMany(t => t.GetProperties())
                                                              .Where(p => p.ClrType == typeof(decimal)
                                                                          || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18, 6)");
            }
        }

        public static void AddDateTimeOffsetConverter(this ModelBuilder builder)
        {
            // SQLite does not support DateTimeOffset
            foreach (var property in builder.Model.GetEntityTypes()
                                                  .SelectMany(t => t.GetProperties())
                                                  .Where(p => p.ClrType == typeof(DateTimeOffset)))
            {
                property.SetValueConverter(
                     new ValueConverter<DateTimeOffset, DateTime>(
                          convertToProviderExpression: dateTimeOffset => dateTimeOffset.UtcDateTime,
                          convertFromProviderExpression: dateTime => new DateTimeOffset(dateTime)
                    ));
            }

            foreach (var property in builder.Model.GetEntityTypes()
                                                  .SelectMany(t => t.GetProperties())
                                                  .Where(p => p.ClrType == typeof(DateTimeOffset?)))
            {
                property.SetValueConverter(
                     new ValueConverter<DateTimeOffset?, DateTime>(
                          convertToProviderExpression: dateTimeOffset => dateTimeOffset.Value.UtcDateTime,
                          convertFromProviderExpression: dateTime => new DateTimeOffset(dateTime)
                    ));
            }
        }

        public static void AddDateTimeUtcKindConverter(this ModelBuilder builder)
        {
          
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                        v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                        v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                        v => !v.HasValue ? v : (v.Value.Kind == DateTimeKind.Utc ? v : v.Value.ToUniversalTime()),
                        v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

            foreach (var property in builder.Model.GetEntityTypes()
                                                  .SelectMany(t => t.GetProperties()))
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(dateTimeConverter);
                }

                if (property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(nullableDateTimeConverter);
                }
            }
        }
    }
}