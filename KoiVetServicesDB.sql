-- Sử dụng cơ sở dữ liệu master và tạo cơ sở dữ liệu mới
USE master;
GO

CREATE DATABASE KoiVetServicesDB;
GO

USE KoiVetServicesDB;
GO

-- Tạo bảng UserAccount để quản lý thông tin tài khoản người dùng
CREATE TABLE UserAccount (
    UserID INT PRIMARY KEY,             -- Mã định danh người dùng
    UserName NVARCHAR(50) NOT NULL,     -- Tên đăng nhập
    Password NVARCHAR(50) NOT NULL,     -- Mật khẩu
    Email NVARCHAR(100) NOT NULL UNIQUE,-- Địa chỉ email (phải duy nhất)
    Role NVARCHAR(20) NOT NULL          -- Vai trò của người dùng (Guest, Customer, Staff, Veterinarian, Manager)
);
GO

-- Thêm dữ liệu mẫu vào bảng UserAccount
INSERT INTO UserAccount VALUES(1, N'guest1', N'guestpass', N'guest1@koivet.com', N'Guest');
INSERT INTO UserAccount VALUES(2, N'customer1', N'customerpass', N'customer1@koivet.com', N'Customer');
INSERT INTO UserAccount VALUES(3, N'staff1', N'staffpass', N'staff1@koivet.com', N'Staff');
INSERT INTO UserAccount VALUES(4, N'veterinarian1', N'veterinarianpass', N'vet1@koivet.com', N'Veterinarian');
INSERT INTO UserAccount VALUES(5, N'manager1', N'managerpass', N'manager1@koivet.com', N'Manager');
GO

-- Tạo bảng Customer để quản lý thông tin khách hàng
CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,         -- Mã định danh khách hàng
    FullName NVARCHAR(100) NOT NULL,    -- Họ và tên khách hàng
    PhoneNumber NVARCHAR(15),           -- Số điện thoại
    Address NVARCHAR(200),              -- Địa chỉ khách hàng
    Email NVARCHAR(100),                -- Địa chỉ email khách hàng
    UserID INT,                         -- Mã định danh người dùng (liên kết tới UserAccount)
    FOREIGN KEY (UserID) REFERENCES UserAccount(UserID) -- Khóa ngoại liên kết với bảng UserAccount
);
GO

-- Thêm dữ liệu mẫu vào bảng Customer
INSERT INTO Customer VALUES(1, N'John Doe', N'123456789', N'123 Street, City', N'john@doe.com', 2);
GO

-- Tạo bảng Service để quản lý thông tin các loại dịch vụ
CREATE TABLE Service (
    ServiceID INT PRIMARY KEY,          -- Mã định danh dịch vụ
    ServiceName NVARCHAR(100) NOT NULL, -- Tên dịch vụ
    Description NVARCHAR(255) NOT NULL, -- Mô tả dịch vụ
    Price DECIMAL(10, 2) NOT NULL       -- Giá của dịch vụ
);
GO

-- Thêm dữ liệu mẫu vào bảng Service
INSERT INTO Service VALUES(1, N'Tư vấn trực tuyến', N'Tư vấn về cá Koi qua video', 50.00);
INSERT INTO Service VALUES(2, N'Kiểm tra tại nhà', N'Bác sĩ thú y đến tận nhà để kiểm tra', 100.00);
GO

-- Tạo bảng ServiceHistory để quản lý lịch sử dịch vụ của khách hàng
CREATE TABLE ServiceHistory (
    HistoryID INT PRIMARY KEY,          -- Mã định danh lịch sử dịch vụ
    CustomerID INT,                     -- Mã định danh khách hàng (liên kết tới Customer)
    ServiceID INT,                      -- Mã định danh dịch vụ (liên kết tới Service)
    VeterinarianID INT,                 -- Mã định danh bác sĩ thú y (liên kết tới UserAccount)
    ServiceDate DATETIME NOT NULL,      -- Ngày sử dụng dịch vụ
    Result NVARCHAR(255),               -- Kết quả dịch vụ
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),      -- Khóa ngoại liên kết với bảng Customer
    FOREIGN KEY (ServiceID) REFERENCES Service(ServiceID),         -- Khóa ngoại liên kết với bảng Service
    FOREIGN KEY (VeterinarianID) REFERENCES UserAccount(UserID)    -- Khóa ngoại liên kết với bảng UserAccount (cho bác sĩ thú y)
);
GO

