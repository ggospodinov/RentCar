using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCars.Data.Migrations
{
    public partial class AddCarsAddAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    InUse = table.Column<bool>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    GearType = table.Column<int>(nullable: false),
                    PricePerDay = table.Column<decimal>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarRentDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CarId = table.Column<int>(nullable: false),
                    RentDate = table.Column<DateTime>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarRentDays_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CarId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    RentStart = table.Column<DateTime>(nullable: false),
                    RentEnd = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PickUpLocationId = table.Column<int>(nullable: false),
                    ReturnLocationId = table.Column<int>(nullable: false),
                    ReviewId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Locations_PickUpLocationId",
                        column: x => x.PickUpLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Locations_ReturnLocationId",
                        column: x => x.ReturnLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Sofia, Airport Terminal 1" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Sofia, Airport Terminal 2" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Plovdiv, Novotel" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Stara Zagora, Stadium Beroe" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Shumen, Post Office" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Burgas, Post Office" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Varna, Dolphinarium" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Pleven, Hotel Bulgaria" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Sozopol, Old City Post Office" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Lovech, Varosha Gallery" },
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "GearType", "Image", "InUse", "IsDeleted", "LocationId", "Model", "ModifiedOn", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The 2020 Mazda 6 doesn’t make a bad step. This year, the mid-size sedan returns mostly unchanged from last year’s version, albeit with standard safety hardware that was optional last year.", 2, "https://www.mazdausa.com/siteassets/vehicles/2020/mazda6/trims/gt/2020-mazda6-gt-soul-red-crystal.png", true, false, 1, "Mazda 6", null, 60m, 2020 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Mazda 3 is a family hatch, not an SUV or a crossover or pretending to be something it’s not. These days you don’t go to the expense of creating a whole new platform from the ground up without doing more than one thing with it, though, so expect more to come from the 3’s box of bits.", 1, "https://www.pngitem.com/pimgs/m/610-6106111_2020-mazda-3-black-hd-png-download.png", true, false, 1, "Mazda 3", null, 39m, 2020 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The X7 by contrast is about luxury. It takes themes from the facelifted 7 Series and the 8er, to make BMW’s three-flagship fleet. They want us to see this top-end trio as a separate high-end luxury series.", 2, "https://images.hgmsites.net/hug/2020-bmw-x7_100728938_h.jpg", true, false, 1, "BMW X7", null, 80m, 2020 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The big Tesla. The one that seats seven and has every other firm on the planet that builds premium SUVs in a bit of a panic. Underneath, the architecture is similar to the Model S (massive battery pack, electric motors, aluminium chassis), but all Model X are four-wheel drive, so have twin electric motors, one driving each axle. ", 2, "https://www.autocar.co.uk/sites/autocar.co.uk/files/images/car-reviews/first-drives/legacy/1-tesla-model-x-long-range-2019-uk-fd-hero-front.jpg", true, false, 1, "Tesla Model X", null, 80m, 2019 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Developed by Mazda, launched by Scion, and now marketed as a Toyota, the Yaris iA proves that subcompact cars can delight. A different model from the Toyota Yaris hatchback, the frisky iA sedan stands out in a segment filled with insubstantial models. It feels refined for this entry-level class, with a smooth and willing four-cylinder engine, slick six-speed automatic transmission, and relatively compliant ride.", 2, "https://media.ed.edmunds-media.com/toyota/yaris/2019/oem/2019_toyota_yaris_sedan_xle_fq_oem_1_1600.jpg", true, false, 1, "Toyota Yaris iA", null, 40m, 2020 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Optima is a vehicle that delivers all of these virtues in a stylish, value-laden package that’s filled with features usually found on pricier cars. With outstanding reliability and extensive warranty coverage, savvy sedan shoppers should take this recently redesigned car for a test drive.", 2, "https://res.cloudinary.com/dis59vn8s/image/upload/v1561931416/Kia-02-17_c1aqgf.jpghttps://cdcssl.ibsrv.net/cimg/www.carsdirect.com/680x382_85/405/15368_2020_Optima-575405.jpg", true, false, 2, "Kia Optima", null, 36m, 2020 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Subaru Forester sets the standard for small SUVs, combining relatively roomy packaging, fuel efficiency, solid reliability, and easy access. Large windows and a boxy shape maximize room for passengers and gear in sharp contrast to style trends exhibited by competitors that compromise practicality. ", 1, "https://cars.usnews.com/static/images/Auto/custom/14103/2020_Subaru_Forester_2.jpg", true, false, 3, "Subaru Forester", null, 55m, 2020 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The 2020 Honda Ridgeline, the second generation of Honda's innovative, one-of-a-kind pickup truck with innovations such as the In-Bed Trunk and world's first Truck Bed Audio System was chosen by a panel of expert automotive journalists as the 2020 North America Truck of the Year. ", 1, "https://blogmedia.dealerfire.com/wp-content/uploads/sites/1074/2019/12/2020-Honda-Ridgeline-exterior-side-shot-with-Obsidian-Blue-Pearl-paint-color-parked-on-a-beach-line-of-gravel-and-sand-next-to-the-ocean_o.jpg", true, false, 4, "Honda RidgeLine", null, 20m, 2020 },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Insignia was the flagship of the Opel range and offered as a medium-large sedan and station wagon. Passenger space is good, with almost as much legroom, but slightly less width in the back seat than Commodore and Falcon.", 1, "https://cdn.statically.io/img/avtotachki.com/wp-content/uploads/2020/05/opel-insignia-grand-sport-2-0-cdti-170-l-s-6-meh-1.png?quality=90&f=auto", true, false, 5, "Opel Insignia", null, 15m, 2020 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Impala continues to reign as the leading large sedan. Slide behind the wheel and you can see why. Roomy, supportive seats put you in the perfect position to access the intuitive controls. Despite its prodigious size, the Impala’s handling is responsive and secure.", 2, "https://cars.usnews.com/static/images/Auto/izmo/i55706568/2018_chevrolet_impala_angularfront.jpg", true, false, 6, "Chevrolet Impala", null, 12m, 2020 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "No matter which new hybrid SUV model you choose, you’ll enjoy distinct styling, flexible design, and impressive fuel economy. Full-size Toyota SUV hybrids deliver roomy versatility, ample seating capacity and cargo space, easy-to-read controls, and countless thoughtful amenities for your active and growing family. For a new hybrid SUV with even more maneuverability, check out a versatile Toyota hybrid crossover SUV instead. In addition to ample cargo space, expect competitive fuel efficiency and Toyota quality in every hybrid SUV we offer. Help blaze your trail with less fuel and more fun. Find the best hybrid SUV for your next adventure.", 2, "https://media.ed.edmunds-media.com/toyota/rav4-hybrid/2019/oem/2019_toyota_rav4-hybrid_4dr-suv_limited_fq_oem_7_815.jpg", true, false, 7, "TOYOTA RAV4 Hybrid", null, 39m, 2020 },
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentDays_CarId",
                table: "CarRentDays",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentDays_IsDeleted",
                table: "CarRentDays",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IsDeleted",
                table: "Cars",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_LocationId",
                table: "Cars",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_IsDeleted",
                table: "Locations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickUpLocationId",
                table: "Orders",
                column: "PickUpLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReturnLocationId",
                table: "Orders",
                column: "ReturnLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReviewId",
                table: "Orders",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CarId",
                table: "Reviews",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IsDeleted",
                table: "Reviews",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentDays");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
