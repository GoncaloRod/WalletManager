/* Create tables */
CREATE TABLE Currencies (
	[id] INT IDENTITY(1,1),
	[code] CHAR(3) NOT NULL,
	[symbol] CHAR(1) NOT NULL,
	PRIMARY KEY([id])
)

CREATE TABLE Users (
	[id] INT IDENTITY(1,1),
	[name] VARCHAR(100) NOT NULL,
	[email] VARCHAR(100) UNIQUE CHECK([email] LIKE '%@%') NOT NULL,
	[password] VARCHAR(100) NOT NULL,
	[currency_id] INT REFERENCES Currencies(id) NOT NULL, 
	PRIMARY KEY([id])
)

CREATE TABLE Wallets (
	[id] INT IDENTITY(1,1),
	[name] VARCHAR(100) NOT NULL,
	[user_id] INT REFERENCES Users(id) NOT NULL,
	[balance] MONEY DEFAULT(0) NOT NULL,
	PRIMARY KEY([id])
)

CREATE TABLE Transactions (
	[id] INT IDENTITY(1,1),
	[value] MONEY NOT NULL,
	[date] DATE NOT NULL,
	[wallet_id] INT REFERENCES Wallets(id) NOT NULL,
	PRIMARY KEY([id])
)

CREATE TABLE Salaries_Categories (
	[id] INT IDENTITY(1,1),
	[name] VARCHAR(100) NOT NULL,
	[user_id] INT REFERENCES Users(id) NOT NULL,
	PRIMARY KEY([id])
)

CREATE TABLE Expenses_Categories (
	[id] INT IDENTITY(1,1),
	[name] VARCHAR(100) NOT NULL,
	[user_id] INT REFERENCES Users(id) NOT NULL,
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

/* Populate some tables */
INSERT INTO Currencies([code], [symbol]) VALUES('USD', '$')

INSERT INTO Currencies([code], [symbol]) VALUES('EUR', '€')

INSERT INTO Currencies([code], [symbol]) VALUES('BTC', '₿')

INSERT INTO Users([name], [email], [password], [currency_id]) VALUES('Goncalo Rodrigues', 'me@me.me', '123', 1)