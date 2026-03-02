# GroceryList

A simple grocery list web application built as a learning project to explore **Server-Side Rendering (SSR)** with **Next.js** and **React**.

**Live demo:** https://grocerylist.danielmigchels.nl/

## About

This project was created purely to gain hands-on experience with SSR and Next.js in combination with React. It features a full-stack setup with a .NET API backend, a Next.js frontend, and a PostgreSQL database — all containerized and deployable via Docker Compose or Kubernetes (Helm).

## Getting Started

### Run with Docker Compose

```bash
docker compose up --build
```

The application will be available at:
- **Frontend:** http://localhost:3000
- **API:** http://localhost:8080
- **Swagger UI:** http://localhost:8080/swagger (development mode)

⚠️ Important: Ensure that the API base URL configured in the frontend matches http://localhost:8080. If this value is incorrect, the frontend will not be able to communicate with the backend.