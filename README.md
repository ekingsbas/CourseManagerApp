# CourseManagerApp

CourseManagerApp is a simple web application that manages "Course" records. The application is built with a .NET 8 Web API backend and a React frontend. It provides an intuitive UI for adding, removing, and searching courses, as well as listing all current courses stored in a SQL Server database.

## Features

- **Course Management**: The application handles the following course information:
  - `id`: Auto-incremented integer
  - `subject`: 3-letter abbreviation (e.g., BIO, MAT)
  - `courseNumber`: A three-digit, zero-padded integer (e.g., 033, 101)
  - `description`: Text description of the course
- **Search**: Allows users to search for a course by description, with partial matches (e.g., searching "Bio" will find "Introduction to Biology").
- **Add Course**: Users can add new courses to the system. `subject` and `courseNumber` must be unique. Duplicate entries will be prevented.
- **Delete Course**: Users can remove any existing course from the list.
- **Validation**: Ensures `courseNumber` follows the required three-digit format. Invalid input triggers an error message.

## Architecture

- **Backend**: The backend is a .NET 8 Web API project that uses a layered architecture:
  - **Repository Pattern**: The application separates data access using repositories, which encapsulate the logic for interacting with the database.
  - **Dependency Injection**: Services and repositories are injected where needed to promote loose coupling and testability.
  - **Interface Segregation**: Interfaces are well-defined and only expose the necessary operations for each component, ensuring better maintainability.
- **Frontend**: The frontend is a React application that interacts with the Web API to fetch and display data to the user in real time.

## Setup Instructions

To get the application running locally, follow these steps:

### 1. Clone the repository

```bash
git clone https://github.com/yourusername/CourseManagerApp.git
```

### 2. Backend Setup (ASP.NET Core Web API)

1. Open the solution in Visual Studio 2022.
2. The solution includes a project that defines the SQL Server database and tables needed for the application. Before running the application, make sure to:
   - Adjust the database connection string in the `appsettings.json` file to match your local SQL Server environment.
   - Publish the database project to your SQL Server instance to create the necessary tables and schema.
3. Run the backend by pressing `F5` in Visual Studio.

### 3. Frontend Setup (React Application)

1. Navigate to the frontend directory:

   ```bash
   cd Frontend/coursemanagerappclient
   ```

2. Install the required packages:

   ```bash
   npm install
   ```

3. Start the React application:

   ```bash
   npm start
   ```

### 4. Usage

- Once both the backend and frontend are running, open your browser and navigate to `http://localhost:3000` to interact with the CourseManagerApp.
- Use the UI to add new courses, search for existing courses, and delete them.

### Database Details

The application uses a SQL Server database to store course records. The database project will create a `Courses` table with the following structure:

| Column        | Type          | Description                              |
|---------------|---------------|------------------------------------------|
| `id`          | INT           | Auto-incremented primary key             |
| `subject`     | VARCHAR(50)   | 3-letter course subject (e.g., BIO, MAT) |
| `courseNumber`| CHAR(50)      | Zero-padded course number (e.g., 033)    |
| `description` | VARCHAR(MAX)  | Description of the course                |

### Additional Notes

- This project follows a clean, layered architecture with a separation of concerns between data, business logic, and presentation layers.
- The backend is built with best practices such as the Repository Pattern, Dependency Injection, and Interface Segregation.
- The frontend is connected to the backend via RESTful API calls, providing a simple but effective UI for managing courses.
- The application has been developed and tested using Google Chrome.

## Conclusion

This application is a basic demonstration of full-stack development using .NET 8 and React, with a clean architecture and good practices for backend and frontend separation. It can be extended further or used as a template for similar projects.
