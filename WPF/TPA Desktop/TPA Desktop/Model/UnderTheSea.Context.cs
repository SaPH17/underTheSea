﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPA_Desktop.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UnderTheSeaEntities : DbContext
    {
        public UnderTheSeaEntities()
            : base("name=UnderTheSeaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Advertisement> Advertisement { get; set; }
        public virtual DbSet<AttractionOrRide> AttractionOrRide { get; set; }
        public virtual DbSet<CleaningLog> CleaningLog { get; set; }
        public virtual DbSet<CleaningSchedule> CleaningSchedule { get; set; }
        public virtual DbSet<ConstructionProgress> ConstructionProgress { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DetailRestaurantTransaction> DetailRestaurantTransaction { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<HotelTransaction> HotelTransaction { get; set; }
        public virtual DbSet<HRRequest> HRRequest { get; set; }
        public virtual DbSet<Idea> Idea { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<MaintenanceLog> MaintenanceLog { get; set; }
        public virtual DbSet<MaintenanceSchedule> MaintenanceSchedule { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<PersonalRequest> PersonalRequest { get; set; }
        public virtual DbSet<PurchaseLog> PurchaseLog { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<RestaurantTransaction> RestaurantTransaction { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketTransaction> TicketTransaction { get; set; }
    }
}
