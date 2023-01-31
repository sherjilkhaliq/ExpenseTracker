using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_expenseCategoroies_expenseCategoroiesExpenseCategoryID",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "IX_expenses_expenseCategoroiesExpenseCategoryID",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "expenseCategoroiesExpenseCategoryID",
                table: "expenses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "expenseCategoroiesExpenseCategoryID",
                table: "expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_expenses_expenseCategoroiesExpenseCategoryID",
                table: "expenses",
                column: "expenseCategoroiesExpenseCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_expenseCategoroies_expenseCategoroiesExpenseCategoryID",
                table: "expenses",
                column: "expenseCategoroiesExpenseCategoryID",
                principalTable: "expenseCategoroies",
                principalColumn: "ExpenseCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
