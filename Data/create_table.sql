USE finstar;
CREATE TABLE DataTable(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Code int NOT NULL,
	Value nvarchar(max) NOT NULL
)
