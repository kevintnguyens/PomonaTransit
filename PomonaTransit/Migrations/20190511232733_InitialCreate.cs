using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomonaTransit.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buses",
                columns: table => new
                {
                    BusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buses", x => x.BusID);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverName = table.Column<string>(nullable: false),
                    DriverTelepohneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverName);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    StopNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StopAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.StopNumber);
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    TripNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartLocationName = table.Column<string>(nullable: true),
                    DestinationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.TripNumber);
                });

            migrationBuilder.CreateTable(
                name: "ActualTripStopInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripNumber = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ScheduledStartTime = table.Column<DateTime>(nullable: false),
                    StopNumber = table.Column<int>(nullable: true),
                    SecheduledArrivalTime = table.Column<DateTime>(nullable: false),
                    ActualStartTime = table.Column<DateTime>(nullable: false),
                    ActualArrivalTime = table.Column<DateTime>(nullable: false),
                    NumberOfPassngerIn = table.Column<int>(nullable: false),
                    NumberOfPassengerOut = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualTripStopInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActualTripStopInfos_Stops_StopNumber",
                        column: x => x.StopNumber,
                        principalTable: "Stops",
                        principalColumn: "StopNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActualTripStopInfos_trips_TripNumber",
                        column: x => x.TripNumber,
                        principalTable: "trips",
                        principalColumn: "TripNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tripOfferings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripNumber = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ScheduledStartTime = table.Column<DateTime>(nullable: false),
                    SecheduledArrivalTime = table.Column<DateTime>(nullable: false),
                    DriverName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tripOfferings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tripOfferings_Drivers_DriverName",
                        column: x => x.DriverName,
                        principalTable: "Drivers",
                        principalColumn: "DriverName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tripOfferings_trips_TripNumber",
                        column: x => x.TripNumber,
                        principalTable: "trips",
                        principalColumn: "TripNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripStopInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripNumber = table.Column<int>(nullable: true),
                    StopNumber = table.Column<int>(nullable: true),
                    SequenceNumber = table.Column<int>(nullable: false),
                    DrivingTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripStopInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TripStopInfos_Stops_StopNumber",
                        column: x => x.StopNumber,
                        principalTable: "Stops",
                        principalColumn: "StopNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripStopInfos_trips_TripNumber",
                        column: x => x.TripNumber,
                        principalTable: "trips",
                        principalColumn: "TripNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualTripStopInfos_StopNumber",
                table: "ActualTripStopInfos",
                column: "StopNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ActualTripStopInfos_TripNumber",
                table: "ActualTripStopInfos",
                column: "TripNumber");

            migrationBuilder.CreateIndex(
                name: "IX_tripOfferings_DriverName",
                table: "tripOfferings",
                column: "DriverName");

            migrationBuilder.CreateIndex(
                name: "IX_tripOfferings_TripNumber",
                table: "tripOfferings",
                column: "TripNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TripStopInfos_StopNumber",
                table: "TripStopInfos",
                column: "StopNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TripStopInfos_TripNumber",
                table: "TripStopInfos",
                column: "TripNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualTripStopInfos");

            migrationBuilder.DropTable(
                name: "buses");

            migrationBuilder.DropTable(
                name: "tripOfferings");

            migrationBuilder.DropTable(
                name: "TripStopInfos");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "trips");
        }
    }
}
