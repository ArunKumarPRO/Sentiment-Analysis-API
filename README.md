# Sentiment Analysis API

## Overview

This project provides a Sentiment Analysis API developed using ASP.NET Core (C#). The API analyzes textual data to determine the sentiment expressed, categorizing it as positive, negative, or neutral.

## Features

- **Sentiment Analysis**: Evaluates input text and returns the associated sentiment.
- **RESTful API**: Offers endpoints to integrate sentiment analysis into various applications.
- **Scalable Architecture**: Built with ASP.NET Core, ensuring high performance and scalability.
- **SQL Server Integration**: Uses SQL Server to store analyzed text and sentiment results for further analysis.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)
- [Gemini API Key](https://developers.gemini.com/) (replace the placeholder in the code with your actual API key)
- [SQL Server](https://www.microsoft.com/en-in/sql-server) (for database storage)

## Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/ArunKumarPRO/Sentiment-Analysis-API.git
   cd Sentiment-Analysis-API
   ```

2. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```

3. **Build the Solution**:
   ```bash
   dotnet build
   ```

4. **Update API Key**:
   - Open the project in your preferred IDE.
   - Locate the configuration file where the Gemini API key is set.
   - Replace the placeholder with your actual Gemini API key.
   - Update `appsettings.json` with your SQL Server connection string.

5. **Run the Application**:
   ```bash
   dotnet run
   ```

## Usage

Once the API is running, you can analyze sentiment by sending a POST request to the `/CreateSentiment` endpoint with the following JSON payload:

```json
{
  "text": "Your text here"
}
```

The API will respond with a JSON object indicating the sentiment of the provided text.

## Project Structure

- `solid.API/`: Contains the API controllers and configurations.
- `solid.Models/`: Defines the data models used in the application.
- `solid.Repositories/`: Implements data access logic from database.
- `solid.Services/`: Contains the business logic for sentiment analysis.
- `Solid.sln`: The solution file for the project.

## License

This project is licensed under the MIT License. See the [LICENSE.txt](LICENSE.txt) file for details.



