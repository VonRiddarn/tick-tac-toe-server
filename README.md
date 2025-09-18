# Tic Tac Toe Server ❌⭕💻

## How to use

Make sure you have dotnet installed on your system.  
Run command `dotnet --version` to make sure.  
If dotnet is not installed, install through the official sources.

### Setup

-   `git clone repo-link` : Clone repo
-   `cd repo-directory-name` : Enter directory
-   `dotnet restore` : Install dependencies
-   `dotnet run` : Run project

### Environment variables

This project depends on DotNetEnv, meaning you can easily add environment variables by creating a `.env` file.

#### Required variables

`HASH_SALT` : `"string"`  
The salt used for hashing user passwords on registration.  
Once live, this cannot change or users will get locked out.
