using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoService.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupsToFlows",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    FlowId = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsToFlows", x => new { x.FlowId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GroupsToFlows_Flows_FlowId",
                        column: x => x.FlowId,
                        principalTable: "Flows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsToFlows_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersToFlows",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    FlowId = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToFlows", x => new { x.UserId, x.FlowId });
                    table.ForeignKey(
                        name: "FK_UsersToFlows_Flows_FlowId",
                        column: x => x.FlowId,
                        principalTable: "Flows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersToFlows_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersToGroups",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToGroups", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UsersToGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersToGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowsToVideos",
                columns: table => new
                {
                    FlowId = table.Column<int>(nullable: false),
                    VideoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowsToVideos", x => new { x.FlowId, x.VideoId });
                    table.ForeignKey(
                        name: "FK_FlowsToVideos_Flows_FlowId",
                        column: x => x.FlowId,
                        principalTable: "Flows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowsToVideos_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupsToVideos",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    VideoId = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsToVideos", x => new { x.VideoId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GroupsToVideos_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsToVideos_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersToVideos",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    VideoId = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToVideos", x => new { x.UserId, x.VideoId });
                    table.ForeignKey(
                        name: "FK_UsersToVideos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersToVideos_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flows",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12
                });

            migrationBuilder.InsertData(
                table: "Groups",
                column: "Id",
                values: new object[]
                {
                    9,
                    8,
                    7,
                    6,
                    1,
                    4,
                    3,
                    2,
                    5
                });

            migrationBuilder.InsertData(
                table: "Users",
                column: "Id",
                values: new object[]
                {
                    7,
                    9,
                    8,
                    6,
                    10,
                    4,
                    3,
                    2,
                    1,
                    5
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 16, "Video 16" },
                    { 17, "Video 17" },
                    { 18, "Video 18" },
                    { 19, "Video 19" },
                    { 20, "Video 20" },
                    { 21, "Video 21" },
                    { 23, "Video 23" },
                    { 24, "Video 24" },
                    { 25, "Video 25" },
                    { 26, "Video 26" },
                    { 27, "Video 27" },
                    { 28, "Video 28" },
                    { 22, "Video 22" },
                    { 15, "Video 15" },
                    { 13, "Video 13" },
                    { 12, "Video 12" },
                    { 11, "Video 11" },
                    { 10, "Video 10" },
                    { 9, "Video 9" },
                    { 8, "Video 8" },
                    { 7, "Video 7" },
                    { 6, "Video 6" },
                    { 5, "Video 5" },
                    { 4, "Video 4" },
                    { 3, "Video 3" },
                    { 2, "Video 2" },
                    { 1, "Video 1" },
                    { 29, "Video 29" },
                    { 14, "Video 14" },
                    { 30, "Video 30" }
                });

            migrationBuilder.InsertData(
                table: "FlowsToVideos",
                columns: new[] { "FlowId", "VideoId" },
                values: new object[,]
                {
                    { 4, 7 },
                    { 4, 5 },
                    { 12, 30 },
                    { 5, 9 },
                    { 5, 10 },
                    { 5, 11 },
                    { 6, 12 },
                    { 6, 13 },
                    { 6, 14 },
                    { 11, 15 },
                    { 11, 16 },
                    { 11, 17 },
                    { 3, 4 },
                    { 7, 18 },
                    { 7, 20 },
                    { 8, 21 },
                    { 8, 22 },
                    { 8, 23 },
                    { 9, 23 },
                    { 9, 24 },
                    { 9, 25 },
                    { 10, 26 },
                    { 10, 27 },
                    { 10, 28 },
                    { 12, 29 },
                    { 7, 19 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "GroupsToFlows",
                columns: new[] { "FlowId", "GroupId", "Priority" },
                values: new object[,]
                {
                    { 3, 4, 1 },
                    { 4, 5, 2 },
                    { 10, 7, 2 },
                    { 11, 8, 1 },
                    { 12, 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "GroupsToVideos",
                columns: new[] { "VideoId", "GroupId", "Priority" },
                values: new object[,]
                {
                    { 22, 7, 1 },
                    { 15, 9, 3 },
                    { 12, 6, 0 },
                    { 17, 9, 3 },
                    { 9, 6, 2 },
                    { 8, 5, 1 },
                    { 24, 7, 2 },
                    { 16, 9, 3 },
                    { 2, 1, 2 },
                    { 4, 3, 2 },
                    { 3, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "UsersToFlows",
                columns: new[] { "UserId", "FlowId", "Priority" },
                values: new object[,]
                {
                    { 3, 1, 3 },
                    { 7, 7, 0 },
                    { 7, 8, 0 },
                    { 7, 9, 1 },
                    { 10, 11, 2 },
                    { 6, 6, 2 },
                    { 4, 2, 3 },
                    { 6, 5, 0 },
                    { 9, 12, 0 },
                    { 5, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "UsersToGroups",
                columns: new[] { "UserId", "GroupId" },
                values: new object[,]
                {
                    { 4, 4 },
                    { 3, 2 },
                    { 5, 5 },
                    { 7, 7 },
                    { 10, 7 },
                    { 4, 3 },
                    { 7, 8 },
                    { 8, 7 },
                    { 8, 9 },
                    { 2, 1 },
                    { 9, 7 },
                    { 9, 8 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "UsersToVideos",
                columns: new[] { "UserId", "VideoId", "Priority" },
                values: new object[,]
                {
                    { 8, 22, 0 },
                    { 8, 23, 0 },
                    { 1, 1, 0 },
                    { 7, 17, 2 },
                    { 8, 16, 0 },
                    { 7, 16, 0 },
                    { 7, 15, 1 },
                    { 5, 7, 0 },
                    { 5, 6, 2 },
                    { 5, 5, 1 },
                    { 4, 4, 0 },
                    { 3, 3, 0 },
                    { 2, 2, 0 },
                    { 8, 21, 1 },
                    { 10, 30, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowsToVideos_VideoId",
                table: "FlowsToVideos",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsToFlows_GroupId",
                table: "GroupsToFlows",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsToVideos_GroupId",
                table: "GroupsToVideos",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToFlows_FlowId",
                table: "UsersToFlows",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToGroups_GroupId",
                table: "UsersToGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToVideos_VideoId",
                table: "UsersToVideos",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowsToVideos");

            migrationBuilder.DropTable(
                name: "GroupsToFlows");

            migrationBuilder.DropTable(
                name: "GroupsToVideos");

            migrationBuilder.DropTable(
                name: "UsersToFlows");

            migrationBuilder.DropTable(
                name: "UsersToGroups");

            migrationBuilder.DropTable(
                name: "UsersToVideos");

            migrationBuilder.DropTable(
                name: "Flows");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
