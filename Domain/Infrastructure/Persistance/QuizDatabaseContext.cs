using System;
using System.Data;
using team1_backend_csharp_quiz_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace team1_backend_csharp_quiz_api.Infrastructure.Persistance
{
    public class QuizDatabaseContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }

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




        private void CreateAnswerModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne<Question>().WithMany().HasForeignKey(q => q.QuestionId);

            });

        }


        private void CreateQuestionModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasData(
                    new Question
                    {
                        Language = "Swedish",
                        QuestionString = "Fråga 1",
                        Category = "Sport"
                    },
                    new Question
                    {
                        Language = "Swedish",
                        QuestionString = "Fråga 2",
                        Category = "Film"
                    },
                    new Question
                    {
                        Language = "Swedish",
                        QuestionString = "Fråga 3",
                        Category = "Serier"
                    }
                    );
            });
        }

            
    }
}
