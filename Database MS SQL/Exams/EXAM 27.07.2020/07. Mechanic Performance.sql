CREATE TABLE Mechanics(
	MechanicId int PRIMARY KEY,
	FirstName varchar(50),
	LastName varchar(50),
	Address varchar(255))

CREATE TABLE Jobs(
	JobId int PRIMARY KEY,
	ModelId int,
	Status varchar(11),
	ClientId int,
	IssueDate date,
	FinishDate date,
	MechanicId int)

INSERT INTO Mechanics (MechanicId, FirstName, LastName, [Address]) VALUES
(1, 'Joni', 'Breland', '35 E Main St #43'),
(2, 'Malcolm', 'Tromblay', '747 Leonis Blvd'),
(3, 'Ryan', 'Harnos', '13 Gunnison St'),
(4, 'Jess', 'Chaffins', '18 3rd Ave'),
(5, 'Nickolas', 'Juvera', '177 S Rider Trl #52'),
(6, 'Gary', 'Nunlee', '2 W Mount Royal Ave')

INSERT INTO Jobs (JobId, ModelId, [Status], ClientId, IssueDate, FinishDate, MechanicId) VALUES
(1, 1, 'Finished', 13, '2017-01-12', '2017-01-23', 1),
(2, 2, 'Finished', 7, '2017-01-16', '2017-01-18', 5),
(3, 6, 'Finished', 3, '2017-01-17', '2017-01-30', 1),
(4, 4, 'Finished', 25, '2017-01-18', '2017-01-30', 2),
(5, 4, 'Finished', 43, '2017-01-20', '2017-01-23', 4),
(6, 3, 'Finished', 2, '2017-01-23', '2017-02-01', 2),
(7, 2, 'Finished', 17, '2017-01-24', '2017-01-30', 1),
(8, 2, 'Finished', 44, '2017-01-26', '2017-02-03', 5),
(9, 5, 'Finished', 9, '2017-01-30', '2017-02-06', 6),
(10, 1, 'Finished', 39, '2017-01-31', '2017-02-13', 1),
(11, 6, 'Finished', 4, '2017-02-01', '2017-02-08', 6),
(12, 2, 'Finished', 24, '2017-02-03', '2017-02-16', 5),
(13, 4, 'Finished', 25, '2017-02-03', '2017-02-07', 1),
(14, 6, 'Finished', 1, '2017-02-06', '2017-02-17', 1),
(15, 1, 'Finished', 47, '2017-02-07', '2017-02-10', 1),
(16, 3, 'Finished', 10, '2017-02-09', '2017-02-21', 5),
(17, 3, 'Finished', 46, '2017-02-13', '2017-02-27', 2),
(18, 1, 'Finished', 38, '2017-02-14', '2017-02-22', 5),
(19, 6, 'Finished', 42, '2017-02-15', '2017-02-22', 3),
(20, 4, 'Finished', 27, '2017-02-17', '2017-02-28', 4),
(21, 1, 'Finished', 6, '2017-02-20', '2017-03-06', 1),
(22, 4, 'Finished', 21, '2017-02-21', '2017-03-02', 6),
(23, 1, 'Finished', 19, '2017-02-23', '2017-02-28', 5),
(24, 1, 'Finished', 5, '2017-02-27', '2017-03-06', 6),
(25, 2, 'Finished', 29, '2017-02-28', '2017-03-06', 4),
(26, 5, 'Finished', 30, '2017-03-01', '2017-03-02', 3),
(27, 6, 'Finished', 36, '2017-03-03', '2017-03-16', 4),
(28, 1, 'Finished', 50, '2017-03-06', '2017-03-20', 6),
(29, 1, 'Finished', 14, '2017-03-07', '2017-03-13', 5),
(30, 1, 'Finished', 33, '2017-03-09', '2017-03-15', 1),
(31, 2, 'Finished', 18, '2017-03-13', '2017-03-27', 2),
(32, 6, 'Finished', 28, '2017-03-14', '2017-03-23', 1),
(33, 2, 'Finished', 32, '2017-03-15', '2017-03-28', 2),
(34, 5, 'Finished', 34, '2017-03-17', '2017-03-23', 6),
(35, 5, 'Finished', 11, '2017-03-20', '2017-03-31', 5),
(36, 2, 'Finished', 40, '2017-03-21', '2017-03-28', 2),
(37, 3, 'Finished', 45, '2017-03-23', '2017-04-03', 6),
(38, 6, 'Finished', 31, '2017-03-27', '2017-04-03', 4),
(39, 2, 'Finished', 22, '2017-03-28', '2017-04-03', 5),
(40, 2, 'Finished', 23, '2017-03-29', '2017-04-04', 3),
(41, 6, 'Finished', 12, '2017-03-31', '2017-04-12', 1),
(42, 5, 'Finished', 37, '2017-04-03', '2017-04-10', 3),
(43, 2, 'Finished', 7, '2017-04-03', '2017-04-12', 5),
(44, 2, 'Finished', 41, '2017-04-04', '2017-04-12', 4),
(45, 6, 'In Progress', 26, '2017-04-06', null, 5),
(46, 2, 'In Progress', 16, '2017-04-10', null, 2),
(47, 5, 'Finished', 20, '2017-04-11', '2017-04-18', 2),
(48, 2, 'In Progress', 35, '2017-04-12', null, 2),
(49, 4, 'In Progress', 25, '2017-04-13', null, 5),
(50, 1, 'In Progress', 8, '2017-04-14', null, 6),
(51, 6, 'In Progress', 49, '2017-04-17', null, 5),
(52, 3, 'Pending', 15, '2017-04-18', null, null),
(53, 1, 'Pending', 48, '2017-04-20', null, null)