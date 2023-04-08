using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_T3.Persistence.Migrations
{
    public partial class initial12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "3837a14a-fcce-4c03-9563-e9ccd59ef491");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "employee",
                column: "ConcurrencyStamp",
                value: "b079724f-df9e-4cd3-be2e-4a0352b1cfc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "projectmanager",
                column: "ConcurrencyStamp",
                value: "8fbe53a0-0fab-4eba-ac4e-d580f8c37bcb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59323082791",
                columns: new[] { "Birthday", "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp", "StartDateOfWork", "UpdatedDate" },
                values: new object[] { new DateTime(1989, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "b46c74ca-d0e0-4fc3-a729-1fc6cc17ce30", new DateTime(2023, 4, 8, 10, 39, 3, 499, DateTimeKind.Local).AddTicks(6702), "AQAAAAEAACcQAAAAEEapZkNkVHPHcMPc+r1ho9CSxOiRKvCk80Vz3s3GQkDHpm9bDrNXdtJs995FzQpgqQ==", "951dc27f-6021-4cd8-b916-18641df1b40e", new DateTime(2018, 4, 8, 10, 39, 3, 499, DateTimeKind.Local).AddTicks(6816), new DateTime(2023, 4, 8, 10, 39, 3, 499, DateTimeKind.Local).AddTicks(6703) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59323082792",
                columns: new[] { "Birthday", "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp", "StartDateOfWork", "UpdatedDate" },
                values: new object[] { new DateTime(1989, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "c452f3c8-5db5-469d-9547-fc33be3833ac", new DateTime(2023, 4, 8, 10, 39, 3, 502, DateTimeKind.Local).AddTicks(5975), "AQAAAAEAACcQAAAAEDILdy2dhGbGalQwCBkv+bazyq9HGSUAu/ugqeeBylU5G4iuG1+7ChQ1a4BBUVGFdA==", "9759807b-aabe-43d5-9f65-e3b40f88feae", new DateTime(2018, 4, 8, 10, 39, 3, 502, DateTimeKind.Local).AddTicks(6004), new DateTime(2023, 4, 8, 10, 39, 3, 502, DateTimeKind.Local).AddTicks(5975) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 8, 10, 39, 3, 499, DateTimeKind.Local).AddTicks(6220), new DateTime(2023, 4, 8, 10, 39, 3, 499, DateTimeKind.Local).AddTicks(6236) });

            migrationBuilder.UpdateData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ResponseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 8, 10, 39, 3, 505, DateTimeKind.Local).AddTicks(6636), new DateTime(2023, 4, 7, 10, 39, 3, 505, DateTimeKind.Local).AddTicks(6642), new DateTime(2023, 4, 8, 10, 39, 3, 505, DateTimeKind.Local).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "ReplyDate", "ResponseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 8, 10, 39, 3, 505, DateTimeKind.Local).AddTicks(6690), new DateTime(2023, 4, 8, 10, 39, 3, 505, DateTimeKind.Local).AddTicks(6695), new DateTime(2022, 4, 8, 10, 39, 3, 505, DateTimeKind.Local).AddTicks(6693), new DateTime(2023, 4, 8, 10, 39, 3, 505, DateTimeKind.Local).AddTicks(6691) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "c5ec4f97-8d45-49af-b8af-668199126d3d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "employee",
                column: "ConcurrencyStamp",
                value: "e771204d-5073-47f1-9339-7e74b9b4be30");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "projectmanager",
                column: "ConcurrencyStamp",
                value: "dca37831-962d-4f43-b655-a58f4aa60317");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59323082791",
                columns: new[] { "Birthday", "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp", "StartDateOfWork", "UpdatedDate" },
                values: new object[] { new DateTime(1989, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "5374efa0-a839-4364-b128-734d72803c07", new DateTime(2022, 12, 30, 16, 31, 22, 177, DateTimeKind.Local).AddTicks(8063), "AQAAAAEAACcQAAAAEB/iK7xKNZszoisxnOUchhw+5klKdwwlHv8Wlx3W3lN1ILFOFioB+9a5GW24cETAGA==", "25fecca7-522c-4511-bfcd-a8c6e307b7bd", new DateTime(2017, 12, 30, 16, 31, 22, 177, DateTimeKind.Local).AddTicks(8153), new DateTime(2022, 12, 30, 16, 31, 22, 177, DateTimeKind.Local).AddTicks(8064) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59323082792",
                columns: new[] { "Birthday", "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp", "StartDateOfWork", "UpdatedDate" },
                values: new object[] { new DateTime(1992, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "80a44ad5-3fd4-4af5-a979-b17891aa4f87", new DateTime(2022, 12, 30, 16, 31, 22, 182, DateTimeKind.Local).AddTicks(9101), "AQAAAAEAACcQAAAAEKYlcAFQPQqqy4QaFGtzpcna8ZTF+a3QE9pwkXxYxA47JX+3WGxgi6Y1vXH+DN03lw==", "1868cd15-953b-49f2-acd9-5a8a98beda92", new DateTime(2017, 12, 30, 16, 31, 22, 182, DateTimeKind.Local).AddTicks(9182), new DateTime(2022, 12, 30, 16, 31, 22, 182, DateTimeKind.Local).AddTicks(9101) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 16, 31, 22, 177, DateTimeKind.Local).AddTicks(7843), new DateTime(2022, 12, 30, 16, 31, 22, 177, DateTimeKind.Local).AddTicks(7852) });

            migrationBuilder.UpdateData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ResponseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 16, 31, 22, 187, DateTimeKind.Local).AddTicks(9959), new DateTime(2022, 12, 29, 16, 31, 22, 187, DateTimeKind.Local).AddTicks(9960), new DateTime(2022, 12, 30, 16, 31, 22, 187, DateTimeKind.Local).AddTicks(9959) });

            migrationBuilder.UpdateData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "ReplyDate", "ResponseDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 16, 31, 22, 187, DateTimeKind.Local).AddTicks(9972), new DateTime(2022, 12, 30, 16, 31, 22, 187, DateTimeKind.Local).AddTicks(9974), new DateTime(2021, 12, 30, 16, 31, 22, 187, DateTimeKind.Local).AddTicks(9973), new DateTime(2022, 12, 30, 16, 31, 22, 187, DateTimeKind.Local).AddTicks(9973) });
        }
    }
}
