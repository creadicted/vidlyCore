using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VidlyCore.Data.Migrations
{
    public partial class PopulateGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Family')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
