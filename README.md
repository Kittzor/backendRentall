# BackendRentall - ASP.NET Core Web API

Detta är backend-API:t för Rentall-projektet. API:t tillhandahåller funktionalitet för att skapa, läsa, radera och boka produkter. Projektet är utvecklat i .NET 6/7 och använder en In-Memory-databas för lagring.

## 🛠 Funktioner

- 📦 Skapa produkter med bild
- 📋 Hämta alla produkter
- 🔍 Visa detaljer om en specifik produkt
- ❌ Radera produkt (endast skaparen)
- 📅 Boka produkt (kräver inloggning)

## 🧱 Teknologier

- ASP.NET Core Web API
- Entity Framework Core (InMemory-databas)
- CORS för React-integration
- Swagger för dokumentation
- DTOs för dataöverföring

Frontend hittar du på:
https://github.com/Kittzor/React

---

## 🚀 Kom igång

### 1. Klona projektet

```bash
git clone https://github.com/ditt-användarnamn/BackendRentall.git
cd BackendRentall
```

### 2. Kör projektet
```bash
dotnet run
```


API:t kommer köras på: https://localhost:5194

| Metod  | Endpoint           | Beskrivning                 |
| ------ | ------------------ | --------------------------- |
| GET    | /api/products      | Hämta alla produkter        |
| GET    | /api/products/{id} | Hämta specifik produkt      |
| POST   | /api/products      | Skapa ny produkt (med bild) |
| DELETE | /api/products/{id} | Radera produkt (om skapare) |


📦 Swagger
Du kan testa alla endpoints via Swagger:

👉 https://localhost:5194/swagger


🔐 Inloggning / Användarhantering
Just nu används localStorage i frontend för att simulera en användare. När en produkt skapas, sparas användarnamnet som createdBy.
