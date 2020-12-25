namespace RentCars.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RentCars.Data.Common.Models;
    using RentCars.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<CarRentDays> CarRentDays { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            builder.Entity<Car>().
               HasMany(x => x.RentDays).
               WithOne(x => x.Car).
               HasForeignKey(k => k.CarId);

            builder.Entity<ApplicationUser>().
               HasMany(x => x.Orders).
               WithOne(x => x.User).
               HasForeignKey(k => k.ApplicationUserId).
               OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Car>().
             HasMany(x => x.RentDays).
             WithOne(x => x.Car).
             HasForeignKey(k => k.CarId).
             OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Location>().HasData(new Location { Id = 1, Name = "Sofia, Airport Terminal 1" });
            builder.Entity<Location>().HasData(new Location { Id = 2, Name = "Sofia, Airport Terminal 2" });
            builder.Entity<Location>().HasData(new Location { Id = 3, Name = "Plovdiv, Novotel" });
            builder.Entity<Location>().HasData(new Location { Id = 4, Name = "Stara Zagora, Stadium Beroe" });
            builder.Entity<Location>().HasData(new Location { Id = 5, Name = "Shumen, Post Office" });
            builder.Entity<Location>().HasData(new Location { Id = 6, Name = "Burgas, Post Office" });
            builder.Entity<Location>().HasData(new Location { Id = 7, Name = "Varna, Dolphinarium" });
            builder.Entity<Location>().HasData(new Location { Id = 8, Name = "Pleven, Hotel Bulgaria" });
            builder.Entity<Location>().HasData(new Location { Id = 9, Name = "Sozopol, Old City Post Office" });
            builder.Entity<Location>().HasData(new Location { Id = 10, Name = "Lovech, Varosha Gallery" });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 1,
                Model = "Mazda 6",
                Description = "The 2020 Mazda 6 doesn’t make a bad step. This year, the mid-size sedan returns mostly unchanged from last year’s version, albeit with standard safety hardware that was optional last year.",
                GearType = Models.Enums.GearType.Automatic,
                LocationId = 1,
                PricePerDay = 60,
                Image = "https://www.mazdausa.com/siteassets/vehicles/2020/mazda6/trims/gt/2020-mazda6-gt-soul-red-crystal.png",
                Year = 2020,
                Speed = 180,
            });

            builder.Entity<Car>().HasData(new Car
            {
                Id = 2,
                Model = "Mazda 3",
                Description = "The Mazda 3 is a family hatch, not an SUV or a crossover or pretending to be something it’s not. These days you don’t go to the expense of creating a whole new platform from the ground up without doing more than one thing with it, though, so expect more to come from the 3’s box of bits.",
                GearType = Models.Enums.GearType.Manual,
                LocationId = 1,
                PricePerDay = 39,
                Image = "https://www.pngitem.com/pimgs/m/610-6106111_2020-mazda-3-black-hd-png-download.png",
                Year = 2020,
                Speed = 180,
            });

            builder.Entity<Car>().HasData(new Car
            {
                Id = 3,
                Model = "BMW X7",
                Description = "The X7 by contrast is about luxury. It takes themes from the facelifted 7 Series and the 8er, to make BMW’s three-flagship fleet. They want us to see this top-end trio as a separate high-end luxury series.",
                GearType = Models.Enums.GearType.Automatic,
                LocationId = 1,
                PricePerDay = 80,
                Image = "https://images.hgmsites.net/hug/2020-bmw-x7_100728938_h.jpg",
                Year = 2020,
                Speed = 155,
            });

            builder.Entity<Car>().HasData(new Car
            {
                Id = 4,
                Model = "Tesla Model X",
                Description = "The big Tesla. The one that seats seven and has every other firm on the planet that builds premium SUVs in a bit of a panic. Underneath, the architecture is similar to the Model S (massive battery pack, electric motors, aluminium chassis), but all Model X are four-wheel drive, so have twin electric motors, one driving each axle. ",
                GearType = Models.Enums.GearType.Automatic,
                LocationId = 1,
                PricePerDay = 80,
                Image = "https://www.autocar.co.uk/sites/autocar.co.uk/files/images/car-reviews/first-drives/legacy/1-tesla-model-x-long-range-2019-uk-fd-hero-front.jpg",
                Year = 2019,
                Speed = 245,
            });

            builder.Entity<Car>().HasData(new Car
            {
                Id = 5,
                Model = "Toyota Yaris iA",
                Description = "Developed by Mazda, launched by Scion, and now marketed as a Toyota, the Yaris iA proves that subcompact cars can delight. A different model from the Toyota Yaris hatchback, the frisky iA sedan stands out in a segment filled with insubstantial models. It feels refined for this entry-level class, with a smooth and willing four-cylinder engine, slick six-speed automatic transmission, and relatively compliant ride.",
                GearType = Models.Enums.GearType.Automatic,
                LocationId = 1,
                PricePerDay = 40,
                Image = "https://media.ed.edmunds-media.com/toyota/yaris/2019/oem/2019_toyota_yaris_sedan_xle_fq_oem_1_1600.jpg",
                Year = 2020,
                Speed = 180,
            });

            builder.Entity<Car>().HasData(new Car
            {
                Id = 6,
                Model = "Kia Optima",
                Description = "The Optima is a vehicle that delivers all of these virtues in a stylish, value-laden package that’s filled with features usually found on pricier cars. With outstanding reliability and extensive warranty coverage, savvy sedan shoppers should take this recently redesigned car for a test drive.",
                GearType = Models.Enums.GearType.Automatic,
                LocationId = 2,
                PricePerDay = 36,
                Image = "https://i.dir-i.net/CMS/2019/12/28/k/5f_kzmt31.jpg",
                Year = 2020,
                Speed = 200,
            });

            builder.Entity<Car>().HasData(new Car
            {
                Id = 7,
                Model = "Subaru Forester",
                Description = "The Subaru Forester sets the standard for small SUVs, combining relatively roomy packaging, fuel efficiency, solid reliability, and easy access. Large windows and a boxy shape maximize room for passengers and gear in sharp contrast to style trends exhibited by competitors that compromise practicality. ",
                GearType = Models.Enums.GearType.Manual,
                LocationId = 3,
                PricePerDay = 55,
                Image = "https://cars.usnews.com/static/images/Auto/custom/14103/2020_Subaru_Forester_2.jpg",
                Year = 2020,
                Speed = 230,
            });
            builder.Entity<Car>().HasData(new Car
            {
                Id = 8,
                Model = "Honda RidgeLine",
                Description = "The 2020 Honda Ridgeline, the second generation of Honda's innovative, one-of-a-kind pickup truck with innovations such as the In-Bed Trunk and world's first Truck Bed Audio System was chosen by a panel of expert automotive journalists as the 2020 North America Truck of the Year. ",
                GearType = Models.Enums.GearType.Manual,
                LocationId = 4,
                PricePerDay = 20,
                Image = "https://blogmedia.dealerfire.com/wp-content/uploads/sites/1074/2019/12/2020-Honda-Ridgeline-exterior-side-shot-with-Obsidian-Blue-Pearl-paint-color-parked-on-a-beach-line-of-gravel-and-sand-next-to-the-ocean_o.jpg",
                Year = 2020,
                Speed = 220,
            });

            builder.Entity<Car>().HasData(new Car
            {
                Id = 9,
                Model = "Opel Insignia",
                Description = "The Insignia was the flagship of the Opel range and offered as a medium-large sedan and station wagon. Passenger space is good, with almost as much legroom, but slightly less width in the back seat than Commodore and Falcon.",
                GearType = Models.Enums.GearType.Manual,
                LocationId = 5,
                PricePerDay = 15,
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq_MfOl8X2QtiGoqH9SOVrrml25pw6g3Rk5w&usqp=CAU",
                Year = 2020,
                Speed = 200,
            });

            builder.Entity<Car>().HasData(new Car
            {
                Id = 10,
                Model = "Chevrolet Impala",
                Description = "The Impala continues to reign as the leading large sedan. Slide behind the wheel and you can see why. Roomy, supportive seats put you in the perfect position to access the intuitive controls. Despite its prodigious size, the Impala’s handling is responsive and secure.",
                GearType = Models.Enums.GearType.Automatic,
                LocationId = 6,
                PricePerDay = 12,
                Image = "https://banner2.cleanpng.com/20180410/xrw/kisspng-2017-chevrolet-impala-2018-chevrolet-impala-chevro-chevrolet-5accd70885ac83.6020416415233738325475.jpg",
                Year = 2020,
                Speed = 200,
            });

            builder.Entity<Car>().HasData(new Car
            {
                Id = 11,
                Model = "TOYOTA RAV4 Hybrid",
                Description = "No matter which new hybrid SUV model you choose, you’ll enjoy distinct styling, flexible design, and impressive fuel economy. Full-size Toyota SUV hybrids deliver roomy versatility, ample seating capacity and cargo space, easy-to-read controls, and countless thoughtful amenities for your active and growing family. For a new hybrid SUV with even more maneuverability, check out a versatile Toyota hybrid crossover SUV instead. In addition to ample cargo space, expect competitive fuel efficiency and Toyota quality in every hybrid SUV we offer. Help blaze your trail with less fuel and more fun. Find the best hybrid SUV for your next adventure.",
                GearType = Models.Enums.GearType.Automatic,
                LocationId = 7,
                PricePerDay = 39,
                Image = "https://media.ed.edmunds-media.com/toyota/rav4-hybrid/2019/oem/2019_toyota_rav4-hybrid_4dr-suv_limited_fq_oem_7_815.jpg",
                Year = 2020,
                Speed = 280,
            });

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
