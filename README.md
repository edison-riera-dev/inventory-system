# 🚀 Inventory System

Sistema de gestión de inventario desarrollado con .NET 8, Blazor WebAssembly y SQL Server, aplicando principios de Clean Architecture, autenticación JWT y contenedores Docker.

---

# 📌 Características principales

* ✅ Autenticación JWT
* ✅ ASP.NET Core Web API
* ✅ Frontend con Blazor WebAssembly
* ✅ CRUD completo de productos
* ✅ Control de stock (Entradas / Salidas)
* ✅ Historial de movimientos
* ✅ Validación de stock disponible
* ✅ Entity Framework Core
* ✅ Identity + Roles
* ✅ Arquitectura en capas
* ✅ Docker + Docker Compose
* ✅ SQL Server en contenedor
* ✅ Migraciones automáticas
* ✅ Swagger/OpenAPI

---

# 🏗️ Arquitectura

El proyecto está organizado utilizando principios de Clean Architecture:

```text
InventorySystem
│
├── InventorySystem.Domain
├── InventorySystem.Application
├── InventorySystem.Infrastructure
├── InventorySystem.Api
├── InventorySystem.Client
└── InventorySystem.Tests
```

## Capas

### 🔹 Domain

Contiene entidades y reglas del dominio.

### 🔹 Application

Contiene interfaces, DTOs y lógica de negocio.

### 🔹 Infrastructure

Implementación de acceso a datos con Entity Framework Core.

### 🔹 API

ASP.NET Core Web API con autenticación JWT y Swagger.

### 🔹 Client

Frontend desarrollado con Blazor WebAssembly.

### 🔹 Tests

Proyecto de pruebas unitarias.

---

# 🛠️ Tecnologías utilizadas

| Tecnología            | Uso                 |
| --------------------- | ------------------- |
| .NET 8                | Backend             |
| ASP.NET Core Web API  | API REST            |
| Blazor WebAssembly    | Frontend            |
| Entity Framework Core | ORM                 |
| SQL Server            | Base de datos       |
| JWT                   | Autenticación       |
| Docker                | Contenedores        |
| Docker Compose        | Orquestación        |
| Swagger               | Documentación API   |
| Identity              | Gestión de usuarios |

---

# 🐳 Ejecución con Docker (Recomendado)

## Requisitos

* Docker Desktop
* Git

---

## 1. Clonar repositorio

```bash
git clone https://github.com/edison-riera-dev/inventory-system.git
```

---

## 2. Entrar al proyecto

```bash
cd inventory-system
```

---

## 3. Levantar el sistema completo

```bash
docker compose up --build
```

---

# 🌐 URLs del sistema

## Frontend Blazor

```text
http://localhost:8081
```

## Swagger API

```text
http://localhost:8080/swagger
```

---

# 🔑 Credenciales demo

```text
Email: admin@demo.com
Password: Admin123*
```

---

# 🐳 Contenedores Docker

El proyecto levanta automáticamente:

| Contenedor          | Descripción     |
| ------------------- | --------------- |
| inventory-api       | API .NET 8      |
| inventory-client    | Frontend Blazor |
| inventory-sqlserver | SQL Server 2022 |

---

# 🗄️ Base de Datos

La base de datos se ejecuta dentro de un contenedor SQL Server.

Las migraciones se aplican automáticamente al iniciar la API.

---

# 🔐 Seguridad

* JWT Authentication
* ASP.NET Core Identity
* Validación de acceso a endpoints
* Swagger protegido con Bearer Token

---

# 📦 Funcionalidades implementadas

## Productos

* Crear productos
* Editar productos
* Eliminar productos
* Consultar productos
* Filtrado por categoría
* Indicador de stock bajo

## Inventario

* Entradas de inventario
* Salidas de inventario
* Validación de stock
* Historial de movimientos

## Seguridad

* Login JWT
* Identity
* Roles

---

# 🧪 Testing

Proyecto preparado para pruebas unitarias:

```text
InventorySystem.Tests
```

---

# 📘 Conceptos aplicados

* Clean Architecture
* Dependency Injection
* Repository Pattern
* DTO Pattern
* JWT Authentication
* RESTful API
* Docker Multi-Stage Builds
* Docker Compose
* Entity Framework Migrations
* SQL Server Containers

---

# 👨‍💻 Autor

## Edison Riera

Ingeniero en Sistemas 
Backend Developer | .NET | Infraestructura | Docker

GitHub:

[https://github.com/edison-riera-dev](https://github.com/edison-riera-dev)

---
