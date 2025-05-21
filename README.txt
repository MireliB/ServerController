Project Explanation - ServerApp Terminal-Based User Manager

This project was developed as part of a home assignment using C# (.NET) and SQL Server.
It includes a full terminal-based interface to perform CRUD operations on users stored in a database.

-----------------------------------------------------
Structure:
- Models/User.cs          → Represents the User table structure.
- Controllers/UserController.cs → Contains all database logic using SqlClient.
- Program.cs              → Main entry point with a terminal-based UI.

-----------------------------------------------------
Features Implemented:

1. Add User
   - Input: Name, Email, Password
   - Saves to SQL Server via INSERT

2. Show All Users
   - Retrieves all users from the DB
   - Displays ID, Name, Email

3. Delete User by ID
   - Deletes user by inputting a valid ID

4. Edit User by ID
   - Retrieves user
   - Allows updating name, email, password (optionally)

5. Exit Program
   - Ends the application

-----------------------------------------------------
Technologies Used:
- C# .NET 6.0
- SQL Server 2022 Express
- ADO.NET (System.Data.SqlClient)
- Console Application

-----------------------------------------------------
Flow:
- Program.cs presents a menu
- User selects an option (1-5)
- Each action communicates with the controller
- The controller handles DB operations securely

-----------------------------------------------------
Tips:
- Connection string is configured to: 
  Server=localhost\SQLEXPRESS;Database=MyDatabase;Trusted_Connection=True;

- Ensure SQL Server and database 'MyDatabase' exist.
- Table 'Users' must have: ID, Name, Email, Password

-----------------------------------------------------
Room to Expand:
- Add hashed password with BCrypt
- Add search by email
- Add paging to user list
- Implement Unit Tests
