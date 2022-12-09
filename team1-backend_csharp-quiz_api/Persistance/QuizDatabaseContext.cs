using System;
using System.Data;
using team1_backend_csharp_quiz_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace team1_backend_csharp_quiz_api.Persistance
{
    public class QuizDatabaseContext : DbContext
    {
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Question> Question { get; set; }

        public QuizDatabaseContext(DbContextOptions<QuizDatabaseContext> options) : base(options)
        {
        }

        public QuizDatabaseContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=quiz.db");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            CreateAnswerModel(modelBuilder);
            CreateQuestionModel(modelBuilder);
        }

        //exempel
        //private void CreatePersonsModel(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Person>(entity =>
        //    {
        //        entity.HasKey(e => e.Id);
        //        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        //        entity.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
        //        entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
        //        entity.Property(e => e.RoleId).IsRequired();
        //        entity.HasOne(e => e.Role).WithMany(e => e.Persons).HasForeignKey(e => e.RoleId);
        //    });
        //}

        private void CreateAnswerModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasIndex(answer => answer.AnswerString)
            .IsUnique(false);
            //modelBuilder.Entity<Answer>()
            //    .HasOne<Role>(person => person.Role);

        }

        private void CreateQuestionModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasIndex(question => question.QuestionString)
                .IsUnique(true);
        }
    }
}
