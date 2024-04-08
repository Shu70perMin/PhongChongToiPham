CREATE DATABASE PCTPDatabase;

USE PCTPDatabase;

CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    FullName NVARCHAR(50) NOT NULL,
    UserName NVARCHAR(50) NOT NULL,
    UserEmail NVARCHAR(100) NOT NULL,
    UserPhone NVARCHAR(20) NOT NULL,
    UserPassword NVARCHAR(100) NOT NULL,
    UserRole NVARCHAR(10) CHECK (UserRole IN (N'admin', N'customer')) 
);

INSERT INTO Users (UserID, FullName, UserName, UserEmail, UserPhone, UserPassword, UserRole)
VALUES 
(1, N'Nguyễn Văn Admin', N'admin', N'admin@example.com', N'123456789', N'adminpassword', N'admin'),
(2, N'Phạm Thị Khách Hàng', N'customer1', N'customer1@example.com', N'987654321', N'customerpassword', N'customer');


CREATE TABLE Crime (
    CrimeID INT PRIMARY KEY,
    CrimeName NVARCHAR(100) NOT NULL,
    CrimeType NVARCHAR(100),
    CrimeGender NVARCHAR(10),
    CrimeDOB DATE,
    CrimeAddress NVARCHAR(255),
    Hometown NVARCHAR(255),
    Status NVARCHAR(20) CHECK (Status IN (N'chưa tóm', N'đã tóm')), 
    SeverityLevel NVARCHAR(20) CHECK (SeverityLevel IN (N'thấp', N'trung bình', N'nguy hiểm', N'rất nguy hiểm')) 
);

INSERT INTO Crime (CrimeID, CrimeName, CrimeType, CrimeGender, CrimeDOB, CrimeAddress, Hometown, Status, SeverityLevel)
VALUES 
(1, N'Vụ cướp ngân hàng', N'Robbery', N'Male', '1990-05-15', N'123 Main Street', N'Hanoi', N'đã tóm', N'nguy hiểm'),
(2, N'Vụ trộm nhà dân', N'Burglary', N'Female', '1985-10-20', N'456 Elm Street', N'Ho Chi Minh City', N'chưa tóm', N'trung bình');


CREATE TABLE CrimeDetail (
    DetailID INT PRIMARY KEY,
    CrimeID INT,
    DateOfCrime DATETIME,
    ModusOperandi NVARCHAR(255),
    VictimName NVARCHAR(100),
    InformantName NVARCHAR(100),
    InformantID INT,
    ReportImageURL NVARCHAR(255),
    FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID),
    FOREIGN KEY (InformantID) REFERENCES Users(UserID) 
);

INSERT INTO CrimeDetail (DetailID, CrimeID, DateOfCrime, ModusOperandi, VictimName, InformantName, InformantID, ReportImageURL)
VALUES 
(1, 1, '2024-04-01 09:30:00', N'Đe doạ sử dụng vũ khí', N'Nguyễn Thị A', N'Trần Văn B', 2, N'http://example.com/report_image1.jpg'),
(2, 2, '2024-03-28 22:00:00', N'Thủ đoạn khéo léo', N'Trần Văn C', N'Phạm Thị D', 2, N'http://example.com/report_image2.jpg');


CREATE TABLE Report (
    ReportID INT PRIMARY KEY,
    UserID INT,
    CrimeID INT, 
    ReportDate DATETIME,
    Statement NVARCHAR(MAX),
    ReportImageURL NVARCHAR(255),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
);

INSERT INTO Report (ReportID, UserID, CrimeID, ReportDate, Statement, ReportImageURL)
VALUES 
(1, 2, 1, '2024-04-02 15:45:00', N'Tôi đã chứng kiến vụ cướp ngân hàng và ghi lại hình ảnh bằng điện thoại di động.', N'http://example.com/report_image3.jpg'),
(2, 2, 2, '2024-03-29 08:20:00', N'Tôi đã thấy một người lạ đột nhập vào ngôi nhà bên cạnh và đã báo công an.', N'http://example.com/report_image4.jpg');


CREATE TABLE BlogPosts (
    PostID INT PRIMARY KEY,
    UserID INT,
    Title NVARCHAR(255) NOT NULL,
    Content NVARCHAR(MAX),
    PostDate DATETIME,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

INSERT INTO BlogPosts (PostID, UserID, Title, Content, PostDate)
VALUES 
(1, 1, N'Cách phòng chống tội phạm', N'Trong bài viết này, chúng tôi sẽ chia sẻ một số cách để bảo vệ bản thân và tài sản khỏi tội phạm.', '2024-04-05 10:00:00'),
(2, 2, N'Kinh nghiệm bảo mật nhà cửa', N'Trên thực tế, những biện pháp bảo mật đơn giản nhưng hiệu quả có thể ngăn chặn nhiều vụ trộm.', '2024-04-07 14:30:00');


CREATE TABLE Comments (
    CommentID INT PRIMARY KEY,
    PostID INT,
    UserID INT,
    Comment NVARCHAR(MAX),
    CommentDate DATETIME,
    FOREIGN KEY (PostID) REFERENCES BlogPosts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

INSERT INTO Comments (CommentID, PostID, UserID, Comment, CommentDate)
VALUES 
(1, 1, 2, N'Bài viết rất hữu ích, cảm ơn bạn đã chia sẻ!', '2024-04-05 11:30:00'),
(2, 2, 1, N'Tôi đồng ý! Đôi khi những biện pháp đơn giản nhưng hiệu quả là quan trọng nhất.', '2024-04-07 15:45:00');
