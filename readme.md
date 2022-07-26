#![EarlyMan](logo.png)
EarlyMan is an online webstore for the sale of local art.
...PS Forget about the logo it's not my strong point

### Tech Stack

- **EntityFramework Core ORM** - ORM library of choice
- **SQLServer** - database of choice
- **C#** and **ASP.NETCore Mvc** - server language and server framework[Dotnet core 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.0)
- **EfCore-Migrations** - for creating and running schema migrations
- **Razor**, **HTML**, **CSS** with [Bootstrap 4](https://getbootstrap.com/docs/4.0/getting-started/download/) - for website's frontend

Font-awesome: [https://fontawesome.com/download](https://fontawesome.com/download)

## Main Files: Project Structure

```sh
│─appsettings.development.jsos *** DB connection strings for local development
│─StartupDevelopment.cs *** Configuration and Services for dev enviroment
│───Areas
│       ├───Pages
│       │   └───Account *** RazorViews for Authentication
│       │───_ViewImports.cshtml
│───Controllers
│   │───HomeController.cs *** Actions methods that control majority of the  main page
│
│───Data ***Data Contexts and Migrations
│
│───Entities *** Internal storage models
│───Models *** DTOs, interfaces and Seed data
│   │───ViewModels
│       │───HomePageItems.cs
│
│───Views*** Project views
│   ├───Home
│   │   │───About.cshtml
│   │   │───Index.cshtml
│   │   │───Privacy.cshtml
│   │   │───ProductShowcase.cshtml
│   │   │───Summary.cshtml
```

## Local Running

─ First run `dotnet restore` to get denpendencies then `dotnet run -p build/build.csproj` and
─ Finally `dotnet run`
