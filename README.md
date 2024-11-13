# .Net Core + ReactJS + Docker

## Folder STRUCTURE

```
/dotnet-reactjs-docker-starter-pack
├── /Api
│   ├── /Controllers      # Contains API controllers (e.g., AuthController, UserController, CourseController)
│   ├── /Models           # Contains data models and entities (e.g., Student, Course, User)
│   ├── /Data             # Contains data context and database configuration (e.g., ApplicationDbContext)
│   ├── /Migrations       # Database migration files
│   ├── /Services         # Business logic services (e.g., UserService, CourseService)
│   ├── /Properties       # Assembly information and other properties
│   ├── Api.csproj        # Configuration settings
│   ├── Api.generated.sln # Configuration settings
│   ├── Api.http          # RESt Client file
│   ├── appsettingsDevelopment.json # Configuration settings for development environment 
│   ├── appsettings.json # Configuration settings
│   ├── Program.cs       # Entry point for the API application
│   └── Dockerfile       # Docker configuration for the API
│
├── /App
|   |
│   ├── nginx.conf       # Nginx production server configuration
│   └── Dockerfile       # Docker configuration for the frontend
│
├── /Database            # The directory where the Database production files will stored by docker
├── docker-compose.yml   # Docker Compose configuration file for the entire project
└── README.md            # Documentation for the project
```

## Tips to generate the Frontend Project

### ReactJS

npx create-react-app App

## Extra Documentation

#### [.NET Core](README_DotNet.md)
#### [Docker](README_Docker.md)
#### [ReactJS](README_ReactJS.md)
#### [Git](README_Git.md)
#### [GitHub](README_GitHub.md)
#### [VSCode](README_VSCode.md)