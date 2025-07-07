# Send Email API

This project is an ASP.NET Core application that provides an API for sending emails. It utilizes SMTP for email delivery and includes Swagger for easy testing and documentation of the API endpoints.

## Project Structure

- **Controllers**
  - `EmailController.cs`: Handles HTTP requests related to sending emails.
  
- **Models**
  - `EmailRequest.cs`: Defines the structure of the email request.

- **Services**
  - `EmailService.cs`: Responsible for sending emails using SMTP.

- **Configuration**
  - `appsettings.json`: Contains configuration settings for the application, including SMTP server details and credentials.

- **Entry Point**
  - `Program.cs`: Sets up the web host, configures services, and enables Swagger for API documentation.

## Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd SendEmailApi
   ```

2. **Install Dependencies**
   Ensure you have the .NET SDK installed. Run the following command to restore the dependencies:
   ```bash
   dotnet restore
   ```

3. **Configure SMTP Settings**
   Update the `appsettings.json` file with your SMTP server details and credentials.

4. **Run the Application**
   Use the following command to run the application:
   ```bash
   dotnet run
   ```

5. **Access Swagger UI**
   Once the application is running, you can access the Swagger UI at:
   ```
   http://localhost:5000/swagger
   ```

## Usage

To send an email, make a POST request to the `/api/send` endpoint with a JSON body that matches the `EmailRequest` model. The required fields are `To`, `Subject`, and `Message`.

### Example Request

```json
{
  "to": "recipient@example.com",
  "subject": "Test Email",
  "message": "This is a test email.",
  "anonymous": true,
  "senderName": "Anonymous",
  "senderEmail": ""
}
```

## License

This project is licensed under the MIT License.