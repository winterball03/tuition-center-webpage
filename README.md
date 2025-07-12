# 🌻 Sunflower Tuition Center Web Application

Sunflower Tuition Center is a role-based web application designed to streamline operations for tuition services. Users can view course details, register for classes, make payments, and explore teacher and center achievements. The platform includes secure login, role-based access, chatbot support, and admin analytics integration with Power BI.

---

## ✨ Key Features

- 🔐 Secure Login & Registration (Student/Parent)
- 📚 Course Registration & Descriptions
- 💳 Tuition Fee Payment Overview
- 📢 Announcements Board (Role-based access)
- 🧑‍🏫 Lecturer & Center Profile Viewing
- 🤖 Live Chatbot Support for Users
- 📊 Admin Dashboard with Power BI Insights
- 🧩 Full CRUD operations for Admin and Teacher panels

---

## 👥 User Roles & Permissions

| Role     | Key Permissions |
|----------|------------------|
| **Admin** | Full access to manage announcements, classes, teachers, parents. Cannot register students or link parents/children. |
| **Teacher** | Manage their own classes, view announcements, access their own students' and parents’ info. |
| **Parent** | Register their children for courses, link to student account, view announcements and payments. |
| **Student** | Update personal info, view assigned classes, courses, announcements, and parent information. |

---

## 🔑 Pages & Screenshots

