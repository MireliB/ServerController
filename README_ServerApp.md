# ServerApp – Terminal-based User Manager with SQL Server

This project is a C# console application for managing users via a terminal-based interface.  
It's connected to a Microsoft SQL Server database and supports full CRUD operations (Create, Read, Update, Delete),  
batch processing, and a basic HTTP server for retrieving all users via GET request.

---

## Project Structure

```
ServerApp/
├── Models/
│   └── User.cs              # User model matching the SQL table
├── Controllers/
│   └── UserController.cs    # Handles all CRUD logic using ADO.NET
├── Services/
│   └── UserBatchService.cs  # Processes users in batch (e.g., sends emails)
├── Server/
│   └── HttpServer.cs        # Basic HTTP Server exposing /users endpoint
├── DbTest.cs                # Test connection to SQL Server
├── Program.cs               # Console-based UI for CRUD
├── ServerApp.csproj         # Project configuration
```

---

## Features

### Terminal Menu (via `Program.cs`)
- `1. Show All Users` → Retrieves and lists all users from DB.
- `2. Add User` → Adds a new user (name, email, password).
- `3. Delete User by ID` → Deletes user based on input ID.
- `4. Edit User by ID` → Updates name, email or password.
- `5. Exit` → Quits the program.

### Controller (`UserController.cs`)
- `AddUser(User user)`
- `GetAllUsers()`
- `GetUser(int id)`
- `UpdateUser(User user)`
- `DeleteUser(int id)`

### Batch Service
- `UserBatchService.Process()` → Simulates email sending to all users.

### HTTP Server
- Endpoint: `GET http://localhost:8080/users` → Returns all users in JSON format.

---

## Technologies Used

- C# (.NET 6.0)
- ADO.NET (`System.Data.SqlClient`)
- Microsoft SQL Server (Express)
- Console application
- Basic HTTP Listener
- Manual dependency wiring (no DI framework)

---

## 🗃️ Database Requirements

Ensure the following table exists in your `MyDatabase` SQL Server:

```sql
CREATE TABLE Users (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    Email VARCHAR(100),
    Password VARCHAR(100)
);
```

Make sure your SQL Server instance is running (e.g., `localhost\SQLEXPRESS`).

---

## Connection String

The following connection string is used in multiple files:

```csharp
"Server=localhost\SQLEXPRESS;Database=MyDatabase;Trusted_Connection=True;"
```

---

## Running the App

### From Terminal

```bash
dotnet build
dotnet run
```

### Using HTTP API (optional)
Start the `HttpServer` class and access:
```
http://localhost:8080/users
```

---

## Packages

```xml
<PackageReference Include="System.Data.SqlClient" Version="4.9.0" />
```

---

## Possible Improvements

- Add password hashing (e.g., using BCrypt)
- Add input validation
- Add logging
- Use Dependency Injection
- Replace manual SQL with Entity Framework Core

---

## Contact

Built by Mirel.