# 🛒 QuickKart API

A modular, secure backend API for a **mini e-commerce platform** built with **ASP.NET Core Web API** and **MongoDB**, featuring **JWT authentication, role-based authorization**, and **Clean Architecture** using the **Repository-Service-Controller pattern**.

---

## 🚀 Features
- ✅ User Registration & Login with **hashed passwords**
- ✅ **JWT Authentication** with role-based access
- ✅ Roles: **Admin, Seller, Customer**
- ✅ **MongoDB Integration** for storing users, products, and orders
- ✅ **CRUD Operations** for Products & Orders
- ✅ Customer **Profile & Order History**
- ✅ **DTOs, Validation, and Defensive Coding**
- ✅ **Middleware** for JWT and Role checks
- ✅ **Swagger** for API documentation

---

## 🧱 MongoDB Collections
- **Users** → Stores user info, hashed password, role, address, phone  
- **Products** → Product details with seller reference  
- **Orders** → Customer orders with product references  
- **OrderHistory** → Completed orders for customers  

---

## 🗂️ Project Structure
QuickKart.API/
│
├── Controllers/
│   ├── AuthController.cs
│   ├── ProductsController.cs
│   ├── OrdersController.cs
│   └── CustomersController.cs
│
├── Services/
│   ├── IUserService.cs / UserService.cs
│   ├── IProductService.cs / ProductService.cs
│   └── IOrderService.cs / OrderService.cs
│
├── Repositories/
│   ├── IUserRepository.cs / UserRepository.cs
│   ├── IProductRepository.cs / ProductRepository.cs
│   └── IOrderRepository.cs / OrderRepository.cs
│
├── Models/
│   ├── User.cs
│   ├── Product.cs
│   ├── Order.cs
│   └── OrderHistory.cs
│
├── DTOs/
│   ├── RegisterDto.cs
│   ├── LoginDto.cs
│   ├── ProductDto.cs
│   ├── OrderDto.cs
│   └── CustomerProfileDto.cs
│
├── Middleware/
│   ├── JwtMiddleware.cs
│   └── RoleAuthorizationMiddleware.cs
│
├── Helpers/
│   ├── JwtHelper.cs
│   └── PasswordHasher.cs
│
├── appsettings.json
└── Program.cs


---

## 🔐 Roles & Access

| Endpoint                  | Role      | Access Type     |
|----------------------------|----------|----------------|
| `/api/auth/register`      | All      | Public          |
| `/api/auth/login`         | All      | Public          |
| `/api/products`           | Customer | Read            |
| `/api/products`           | Seller   | CRUD            |
| `/api/orders`             | Customer | Create / View   |
| `/api/orders`             | Admin    | View All        |
| `/api/customers/profile`  | Customer | View / Update   |
| `/api/orders/history`     | Customer | View            |

---

## 📚 Tech Stack
- **ASP.NET Core Web API**
- **MongoDB**
- **JWT Authentication**
- **Repository-Service Pattern**
- **DTOs & Validation**
- **Swagger (API Documentation)**




