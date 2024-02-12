# ContactList API

This project contains an API for managing a contact list. Below you will find a description of each class, methods, used libraries, and the compilation process of the application.

## Description of Each Class and Methods

### ContactController

The `ContactController` class is the API controller responsible for handling requests related to contacts. It includes methods for retrieving, adding, editing, and deleting contacts.

#### Methods:

- `GET /Contact/getContact` - Retrieves the list of all contacts.
- `POST /Contact/addNewContact` - Adds a new contact.
- `PUT /Contact/updateContact` - Edits an existing contact.
- `DELETE /Contact/DeleteContact/{id}` - Deletes a contact based on its identifier.
- `GET /Auth/login`

### ContactService

The `ContactService` class is a service for handling operations on contacts. It contains methods for communicating with the database or other data sources, such as external APIs.

#### Methods:

- `GetAllContact()` - Retrieves the list of all contacts.
- `FindContactById(int id)` - Retrieves a specific contact based on its identifier.
- `AddNewContact(Contact contact)` - Adds a new contact to the database.
- `UpdateContact(Contact contact)` - Updates an existing contact in the database.
- `DeleteContact(int id)` - Deletes a contact from the database based on its identifier.

### AuthenticationService

The `AuthenticationService` class is a service responsible for user authentication.

#### Methods:

- `LoginAsync(LoginDto loginDto)` - Validates the data entered by the user and returns a JWT token.

## Used Libraries

- **Entity Framework Core:** A library for handling databases in .NET Core applications.
- **ASP.NET Core Web API:** A framework for creating API interfaces in .NET Core applications.
- **Newtonsoft.Json:** A library for serializing and deserializing JSON data in .NET applications.

## Compilation Process of the Application

The application is compiled using tools provided by the .NET Core platform. It can be compiled using CLI commands available in the development environment. After compilation, the application can be run on a web server supported by the .NET Core platform.
