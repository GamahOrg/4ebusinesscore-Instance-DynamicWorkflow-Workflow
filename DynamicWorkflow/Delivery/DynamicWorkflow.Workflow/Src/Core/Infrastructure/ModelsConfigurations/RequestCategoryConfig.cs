namespace _4EPlatForm.Infrastructure.ModelsConfigurations
{
    public class RequestCategoryConfig : IEntityTypeConfiguration<RequestCategory>
    {
        public void Configure(EntityTypeBuilder<RequestCategory> builder)
        {
            builder.HasMany(rc => rc.RequestTemplates)
                .WithOne(rt => rt.RequestCategory)
                .HasForeignKey(rt => rt.RequestCategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
