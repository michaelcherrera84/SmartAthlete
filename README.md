# SmartAthlete

**SmartAthlete** is a full-stack application designed to help coaches, trainers, and sports programs manage athletes, 
their injuries, and related performance data. The backend is built with .NET 10 Web API, using Entity Framework Core,
AutoMapper, and a clean service-layer architecture. The frontend is being implemented with PrimeReact to deliver a 
fast, modern, component-driven UI.

### Features
- Athlete management (CRUD)
- Injury tracking with composite-key join tables
- Coach, sport, and injury reference tables
- Clean, scalable domain → DTO mapping via AutoMapper
- Extensible service layer with support for specialized queries
- PrimeReact-based frontend for rich UI components and fast interactions
- SQLite database for local development

### Tech Stack
- Backend: .NET 10, ASP.NET Core Web API, EF Core, AutoMapper
- Frontend: React (TypeScript), PrimeReact, PrimeFlex CSS Framework, Tanstack Query, Axios
- Database: SQLite

*This project is not yet complete. The idea for this project comes curtesy of the [South Louisiana Community College 
Application Software Development Program.](https://www.solacc.edu/academics/programs-offered/application-software-development/index)*