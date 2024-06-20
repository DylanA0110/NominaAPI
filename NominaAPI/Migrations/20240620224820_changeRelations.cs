using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deductions_Employees_EmployeeID",
                table: "Deductions");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Employees_EmployeeID",
                table: "Incomes");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Incomes",
                newName: "PayrollId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_EmployeeID",
                table: "Incomes",
                newName: "IX_Incomes_PayrollId");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Deductions",
                newName: "PayrollId");

            migrationBuilder.RenameIndex(
                name: "IX_Deductions_EmployeeID",
                table: "Deductions",
                newName: "IX_Deductions_PayrollId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deductions_Payrolls_PayrollId",
                table: "Deductions",
                column: "PayrollId",
                principalTable: "Payrolls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Payrolls_PayrollId",
                table: "Incomes",
                column: "PayrollId",
                principalTable: "Payrolls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deductions_Payrolls_PayrollId",
                table: "Deductions");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Payrolls_PayrollId",
                table: "Incomes");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                table: "Incomes",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_PayrollId",
                table: "Incomes",
                newName: "IX_Incomes_EmployeeID");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                table: "Deductions",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Deductions_PayrollId",
                table: "Deductions",
                newName: "IX_Deductions_EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Deductions_Employees_EmployeeID",
                table: "Deductions",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Employees_EmployeeID",
                table: "Incomes",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
