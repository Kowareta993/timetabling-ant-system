CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "ChartGroups" (
    "GroupId" INTEGER NOT NULL CONSTRAINT "PK_ChartGroups" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Rooms" (
    "RoomId" INTEGER NOT NULL CONSTRAINT "PK_Rooms" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Students" (
    "StudentId" INTEGER NOT NULL CONSTRAINT "PK_Students" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Teachers" (
    "TeacherId" INTEGER NOT NULL CONSTRAINT "PK_Teachers" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Times" (
    "TimeId" INTEGER NOT NULL CONSTRAINT "PK_Times" PRIMARY KEY AUTOINCREMENT,
    "Day" INTEGER NOT NULL,
    "Start" REAL NOT NULL,
    "Duration" REAL NOT NULL
);

CREATE TABLE "CourseGroups" (
    "GroupId" INTEGER NOT NULL CONSTRAINT "PK_CourseGroups" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "ChartGroupGroupId" INTEGER NULL,
    CONSTRAINT "FK_CourseGroups_ChartGroups_ChartGroupGroupId" FOREIGN KEY ("ChartGroupGroupId") REFERENCES "ChartGroups" ("GroupId")
);

CREATE TABLE "ConfirmedRooms" (
    "TeacherId" INTEGER NOT NULL,
    "RoomId" INTEGER NOT NULL,
    CONSTRAINT "PK_ConfirmedRooms" PRIMARY KEY ("TeacherId", "RoomId"),
    CONSTRAINT "FK_ConfirmedRooms_Rooms_RoomId" FOREIGN KEY ("RoomId") REFERENCES "Rooms" ("RoomId") ON DELETE CASCADE,
    CONSTRAINT "FK_ConfirmedRooms_Teachers_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES "Teachers" ("TeacherId") ON DELETE CASCADE
);

CREATE TABLE "ProposedRooms" (
    "TeacherId" INTEGER NOT NULL,
    "RoomId" INTEGER NOT NULL,
    CONSTRAINT "PK_ProposedRooms" PRIMARY KEY ("TeacherId", "RoomId"),
    CONSTRAINT "FK_ProposedRooms_Rooms_RoomId" FOREIGN KEY ("RoomId") REFERENCES "Rooms" ("RoomId") ON DELETE CASCADE,
    CONSTRAINT "FK_ProposedRooms_Teachers_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES "Teachers" ("TeacherId") ON DELETE CASCADE
);

CREATE TABLE "ConfirmedTimes" (
    "TeacherId" INTEGER NOT NULL,
    "TimeId" INTEGER NOT NULL,
    CONSTRAINT "PK_ConfirmedTimes" PRIMARY KEY ("TeacherId", "TimeId"),
    CONSTRAINT "FK_ConfirmedTimes_Teachers_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES "Teachers" ("TeacherId") ON DELETE CASCADE,
    CONSTRAINT "FK_ConfirmedTimes_Times_TimeId" FOREIGN KEY ("TimeId") REFERENCES "Times" ("TimeId") ON DELETE CASCADE
);

CREATE TABLE "ProposedTimes" (
    "TeacherId" INTEGER NOT NULL,
    "TimeId" INTEGER NOT NULL,
    CONSTRAINT "PK_ProposedTimes" PRIMARY KEY ("TeacherId", "TimeId"),
    CONSTRAINT "FK_ProposedTimes_Teachers_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES "Teachers" ("TeacherId") ON DELETE CASCADE,
    CONSTRAINT "FK_ProposedTimes_Times_TimeId" FOREIGN KEY ("TimeId") REFERENCES "Times" ("TimeId") ON DELETE CASCADE
);

CREATE TABLE "Courses" (
    "CourseId" INTEGER NOT NULL CONSTRAINT "PK_Courses" PRIMARY KEY AUTOINCREMENT,
    "TeacherId" INTEGER NOT NULL,
    "Name" TEXT NOT NULL,
    "GroupId" INTEGER NOT NULL,
    "IsLab" INTEGER NOT NULL,
    CONSTRAINT "FK_Courses_CourseGroups_GroupId" FOREIGN KEY ("GroupId") REFERENCES "CourseGroups" ("GroupId") ON DELETE CASCADE,
    CONSTRAINT "FK_Courses_Teachers_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES "Teachers" ("TeacherId") ON DELETE CASCADE
);

CREATE TABLE "RoomOptions" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_RoomOptions" PRIMARY KEY AUTOINCREMENT,
    "CourseId" INTEGER NULL,
    "Discriminator" TEXT NOT NULL,
    "RoomId" INTEGER NULL,
    "Capacity" INTEGER NULL,
    "Projector" INTEGER NULL,
    CONSTRAINT "FK_RoomOptions_Courses_CourseId" FOREIGN KEY ("CourseId") REFERENCES "Courses" ("CourseId"),
    CONSTRAINT "FK_RoomOptions_Rooms_RoomId" FOREIGN KEY ("RoomId") REFERENCES "Rooms" ("RoomId")
);

CREATE INDEX "IX_ConfirmedRooms_RoomId" ON "ConfirmedRooms" ("RoomId");

CREATE INDEX "IX_ConfirmedTimes_TimeId" ON "ConfirmedTimes" ("TimeId");

CREATE INDEX "IX_CourseGroups_ChartGroupGroupId" ON "CourseGroups" ("ChartGroupGroupId");

CREATE INDEX "IX_Courses_GroupId" ON "Courses" ("GroupId");

CREATE INDEX "IX_Courses_TeacherId" ON "Courses" ("TeacherId");

CREATE INDEX "IX_ProposedRooms_RoomId" ON "ProposedRooms" ("RoomId");

CREATE INDEX "IX_ProposedTimes_TimeId" ON "ProposedTimes" ("TimeId");

CREATE INDEX "IX_RoomOptions_CourseId" ON "RoomOptions" ("CourseId");

CREATE INDEX "IX_RoomOptions_RoomId" ON "RoomOptions" ("RoomId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220909140753_InitialCreate', '6.0.6');

COMMIT;


