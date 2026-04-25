# Inventory Management System

## 🚀 Overview

Inventory management system built with:

* ASP.NET Core Web API
* Blazor WebAssembly
* Entity Framework Core (SQLite)
* ASP.NET Core Identity + JWT Authentication
* Clean Architecture

The system allows managing products and tracking stock movements (inbound/outbound).

---

## 🧱 Architecture

The solution follows Clean Architecture:

* **Domain** → Entities and business rules
* **Application** → DTOs and interfaces
* **Infrastructure** → EF Core, database, services
* **API** → Controllers, authentication, endpoints
* **Client** → Blazor WebAssembly UI

---

## ⚙️ Prerequisites

* .NET 8 SDK
* Git

---

## ▶️ How to Run

### 1. Clone repository

```bash
git clone <REPO_URL>
cd InventorySystem
```

---

### 2. Restore packages

```bash
dotnet restore
```

---

### 3. Apply database migrations

```bash
dotnet ef database update --project InventorySystem.Infrastructure --startup-project InventorySystem.Api
```

---

### 4. Run API

```bash
dotnet run --project InventorySystem.Api
```

Swagger will be available at:

```
http://localhost:5282/swagger
```

---

### 5. Run Blazor Client

```bash
dotnet run --project InventorySystem.Client
```

---

## 🔐 Authentication

Use the following credentials:

```text
Email: admin@demo.com
Password: Admin123*
```

---

## 📦 API Endpoints

### Products

* GET `/api/products`
* GET `/api/products/{id}`
* POST `/api/products`
* PUT `/api/products/{id}`
* DELETE `/api/products/{id}`

### Stock Movements

* GET `/api/products/{id}/movements`
* POST `/api/products/{id}/movements`

---

## 🧠 Business Logic

* Prevents negative stock
* Tracks all stock movements
* Supports inbound and outbound operations
* Ensures SKU uniqueness

---

## 🔒 Security

* JWT-based authentication
* Protected endpoints using `[Authorize]`

---

## 🧪 Testing

```bash
dotnet test
```

---

## 📝 Notes

* Database is SQLite for simplicity
* Migrations are included
* Designed to run in under 10 minutes after cloning

---
