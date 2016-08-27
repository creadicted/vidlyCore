using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VidlyCore.Data.Migrations
{
    public partial class PopulateMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MembershipType (SignUpFee, DurationInMonths, DiscountRate) VALUES (0, 0, 0)");
            migrationBuilder.Sql("INSERT INTO MembershipType (SignUpFee, DurationInMonths, DiscountRate) VALUES (30, 1, 10)");
            migrationBuilder.Sql("INSERT INTO MembershipType (SignUpFee, DurationInMonths, DiscountRate) VALUES (90, 3, 15)");
            migrationBuilder.Sql("INSERT INTO MembershipType (SignUpFee, DurationInMonths, DiscountRate) VALUES (300, 12, 20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MembershipType WHERE SignUpFee = 0 AND DurationInMonths = 0");
            migrationBuilder.Sql("DELETE FROM MembershipType WHERE SignUpFee = 30 AND DurationInMonths = 1");
            migrationBuilder.Sql("DELETE FROM MembershipType WHERE SignUpFee = 90 AND DurationInMonths = 3");
            migrationBuilder.Sql("DELETE FROM MembershipType WHERE SignUpFee = 300 AND DurationInMonths = 12");
        }
    }
}
