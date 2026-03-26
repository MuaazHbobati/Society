# Society

> **© 2026 Mohammad Muaz Hbobati – All Rights Reserved**
>
> This repository is a **public archive** for portfolio and demonstration purposes only.
> You may view the code for reference, but you are **not permitted** to copy, modify, distribute, or use it for any commercial purpose without explicit written permission.
> The active development of this project continues in a **private repository**.

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

| Desktop                                                                | Mobile                                                               |
| ---------------------------------------------------------------------- | -------------------------------------------------------------------- |
| ![Landing Desktop](Society-SPA/public/screenshots/landing-desktop.png) | ![Landing Mobile](Society-SPA/public/screenshots/landing-mobile.png) |

### Registration Page

| Desktop                                                                  | Mobile                                                                 |
| ------------------------------------------------------------------------ | ---------------------------------------------------------------------- |
| ![Register Desktop](Society-SPA/public/screenshots/register-desktop.png) | ![Register Mobile](Society-SPA/public/screenshots/register-mobile.png) |

### Home Dashboard

| Desktop                                                          | Mobile                                                         |
| ---------------------------------------------------------------- | -------------------------------------------------------------- |
| ![Home Desktop](Society-SPA/public/screenshots/home-desktop.png) | ![Home Mobile](Society-SPA/public/screenshots/home-mobile.png) |

### Team Formation System

| Desktop                                                               | Mobile                                                           |
| --------------------------------------------------------------------- | ---------------------------------------------------------------- |
| ![Teams Desktop](Society-SPA/public/screenshots/teams-desktop.png)    | ![Teams Mobile](Society-SPA/public/screenshots/teams-mobile.png) |
| ![Teams Desktop 2](Society-SPA/public/screenshots/teams-desktop2.png) | ![Menu Mobile](Society-SPA/public/screenshots/menu-mobile.png)   |

### Team Details

| Desktop                                                                          | Mobile                                                                         |
| -------------------------------------------------------------------------------- | ------------------------------------------------------------------------------ |
| ![Team Details Desktop](Society-SPA/public/screenshots/team-details-desktop.png) | ![Team Details Mobile](Society-SPA/public/screenshots/team-details-mobile.png) |

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

## 🔗 Links

- [GitHub Repository](https://github.com/MuaazHbobati/Society)
- [Live Demo (coming soon)](#)
- [My LinkedIn](https://linkedin.com/in/mohammed-mouaz-hbobati)
