INSERT INTO Times (Day, Start, Duration) VALUES (0, 7, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (0, 9, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (0, 11, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (0, 1, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (0, 3, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (0, 5, 2);

INSERT INTO Times (Day, Start, Duration) VALUES (1, 7, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (1, 9, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (1, 11, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (1, 1, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (1, 3, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (1, 5, 2);

INSERT INTO Times (Day, Start, Duration) VALUES (2, 7, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (2, 9, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (2, 11, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (2, 1, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (2, 3, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (2, 5, 2);

INSERT INTO Times (Day, Start, Duration) VALUES (3, 7, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (3, 9, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (3, 11, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (3, 1, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (3, 3, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (3, 5, 2);

INSERT INTO Times (Day, Start, Duration) VALUES (4, 7, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (4, 9, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (4, 11, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (4, 1, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (4, 3, 2);
INSERT INTO Times (Day, Start, Duration) VALUES (4, 5, 2);


INSERT INTO Rooms (name) VALUES ("101");
INSERT INTO Rooms (name) VALUES ("102");

INSERT INTO Rooms (name) VALUES ("201");
INSERT INTO Rooms (name) VALUES ("202");

INSERT INTO Rooms (name) VALUES ("301");
INSERT INTO Rooms (name) VALUES ("302");


INSERT INTO RoomOptions (RoomId, Discriminator, Capacity) VALUES (1, "RoomCapacity", 30);
INSERT INTO RoomOptions (RoomId, Discriminator, Capacity) VALUES (2, "RoomCapacity", 80);
INSERT INTO RoomOptions (RoomId, Discriminator, Capacity) VALUES (3, "RoomCapacity", 70);
INSERT INTO RoomOptions (RoomId, Discriminator, Capacity) VALUES (4, "RoomCapacity", 20);
INSERT INTO RoomOptions (RoomId, Discriminator, Capacity) VALUES (5, "RoomCapacity", 40);
INSERT INTO RoomOptions (RoomId, Discriminator, Capacity) VALUES (6, "RoomCapacity", 80);

INSERT INTO RoomOptions (RoomId, Discriminator, Projector) VALUES (1, "RoomHasProjector", False);
INSERT INTO RoomOptions (RoomId, Discriminator, Projector) VALUES (2, "RoomHasProjector", True);
INSERT INTO RoomOptions (RoomId, Discriminator, Projector) VALUES (3, "RoomHasProjector", False);
INSERT INTO RoomOptions (RoomId, Discriminator, Projector) VALUES (4, "RoomHasProjector", True);
INSERT INTO RoomOptions (RoomId, Discriminator, Projector) VALUES (5, "RoomHasProjector", False);
INSERT INTO RoomOptions (RoomId, Discriminator, Projector) VALUES (6, "RoomHasProjector", True);




INSERT INTO Teachers (name) VALUES ("استاد ریاضیات اول");
INSERT INTO Teachers (name) VALUES ("استاد ریاضیات دوم");
INSERT INTO Teachers (name) VALUES ("استاد کامپیوتر اول");
INSERT INTO Teachers (name) VALUES ("استاد کامپیوتر دوم");

INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (1, 1);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (1, 2);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (1, 3);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (1, 4);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (2, 5);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (2, 6);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (2, 1);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (2, 2);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (3, 1);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (3, 2);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (3, 3);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (3, 4);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (4, 5);
INSERT INTO ConfirmedRooms (TeacherId, RoomId) VALUES (4, 6);

INSERT INTO ProposedRooms (TeacherId, RoomId) VALUES (1, 1);
INSERT INTO ProposedRooms (TeacherId, RoomId) VALUES (1, 2);
INSERT INTO ProposedRooms (TeacherId, RoomId) VALUES (2, 5);
INSERT INTO ProposedRooms (TeacherId, RoomId) VALUES (3, 1);
INSERT INTO ProposedRooms (TeacherId, RoomId) VALUES (3, 2);
INSERT INTO ProposedRooms (TeacherId, RoomId) VALUES (4, 6);

INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (1, 1);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (1, 2);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (1, 12);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (1, 13);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (2, 7);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (2, 8);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (2, 19);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (2, 20);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 1);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 2);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 3);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 4);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 5);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 6);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 7);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 8);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 9);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 10);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 11);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (3, 12);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 1);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 2);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 3);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 4);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 5);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 6);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 7);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 8);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 9);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 10);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 11);
INSERT INTO ConfirmedTimes (TeacherId, TimeId) VALUES (4, 12);

INSERT INTO ChartGroups (Name) VALUES ("term1");

INSERT INTO CourseGroups (Name) VALUES ("ریاضی ۱");
INSERT INTO CourseGroups (Name) VALUES ("ریاضی ۲");
INSERT INTO CourseGroups (Name) VALUES ("ریاضی مهندسی");
INSERT INTO CourseGroups (Name) VALUES ("تحلیل و طراحی");
INSERT INTO CourseGroups (Name) VALUES ("معماری");
INSERT INTO CourseGroups (Name) VALUES ("سیستم عامل");
INSERT INTO CourseGroups (Name) VALUES ("روش پژوهش");
INSERT INTO CourseGroups (Name) VALUES ("پروژه");

INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (1, "ریاضی ۱", 1, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (2, "ریاضی ۱", 1, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (1, "ریاضی ۲", 2, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (2, "ریاضی ۲", 2, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (1, "ریاضیات مهندسی", 3, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (2, "ریاضیات مهندسی", 3, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (3, "تحلیل و طراحی سیستم ها", 4, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (4, "تحلیل و طراحی سیستم ها", 4, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (3, "معماری کامپیوتر", 5, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (4, "معماری کامپیوتر", 5, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (3, "سیستم های عامل", 6, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (4, "سیستم های عامل", 6, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (3, "روش پژوهش و ارائه", 7, False);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (3, "پروژه کارشناسی", 8, True);
INSERT INTO Courses (TeacherId, Name, GroupId, IsLab) VALUES (4, "پروژه کارشناسی", 8, True);


INSERT INTO RoomOptions (CourseId, Discriminator, Capacity) VALUES (1, "RoomCapacity", 70);
INSERT INTO RoomOptions (CourseId, Discriminator, Capacity) VALUES (2, "RoomCapacity", 70);
INSERT INTO RoomOptions (CourseId, Discriminator, Capacity) VALUES (3, "RoomCapacity", 70);
INSERT INTO RoomOptions (CourseId, Discriminator, Capacity) VALUES (4, "RoomCapacity", 70);
INSERT INTO RoomOptions (CourseId, Discriminator, Capacity) VALUES (13, "RoomCapacity", 15);
INSERT INTO RoomOptions (CourseId, Discriminator, Capacity) VALUES (14, "RoomCapacity", 15);

INSERT INTO RoomOptions (CourseId, Discriminator, Projector) VALUES (10, "RoomHasProjector", True);
INSERT INTO RoomOptions (CourseId, Discriminator, Projector) VALUES (11, "RoomHasProjector", True);
