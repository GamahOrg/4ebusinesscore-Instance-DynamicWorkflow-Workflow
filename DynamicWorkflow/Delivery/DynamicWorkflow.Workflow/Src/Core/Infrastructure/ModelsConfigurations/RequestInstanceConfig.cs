namespace _4EPlatForm.Infrastructure.ModelsConfigurations
{
    public class RequestInstanceConfig : IEntityTypeConfiguration<RequestInstance>
    {
        public void Configure(EntityTypeBuilder<RequestInstance> builder)
        {
            builder.HasMany(ri => ri.RequestTransactions)
                 .WithOne(rt => rt.RequestInstance)
                 .HasForeignKey(rt => rt.RequestInstanceId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ri => ri.CurrentStep)
                .WithMany(rs => rs.RequestInstances)
                .HasForeignKey(ri => ri.CurrentStepId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

        }
    }

    public class RequestTransactionConfig : IEntityTypeConfiguration<RequestTransaction>
    {
        public void Configure(EntityTypeBuilder<RequestTransaction> builder)
        {
            builder.HasOne(rt => rt.AssginRequestInstance)
            .WithOne(ari => ari.RequestTransaction)
            .HasForeignKey<AssginRequestInstance>(ari => ari.RequestTransactionId);
        }
    }
}
