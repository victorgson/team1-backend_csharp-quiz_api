using System;
using System.Data;
using team1_backend_csharp_quiz_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace team1_backend_csharp_quiz_api.Persistance
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
            //modelBuilder.Entity<Answer>(entity =>
            //{
            
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //    //entity.Property(e => e.QuestionId).IsRequired();
            //    entity.HasOne<Question>().WithOne().HasForeignKey(p => p.)
            
      
           
            //});

            modelBuilder.Entity<Answer>()
      
                .HasOne<Question>()
                .WithMany()
                .HasForeignKey(a => a.QuestionId);

        }

        private void CreateQuestionModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(q => q.Id).IsUnique(true);

                
          
                // .HasIndex(question => question.QuestionString)
                //.IsUnique(true);
            });
                
               
        }
    }
}
