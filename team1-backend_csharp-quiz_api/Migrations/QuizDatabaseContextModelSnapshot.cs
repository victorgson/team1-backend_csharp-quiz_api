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
                            Id = new Guid("eb11e3d2-a64f-43c3-bee8-12824d8e788c"),
                            Category = "Sport",
                            Language = "Swedish",
                            QuestionString = "Fråga 1"
                        },
                        new
                        {
                            Id = new Guid("e028a100-3497-405e-8943-a15c4b193b08"),
                            Category = "Film",
                            Language = "Swedish",
                            QuestionString = "Fråga 2"
                        },
                        new
                        {
                            Id = new Guid("cee56094-cea4-4d51-83bf-302a4ec3d41b"),
                            Category = "Serier",
                            Language = "Swedish",
                            QuestionString = "Fråga 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
