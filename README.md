
README.md

```markdown
# Educational Institute Management System

The **Educational Institute Management System** is a desktop-based application developed in C# with SQL Server as the database. The system is designed to help educational institutions manage students, teachers, sections, enrollment, payments, and grading. This project features role-based access, allowing students, teachers, and administrators to perform tasks based on their assigned roles.

## Features

### 1. Grading System
- Teachers can add grades for specific students and subjects.
- Students can view their grades by entering their Student ID.
- Grades are stored in the `Grades` table, which is linked to `StudentId` and `SubjectId`.

### 2. Section Enrollment with Seat Limitation
- Students can enroll in sections, and each section has a seat limit of 40.
- The system automatically checks available seats before allowing enrollment.
- Admins can view the number of students enrolled in each section and how many seats remain.

### 3. Payment History
- Students can view their payment history, including payment amount, status, and date.
- Admins can manage student payments and track which students have made payments.

### 4. Back Button Functionality
- Each form has a back button that allows users to navigate back to the previous page, improving user experience.

## Getting Started

### Prerequisites
To run this project, you will need:
- **Visual Studio**: Version 2019 or later with C# desktop development.
- **SQL Server**: Microsoft SQL Server 2016 or later (Express edition is fine).
- **SQL Server Management Studio (SSMS)**: For managing the database.

### Database Setup
1. Open **SQL Server Management Studio (SSMS)** and connect to your local server.
2. Create a new database named `edudb`.
3. Run the SQL scripts provided in the `db-scripts` folder to create the necessary tables:
    - `Grades.sql`: Creates the `Grades` table for storing grades.
    - `SectionEnrollment.sql`: Creates the `sectionab` and `entab` tables for section management.
    - `Payment.sql`: Creates the `Payment` table for tracking student payments.

### Tables Overview

- `studentab`: Stores basic student information.
- `sectionab`: Stores section details, including the number of available seats.
- `entab`: Stores student enrollment data.
- `Grades`: Stores grades for students by subject.
- `Payment`: Tracks payments made by students.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/educational-institute-management.git
   ```
2. Open the solution in **Visual Studio**.
3. Update the connection string in your C# code (typically found in `App.config` or within the `SqlConnection` objects) to match your SQL Server instance:
   ```csharp
   SqlConnection con = new SqlConnection(@"Data Source=YOUR-SERVER-NAME;Initial Catalog=edudb;Integrated Security=True;");
   ```
4. Build and run the project in **Visual Studio**.

## Usage

### Student Enrollment
1. Navigate to the **Enrollment Form**.
2. Enter the **Student ID** and select the desired **Section ID**.
3. Click **Enroll** to register the student in the selected section. The system will automatically check seat availability.

### Grading System
1. Teachers can use the **Grade Entry Form** to input grades for students.
2. Students can view their grades by entering their **Student ID** in the **View Results Form**.

### Payment Management
1. Admins can manage and track student payments using the **Admin Dashboard**.
2. Students can view their payment history on the **Payment History Form**.

### Section Management
- Admins can view how many students are enrolled in each section and how many seats remain.

## Technologies Used
- **C#**: For desktop application development.
- **SQL Server**: For data storage and management.
- **Windows Forms**: For user interface development.

## Contributing
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add some feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Open a pull request.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
For any inquiries, please contact:
- **Twaki Hasan** - mailto: twakihasan@gmail.com

---

**Note:** This project is meant to demonstrate various concepts related to educational institute management and can be extended for real-world use.
```



