# MoviesAPI

MoviesAPI is a RESTful API built using .NET Core for managing movie-related data. It provides endpoints for performing CRUD operations on movies and genres. The project follows clean architecture principles and incorporates a service layer for handling business logic. Additionally, it uses Data Transfer Objects (DTOs) for efficient data flow and AutoMapper for object mapping.

## Features

- **CRUD Operations**: Manage Movies and Genres through RESTful endpoints.
- **DTOs**: Implements Data Transfer Objects to ensure optimized and secure data transmission.
- **AutoMapper**: Integrated for seamless mapping between entities and DTOs.
- **Service Layer**: Business logic is encapsulated in a service layer, promoting a clean separation of concerns.
- **RESTful API**: Adheres to RESTful principles with well-structured endpoints and clear request/response patterns.

## Technologies

- **.NET Core**: The core framework used to build the API.
- **AutoMapper**: For efficient mapping between objects (Entities <=> DTOs).
- **Entity Framework Core**: ORM for data access and database management.
- **Service Layer Pattern**: Ensures separation of concerns and keeps the codebase maintainable.
- **DTO Pattern**: Used for safer, more efficient data transfer.
