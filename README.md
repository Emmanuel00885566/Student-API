# Student API (.NET 8 Minimal API)

This is a simple **Student Management API** built with **.NET 8 Minimal API** and **Entity Framework Core**.  
It allows you to **create**, **read**, **update**, and **delete (CRUD)** student records easily.

## Features
- Add a new student  
- Get all students  
- Get a single student by ID  
- Update student details  
- Delete a student  
- Uses SQLite for database storage  

## Tools & Technologies
- **.NET 8 SDK**
- **Entity Framework Core**
- **SQLite Database**

## How to Run Locally

1. Clone this repository:

```bash
git clone https://github.com/Emmanuel00885566/StudentApi.git
cd StudentApi
Restore dependencies:

dotnet restore
Run the project:

dotnet run
You’ll see all available endpoints for testing using Postman or any API tool.

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
GitHub
https://github.com/Emmanuel00885566