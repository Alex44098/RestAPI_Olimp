/*Конфигурация базы данных для работы с пользователями*/
using Microsoft.EntityFrameworkCore;
using Models.Entitis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelsConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(user => user.id);
            builder.HasIndex(user => user.id).IsUnique();
            builder.Property(user => user.firstName).HasMaxLength(128);
            builder.Property(user => user.lastName).HasMaxLength(128);
        }
    }
}
