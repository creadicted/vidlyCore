using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VidlyCore.Data.Migrations
{
    public partial class AddMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountRate = table.Column<byte>(nullable: false),
                    DurationInMonth = table.Column<byte>(nullable: false),
                    SignUpFee = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.AddColumn<byte>(
                name: "MembershipTypeId",
                table: "Customers",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "MembershipType");
        }
    }
}
