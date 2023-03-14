﻿// <auto-generated />
using System;
using Election.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Election.Migrations
{
    [DbContext(typeof(ElectionContext))]
    [Migration("20221209151725_Q21")]
    partial class Q21
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Election.Candidate", b =>
                {
                    b.Property<uint>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("First")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Last")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<uint>("PartyId")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("RidingId")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CandidateId");

                    b.HasIndex("PartyId");

                    b.HasIndex("RidingId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Election.Party", b =>
                {
                    b.Property<uint>("PartyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("PartyEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PartyName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("PartyWebsite")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PartyId");

                    b.ToTable("Parties");
                });

            modelBuilder.Entity("Election.Province", b =>
                {
                    b.Property<uint>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ShortCode")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("ProvinceId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Election.Riding", b =>
                {
                    b.Property<uint>("RidingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<uint>("ProvinceId")
                        .HasColumnType("int unsigned");

                    b.Property<string>("RidingName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("RidingId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Ridings");
                });

            modelBuilder.Entity("Election.Vote", b =>
                {
                    b.Property<uint>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<uint>("CandidateId")
                        .HasColumnType("int unsigned");

                    b.Property<DateTime>("CastTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("VoteId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Election.Candidate", b =>
                {
                    b.HasOne("Election.Party", "Party")
                        .WithMany("Candidates")
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Election.Riding", "Riding")
                        .WithMany("Candidates")
                        .HasForeignKey("RidingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Party");

                    b.Navigation("Riding");
                });

            modelBuilder.Entity("Election.Riding", b =>
                {
                    b.HasOne("Election.Province", "Province")
                        .WithMany("Ridings")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Election.Vote", b =>
                {
                    b.HasOne("Election.Candidate", "Candidate")
                        .WithMany("Votes")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("Election.Candidate", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("Election.Party", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("Election.Province", b =>
                {
                    b.Navigation("Ridings");
                });

            modelBuilder.Entity("Election.Riding", b =>
                {
                    b.Navigation("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}
