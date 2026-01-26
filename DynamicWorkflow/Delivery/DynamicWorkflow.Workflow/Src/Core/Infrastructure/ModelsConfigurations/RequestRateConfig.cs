namespace _4EPlatForm.Infrastructure.ModelsConfigurations
{
    public class RequestRateConfig : IEntityTypeConfiguration<RequestRate>
    {
        public void Configure(EntityTypeBuilder<RequestRate> builder)
        {
            builder.HasOne(ri => ri.RequestInstance)
            .WithOne(rr => rr.RequestRate)
          .HasForeignKey<RequestRate>(rr => rr.RequsetId);
        }
    }

}
