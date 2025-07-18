# 📚 Library Management System API

<div align="center">

![Library API](https://img.shields.io/badge/Library-API-blue?style=for-the-badge&logo=books)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-purple?style=for-the-badge&logo=.net)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red?style=for-the-badge&logo=microsoft-sql-server)
![Clean Architecture](https://img.shields.io/badge/Clean%20Architecture-✅-green?style=for-the-badge)

*A comprehensive library management system built with ASP.NET Core 8.0 and SQL Server*

[![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen?style=flat-square)](https://github.com/your-repo/library-api)
[![License](https://img.shields.io/badge/License-MIT-blue?style=flat-square)](LICENSE)
[![Contributors](https://img.shields.io/badge/Contributors-1-orange?style=flat-square)](https://github.com/your-repo/library-api/graphs/contributors)

</div>

---

## 🏗️ Architecture Overview

This project follows **Clean Architecture** principles with a well-structured layered approach:

```
📁 LibraryAPI/
├── 📁 Core/                    # Domain entities and business logic
├── 📁 Application/             # Use cases and application services
├── 📁 Infrastructure/          # Data access and external services
└── 📁 Presentation/            # API controllers and presentation layer
```

<div align="center">

```
┌─────────────────────────────────────────────────────────────┐
│                    Clean Architecture                       │
├─────────────────────────────────────────────────────────────┤
│  ┌─────────────────┐  ┌─────────────────┐  ┌──────────────┐ │
│  │   Presentation  │  │   Application   │  │   Domain     │ │
│  │     Layer       │  │     Layer       │  │   Layer      │ │
│  │                 │  │                 │  │              │ │
│  │ • Controllers   │  │ • Services      │  │ • Entities   │ │
│  │ • DTOs          │  │ • Use Cases     │  │ • Interfaces │ │
│  │ • Middleware    │  │ • Validators    │  │ • Value Obj. │ │
│  └─────────────────┘  └─────────────────┘  └──────────────┘ │
│           │                     │                    │      │
│           └─────────────────────┼────────────────────┘      │
│                                 │                           │
│  ┌─────────────────────────────────────────────────────────┐ │
│  │                Infrastructure Layer                     │ │
│  │                                                         │ │
│  │ • Data Access (EF Core)                                 │ │
│  │ • External Services                                     │ │
│  │ • Configuration                                         │ │
│  │ • Logging                                               │ │
│  └─────────────────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
```

</div>

---

## 🚀 Features

### 📖 Core Management
- **Books Management** - Complete CRUD operations for books
- **Authors Management** - Author information and book associations
- **Publishers Management** - Publisher details and book relationships
- **Categories Management** - Book categorization system
- **Shelves Management** - Physical shelf organization

### 👥 User Management
- **Employees Management** - Staff and librarian accounts
- **Users Management** - Library member registration
- **Floor Management** - Multi-floor library organization

### 🔄 Borrowing System
- **Book Borrowing** - Complete borrowing workflow
- **Overdue Tracking** - Automatic overdue detection
- **User History** - Borrowing history per user
- **Employee Tracking** - Staff handling records

### 🔍 Advanced Features
- **Search & Filter** - Advanced querying capabilities
- **Date Range Queries** - Time-based filtering
- **Relationship Mapping** - Full entity relationships
- **Data Validation** - Comprehensive input validation

---

## 🛠️ Technology Stack

| Component | Technology | Version |
|-----------|------------|---------|
| **Framework** | ASP.NET Core | 9.0 |
| **Database** | SQL Server | 2022 |
| **ORM** | Entity Framework Core | 9.0 |
| **AutoMapper** | Object Mapping | 12.0 |
| **Swagger** | API Documentation | 6.5 |

<div align="center">

```
┌─────────────────────────────────────────────────────────────┐
│                    Technology Stack                         │
├─────────────────────────────────────────────────────────────┤
│                                                             │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐         │
│  │ ASP.NET     │  │ SQL Server  │  │ Entity      │         │
│  │ Core 9.0    │  │ 2022        │  │ Framework   │         │
│  │             │  │             │  │ Core 9.0    │         │
│  └─────────────┘  └─────────────┘  └─────────────┘         │
│         │                │                │                │
│         └────────────────┼────────────────┘                │
│                          │                                 │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐         │
│  │ AutoMapper  │  │ Swagger     │  │ Docker      │         │
│  │ 12.0        │  │ 6.5         │  │ & Compose   │         │
│  │             │  │             │  │             │         │
│  └─────────────┘  └─────────────┘  └─────────────┘         │
│                                                             │
└─────────────────────────────────────────────────────────────┘
```

</div>

---

## 📋 Prerequisites

Before running this application, ensure you have:

- **.NET 9.0 SDK** or later
- **SQL Server 2022** or later
- **Visual Studio 2022** or **VS Code**
- **SQL Server Management Studio** (optional)

<div align="center">

```
┌─────────────────────────────────────────┐
│              Prerequisites              │
├─────────────────────────────────────────┤
│                                         │
│  ✅ .NET 9.0 SDK                        │
│  ✅ SQL Server 2022                     │
│  ✅ Visual Studio 2022                  │
│  ✅ Git                                 │
│  ✅ Docker (Optional)                   │
│  ✅ Postman (Optional)                  │
│                                         │
└─────────────────────────────────────────┘
```

</div>

---

## ⚡ Quick Start

### 1. Clone the Repository
```bash
git clone https://github.com/your-repo/library-api.git
cd library-api
```

### 2. Configure Database
Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=LibraryDB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

### 3. Run Migrations
```bash
dotnet ef database update
```

### 4. Start the Application
```bash
dotnet run
```

### 5. Access Swagger UI
Navigate to: `https://localhost:7035/swagger`

<div align="center">

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                              Swagger UI                                     │
├─────────────────────────────────────────────────────────────────────────────┤
│                                                                             │
│  📚 Library Management System API                                          │
│  ───────────────────────────────────────────────────────────────────────   │
│                                                                             │
│  🔍 Books                    [GET] /api/Books                              │
│  📖 Authors                  [GET] /api/Authors                            │
│  🏢 Publishers               [GET] /api/Publishers                         │
│  📂 Categories               [GET] /api/Categories                         │
│  📚 Shelves                  [GET] /api/Shelves                            │
│  👥 Employees                [GET] /api/Employees                          │
│  🏢 Floors                   [GET] /api/Floors                             │
│  👤 Users                    [GET] /api/Users                              │
│  🔄 BookBorrows              [GET] /api/BookBorrows                        │
│                                                                             │
│  🌐 Access at: https://localhost:7035/swagger                              │
│                                                                             │
└─────────────────────────────────────────────────────────────────────────────┘
```

</div>

---

## 📚 API Endpoints Documentation

### 🔐 Authentication & Authorization
*Currently using basic authentication. JWT implementation planned for future releases.*

### 📖 Books Management

#### Get All Books
```http
GET /api/Books
```
**Response:**
```json
[
  {
    "id": 1,
    "title": "The Great Gatsby",
    "shelfCode": "FIC-001",
    "categoryId": 1,
    "publisherId": 1,
    "category": {
      "id": 1,
      "catName": "Fiction"
    },
    "publisher": {
      "id": 1,
      "name": "Scribner"
    },
    "authors": [
      {
        "id": 1,
        "name": "F. Scott Fitzgerald"
      }
    ]
  }
]
```

#### Get Book by ID
```http
GET /api/Books/{id}
```

#### Create New Book
```http
POST /api/Books
Content-Type: application/json

{
  "title": "New Book Title",
  "shelfCode": "FIC-002",
  "categoryId": 1,
  "publisherId": 1
}
```

#### Update Book
```http
PUT /api/Books/{id}
Content-Type: application/json

{
  "title": "Updated Book Title",
  "shelfCode": "FIC-002",
  "categoryId": 1,
  "publisherId": 1
}
```

#### Delete Book
```http
DELETE /api/Books/{id}
```

### 👨‍💼 Authors Management

#### Get All Authors
```http
GET /api/Authors
```

#### Get Author by ID
```http
GET /api/Authors/{id}
```

#### Create New Author
```http
POST /api/Authors
Content-Type: application/json

{
  "name": "New Author Name"
}
```

#### Update Author
```http
PUT /api/Authors/{id}
Content-Type: application/json

{
  "name": "Updated Author Name"
}
```

#### Delete Author
```http
DELETE /api/Authors/{id}
```

### 🏢 Publishers Management

#### Get All Publishers
```http
GET /api/Publishers
```

#### Get Publisher by ID
```http
GET /api/Publishers/{id}
```

#### Create New Publisher
```http
POST /api/Publishers
Content-Type: application/json

{
  "name": "New Publisher Name"
}
```

#### Update Publisher
```http
PUT /api/Publishers/{id}
Content-Type: application/json

{
  "name": "Updated Publisher Name"
}
```

#### Delete Publisher
```http
DELETE /api/Publishers/{id}
```

### 📂 Categories Management

#### Get All Categories
```http
GET /api/Categories
```

#### Get Category by ID
```http
GET /api/Categories/{id}
```

#### Create New Category
```http
POST /api/Categories
Content-Type: application/json

{
  "catName": "New Category Name"
}
```

#### Update Category
```http
PUT /api/Categories/{id}
Content-Type: application/json

{
  "catName": "Updated Category Name"
}
```

#### Delete Category
```http
DELETE /api/Categories/{id}
```

### 📚 Shelves Management

#### Get All Shelves
```http
GET /api/Shelves
```

#### Get Shelf by ID
```http
GET /api/Shelves/{id}
```

#### Create New Shelf
```http
POST /api/Shelves
Content-Type: application/json

{
  "shelfCode": "SHELF-001",
  "floorId": 1
}
```

#### Update Shelf
```http
PUT /api/Shelves/{id}
Content-Type: application/json

{
  "shelfCode": "SHELF-001",
  "floorId": 1
}
```

#### Delete Shelf
```http
DELETE /api/Shelves/{id}
```

### 👥 Employees Management

#### Get All Employees
```http
GET /api/Employees
```

#### Get Employee by ID
```http
GET /api/Employees/{id}
```

#### Create New Employee
```http
POST /api/Employees
Content-Type: application/json

{
  "name": "John Doe",
  "email": "john.doe@library.com",
  "phone": "+1234567890",
  "floorId": 1
}
```

#### Update Employee
```http
PUT /api/Employees/{id}
Content-Type: application/json

{
  "name": "John Doe Updated",
  "email": "john.updated@library.com",
  "phone": "+1234567890",
  "floorId": 1
}
```

#### Delete Employee
```http
DELETE /api/Employees/{id}
```

### 🏢 Floors Management

#### Get All Floors
```http
GET /api/Floors
```

#### Get Floor by ID
```http
GET /api/Floors/{id}
```

#### Create New Floor
```http
POST /api/Floors
Content-Type: application/json

{
  "floorNumber": 3,
  "numberOfBlocks": 8
}
```

#### Update Floor
```http
PUT /api/Floors/{id}
Content-Type: application/json

{
  "floorNumber": 3,
  "numberOfBlocks": 10
}
```

#### Delete Floor
```http
DELETE /api/Floors/{id}
```

### 👤 Users Management

#### Get All Users
```http
GET /api/Users
```

#### Get User by SSN
```http
GET /api/Users/{ssn}
```

#### Create New User
```http
POST /api/Users
Content-Type: application/json

{
  "ssn": "123456789",
  "name": "Jane Smith",
  "email": "jane.smith@email.com",
  "phone": "+1987654321",
  "registeredByEmployeeId": 1
}
```

#### Update User
```http
PUT /api/Users/{ssn}
Content-Type: application/json

{
  "name": "Jane Smith Updated",
  "email": "jane.updated@email.com",
  "phone": "+1987654321",
  "registeredByEmployeeId": 1
}
```

#### Delete User
```http
DELETE /api/Users/{ssn}
```

### 🔄 Book Borrows Management

#### Get All Book Borrows
```http
GET /api/BookBorrows
```

#### Get Book Borrow by ID
```http
GET /api/BookBorrows/{id}
```

#### Create New Book Borrow
```http
POST /api/BookBorrows
Content-Type: application/json

{
  "bookId": 1,
  "userSSN": "123456789",
  "employeeId": 1,
  "dateBorrowed": "2024-01-15T10:00:00Z",
  "dueDate": "2024-02-15T10:00:00Z",
  "amountPaid": 5.00
}
```

#### Update Book Borrow
```http
PUT /api/BookBorrows/{id}
Content-Type: application/json

{
  "bookId": 1,
  "userSSN": "123456789",
  "employeeId": 1,
  "dateBorrowed": "2024-01-15T10:00:00Z",
  "dueDate": "2024-02-20T10:00:00Z",
  "amountPaid": 7.50
}
```

#### Delete Book Borrow
```http
DELETE /api/BookBorrows/{id}
```

#### Get Borrows by User
```http
GET /api/BookBorrows/user/{userSSN}
```

#### Get Borrows by Book
```http
GET /api/BookBorrows/book/{bookId}
```

#### Get Borrows by Employee
```http
GET /api/BookBorrows/employee/{employeeId}
```

#### Get Overdue Books
```http
GET /api/BookBorrows/overdue
```

#### Get Borrows by Date Range
```http
GET /api/BookBorrows/daterange?startDate=2024-01-01&endDate=2024-12-31
```

---

## 🗄️ Database Schema

<div align="center">

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                              Database Schema                                │
├─────────────────────────────────────────────────────────────────────────────┤
│                                                                             │
│  ┌─────────────┐    ┌─────────────┐    ┌─────────────┐                     │
│  │   Books     │    │  Authors    │    │ Publishers  │                     │
│  │             │    │             │    │             │                     │
│  │ • Id        │    │ • Id        │    │ • Id        │                     │
│  │ • Title     │    │ • Name      │    │ • Name      │                     │
│  │ • ShelfCode │    └─────────────┘    └─────────────┘                     │
│  │ • CategoryId│           │                    │                          │
│  │ • PublisherId│          │                    │                          │
│  └─────────────┘           │                    │                          │
│           │                │                    │                          │
│           │                │                    │                          │
│  ┌─────────────┐    ┌─────────────┐    ┌─────────────┐                     │
│  │ Categories  │    │ BookAuthors │    │ BookBorrows │                     │
│  │             │    │             │    │             │                     │
│  │ • Id        │    │ • BookId    │    │ • Id        │                     │
│  │ • CatName   │    │ • AuthorId  │    │ • BookId    │                     │
│  └─────────────┘    └─────────────┘    │ • UserSSN   │                     │
│           │                            │ • EmployeeId│                     │
│           │                            │ • DateBorrowed│                   │
│  ┌─────────────┐    ┌─────────────┐    │ • DueDate   │                     │
│  │   Shelves   │    │  Employees  │    │ • AmountPaid│                     │
│  │             │    │             │    └─────────────┘                     │
│  │ • Id        │    │ • Id        │              │                         │
│  │ • ShelfCode │    │ • Name      │              │                         │
│  │ • FloorId   │    │ • Email     │              │                         │
│  └─────────────┘    │ • Phone     │              │                         │
│           │         │ • Salary    │              │                         │
│           │         │ • Bonus     │              │                         │
│  ┌─────────────┐    │ • FloorId   │    ┌─────────────┐                     │
│  │   Floors    │    └─────────────┘    │    Users    │                     │
│  │             │              │        │             │                     │
│  │ • Id        │              │        │ • SSN       │                     │
│  │ • FloorNumber│             │        │ • Name      │                     │
│  │ • NumberOfBlocks│          │        │ • Email     │                     │
│  └─────────────┘              │        │ • Phone     │                     │
│                               │        │ • RegisteredByEmployeeId│         │
│                               │        └─────────────┘                     │
│                               │                                              │
└─────────────────────────────────────────────────────────────────────────────┘
```

</div>

### Entity Relationships

| Entity | Relationships |
|--------|---------------|
| **Book** | Category, Publisher, Authors (Many-to-Many), BookBorrows |
| **Author** | Books (Many-to-Many) |
| **Publisher** | Books |
| **Category** | Books |
| **Shelf** | Floor, Books |
| **Floor** | Shelves, Employees |
| **Employee** | Floor, BookBorrows, Users |
| **User** | Employee (RegisteredBy), BookBorrows |
| **BookBorrow** | Book, User, Employee |

---

## 🔧 Configuration

### Environment Variables
```bash
# Database
ConnectionStrings__DefaultConnection=Server=localhost;Database=LibraryDB;Trusted_Connection=true;TrustServerCertificate=true;

# Logging
Logging__LogLevel__Default=Information
Logging__LogLevel__Microsoft.AspNetCore=Warning

# Swagger
ASPNETCORE_ENVIRONMENT=Development
```

### App Settings
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=LibraryDB;Trusted_Connection=true;TrustServerCertificate=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

---


---

## 📊 Sample Data

The application comes with comprehensive sample data including:

- **6 Floors** with varying block counts
- **12 Employees** across different floors
- **8 Users** with realistic information
- **6 Authors** from various genres
- **6 Publishers** including major publishing houses
- **8 Categories** covering different book types
- **12 Books** with full relationships
- **10 Book Borrows** with realistic scenarios

<div align="center">

```
┌─────────────────────────────────────────────────────────────┐
│                        Sample Data                          │
├─────────────────────────────────────────────────────────────┤
│                                                             │
│  📊 Database Statistics:                                    │
│  ───────────────────────────────────────────────────────   │
│                                                             │
│  🏢 Floors: 6 floors with varying block counts             │
│  👥 Employees: 12 staff members across different floors    │
│  👤 Users: 8 library members with realistic information    │
│  📖 Authors: 6 authors from various genres                 │
│  🏢 Publishers: 6 major publishing houses                  │
│  📂 Categories: 8 different book categories                │
│  📚 Books: 12 books with full relationships                │
│  🔄 BookBorrows: 10 realistic borrowing scenarios          │
│                                                             │
│  🎯 Ready for testing and development!                     │
│                                                             │
└─────────────────────────────────────────────────────────────┘
```

</div>

---

---

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 📞 Support

If you have any questions or need support:

- 📧 Email: 1seif1ahmed1@gmail.com

<div align="center">

```
┌─────────────────────────────────────────┐
│                Support                  │
├─────────────────────────────────────────┤
│                                         │
│  📧 Email: 1seif1ahmed1@gmail.com       │
│                                         │
│  🚀 We're here to help!                 │
│                                         │
└─────────────────────────────────────────┘
```

</div>

---

## 🙏 Acknowledgments

- **ASP.NET Core Team** for the amazing framework
- **Entity Framework Team** for the excellent ORM
- **Swagger Team** for the API documentation tools
- **Clean Architecture Community** for the architectural patterns

---

<div align="center">

**Made with ❤️ by Seif Ahmed :) **

</div> 