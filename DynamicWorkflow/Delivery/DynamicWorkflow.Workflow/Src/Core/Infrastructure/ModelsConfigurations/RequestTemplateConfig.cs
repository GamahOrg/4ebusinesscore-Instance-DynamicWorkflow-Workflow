namespace _4EPlatForm.Infrastructure.ModelsConfigurations
{
    public class RequestTemplateConfig : IEntityTypeConfiguration<RequestTemplate>
    {
        public void Configure(EntityTypeBuilder<RequestTemplate> builder)
        {
            builder.HasMany(rt => rt.RequestTemplateSteps)
                .WithOne(rs => rs.RequestTemplate)
                .HasForeignKey(rs => rs.RequestTemplateId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasMany(rt => rt.RequestInstances)
                .WithOne(ri => ri.RequestTemplate)
                .HasForeignKey(ri => ri.RequestTemplateId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

        }
    }
}
