# Scope

	This is the Database Model for User:
		Id int NOT NULL (IDENTITY)
		Name VARCHAR(50) NOT NULL
		Age INT NOT NULL
		Address VARCHAR(50) NULL
	It's not necessary to persist the data into a real database. You can work using in-memory collections/arrays.
		1 - create an endpoint to CREATE a new user
		1.1 - validate the model for required fields and max length of strings
		2 - create an endpoint to UPDATE the user
		2.1 - validate the model for required fields and max length of strings
		3 - create an endpoint to GET the user by its ID
		4 - create an endpoint to LIST all users (no filters needed)

# Main Technology Stack

- NET Core 2.1
- Swagger for API Spec and Test
- IDE: Visual Studio .NET 2017

# How to Test

- Option 1:
	- Build and run the solution
	- Browse the Swagger URL https://localhost:44364/swagger to see the API spec and test.
- Option 2:
	- Check the live Swagger URL on Azure at https://dfoglobal.azurewebsites.net/swagger

# Important Notes

- The model validation is handled by the ApiControllerAttribute
- The exceptions are handled by a custom extension ConfigureExceptionHandler. We also log the exception message.
- To keep thing simple, I don't handle others: Globalization, Log to file systems, PATCH method...
