﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ThAmCo.Events.Data.Migrations
{
    [DbContext(typeof(EventsDbContext))]
    [Migration("20241212150154_AddIsAttendingToGuestBooking")]
    partial class AddIsAttendingToGuestBooking
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("ThAmCo.Events.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("VenueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2025, 1, 12, 15, 1, 53, 832, DateTimeKind.Local).AddTicks(8930),
                            EventType = "Gala",
                            IsCancelled = false,
                            Title = "Annual Gala"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2025, 2, 12, 15, 1, 53, 832, DateTimeKind.Local).AddTicks(8977),
                            EventType = "Conference",
                            IsCancelled = false,
                            Title = "Tech Summit"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "john@example.com",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jane@example.com",
                            Name = "Jane Smith"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Models.GuestBooking", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAttending")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventId", "GuestId");

                    b.HasIndex("GuestId");

                    b.ToTable("GuestBookings");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            GuestId = 1,
                            Id = 0,
                            IsAttending = true
                        },
                        new
                        {
                            EventId = 1,
                            GuestId = 2,
                            Id = 0,
                            IsAttending = true
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFirstAider")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StaffMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsFirstAider = true,
                            Name = "Alice Johnson",
                            Role = "Coordinator"
                        },
                        new
                        {
                            Id = 2,
                            IsFirstAider = false,
                            Name = "Bob Brown",
                            Role = "Security"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Staffing", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StaffId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventId", "StaffId");

                    b.HasIndex("StaffId");

                    b.ToTable("Staffings");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            StaffId = 1,
                            Id = 0
                        },
                        new
                        {
                            EventId = 1,
                            StaffId = 2,
                            Id = 0
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Models.GuestBooking", b =>
                {
                    b.HasOne("ThAmCo.Events.Models.Event", "Event")
                        .WithMany("GuestBookings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThAmCo.Events.Models.Guest", "Guest")
                        .WithMany("GuestBookings")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Staffing", b =>
                {
                    b.HasOne("ThAmCo.Events.Models.Event", "Event")
                        .WithMany("Staffings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThAmCo.Events.Models.Staff", "Staff")
                        .WithMany("Staffings")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Event", b =>
                {
                    b.Navigation("GuestBookings");

                    b.Navigation("Staffings");
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Guest", b =>
                {
                    b.Navigation("GuestBookings");
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Staff", b =>
                {
                    b.Navigation("Staffings");
                });
#pragma warning restore 612, 618
        }
    }
}