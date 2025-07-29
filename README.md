# EmployeeCRUDApi-ASP.NET-Core-WebApi

This is a simple CRUD (Create, Read, Update, Delete) Web API built with **.NET 8** and **Entity Framework Core (Database-First)**.

---

## 📌 Features

- ✅ Get all employees
- ✅ Get an employee by ID
- ✅ Add a new employee
- ✅ Update an existing employee
- ✅ Delete an employee
- ✅ API testing with Swagger UI
- ✅ Clean architecture with Repository Pattern (optional)

---

## 🛠️ Technologies Used

- .NET 8 Web API
- Entity Framework Core 8 (Database-First)
- SQL Server
- Swagger/OpenAPI
- Visual Studio / VS Code

---

## 📂 Folder Structure

```

EmployeeApi/
├── Controllers/
│   └── EmployeesController.cs
├── Models/                
│   ├── Employee.cs
│   └── EmployeeDbContext.cs
├── Program.cs
├── appsettings.json
└── README.md

````

---

## ⚙️ Setup Instructions

### 1. 📥 Clone the Repository

```bash
git clone https://github.com/yourusername/EmployeeApi.git
cd EmployeeApi
````

---

### 2. 🔧 Configure Database Connection

Update `appsettings.json` with your actual SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=YourDatabaseName;Trusted_Connection=True;"
}
```

---

### 3. 📦 Install Required NuGet Packages

```bash
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
```

---

### 4. 🧬 Scaffold the Models and DbContext

```bash
dotnet ef dbcontext scaffold "Server=.;Database=YourDatabaseName;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

> Make sure `dotnet-ef` is installed:
>
> ```bash
> dotnet tool install --global dotnet-ef
> ```

---

### 5. 🚀 Run the Application

```bash
dotnet run or use run oprtion in visual studio
```

Visit Swagger UI:

```
https://localhost:5001/swagger
```

---

## 📮 API Endpoints

| Method | Endpoint            | Description              |
| ------ | ------------------- | ------------------------ |
| GET    | /api/employees      | Get all employees        |
| GET    | /api/employees/{id} | Get employee by ID       |
| POST   | /api/employees      | Add new employee         |
| PUT    | /api/employees/{id} | Update existing employee |
| DELETE | /api/employees/{id} | Delete employee          |

---

## 🧪 Testing

Use Swagger UI or Postman to test the API endpoints.

---

## 📌 Notes

* This project uses **Database-First** approach: Tables must exist before scaffolding.
* Swagger is enabled for testing and documentation.
* You can extend it with authentication, DTOs, logging, or unit tests as needed.

---

## 👨‍💻 Author

Gayan Muthukumara
Email: mglmuthukumara@gmail.com

---



