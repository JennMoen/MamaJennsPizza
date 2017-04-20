using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MamaJennsPizza.Data.Migrations
{
    public partial class AddedUserKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_AspNetUsers_ApplicationUserId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_ApplicationUserId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Pizzas");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pizzas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_UserId",
                table: "Pizzas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_AspNetUsers_UserId",
                table: "Pizzas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_AspNetUsers_UserId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_UserId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pizzas");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Pizzas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ApplicationUserId",
                table: "Pizzas",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_AspNetUsers_ApplicationUserId",
                table: "Pizzas",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
