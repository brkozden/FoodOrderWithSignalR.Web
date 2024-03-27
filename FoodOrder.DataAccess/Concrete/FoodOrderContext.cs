﻿using FoodOrder.Entity.Entities;
using FoodOrder.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.DataAccess.Concrete
{
    public class FoodOrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-ELRUEBF;initial Catalog=FoodOrderDb;integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyCase> MoneyCases { get; set; }
        public DbSet<RestaurantTable> RestaurantTables { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Notification> Notifications { get; set; }


    }
}

