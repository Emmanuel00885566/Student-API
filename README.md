
# Student API (.NET 8 Minimal API)

This is a simple **Student Management API** built with **.NET 8 Minimal API** and **Entity Framework Core**.  
It allows you to **create**, **read**, **update**, and **delete (CRUD)** student records easily.

---

## Features
- Add a new student  
- Get all students  
- Get a single student by ID  
- Update student details  
- Delete a student  
- Uses SQLite for database storage  

---

## Tools & Technologies
- **.NET 8 SDK**
- **Entity Framework Core**
- **SQLite Database**
- **Swagger (API Testing Interface)**


## How to Run Locally
1. Clone this repository:
   git clone https://github.com/your-username/StudentApi.git
   cd StudentApi

Restore dependencies:

dotnet restore

Run the project:

dotnet run

Open your browser and visit:

http://localhost:5250/swagger

You’ll see all available endpoints for testing.

Endpoints
Method	Endpoint	Description
GET	/students	Get all students
GET	/students/{id}	Get a student by ID
POST	/students	Add a new student
PUT	/students/{id}	Update a student
DELETE	/students/{id}	Delete a student

Author

ADEBOYE EMMANUEL
Software Developer | Backend & Frontend
emmanuelniyi1997@gmail.com
🌐 [Your GitHub profile link here]