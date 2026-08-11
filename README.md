# Socitech

<img src="assets/logo.svg" alt="Socitech Logo" width="200" height="auto" />

> **The Digital Tech Community Platform for University Students**

---

> **📌 This repository is a public archive for portfolio and demonstration purposes only.**  
> Active development continues in a private repository with 250+ commits. You may view the code for reference here, but you are **not permitted** to copy, modify, distribute, or use it for any commercial purpose without explicit written permission.

---

## 🌐 Live Demo

The project is currently live at:  
🔗 **[socitech.vercel.app](https://socitech.vercel.app)**

**Hosting Environment:**

- **Frontend**: Hosted on **Vercel** for fast deployment and high performance.
- **Backend**: Hosted on **MonsterASP.NET** for a reliable .NET hosting environment.

---

## 📖 About the Platform

**Socitech** is a digital platform designed specifically for technology students in universities. It replaces the noise of fragmented social media groups with an organized environment that combines:

- **Professional Digital Identity**: Personal profiles showcasing skills, projects, and work experience.
- **Smart Partner System**: Post project requests and get matched with compatible students.
- **Meaningful Discussions**: A space for serious academic discussions, tech-focused posts, and productive comments away from chaos and noise.

---

## 🤔 The Problem It Solves

Every semester starts with the same familiar scenario at any Syrian university:

- A WhatsApp group for the course.
- Another version without the professor.
- Another version without the "serious" students.
- Another one "just for announcements."
- Another one for memes.
- A Telegram channel.
- A backup Telegram channel.
- A Facebook group.

All for **one** subject.

Thousands of messages. Arguments. Spam. Forwarded jokes. Important information gets buried under the noise. Serious students drown in the chaos. And when project time comes, the chaos multiplies exponentially.

---

## 💡 The Solution: Socitech

Socitech provides:

| **Feature**                | **Description**                                                                                                                                                                         |
| -------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Digital Identity**       | A professional profile reflecting your name, specialization, skills, interests, digital presence links, and portfolio.                                                                  |
| **Partner System**         | End the random search. Post a project request (required number, course, deadline), and the system suggests the most compatible students, notifying you as soon as the team is complete. |
| **Meaningful Interaction** | Organized academic discussions, categorized posts, productive comments within purely technical topics.                                                                                  |
| **Self-Development**       | Gain practical experience, build relationships with successful students, and participate in real projects.                                                                              |

---

## ✨ Key Features

- ✅ **Fully Responsive** – Seamlessly works on desktop, tablet, and mobile.
- ✅ **JWT Authentication** – Secure login and registration.
- ✅ **Team Formation System** – Browse, filter, and view team details.
- ✅ **Clean Architecture** – Domain, Application, Infrastructure, Presentation layers.
- ✅ **Profile Management** – Edit personal info, skills, and portfolio links.
- ✅ **Modern UI** – Clean, intuitive interface with a comfortable blue theme.
- ✅ **Real-time Notifications** – Via SignalR WebSocket.
- ✅ **Smart Caching** – Using Redis Cache and React Query Client-Side Caching.
- ✅ **Advanced Security** – Rate Limiting Policies to protect the API.

---

## 🛠️ Tech Stack

| **Layer**                   | **Technologies**                                            |
| --------------------------- | ----------------------------------------------------------- |
| **Backend**                 | ASP.NET Core 8.0.0 Web API, Clean Architecture              |
| **Server-Side Caching**     | Redis Cache                                                 |
| **Client-Side Caching**     | React Query                                                 |
| **Real-time Communication** | SignalR WebSocket                                           |
| **Database**                | SQL Server with Entity Framework Core & LINQ                |
| **File Storage**            | Cloud Storage (for image uploads)                           |
| **Authentication**          | JWT (JSON Web Token)                                        |
| **Security**                | Rate Limiting Policies                                      |
| **Frontend**                | React.js, JavaScript (ES6+), HTML5, CSS3, Responsive Design |
| **Design Principles**       | SOLID, OOD, OOP, Design Patterns                            |

---

## 🧱 Architecture

![Full Stack Application Struct](assets/architecture-struct.png)

![Context Diagram](assets/architecture-cd.png)

![System Design & Architecture Diagram](assets/architecture.png)

The project follows **Clean Architecture** with clear separation of concerns:

- **Domain**: Entities, enums, core business rules.
- **Application**: Use cases, DTOs, interfaces.
- **Infrastructure**: Data access (EF Core + SQL Server), external services (Redis, Cloud Storage, SignalR).
- **Presentation**: Web API controllers, React frontend.

### Principles & Standards Followed:

- ✅ **SOLID Principles**
- ✅ **Object-Oriented Design (OOD)**
- ✅ **Object-Oriented Programming (OOP)**
- ✅ **Design Patterns**
- ✅ **Clean Architecture**
- ✅ **Repository Pattern**
- ✅ **Dependency Injection**

This design ensures the system is **Scalable**, **Testable**, and **Maintainable**.

---

## 🏗️ Technical Architecture Details

### Backend (.NET Core 8 Web API)

| **Component**       | **Details**                                                            |
| ------------------- | ---------------------------------------------------------------------- |
| **ASP.NET Core**    | 8.0.0                                                                  |
| **ORM**             | Entity Framework Core (Code First) with LINQ                           |
| **Caching**         | Redis Cache (reduces database queries)                                 |
| **Real-time**       | SignalR WebSocket for instant communication                            |
| **Security**        | JWT Authentication + Rate Limiting Policies                            |
| **Image Storage**   | Cloud Storage                                                          |
| **Architecture**    | Clean Architecture (Domain, Application, Infrastructure, Presentation) |
| **Design Patterns** | Repository, Dependency Injection, Unit of Work                         |

### Frontend (React.js)

| **Component**         | **Details**                                       |
| --------------------- | ------------------------------------------------- |
| **Framework**         | React.js                                          |
| **State Management**  | React Context + React Query (Client-Side Caching) |
| **API Communication** | Axios                                             |
| **Styling**           | CSS3 with fully responsive design                 |
| **Performance**       | Lazy Loading, Code Splitting                      |

## 📸 Screenshots

### Landing Page

| Desktop                                        | Mobile                                       |
| ---------------------------------------------- | -------------------------------------------- |
| ![Landing Desktop](assets/landing-desktop.png) | ![Landing Mobile](assets/landing-mobile.png) |

### Community Dashboard

| Desktop                                            | Mobile                                           |
| -------------------------------------------------- | ------------------------------------------------ |
| ![Community Desktop](assets/community-desktop.png) | ![Community Mobile](assets/community-mobile.png) |

### Post Details

| Desktop                                                  | Mobile                                                 |
| -------------------------------------------------------- | ------------------------------------------------------ |
| ![Post Details Desktop](assets/post-details-desktop.png) | ![Post Details Mobile](assets/post-details-mobile.png) |

### Teams Formation

| Desktop                                    | Mobile                                   |
| ------------------------------------------ | ---------------------------------------- |
| ![Teams Desktop](assets/teams-desktop.png) | ![Teams Mobile](assets/teams-mobile.png) |

### Team Details

| Desktop                                                  | Mobile                                                 |
| -------------------------------------------------------- | ------------------------------------------------------ |
| ![Team Details Desktop](assets/team-details-desktop.png) | ![Team Details Mobile](assets/team-details-mobile.png) |

---

## 🔮 Roadmap

- [x] Team Formation system (backend)
- [x] React Landing Page
- [x] Login / Register pages
- [x] Teams listing & details
- [x] Fully responsive design
- [x] Redis Caching
- [x] Cloud Storage for images
- [x] SignalR WebSocket for notifications
- [x] Rate Limiting Policies
- [x] User Dashboard
- [x] Community system
- [x] Posts, Comments functionality

---

## 🤝 Contributing

This is a public archive for portfolio purposes only. The active development is ongoing in a private repository. Therefore, contributions are not accepted at this time.

However, if you have questions or feedback, feel free to reach out via the links below.

---

## 📄 License

© 2026 Mohammad Muaz Hbobati – All Rights Reserved.

This repository is a **public archive** for portfolio and demonstration purposes only. You may view the code for reference, but you are **not permitted** to copy, modify, distribute, or use it for any commercial purpose without explicit written permission.

---

## 👤 Founder and Developer

**Mohammad Muaz Hbobati**  
IT Engineering Student at Syrian Virtual University (SVU).  
Passionate about software architecture, clean code, and building solutions that solve real-world problems.

- **GitHub**: [github.com/MuaazHbobati](https://github.com/MuaazHbobati)
- **LinkedIn**: [linkedin.com/in/mohammed-mouaz-hbobati](https://www.linkedin.com/in/mohammed-mouaz-hbobati-54a2992a1)
- **Live Demo**: [socitech.vercel.app](https://socitech.vercel.app)

---

## ⭐ Show Your Support

If you find this project interesting or inspiring:

- ⭐ Star the repository on GitHub
- 🔗 Share it with your network
- 📧 Reach out for collaboration or feedback

---

## 📊 Repository Statistics

| **Metric**       | **Value**                     |
| ---------------- | ----------------------------- |
| **Commits**      | 50+ (archive) / 250+ (active) |
| **Languages**    | C#, JavaScript, CSS, HTML     |
| **Stars**        | ⭐ 2                          |
| **Forks**        | 0                             |
| **Contributors** | 1                             |

---

## 🏷️ Tags

`aspnetcore` `react` `clean-architecture` `solid-principles` `design-patterns` `signalr` `redis` `jwt` `entity-framework` `sql-server` `vercel` `monsteraspnet` `fullstack` `portfolio`

---

## 🔗 Quick Links

- [Live Demo](https://socitech.vercel.app)
- [GitHub Repository](https://github.com/MuaazHbobati/Socitech-Portfolio)
- [LinkedIn Profile](https://www.linkedin.com/in/mohammed-mouaz-hbobati-54a2992a1)

---

_Built with ❤️ by Mohammad Muaz Hbobati_
