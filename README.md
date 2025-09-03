# Web API Project

Welcome to our Web API project built with .NET 8. This project adheres to REST architectural principles to ensure a scalable, maintainable, and efficient API.

## API Documentation
You can explore our API using the provided Swagger documentation.  
By default (development environment), it is available at:  
https://localhost:44398/Swagger/index.html  
> Note: In staging/production environments the Swagger URL may differ.

## Project Structure

Our project is organized into several layers to promote separation of concerns and maintainability. Here's a brief overview of each layer and the reasoning behind this structure:

- **DTO (Data Transfer Objects) Layer**: This layer contains records that represent the data structures used for communication between the client and the server. It ensures that only required data is exposed and transferred.
  - **Why use records in DTO?**: Using records in DTOs offers several advantages. Records provide a concise and immutable way to define data structures, reducing boilerplate code and preventing accidental modifications. They also support value equality, which is useful for comparing DTOs.
- **Service Layer**: Contains business logic and handles the core functionality of the application. It processes data received from the DTO layer and interacts with the Repository layer.
- **Repository Layer**: Responsible for data access and persistence. It communicates with the database and performs CRUD operations.
- **Controller Layer**: The entry point for API requests. It receives HTTP requests, invokes the appropriate service methods, and returns HTTP responses.
- **Entities Layer**: Contains the entity classes that represent the data model of the application. These classes are used by the Repository layer to interact with the database.
  - **Why use an Entities Layer?**: The Entities layer encapsulates the database schema and provides a clear separation between the data model and the business logic. This separation improves maintainability and allows for easier updates to the data model without affecting the business logic.

### Why These Layers?

- **Separation of Concerns**: Each layer has a distinct responsibility, making the codebase easier to manage, understand, and test.
- **Maintainability**: Changes in one layer (e.g., changing the database) do not directly affect other layers.
- **Scalability**: The layered architecture supports scalability by allowing independent scaling of each layer.

## AutoMapper for Layer Conversion

We use AutoMapper to handle the conversion between different layers. This ensures efficient and error-free mapping of data structures, reducing boilerplate code and potential bugs.

## Dependency Injection (DI)

Layers interact with each other through Dependency Injection (DI). This promotes loose coupling between components, making the system easier to test and maintain.

## Scalability with Async/Await

To enhance scalability, we use `async` and `await` for asynchronous programming. This allows our API to handle a larger number of concurrent requests efficiently.

## Database

We use SQL as our primary database with a Code First approach. If you need to create the database, use the following commands:


'''Add-migration MyShop_214859456
Update-database'''


In addition, we use **Redis as an in-memory Distributed Cache** to improve performance and scalability. Redis can be easily run via **Docker Compose** alongside the API.

## Configuration Files

Our project leverages configuration files to manage settings and environment-specific configurations.  
Configuration also includes **Docker Compose support**, allowing the API and Redis cache to run together seamlessly in containers.

## Error Handling

All errors are handled by a custom middleware. Errors are logged using a logger and sent via email.  
Authentication tokens are returned in **HttpOnly cookies** to protect against XSS attacks and prevent exposure of sensitive data.

## Request Logging

Every request to the system is logged for rating and analysis purposes. This helps in monitoring usage patterns and improving the system based on real-world data.  
Logs can be correlated with token-based access while ensuring that sensitive information is never exposed.

## Clean Code

We adhere to clean code principles, ensuring that our codebase is readable, maintainable, scalable, and designed with **security best practices** in mind.

---

## 🔐 Information Security

- **Token-based Access**: Access is restricted using tokens.
- **Optimized Tokens**: Tokens contain essential information to reduce unnecessary DB queries.
- **Secure Storage**: Tokens are securely stored and returned to the client inside `HttpOnly` cookies to prevent **XSS attacks**.
- **Password Security**: All passwords are stored **hashed + salted** to protect user credentials in case of a data breach.
- **CSP Headers**: Content Security Policy headers are enforced to mitigate XSS vulnerabilities.
- **Rate Limiting**: The API enforces request rate limiting/throttling to mitigate brute-force attempts and abusive traffic.
- **Performance + Caching**: We use **Distributed Cache with Redis (in-memory)**, which can be easily run via **Docker Compose** to ensure fast and scalable performance.
- **Docker Support**: The entire system can be run in a Docker container for easy deployment and scalability.
