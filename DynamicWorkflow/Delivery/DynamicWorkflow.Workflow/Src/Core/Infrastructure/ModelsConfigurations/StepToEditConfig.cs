namespace _4EPlatForm.Infrastructure.ModelsConfigurations
{
    public class StepToEditConfig : IEntityTypeConfiguration<StepToEdit>
    {
        public void Configure(EntityTypeBuilder<StepToEdit> builder)
        {
            builder.HasKey(s => new { s.RequestInstanceId, s.StepId })
                .IsClustered();

            builder.HasOne(s => s.RequestInstance)
                .WithMany(rs => rs.StepsToEdit)
                .HasForeignKey(s => s.RequestInstanceId);

            builder.HasOne(s => s.Step)
               .WithMany(s => s.StepToEdits)
               .HasForeignKey(s => s.StepId);
        }
    }
}
