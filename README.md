# 🧾 Inventory System - .NET 8 + Blazor WebAssembly

Sistema de gestión de inventario desarrollado como prueba técnica, aplicando arquitectura en capas, autenticación JWT y frontend  con Blazor.


---


## 🚀 Tecnologías utilizadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* Blazor WebAssembly
* JWT Authentication
* Clean Architecture (Domain / Application / Infrastructure / API)

---

## 🔐 Funcionalidades principales

* ✔ Autenticación con JWT
* ✔ CRUD de productos
* ✔ Control de inventario (Entradas / Salidas)
* ✔ Validación de stock
* ✔ Historial de movimientos por producto
* ✔ Interfaz web con Blazor
* ✔ Manejo de errores

---

## 🏗️ Arquitectura

El proyecto está organizado siguiendo principios de Clean Architecture:

* **Domain** → Entidades del negocio
* **Application** → Interfaces, DTOs y lógica de negocio
* **Infrastructure** → Acceso a datos (EF Core)
* **API** → Endpoints REST
* **Client (Blazor)** → Interfaz de usuario

---

## ▶️ Ejecución del proyecto

### 1. Clonar repositorio

git clone https://github.com/edison-riera-dev/inventory-system.git

### 2. Ejecutar Backend

cd InventorySystem.Api
dotnet run

Swagger:
http://localhost:5282/swagger

### 3. Ejecutar Frontend

cd InventorySystem.Client
dotnet run

Aplicación:
http://localhost:5228

---

## 🔑 Credenciales de prueba

Email: admin@demo.com
Password: Admin123*

---

---

## ⚠️ Consideraciones técnicas

* Uso de JWT para autenticación segura
* Validación de stock en movimientos tipo OUT
* Separación de responsabilidades por capas
* Uso de DTOs para desacoplar entidades
* Base de datos SQLite para facilidad de ejecución

---

## 👨‍💻 Autor

**Edison Riera**

---
