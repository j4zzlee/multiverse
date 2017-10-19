﻿// <auto-generated />
using bc.cores.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace bc.multiverse.edu.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171019172612_UpdateUserSchemaMaxLength")]
    partial class UpdateUserSchemaMaxLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bc.cores.models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("bc.cores.models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(256);

                    b.Property<string>("LastName")
                        .HasMaxLength(256);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(256);

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayType");

                    b.Property<Guid?>("PhotoId");

                    b.Property<Guid>("QuestionId");

                    b.Property<Guid?>("SoundId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Audio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Length");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Audio");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CreatedAt");

                    b.Property<Guid>("CreatedById");

                    b.Property<string>("Description");

                    b.Property<int?>("MaxQuestionsToPlay");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Visibility");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CreatedAt");

                    b.Property<Guid>("CreatedById");

                    b.Property<string>("Description");

                    b.Property<int?>("MaxQuestionsToPlay");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Visibility");

                    b.HasKey("Id");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Height");

                    b.Property<string>("Name");

                    b.Property<double>("Width");

                    b.HasKey("Id");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<int>("DisplayType");

                    b.Property<Guid?>("PhotoId");

                    b.Property<int>("QuestionType");

                    b.Property<Guid?>("SoundId");

                    b.Property<string>("Value");

                    b.Property<Guid?>("VideoId");

                    b.Property<int>("Visibility");

                    b.HasKey("Id");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Rels.ExamCourseRel", b =>
                {
                    b.Property<Guid>("ExamId");

                    b.Property<Guid>("CourseId");

                    b.HasKey("ExamId", "CourseId");

                    b.ToTable("ExamCourseRel");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Rels.ExamQuestionRel", b =>
                {
                    b.Property<Guid>("ExamId");

                    b.Property<Guid>("QuestionId");

                    b.HasKey("ExamId", "QuestionId");

                    b.ToTable("ExamQuestionRel");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Scores.UserCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CorrectAnswers");

                    b.Property<Guid>("CourseId");

                    b.Property<long>("CreatedAt");

                    b.Property<int>("ExamType");

                    b.Property<double>("Score");

                    b.Property<int>("TotalAnswers");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "CourseId", "CreatedAt");

                    b.ToTable("UserCourse");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Scores.UserCourseAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AnswerId");

                    b.Property<bool>("IsCorrect");

                    b.Property<Guid>("QuestionId");

                    b.Property<Guid>("UserCourseId");

                    b.HasKey("Id");

                    b.ToTable("UserCourseAnswer");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Scores.UserExam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CorrectAnswers");

                    b.Property<long>("CreatedAt");

                    b.Property<Guid>("ExamId");

                    b.Property<int>("ExamType");

                    b.Property<double>("Score");

                    b.Property<int>("TotalAnswers");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "ExamId", "CreatedAt");

                    b.ToTable("UserExam");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Scores.UserExamAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AnswerId");

                    b.Property<bool>("IsCorrect");

                    b.Property<Guid>("QuestionId");

                    b.Property<Guid>("UserExamId");

                    b.HasKey("Id");

                    b.ToTable("UserExamAnswer");
                });

            modelBuilder.Entity("bc.cores.models.Exams.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Height");

                    b.Property<string>("Name");

                    b.Property<double>("Width");

                    b.HasKey("Id");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("bc.cores.models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("bc.cores.models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("bc.cores.models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("bc.cores.models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("bc.cores.models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("bc.cores.models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
