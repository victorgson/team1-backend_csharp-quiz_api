﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using team1_backend_csharp_quiz_api.Persistance;

#nullable disable

namespace team1backendcsharpquizapi.Migrations
{
    [DbContext(typeof(QuizDatabaseContext))]
    partial class QuizDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("team1_backend_csharp_quiz_api.Entities.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AnswerString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isCorrectAnswer")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("team1_backend_csharp_quiz_api.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("QuestionString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f4ddd58f-97b9-49b2-8617-07901860dd99"),
                            Category = "Sport",
                            Language = "Swedish",
                            QuestionString = "Fråga 1"
                        },
                        new
                        {
                            Id = new Guid("5a346a66-eeec-48f0-a1c8-e8a863374551"),
                            Category = "Film",
                            Language = "Swedish",
                            QuestionString = "Fråga 2"
                        },
                        new
                        {
                            Id = new Guid("f6609ae1-ddf3-4969-af45-aa80ebd3f30c"),
                            Category = "Serier",
                            Language = "Swedish",
                            QuestionString = "Fråga 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
