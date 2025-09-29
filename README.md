# Blazor WebAssembly Project

## Project info

**URL**: (Not yet hosted)

## Overview

This is a Blazor WebAssembly application with Tailwind CSS styling and Azure SQL database integration. The project has been converted from React to use Blazor's component-based architecture while maintaining the same design system and UI components.

## How can I edit this code?

There are several ways of editing your application.

**Use your preferred IDE**

If you want to work locally using your own IDE, you can clone this repo and push changes. Pushed changes will also be reflected in Lovable.

Requirements:
- .NET 8.0 SDK or later
- Node.js & npm (for Tailwind CSS build process) - [install with nvm](https://github.com/nvm-sh/nvm#installing-and-updating)

## 🛠️ Follow these steps:

1. Step 1: Clone the repository using the project's Git URL.
```sh
git clone <https://github.com/Siya-S10-ai/disaster-relief-hub.git>
```

2. Step 2: Navigate to the project directory.
```sh
cd <"/giver-of-givers">
```

3. Step 3: Install npm dependencies for Tailwind CSS.
```sh
npm install
```

4. Step 4: Build Tailwind CSS (in a separate terminal, keep running)
```sh
npm run build-css
```

5. Step 5: Restore .NET dependencies.
```sh
dotnet restore
```

6. Step 6: Start the development server.
```sh
dotnet watch run
```

**Edit a file directly in GitHub**

- Navigate to the desired file(s).
- Click the "Edit" button (pencil icon) at the top right of the file view.
- Make your changes and commit the changes.

**Use GitHub Codespaces**

- Navigate to the main page of your repository.
- Click on the "Code" button (green button) near the top right.
- Select the "Codespaces" tab.
- Click on "New codespace" to launch a new Codespace environment.
- Edit files directly within the Codespace and commit and push your changes once you're done.

## What technologies are used for this project?

This project is built with:

- Blazor WebAssembly
- C# / .NET 8.0
- Tailwind CSS
- Azure SQL Database
- Entity Framework Core

## How can I deploy this project?

To deploy this project on **Netlify**, follow these steps:

1. Open [Netlify](https://app.netlify.com/).
2. Upload your project folder or connect your Git repository (GitHub, GitLab, or Bitbucket).
3. Configure build settings if not auto-detected:
   - **Build command:** `npm run build` (or `yarn build`)
   - **Publish directory:** `dist` (or `build`, depending on your framework)
4. Click **Deploy Site**.
5. Once the build completes, click **Share → Publish** to make your project live.
6. Your project will be available at:  