### 🔐 Login Page  
All users must log in to access the system. New users (students/parents) can register via the “Register” button.  
![Login Page](https://github.com/user-attachments/assets/af491829-4800-4e4a-963d-fde8030dc97b)

### 📝 Registration Page  
Students and parents can register by filling in all fields correctly and selecting the appropriate role.  
![Register Page](https://github.com/user-attachments/assets/c3b40ff5-8918-47ea-ade7-f5ddf1a79dd1)

---

### 🏠 Home Page  
After login, users are routed to the homepage with course info and services.  
![Home Top](https://github.com/user-attachments/assets/9a4e4f0a-d35f-4c0c-b5e9-32fda7e60c45)  
![Courses](https://github.com/user-attachments/assets/f47120b1-a8da-4418-87e2-0cf3595e69e7)  
![Facilities](https://github.com/user-attachments/assets/efdd4e7e-768e-4be6-90bc-34f67fa9cdb0)

### 🤖 Chatbot  
Live chatbot available at the bottom left for quick assistance.  
![Chatbot](https://github.com/user-attachments/assets/7f288e14-16ba-4344-b008-a85410cad11c)

---

## 📢 Announcements

### Admin View  
Admins can create, edit, and delete announcements.  
![Admin Announcement](https://github.com/user-attachments/assets/fdb45b2f-6f31-40a3-acf0-35848880640f)

### Other User Views  
Students, parents, and teachers can view but not modify announcements.  
![User Announcement](https://github.com/user-attachments/assets/b1031ce7-8c3c-4aec-a37c-dd502ef2e4a2)

---

## 🧮 Admin Dashboard

### Power BI Integration  
Visual insights into login activity and usage.  
![Dashboard](https://github.com/user-attachments/assets/7fab1013-a53e-4916-a2a2-1ba5b9af3156)

### Management Sections  
Admins can manage courses, teachers, students, parents, and classes.  
![Management 1](https://github.com/user-attachments/assets/df333d45-6ac4-4405-95c8-15c9449f6bec)  
![Management 2](https://github.com/user-attachments/assets/d5df1336-89be-47ee-9475-241c79b13da1)

---

## 🎓 Course Management (Admin)

- **Add Course**  
![Add Course](https://github.com/user-attachments/assets/2bf8d1dd-b646-4cf5-98cd-3bedd9edd168)

- **Edit Course**  
![Edit Course](https://github.com/user-attachments/assets/de67c6fb-36b3-447e-858c-185f2e7b77c8)

- **Delete Course**  
![Delete Course](https://github.com/user-attachments/assets/fcc57180-da97-424d-8747-acf7f52c132e)

---

## 👩‍🏫 Teacher Management (Admin)
Admins can create, edit, and delete teacher profiles.

- **Teacher List**  
![Teacher List](https://github.com/user-attachments/assets/a2eca284-a4e5-4a46-9c60-cc50c9f04688)

- **Add Teacher**  
![Add Teacher](https://github.com/user-attachments/assets/a558449b-5f3b-47bf-84cb-3a11157aa7ce)

- **Edit Teacher**  
![Edit Teacher](https://github.com/user-attachments/assets/4b94adec-ab09-41b2-872e-5f338445711c)

- **Delete Teacher**  
![Delete Teacher](https://github.com/user-attachments/assets/63b56d02-918f-4250-8e39-8de5be7ffa81)

---

## 🧑‍🎓 Student Management (Admin)
Admins cannot create new students, but can edit or delete existing student accounts.

- **Student List**  
![Student List](https://github.com/user-attachments/assets/67ab6bc1-8ad9-4932-8c48-0eb914202e57)

- **Edit Student**  
![Edit Student](https://github.com/user-attachments/assets/ee279e48-ac82-4175-93d4-cca204b966ee)

- **Delete Student**  
![Delete Student](https://github.com/user-attachments/assets/c268b6a5-84d4-4b85-bd0c-a24d7d8dd7f6)

---

## 👪 Parent Management (Admin)
Admins can create, edit, and delete parent user accounts.

- **Parent List**  
![Parent List](https://github.com/user-attachments/assets/08f9ffee-6a77-4f3c-a67d-aab75b69a66f)

- **Add Parent**  
![Add Parent](https://github.com/user-attachments/assets/ce179ee3-ea87-4a4a-9d76-27698073fad2)

- **Edit Parent**  
![Edit Parent](https://github.com/user-attachments/assets/015fabf5-eafc-4db1-a937-570d017fa631)

- **Delete Parent**  
![Delete Parent](https://github.com/user-attachments/assets/4ceb8454-ac36-4f6b-8937-9590a1cd2742)

---

## 🏫 Class Details Page
Admins and users can view class information. Admins access it from the dashboard, users from the homepage.

- **Class Details View**  
![Class View](https://github.com/user-attachments/assets/6807f4eb-6e0f-4a3c-885d-af78558661f2)

---

## 👶 Child Management (Parents)
Parents can link student accounts as their child.

- **My Child Page**  
![My Child](https://github.com/user-attachments/assets/c4ae64d8-c1e3-4ded-aae1-d5945207a5a3)

- **Link a Child**  
![Link Child](https://github.com/user-attachments/assets/131ee817-06ba-4a25-9e00-d6c6790cc47f)

---

## 📝 Register Course (Parents)
Parents can register their child to courses and make payments.

- **Course List for Parents**  
![Parent Courses](https://github.com/user-attachments/assets/0d43bd30-c52e-4e55-b6ee-c605dc983c41)

- **Proceed to Register & Pay**  
![Register Course](https://github.com/user-attachments/assets/9bf9ef91-568b-4691-8430-3222fb968b75)

- **Payment Confirmation**  
![Payment Confirm](https://github.com/user-attachments/assets/f015099f-5616-4f40-86ee-dbab62a5a42c)

---

## 📚 Course Page (Teacher)
Teachers can select courses they wish to teach.

- **Available Courses to Select**  
![Select Course](https://github.com/user-attachments/assets/44aca007-4154-4e10-9932-49bc039fb987)

- **Course Selection Confirmation**  
![Success Message](https://github.com/user-attachments/assets/d4ec3626-8474-42b8-a373-b551d9024736)

- **My Teaching Courses View**  
![Teacher View](https://github.com/user-attachments/assets/c153b099-86bd-41bf-b2b4-21b206185da2)

---

## 🏷️ Total Class View (Teacher)
Teachers can view a list of all available classes and see their statuses.

- **All Classes View**  
![All Class List](https://github.com/user-attachments/assets/b8c123c1-fa47-4ff0-af45-0c9bd5079dfe)

---

## 💬 Classroom Forum (Teacher & Students)
Teachers and students can post comments in their class forums.

- **Forum Page**  
![Forum](https://github.com/user-attachments/assets/1ca30d68-86f6-460a-b284-676577ae201e)

---

## 🛠️ Tech Stack

- ASP.NET MVC (.NET Framework)
- Entity Framework
- SQL Server (.mdf)
- HTML, CSS, JavaScript
- Power BI (Dashboard integration)
- Azure / Localhost deployment

---

## 📂 How to Run

1. Clone the repo.
2. Open the `.sln` file in Visual Studio.
3. Restore NuGet packages.
4. Update the database connection string in `appsettings.json` if needed.
5. Run the project with IIS Express.

---

## 📬 Contact

For questions or feedback, feel free to reach out via GitHub Issues.

---
