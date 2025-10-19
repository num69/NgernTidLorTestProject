# 🧮 Calculator API (.NET 8)

โปรเจกต์นี้เป็น **Simple Calculator API** ที่พัฒนาโดยใช้ **.NET 8 Minimal API**

## 🚀 Features

- รองรับการคำนวณพื้นฐาน: `+`, `-`, `*`, `/`
- รองรับวงเล็บ `( )`
- รองรับเลขทศนิยม (เช่น `3.5` หรือ `3,5`)
- ตรวจจับกรณีหารด้วยศูนย์ (`DivideByZeroException`)
- ตรวจจับสมการผิดรูป (`FormatException`)
- มี Swagger UI ใช้งานง่าย
- มี Unit Test ด้วย NUnit

## 🧰 Tech Stack

| Component                | Description                              |
| ------------------------ | ---------------------------------------- |
| **Framework**            | .NET 8 (C# 12)                           |
| **API Style**            | Minimal API                              |
| **Testing**              | NUnit 3                                  |
| **Docs**                 | Swagger / OpenAPI                        |
| **Dependency Injection** | Microsoft.Extensions.DependencyInjection |

---

Restore Dependencies

```bash
dotnet restore
```

Build Project

```bash
dotnet build
```

Run Project

```bash
dotnet run
```

เปิดใช้งาน Swagger UI

เปิดเบราว์เซอร์แล้วเข้า:
👉 http://localhost:5000
หรือ
👉 https://localhost:5001
