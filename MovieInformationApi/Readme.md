# Movie Information API

## Description
The Movie Information API is a .NET 6 application that provides information about movies. This API can be run in different environments, including Docker, Kestrel, and IIS Express.

## Requirements
- .NET 6 SDK
- Docker (optional)
- Visual Studio 2022 (or higher)

## Running the Application

### Docker
To run the application in Docker, follow the steps below:
1. Make sure Docker is installed and running.
2. In the root directory of the project, run the command:
3. After building the image, run the command:
4. The application will be available at `http://localhost:8080`.

### Kestrel
To run the application using the Kestrel server:
1. Open the project in Visual Studio.
2. Select the startup profile `MovieInformationApi`.
3. Press `F5` to start the application.
4. The application will be available at `http://localhost:5000`.

### IIS Express
To run the application using IIS Express:
1. Open the project in Visual Studio.
2. Select the startup profile `IIS Express`.
3. Press `F5` to start the application.
4. The application will be available at `http://localhost:5000`.

## Endpoints
The API provides the following endpoints:
- `GET /movies` - Returns a list of movies.
- `GET /movies/{id}` - Returns detailed information about a specific movie.
- `POST /movies` - Adds a new movie.
- `PUT /movies/{id}` - Updates an existing movie.
- `DELETE /movies/{id}` - Deletes a specific movie.
- `GET /actors` - Returns a list of actors.
- `GET /actors/{id}` - Returns detailed information about a specific actor.
- `POST /actors` - Adds a new actor.
- `PUT /actors/{id}` - Updates an existing actor.
- `DELETE /actors/{id}` - Deletes a specific actor.
- `GET /ratings` - Returns a list of ratings.
- `GET /ratings/{id}` - Returns detailed information about a specific rating.
- `POST /ratings` - Adds a new rating.
- `PUT /ratings/{id}` - Updates an existing rating.
- `DELETE /ratings/{id}` - Deletes a specific rating.

## Contribution
Contributions are welcome! Feel free to open issues and pull requests.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
