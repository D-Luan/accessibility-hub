# Accessibility Hub

![license](https://img.shields.io/badge/license-MIT-green)
![C#](https://img.shields.io/badge/language-C%23-purple)
![ASP.NET Core](https://img.shields.io/badge/framework-ASP.NET%20Core-blue)
![Status](https://img.shields.io/badge/status-in%20progress-yellow)

## About
An accessibility portal designed to connect people with disabilities with essential technologies, services, and communities. The platform aims to facilitate navigation and access to information, aggregating technologies, services, articles, and communities dedicated to accessibility in one single place.

## Topics

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Stack](#stack)
- [License](#license)

## Features

The current version (Backend) of the Accessibility Hub provides the core functionality for browsing and managing accessibility providers.

- **Category Management (Disabilities):**

    - **Browse Categories:** Users can view a list of all pre-defined disability categories available on the platform.
    - **Dedicated Category Pages:** Each category has a dedicated details page that serves as a hub for its specific resources.

- **Provider Management (Complete CRUD):**
    - **List Providers by Category:** View a list of all relevant providers (companies, tools, communities) associated with a specific disability.
    - **View Provider Details:** Access a dedicated page with detailed information for each provider.
    - **Add New Providers:** Ability to add new providers to a disability category through a creation form.
    - **Edit Existing Providers:** Full capability to edit the information of an existing provider.
    - **Delete Providers:** Ability to remove providers from the system.

## Prerequisites

You will need the following tools installed on your machine:
* [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
* [PostgreSQL](https://www.postgresql.org/download/)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

## Installation

1. **Clone the repository:** `https://github.com/D-Luan/accessibility-hub.git`

2. **Navigate to the WebAPP project folder:** `cd src/AccessibilityHub.WebApp`

3. **Initialize User Secrets:** `dotnet user-secrets init`

4. **Set your connection string:** `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=YourDbName;Username=YourUser;Password=YourPassword;"`

5. **Apply the Database Migrations:** `dotnet ef database update`

6. **Run the Application:** `dotnet run`

## Stack

- **Backend:** C#, .NET 9, ASP.NET Core MVC, Entity Framework Core
- **Frontend:** HTML, Razor Views
- **Database:** PostgreSQL
- **Tools:** Git, Visual Studio 2022, .NET CLI

## License

Distributed under the MIT License. See the [LICENSE](./LICENSE) for more information.
