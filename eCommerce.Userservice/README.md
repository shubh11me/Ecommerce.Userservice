# Ecommerce.Userservice

Lightweight ASP.NET Core Web API that provides user authentication and account management for the eCommerce platform. This solution contains three projects:

- `Ecommerce.Userservice` - the Web API project (entry point)
- `eCommerce.Core` - domain models, DTOs, validators, and service/repository contracts
- `eCommerce.Infrastructure` - repository implementations, data access, and DI setup

## Prerequisites

- .NET 8 SDK
- Docker (optional, for containerized runs)
- Git (to clone the repository)

## Clone

```bash
git clone https://github.com/shubh11me/Ecommerce.Userservice.git
cd Ecommerce.Userservice/eCommerce.Userservice
```

## Build and run locally

From the repository root you can build and run the API using the .NET CLI:

```bash
# build the whole solution
dotnet build

# run the API project
dotnet run --project Ecommerce.Userservice
```

The application reads configuration from the `appsettings.Development.json` file while running in development. Check that file to configure database connection strings, JWT settings, and other options.

## Docker

Build the Docker image and run a container (example maps host port 5000 to container port 80):

```bash
# build image
docker build -t ecommerce-userservice .

# run container
docker run -p 5000:80 ecommerce-userservice
```

## API Endpoints

This service exposes endpoints for user registration and authentication. The main controller is `Controllers/AuthController.cs`.

Typical endpoints (adjust base path if configured):

- `POST /api/auth/register` — register a new user (accepts registration DTO)
- `POST /api/auth/login` — authenticate a user and receive a JWT (accepts login DTO)

Use JSON bodies matching the DTOs in `eCommerce.Core/DTO` (`RegisterRequest`, `LoginRequest`). Responses include `AuthenticationResponse` on success.

Example using `curl`:

```bash
# register
curl -X POST http://localhost:5000/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"email":"user@example.com","password":"P@ssw0rd","firstName":"John","lastName":"Doe"}'

# login
curl -X POST http://localhost:5000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"user@example.com","password":"P@ssw0rd"}'
```

## Project structure

- `Controllers/` - API controllers
- `Middlewares/` - custom middleware (e.g. exception handling)
- `eCommerce.Core/` - domain, DTOs, validators, mapping profiles and contracts
- `eCommerce.Infrastructure/` - database contexts, repositories, services, and DI registration

## Configuration

See `appsettings.Development.json` for sample configuration values (JWT, connection strings, logging). Make sure to provide required secrets in development or production environments.

## Contributing

Contributions are welcome. Open issues or pull requests against the `master` branch.

## License

This repository does not include an explicit license. Add a `LICENSE` file if you want to make the project open source.

---

If you need a more detailed README (examples for JWT configuration, database setup, or API swagger usage), tell me which sections to expand.