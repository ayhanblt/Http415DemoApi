
# HTTP 415 Demo API

This project demonstrates how to handle and fix the common HTTP 415 Unsupported Media Type error in .NET Core Web APIs.

## What is HTTP 415?

The HTTP 415 Unsupported Media Type error occurs when the API endpoint cannot process the content type of the request body. This commonly happens when:

1. The request doesn't include the `Content-Type: application/json` header
2. The `[FromBody]` attribute is missing on the parameter in the controller
3. The request body format doesn't match what the API expects

## How to Test

Use Swagger UI at `/swagger` or Postman with this sample request:

```http
POST http://your-repl-url/api/products
Content-Type: application/json

{
    "name": "Test Product",
    "price": 19.99
}
```

## Common Fixes

1. Always use `[FromBody]` attribute for POST/PUT requests
2. Set the correct Content-Type header
3. Ensure the request body matches the DTO structure
4. Configure JSON options in Program.cs if needed

## Project Structure

- `Controllers/`: API endpoints
- `Models/`: Domain models
- `DTOs/`: Data Transfer Objects
- `Program.cs`: Application configuration
