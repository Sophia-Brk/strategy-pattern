# strategy-pattern
Strategy Pattern for Agentic AI/LLMs
# Agentics AI Strategy Pattern API

## Overview

This project Show the implementation of **Strategy Pattern** using.NET Core API to integrate multiple AI providers. The API allows switching between different AI services dynamically using dependency injection and delegates.

## Features

- Implements the **Strategy Pattern** for AI service selection.
- Provides a flexible and scalable architecture to add more AI providers easily.

## Tech Stack

- **ASP.NET 9 Core Web API**

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/Sophia-Brk/strategy-pattern.git
   cd strategy-pattern
   ```
2. Open the project in Visual Studio or VS Code.
3. Install dependencies (if required):
   ```sh
   dotnet restore
   ```
4. Run the project:
   ```sh
   dotnet run
   ```

## API Endpoints

### Generate AI Response

- **Endpoint:** `GET `/ai/ask?prompt=&agent
- **Request Example:**
  ```plaintext
  http://localhost:5217/ai/ask?prompt=hi%20ai&agent=Local
  ```
- **Response:** AI-generated response based on the selected provider.

## Configuration

- Replace `YOUR_OPENAI_API_KEY` in `OpenAIAIClient` with your OpenAI API key.
- Modify `AIClientContext` to add new AI providers dynamically.

## Contribution

Feel free to fork the repository, submit issues, or open pull requests to improve this project.

## License

This project is licensed under the MIT License.

