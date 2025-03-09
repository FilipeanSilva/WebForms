# ASP.NET WebForms Application (Coding challenge)

This project was built as a 5-hour coding challenge for an interview. It demonstrates core ASP.NET WebForms functionalities, including user authentication, file submission, and session management. A simple ASP.NET WebForms application demonstrating user registration, login, file submission, and other fundamental functionalities using the .NET Framework.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies](#technologies)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Overview

This repository contains a basic ASP.NET WebForms project. The application includes the following functionalities:

- **User Authentication**: Registration, login, and logout.
- **File Submission**: Users can submit files (e.g., images, documents) through a simple interface.
- **Responsive Layout**: Leverages the default master page architecture to ensure a consistent look and feel across all pages.

The main goal of this project is to provide a straightforward example of how to structure and implement a WebForms app in ASP.NET, including managing user sessions and standard web form actions.

## Features

1. **User Registration** – A `Register.aspx` page that allows new users to sign up.
2. **User Login** – A `Login.aspx` page for existing users to authenticate.
3. **Logout** – A `LogOut.aspx` page (or mechanism) to end a user session.
4. **File Submission** – A `SubmitFile.aspx` page where authenticated users can upload files.
5. **Default Home Page** – A `Default.aspx` serving as the landing page of the application.
6. **Global Error Handling** – A `Global.asax` file to manage application-level events and errors.
7. **Layout** – A `Site.Master` master page to maintain a consistent UI across pages.
8. **View Switcher** – A `ViewSwitcher.ascx` that may be used to toggle layouts or handle other UI switches (if configured).

## Technologies

- **ASP.NET WebForms** (.NET Framework)
- **C#** as the primary programming language
- **Microsoft Visual Studio** (or VS Code with extensions) for development
- **Packages** as referenced in `packages.config`

## Prerequisites

1. **.NET Framework**  
   Make sure you have a version of the .NET Framework compatible with the project (e.g., .NET Framework 4.7.2 or 4.8).

2. **IDE**  
   [Microsoft Visual Studio](https://visualstudio.microsoft.com/) (any recent edition) is recommended for convenient development and debugging.  
   Alternatively, you can use Visual Studio Code with the appropriate .NET extensions.

3. **SQL Server** (Optional)  
   If the application uses a database for user authentication and storage (common for Membership or Identity), you will need access to a SQL Server instance or LocalDB.

## Installation

1. **Clone the repository**  
   ```bash
   git clone https://github.com/YourUsername/YourRepositoryName.git
   ```
2. **Open the project**  
   - Launch Visual Studio.
   - From the top menu, select **File** > **Open** > **Project/Solution...**.
   - Select the `WebForms.sln` file.

3. **Restore NuGet packages**  
   - Visual Studio should automatically restore NuGet packages as per `packages.config`.
   - If needed, right-click on the solution in **Solution Explorer** and select **Restore NuGet Packages**.

4. **Configure database (if applicable)**  
   - Update the `Web.config` file with your database connection string settings if using database-driven features.

5. **Build the solution**  
   - From the **Build** menu, select **Build Solution**.

## Usage

1. **Run the application**  
   - Press **F5** in Visual Studio or choose **Debug** > **Start Debugging** to launch the development server.
   - The app should open in your default web browser (e.g., `https://localhost:xxxx/`).

2. **Register**  
   - Navigate to the registration page (`/Register.aspx`).
   - Fill out the registration form to create a new user account.

3. **Login**  
   - Navigate to the login page (`/Login.aspx`).
   - Sign in with your registered credentials.

4. **Submit Files**  
   - After logging in, go to the file submission page (`/SubmitFile.aspx`) and upload a file.

5. **Logout**  
   - Click the logout link or navigate to `LogOut.aspx` to end your session.

6. **Modify / Extend**  
   - Feel free to add more pages or modify existing functionality to suit your needs. All changes should be reflected by rebuilding the solution.

## Project Structure

```
YourRepositoryName/
│
├─ WebForms.sln               // The main solution file
├─ Global.asax                // Global application events
├─ packages.config            // NuGet package references
├─ Site.Master                // Master page providing layout
├─ ViewSwitcher.ascx          // User control for view switching (if enabled)
│
├─ Default.aspx               // Home/Landing page
├─ Login.aspx                 // User login page
├─ LogOut.aspx                // Logout handling page
├─ Register.aspx              // New user registration page
├─ SubmitFile.aspx            // Page for file submission
│
└─ App_Code/                  // (Optional) Shared classes, helpers
└─ App_Data/                  // (Optional) Local database or data files
└─ Scripts/                   // JavaScript files
└─ Styles/                    // CSS files
```

*(Your exact folder structure may vary.)*

## Contributing

Contributions are welcome! To contribute:

1. **Fork** the repository.
2. **Create** a new feature branch:  
   ```bash
   git checkout -b feature/my-new-feature
   ```
3. **Commit** your changes:  
   ```bash
   git commit -m "Add some new feature"
   ```
4. **Push** to the branch:  
   ```bash
   git push origin feature/my-new-feature
   ```
5. **Open a Pull Request** describing the changes you’ve made and how they address the issue or feature request.

## License

Specify your chosen license here. Common choices include [MIT](https://choosealicense.com/licenses/mit/), [Apache 2.0](https://choosealicense.com/licenses/apache-2.0/), or [GPL](https://choosealicense.com/licenses/gpl-3.0/).

```
MIT License (example)
Copyright (c) 2025 [Your Name]

Permission is hereby granted, free of charge, to any person obtaining a copy
...
```

Alternatively, if you do not wish to specify a license, you can remove this section, but note that unlicensed work restricts how others can use your project.

## Contact

- **Author**: [Your Name]
- **Email**: [Your Email Address]
- **GitHub**: [Your GitHub Profile](https://github.com/YourUsername)

If you have any questions or suggestions, feel free to open an issue or contact me directly.

---

*Thank you for using this ASP.NET WebForms application! If you find it helpful, please give it a star on GitHub and share it with others.*
