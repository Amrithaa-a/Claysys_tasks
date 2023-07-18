USE School
CREATE PROCEDURE ManageStudent
    @Operation NVARCHAR(10),
    @ID INT = NULL,
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL,
    @RollNumber NVARCHAR(10) = NULL,
    @MobileNumber NVARCHAR(10) = NULL
AS
BEGIN
    IF @Operation = 'SELECT'
    BEGIN
        SELECT * FROM Register
    END
    ELSE IF @Operation = 'INSERT'
    BEGIN
        INSERT INTO Register (FirstName, LastName, RollNumber, MobileNumber)
        VALUES (@FirstName, @LastName, @RollNumber, @MobileNumber)
    END
    ELSE IF @Operation = 'UPDATE'
    BEGIN
        UPDATE Register
        SET FirstName = @FirstName,
            LastName = @LastName,
            RollNumber = @RollNumber,
            MobileNumber = @MobileNumber
        WHERE ID = @ID
    END
    ELSE IF @Operation = 'DELETE'
    BEGIN
        DELETE FROM Register
        WHERE ID = @ID
    END
END

SELECT COUNT(ID) AS [COUNT OF ID] FROM Register ;

EXEC ManageStudent @Operation='SELECT';
