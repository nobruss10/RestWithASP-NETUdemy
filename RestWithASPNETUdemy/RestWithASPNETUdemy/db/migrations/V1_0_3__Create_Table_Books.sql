CREATE TABLE IF NOT EXISTS books(
	Id INT UNSIGNED AUTO_INCREMENT NOT NULL,
    Title LONGTEXT,
	Author LONGTEXT,
    LaunchDate DATETIME(6) NOT NULL,
    Price DECIMAL,
    PRIMARY KEY(Id) 
)