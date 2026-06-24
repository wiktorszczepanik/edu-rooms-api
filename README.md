# Classrooms & Reservations API

ASP.NET Core Web API for managing rooms and reservations in a training center. The application is built using controllers and focuses on REST API design, routing, model binding, validation, and correct HTTP status codes.

All data is stored in memory using static collections initialized at application startup. No database is used.

## API Structure

### Rooms

| Method | Endpoint                                            | Description                           |
| ------ | --------------------------------------------------- | ------------------------------------- |
| GET    | `/api/rooms`                                        | Returns all rooms                     |
| GET    | `/api/rooms/{id}`                                   | Returns a room by ID                  |
| GET    | `/api/rooms/building/{buildingCode}`                | Returns rooms for a specific building |
| GET    | `/api/rooms?minCapacity=&hasProjector=&activeOnly=` | Filters rooms using query parameters  |
| POST   | `/api/rooms`                                        | Creates a new room                    |
| PUT    | `/api/rooms/{id}`                                   | Updates an existing room              |
| DELETE | `/api/rooms/{id}`                                   | Deletes a room                        |

### Reservations

| Method | Endpoint                                  | Description                                 |
| ------ | ----------------------------------------- | ------------------------------------------- |
| GET    | `/api/reservations`                       | Returns all reservations                    |
| GET    | `/api/reservations/{id}`                  | Returns a reservation by ID                 |
| GET    | `/api/reservations?date=&status=&roomId=` | Filters reservations using query parameters |
| POST   | `/api/reservations`                       | Creates a new reservation                   |
| PUT    | `/api/reservations/{id}`                  | Updates an existing reservation             |
| DELETE | `/api/reservations/{id}`                  | Deletes a reservation                       |

## Validation & Rules

* Required fields must not be empty
* Numeric values must be valid (e.g. capacity > 0)
* Time ranges must be valid (end time must be after start time)
* Reservations cannot overlap for the same room
* Reservations cannot be created for non existent or inactive rooms

## HTTP Status Codes

* `200 OK` – successful read or update
* `201 Created` – resource created successfully
* `204 No Content` – successful deletion
* `400 Bad Request` – validation errors
* `404 Not Found` – resource not found
* `409 Conflict` – business rule violation (e.g. overlapping reservation)

## Running the Application

```bash id="k9p1xq"
dotnet restore
dotnet run
```
