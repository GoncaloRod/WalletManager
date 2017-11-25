CREATE TABLE Users (
	[id] INT IDENTITY(1,1),
	[name] VARCHAR(100) NOT NULL,
	[email] VARCHAR(100) UNIQUE CHECK([email] LIKE '%@%.%') NOT NULL,
	[password] VARCHAR(100) NOT NULL,
	[balance] MONEY DEFAULT(0) NOT NULL,
	PRIMARY KEY([id])
)

CREATE TABLE Wallets (
	[id] INT IDENTITY(1,1),
	[name] VARCHAR(100) NOT NULL,
	[user_id] INT REFERENCES Users(id) NOT NULL,
	PRIMARY KEY([id])
)

CREATE TABLE Transactions (
	[id] INT IDENTITY(1,1),
	[values] MONEY NOT NULL,
	[date] DATE NOT NULL,
	[wallet_id] INT REFERENCES Wallets(id) NOT NULL,
	PRIMARY KEY([id])
)

CREATE TABLE Salaries_Categories (
	[id] INT IDENTITY(1,1),
	[name] VARCHAR(100) NOT NULL,
	[color_code] CHAR(7) CHECK([color_code] LIKE '#%'),
	[user_id] INT REFERENCES Users(id),
	PRIMARY KEY([id])
)

CREATE TABLE Expenses_Categories (
	[id] INT IDENTITY(1,1),
	[name] VARCHAR(100) NOT NULL,
	[color_code] CHAR(7) CHECK([color_code] LIKE '#%'),
	[user_id] INT REFERENCES Users(id),
	PRIMARY KEY([id])
)

CREATE TABLE Salaries (
	[id] INT IDENTITY(1,1),
	[category_id] INT REFERENCES Salaries_Categories([id]) NOT NULL,
	[transaction_id] INT REFERENCES Transactions([id]) NOT NULL,
	PRIMARY KEY([id])
)

CREATE TABLE Expenses (
	[id] INT IDENTITY(1,1),
	[category_id] INT REFERENCES Expenses_Categories([id]) NOT NULL,
	[transaction_id] INT REFERENCES Transactions([id]) NOT NULL,
	PRIMARY KEY ([id])
)