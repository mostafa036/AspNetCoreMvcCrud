**AspNetCoreMvcCrudApp**

Overview
AspNetCoreMvcCrudApp is a sample project demonstrating CRUD operations using ASP.NET Core MVC, LINQ, and Entity Framework. This project integrates various technologies and design patterns  to provide a robust, scalable, and secure web application.

Technology Stack
  Backend: .NET Core, ASP.NET MVC
  Data Access: LINQ, Entity Framework
  Database: MSSQL
  Authentication: Integrated Identity for secure access control
  Architecture: Onion Architecture
  Frontend: HTML, CSS, Bootstrap

Features
  CRUD Operations: Create, Read, Update, Delete functionalities.
  Secure Authentication: Integrated Identity for user authentication and authorization.\
  Responsive UI: Built with Bootstrap for a mobile-first, responsive design.
  Design Patterns: Implements the Unit Of Work pattern for better data management and testing.

Project Structure

  The project follows the Onion Architecture, which promotes a separation of concerns and makes the application more maintainable and testable.
  
  AspNetCoreMvcCrudApp/
│
├── AspNetCoreMvcCrudApp.Api           # Web API layer
├── AspNetCoreMvcCrudApp.Application   # Application layer
├── AspNetCoreMvcCrudApp.Domain        # Domain layer
├── AspNetCoreMvcCrudApp.Infrastructure # Infrastructure layer
└── AspNetCoreMvcCrudApp.Web           # Presentation layer (MVC)



Setup and Installation 

 Prerequisites
   .NET Core SDK
   Visual Studio 2019 or later
   SQL Server

Steps

    1-Clone the repository
      git clone https://github.com/yourusername/AspNetCoreMvcCrudApp.git 
      
    2- Navigate to the project directory
      cd AspNetCoreMvcCrudApp

    3-Set up the database
      Update the connection string in appsettings.json file in the Web project.
 
   "ConnectionStrings": {
   "DefaultConnection": "Server=your_server;Database=AspNetCoreMvcCrudAppDb;User Id=your_username;Password=your_password;"
   }

    }
    
 4-Apply migrations
   dotnet ef database update
   
 5-Run the application
   dotnet run --project AspNetCoreMvcCrudApp.Web
   
 6-Open in your browser

Navigate to https://localhost:5001 to see the application in action.

Usage
Once the application is up and running, you can perform the following operations:

* Create: Add new records to the database.
* Read: View records from the database.
* Update: Modify existing records.
* Delete: Remove records from the database.
* 
Contributing
Contributions are welcome! Please submit a pull request or open an issue for any suggestions or improvements.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
For any inquiries or feedback, feel free to reach out:

Email: mostafa.omara063@gmail.com
GitHub: mostafa063


   
  
