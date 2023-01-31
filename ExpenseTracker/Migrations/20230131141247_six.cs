using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class six : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_expenses",
                table: "expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expenseCategoroies",
                table: "expenseCategoroies");

            migrationBuilder.RenameTable(
                name: "expenses",
                newName: "tbl_Expense");

            migrationBuilder.RenameTable(
                name: "expenseCategoroies",
                newName: "tbl_ExpenseCategoroy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Expense",
                table: "tbl_Expense",
                column: "ExpenseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_ExpenseCategoroy",
                table: "tbl_ExpenseCategoroy",
                column: "ExpenseCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_ExpenseCategoroy",
                table: "tbl_ExpenseCategoroy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Expense",
                table: "tbl_Expense");

            migrationBuilder.RenameTable(
                name: "tbl_ExpenseCategoroy",
                newName: "expenseCategoroies");

            migrationBuilder.RenameTable(
                name: "tbl_Expense",
                newName: "expenses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenseCategoroies",
                table: "expenseCategoroies",
                column: "ExpenseCategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenses",
                table: "expenses",
                column: "ExpenseID");
        }
    }
}
