# 📰 Blog System with Role-Based Authentication

## 📋 Overview
The **Blog System** is a full-featured web application built using **ASP.NET Core MVC**, **ASP.NET Core Web API**, and **Entity Framework Core**.  
It allows users to **create, manage, and comment** on blog posts with **role-based access control**.  
The system implements **ASP.NET Core Identity** for user registration, authentication, and authorization.

This project demonstrates a clean architectural design using both **MVC** and **Web API** layers, with a focus on **security**, **maintainability**, and **scalability**.

---

## 🚀 Key Features

### 🔐 User Authentication & Role Management
- Secure registration and login using **ASP.NET Core Identity**.
- Supports three roles:
  - **Admin**: Full control (manage users, posts, and comments).
  - **Editor**: Can create and edit posts (but not delete).
  - **Reader**: Can view and comment on posts.
- Role-based authorization via `[Authorize(Roles = "...")]`.

### 📝 Blog Post Management
- Admins and editors can create, edit, and (for admins) delete posts.
- Each post includes:
  - Title  
  - Content  
  - Category  
  - Tags  
  - Created/Updated timestamps  
  - Status: `Published`, `Draft`, or `Archived`
- Readers can view published posts only.

### 💬 Commenting System
- Readers, editors, and admins can leave comments.
- Admins can **moderate** (delete inappropriate comments).
- Comments are linked to specific blog posts.

### 🔎 Search & Filtering
- Search posts by **title**, **tags**, or **categories**.
- Admins and editors can filter posts by **status** (draft, published, archived).

### ⚙️ RESTful API Endpoints
- Full CRUD API for managing posts and comments.
- Authentication endpoints for registration and login.
- Role-secured routes for admin/editor actions.

---

## 🧰 Technologies Used

| Layer | Technology |
|-------|-------------|
| **Frontend** | ASP.NET Core MVC |
| **Backend API** | ASP.NET Core Web API |
| **ORM** | Entity Framework Core |
| **Authentication** | ASP.NET Core Identity |
| **Authorization** | Role-based Authorization |
| **Database** | SQL Server (or any EF Core-supported provider) |

---

## 🏗️ System Architecture

### 1️⃣ Frontend (MVC)
- Handles user interaction and presentation.
- Contains role-specific pages:
  - Admin Dashboard
  - Editor Panel
  - Reader View
- Integrates with backend APIs for data management.

### 2️⃣ Backend (Web API)
- Provides REST endpoints for blog and comment management.
- Handles authentication and authorization.
- Decoupled from the front-end (can serve external clients too).

### 3️⃣ Database (EF Core)
- Manages all entities and relationships.
- Uses **Code-First Migrations** to build the database.

---

## 🗄️ Database Design

### 🧩 Entities

#### **User**
| Column | Type | Description |
|--------|------|-------------|
| Id | Primary Key | Unique user ID |
| Username | String | Display name |
| Email | String | Login email |
| PasswordHash | String | Encrypted password |
| Role | Enum/String | Admin / Editor / Reader |

#### **BlogPost**
| Column | Type | Description |
|--------|------|-------------|
| Id | Primary Key | Unique post ID |
| Title | String | Post title |
| Content | String | Main content |
| AuthorId | FK → User | Post author |
| CreatedAt | DateTime | Creation time |
| UpdatedAt | DateTime | Last update |
| Status | Enum | Published / Draft / Archived |
| CategoryId | FK → Category | Post category |
| Tags | Many-to-Many | Related tags |

#### **Category**
| Column | Type |
|--------|------|
| Id | Primary Key |
| Name | String |

#### **Tag**
| Column | Type |
|--------|------|
| Id | Primary Key |
| Name | String |

#### **Comment**
| Column | Type |
|--------|------|
| Id | Primary Key |
| Content | String |
| CreatedAt | DateTime |
| PostId | FK → BlogPost |
| AuthorId | FK → User |

---

## 🧭 API Endpoints

### 🔑 Authentication
| Method | Endpoint | Description |
|--------|-----------|-------------|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Log in and receive a JWT token |

### 📰 Blog Posts
| Method | Endpoint | Access | Description |
|--------|-----------|---------|-------------|
| GET | `/api/posts` | All users | Retrieve all blog posts |
| GET | `/api/posts/{id}` | All users | Get post by ID |
| POST | `/api/posts` | Admin, Editor | Create a new post |
| PUT | `/api/posts/{id}` | Admin, Editor | Update a post |
| DELETE | `/api/posts/{id}` | Admin | Delete a post |

### 💬 Comments
| Method | Endpoint | Access | Description |
|--------|-----------|---------|-------------|
| POST | `/api/comments` | All logged-in users | Add comment |
| GET | `/api/comments/{postId}` | All users | Get comments for a post |
| DELETE | `/api/comments/{id}` | Admin | Delete inappropriate comment |

---

## 🧑‍💻 Role-Based Authorization Example

```csharp
// Admin only
[Authorize(Roles = "Admin")]
public IActionResult ManageUsers() { ... }

// Admin and Editor
[Authorize(Roles = "Admin, Editor")]
public IActionResult CreateOrEditPost() { ... }

// Reader only
[Authorize(Roles = "Reader")]
public IActionResult ViewPosts() { ... }
