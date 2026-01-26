namespace _4EPlatForm.Infrastructure.ModelsConfigurations
{
    public class RequestTemplateStepConfig : IEntityTypeConfiguration<RequestTemplateStep>
    {
        public void Configure(EntityTypeBuilder<RequestTemplateStep> builder)
        {

            builder.HasMany(s => s.RequestTransactions)
                .WithOne(rt => rt.RequestTemplateStep)
                .HasForeignKey(s => s.RequestTemplateStepId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(s => s.ActionTacker)
                .WithMany(a => a.RequestTemplateSteps)
                .HasForeignKey(a => a.ActionTackerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

        }
    }
}
