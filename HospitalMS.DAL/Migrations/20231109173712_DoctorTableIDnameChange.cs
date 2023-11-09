using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DoctorTableIDnameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctor",
                newName: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Doctor",
                newName: "Id");
        }
    }
}
