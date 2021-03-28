using Microsoft.EntityFrameworkCore;

namespace Un.EntityFramework.ReadWriteContext.Tests
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Text)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.HasOne(d => d.Question)
                      .WithMany(p => p.Answers)
                      .HasForeignKey(d => d.QuestionId);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Text)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.HasOne(d => d.CorrectAnswer)
                      .WithMany(p => p.QuestionNavigation)
                      .HasForeignKey(d => d.CorrectAnswerId);

                entity.HasOne(d => d.Quiz)
                      .WithMany(p => p.Question)
                      .HasForeignKey(d => d.QuizId);
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
