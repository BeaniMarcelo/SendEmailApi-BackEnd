# Send Email API

A UI interface built with Angular and Node.js that allows users to send emails without logging into any email provider.  
A practical solution for quick email sending needs.

---

## Features

- Send emails without logging in to any email provider
- Simple, fast, and anonymous option available
- Modern UI built with Angular and Node.js
- Backend API in ASP.NET Core


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

---

## Setup Instructions

1. **Clone the Repository**git clone <repository-url>
cd SendEmailApi
2. **Install Dependencies**
   Ensure you have the .NET SDK installed. Run the following command to restore the dependencies:dotnet restore
3. **Configure SMTP Settings**
   Update the `appsettings.json` file with your SMTP server details and credentials.

4. **Run the Application**
   Use the following command to run the application:dotnet run
5. **Access Swagger UI**
   Once the application is running, you can access the Swagger UI at:http://localhost:5000/swagger
---

## Usage

To send an email, make a POST request to the `/api/send` endpoint with a JSON body that matches the `EmailRequest` model. The required fields are `To`, `Subject`, and `Message`.

# Example Request
{
  "to": "recipient@example.com",
  "subject": "Test Email",
  "message": "This is a test email.",
  "anonymous": true,
  "senderName": "Anonymous",
  "senderEmail": ""
}
