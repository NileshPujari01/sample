using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Koperasi.Domain.Entities;

namespace Koperasi.Domain.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");
            builder.HasKey(e => e.UserId);
            builder.Property(e => e.UserId).HasColumnName("user_id");
            builder.Property(e => e.CustomerName).HasColumnName("customer_name");
            builder.Property(e => e.ICNumber).HasColumnName("customer_ic_number");
            builder.Property(e => e.CustomerMobileNo).HasColumnName("customer_mobile_no");
            builder.Property(e => e.CustomerEmailId).HasColumnName("customer_email_id");
            builder.Property(e => e.AgreePrivacyPolicy).HasColumnName("is_privacy_policy_agreed");
            builder.Property(e => e.ApplicationPIN).HasColumnName("app_pin");
            builder.Property(e => e.CreatedBy).HasColumnName("created_by");
            builder.Property(e => e.CreatedDate).HasColumnName("created_date");
            builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            builder.Property(e => e.UpdatedDate).HasColumnName("updated_date");
        }
    }
}