
/*crud with single stored procedure */
USE demo;

CREATE TABLE CRUDAS (ID INT PRIMARY KEY IDENTITY(1,1), [Name] VARCHAR(20), Age INT, [Address] VARCHAR(20));
SELECT * FROM CRUDAS;

CREATE PROCEDURE UserManagement (@ID INT, @Name VARCHAR(20), @Age INT, @Address VARCHAR(20), @Type VARCHAR(20))
AS
BEGIN
  IF @Type = 'SELECT'
  BEGIN
    SELECT * FROM CRUDAS;
  END;
  IF @Type = 'INSERT'
  BEGIN
    INSERT INTO CRUDAS ([Name], Age, [Address]) VALUES (@Name, @Age, @Address);
  END;
  IF @Type = 'UPDATE'
  BEGIN
    UPDATE CRUDAS SET [Name] = @Name, Age = @Age, [Address] = @Address WHERE ID = @ID;
  END;
  IF @Type = 'DELETE'
  BEGIN
    DELETE FROM CRUDAS WHERE ID = @ID;
  END;
END;

EXEC UserManagement 0, '', 0, '', 'SELECT';
EXEC UserManagement 0, 'Aadya', 10, 'Kasaragod', 'INSERT';
EXEC UserManagement 0, 'Amala', 15, 'Kannur', 'INSERT';
EXEC UserManagement 0, 'Bibin', 20, 'Trivandrum', 'INSERT';
EXEC UserManagement 2, 'Amal', 12, 'Nilambur','UPDATE';
EXEC UserManagement 2, '', 0, '', 'INSERT';
EXEC UserManagement 4, '', 0, '', 'DELETE';

/*crud with different stored procedure */

CREATE TABLE CRUDDIFFSP (ID INT PRIMARY KEY IDENTITY(1,1),[CustomerName] VARCHAR(20),CustomerAge INT,[CustomerAddress] VARCHAR(20));

/* Create Procedure for READ (SELECT) Operation*/

CREATE PROCEDURE CustomerManagement
AS
BEGIN
  SELECT * FROM CRUDDIFFSP;
END;

/* Create Procedure for CREATE (INSERT) Operation */

CREATE PROCEDURE CreateCustomerManagement(@CustomerName VARCHAR(20), @CustomerAge INT, @CustomerAddress VARCHAR(20))
AS
BEGIN
  INSERT INTO CRUDDIFFSP ([CustomerName], CustomerAge, [CustomerAddress])
  VALUES (@CustomerName, @CustomerAge, @CustomerAddress);
END;

/*Create Procedure for UPDATE Operation */

CREATE PROCEDURE UpdateCustomerManagement(@ID INT,@CustomerName VARCHAR(20),@CustomerAge INT,@CustomerAddress VARCHAR(20))
AS
BEGIN
  UPDATE CRUDDIFFSP
  SET [CustomerName] = @CustomerName, CustomerAge = @CustomerAge, [CustomerAddress] = @CustomerAddress
  WHERE ID = @ID;
END;

/* Create Procedure for DELETE Operation */

CREATE PROCEDURE DeleteCustomerManagement
  @ID INT
AS
BEGIN
  DELETE FROM CRUDDIFFSP
  WHERE ID = @ID;
END;

/*Execute the stored procedures */

EXEC CustomerManagement;
EXEC CreateCustomerManagement '', 25, '123 Main Street';
EXEC CreateCustomerManagement 'qwerty', 25, '123 Main Street';
EXEC CreateCustomerManagement 'hhj', 30, '12663 Main Street';
EXEC UpdateCustomerManagement 1, 'John Doe', 30, '456 Elm Street';
EXEC DeleteCustomerManagement 3;
