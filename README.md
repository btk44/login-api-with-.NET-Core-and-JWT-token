## About the project

This is just an example of using JWT token in .NET Core API. 

### Built with

* .Net Core
* JWT token
* MySQL database

## Short files description

* Code that performs all authorization actions is in Api/Auth
* The rest of Api endpoints should go to Api/OtherApiCode to keep Auth nicely separated
* There is also an ErrorHandlerMiddleware to catch errors and format them for response

## How to run:

1. Run Database creation.sql script to create example database LoginAppDb with test account (test/password)
2. Go to Api/appsettings.json and change database connection string to match your user and password
3. Run code in Visual Studio Code

## Make requests

Use postman or whatever you like to make requests below:

### Login
   Make POST:
   ```sh
   http://localhost:5000/auth/login
   ```
   with body:
   ```sh
   {
      "accountName": "test",
      "password": "password"
   }
   ```

### Refresh
   Make POST:
   ```sh
   http://localhost:5000/auth/refresh
   ```
   with body:
   ```sh
   {
      "accountName": "test",
      "refreshToken": "PASTE YOUR REFRESH TOKEN HERE (LOGIN RESPONSE)"
   }
   ```

### Private endpoint
   Make GET:
   ```sh
   http://localhost:5000/test/private
   ```
   Don't forget to add token to headers!