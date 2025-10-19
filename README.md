# 🧮 Calculator API (.NET 8)

โปรเจกต์นี้เป็น **Simple Calculator API** ที่พัฒนาโดยใช้ **.NET 8 Minimal API**

## 🚀 Features

- รองรับการคำนวณพื้นฐาน: `+`, `-`, `*`, `/`
- รองรับวงเล็บ `( )`
- รองรับเลขทศนิยม (เช่น 3.5)
- ตรวจจับกรณีหารด้วยศูนย์ (`DivideByZeroException`)
- ตรวจจับสมการผิดรูป (`invalid syntax`)
- มี Swagger UI
- มี Unit Test

## 🧰 Tech Stack

| Component     | Description    |
| ------------- | -------------- |
| **Framework** | .NET 8 (C# 12) |
| **API Style** | Minimal API    |
| **Testing**   | NUnit 3        |
| **Docs**      | Swagger        |

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
dotnet run --project .\NgernTidLorTestProject\
```

เปิดใช้งาน Swagger UI

เปิดเบราว์เซอร์แล้วเข้า:
👉 http://localhost:5000
หรือ
👉 https://localhost:5001
