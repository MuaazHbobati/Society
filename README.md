# 🎓 Society

### _Building structure where there is none._

[![GitHub last commit](https://img.shields.io/github/last-commit/MuaazHbobati/Society)](https://github.com/MuaazHbobati/Society)
[![.NET 8](https://img.shields.io/badge/.NET%208-512BD4?logo=.net)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-61DAFB?logo=react)](https://reactjs.org/)

---

## 📖 The Problem

If you study at a Syrian university, you already know what the “digital student community” looks like.

It’s chaos.

Every semester starts the same:

- A WhatsApp group for the course
- Another version without the professor
- Another version without the “serious” students
- Another one “just for announcements”
- Another one for memes
- A Telegram channel
- A backup Telegram channel
- A Facebook group

All for **one** subject.

Thousands of messages.  
Arguments. Spam. Forwarded jokes.  
Important information gets buried under nonsense.  
Serious students drown in noise.

And when project time comes, the chaos **multiplies**.

---

## 💡 The Solution

**Society** is a digital academic community built specifically for IT engineering students at SVU.  
It replaces fragmented social media groups with:

- **Digital Identity** – professional profiles showcasing skills, portfolio, and academic background.
- **Smart Team Formation** – post project requests, get matched with compatible students.
- **Organized Discussions** – tech-focused, no noise, no spam.

---

## ✨ Key Features

- ✅ **Fully responsive** – works seamlessly on desktop, tablet, and mobile.
- ✅ **JWT Authentication** – secure login and registration.
- ✅ **Team Formation System** – browse, filter, and view team details.
- ✅ **Clean Architecture** – Domain, Application, Infrastructure, Presentation layers.
- ✅ **Profile Management** – edit personal info, skills, and portfolio links.
- ✅ **Modern UI** – clean, intuitive interface with a blue color theme.

---

## 🛠️ Tech Stack

| Layer        | Technologies                                                                        |
| ------------ | ----------------------------------------------------------------------------------- |
| **Backend**  | ASP.NET Core 8 Web API, Clean Architecture, Entity Framework Core (Code First), JWT |
| **Frontend** | React.js, JavaScript (ES6+), HTML5, CSS3, Responsive Design                         |
| **Database** | SQL Server                                                                          |

---

## 🧱 Architecture

Society follows **Clean Architecture** with clear separation of concerns:

- **Domain**: Entities, enums, business rules
- **Application**: Use cases, DTOs, interfaces
- **Infrastructure**: Data access (EF Core), external services
- **Presentation**: Web API controllers, React UI

This ensures the system is **scalable**, **testable**, and **maintainable**.

---

## 📸 Screenshots

### Landing Page

| Desktop                                                                                                                                  | Mobile                                                                                                                                  |
| ---------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/landing-desktop.png" height="400"/> | <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/landing-mobile.png" height="400"/> |

### Registration Page

| Desktop                                                                                                                                   | Mobile                                                                                                                                   |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/register-desktop.png" height="400"/> | <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/register-mobile.png" height="400"/> |

### Home Dashboard

| Desktop                                                                                                                               | Mobile                                                                                                                               |
| ------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/home-desktop.png" height="400"/> | <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/home-mobile.png" height="400"/> |

### Team Formation System

| Desktop                                                                                                                                | Desktop 2                                                                                                                               |
| -------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/teams-desktop.png" height="400"/> | <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/teams-desktop2.png" height="400"/> |

| Mobile                                                                                                                                | Menu Mobile                                                                                                                          |
| ------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/teams-mobile.png" height="400"/> | <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/menu-mobile.png" height="400"/> |

### Team Details

| Desktop                                                                                                                                       | Mobile                                                                                                                                       |
| --------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/team-details-desktop.png" height="400"/> | <img src="https://raw.githubusercontent.com/MuaazHbobati/Society/main/Society-SPA/public/screenshots/team-details-mobile.png" height="400"/> |

---

## 🚀 Getting Started (Run Locally)

### 1. Clone the repository

```bash
git clone https://github.com/MuaazHbobati/Society.git
cd Society
```

### 2. Backend (API)

- Open `Society.Api/appsettings.json` and update the connection string.
- Run migrations:

```bash
dotnet ef database update --project Society.Infrastructure --startup-project Society.Api
```

- Run the API:

```bash
dotnet run --project Society.Api
```

The API will be available at `https://localhost:5001`

### 3. Frontend (React)

```bash
cd Society-SPA
npm install
npm start
```

The app will open at `http://localhost:3000`

---

## 🔮 Roadmap

- [x] Clean Architecture setup
- [x] JWT Authentication
- [x] Team Formation system (backend)
- [x] React Landing Page
- [x] Login / Register pages
- [x] Teams listing & details
- [x] Fully responsive design
- [ ] Complete user dashboard
- [ ] Notifications system
- [ ] Deployment to Azure
- [ ] Student job & internship marketplace

---

## 📄 License

MIT © [Mohammad Muaz Hbobati](https://github.com/MuaazHbobati)

## 🔗 Links

- [GitHub Repository](https://github.com/MuaazHbobati/Society)
- [Live Demo (coming soon)](#)
- [My LinkedIn](https://linkedin.com/in/mohammed-mouaz-hbobati)
