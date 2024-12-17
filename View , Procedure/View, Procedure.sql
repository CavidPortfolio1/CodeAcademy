CREATE VIEW BlogUsersView AS
SELECT 
    Blogs.Title,
    Users.UserName,
    Users.FullName
FROM Blogs
INNER JOIN Users ON Blogs.UserId = Users.Id;

CREATE VIEW BlogCategoriesView AS
SELECT 
    Blogs.Title,
    Categories.Name AS CategoryName
FROM Blogs
INNER JOIN Categories ON Blogs.CategoryId = Categories.Id;

CREATE PROCEDURE GetUserComments
    @userId INT
AS
BEGIN
    SELECT 
        Comments.Id,
        Comments.Content
    FROM Comments
    WHERE Comments.UserId = @userId;
END;

CREATE PROCEDURE GetUserBlogs
    @userId INT
AS
BEGIN
    SELECT 
        Blogs.Id,
        Blogs.Title,
        Blogs.Description
    FROM Blogs
    WHERE Blogs.UserId = @userId;
END;

CREATE FUNCTION GetBlogCountByCategory
    (@categoryId INT)
RETURNS INT
AS
BEGIN
    DECLARE @BlogCount INT;

    SELECT @BlogCount = COUNT(*)
    FROM Blogs
    WHERE Blogs.CategoryId = @categoryId;

    RETURN @BlogCount;
END;

CREATE FUNCTION GetUserBlogsTable
    (@userId INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        Blogs.Id,
        Blogs.Title,
        Blogs.Description
    FROM Blogs
    WHERE Blogs.UserId = @userId
);

ALTER TABLE Blogs
ADD isDeleted BIT DEFAULT 0;

CREATE TRIGGER SetBlogAsDeleted
ON Blogs
INSTEAD OF DELETE
AS
BEGIN
    UPDATE Blogs
    SET isDeleted = 1
    WHERE Id IN (SELECT Id FROM deleted);
END;