-- Thêm dữ liệu mẫu vào bảng ServiceHistory
INSERT INTO ServiceHistory VALUES(1, 1, 1, 4, GETDATE(), N'Tư vấn thành công, sức khỏe cá tốt.');
GO

-- Tạo bảng VetSchedule để quản lý lịch làm việc của bác sĩ thú y
CREATE TABLE VetSchedule (
    ScheduleID INT PRIMARY KEY,         -- Mã định danh lịch trình
    VeterinarianID INT,                 -- Mã định danh bác sĩ thú y (liên kết tới UserAccount)
    ScheduleDate DATETIME NOT NULL,     -- Ngày lịch làm việc
    TimeSlot NVARCHAR(50),              -- Khung giờ làm việc
    FOREIGN KEY (VeterinarianID) REFERENCES UserAccount(UserID)    -- Khóa ngoại liên kết với bảng UserAccount
);
GO

-- Thêm dữ liệu mẫu vào bảng VetSchedule
INSERT INTO VetSchedule VALUES(1, 4, GETDATE(), N'08:00 - 12:00');
GO

-- Tạo bảng Feedback để quản lý đánh giá và phản hồi của khách hàng
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY,         -- Mã định danh đánh giá
    CustomerID INT,                     -- Mã định danh khách hàng (liên kết tới Customer)
    ServiceID INT,                      -- Mã định danh dịch vụ (liên kết tới Service)
    Rating INT CHECK (Rating >= 1 AND Rating <= 5), -- Đánh giá từ 1 đến 5
    Comments NVARCHAR(255),             -- Phản hồi của khách hàng
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),      -- Khóa ngoại liên kết với bảng Customer
    FOREIGN KEY (ServiceID) REFERENCES Service(ServiceID)          -- Khóa ngoại liên kết với bảng Service
);
GO

-- Thêm dữ liệu mẫu vào bảng Feedback
INSERT INTO Feedback VALUES(1, 1, 1, 5, N'Dịch vụ rất tốt, bác sĩ tư vấn tận tình.');
GO

-- Tạo bảng Cost để quản lý bảng giá các dịch vụ
CREATE TABLE Cost (
    CostID INT PRIMARY KEY,             -- Mã định danh chi phí
    ServiceID INT,                      -- Mã định danh dịch vụ (liên kết tới Service)
    Cost DECIMAL(10, 2) NOT NULL,       -- Chi phí của dịch vụ
    AdditionalFees DECIMAL(10, 2),      -- Các khoản phí bổ sung (nếu có)
    FOREIGN KEY (ServiceID) REFERENCES Service(ServiceID)          -- Khóa ngoại liên kết với bảng Service
);
GO

-- Thêm dữ liệu mẫu vào bảng Cost
INSERT INTO Cost VALUES(1, 1, 50.00, 0.00);
INSERT INTO Cost VALUES(2, 2, 100.00, 10.00);
GO

-- Tạo bảng Report để lưu trữ báo cáo tổng quan về dịch vụ và đánh giá
CREATE TABLE Report (
    ReportID INT PRIMARY KEY,           -- Mã định danh báo cáo
    ReportDate DATETIME NOT NULL,       -- Ngày lập báo cáo
    TotalCustomers INT,                 -- Tổng số khách hàng
    TotalServices INT,                  -- Tổng số dịch vụ đã thực hiện
    AverageRating DECIMAL(3, 2),        -- Điểm đánh giá trung bình
    Notes NVARCHAR(255)                 -- Ghi chú báo cáo
);
GO

-- Thêm dữ liệu mẫu vào bảng Report
INSERT INTO Report VALUES(1, GETDATE(), 1, 1, 5.00, N'Báo cáo dịch vụ tháng 1');
GO
