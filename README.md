# Employee Management API (Azure Cloud Deployed)

A production-style RESTful Web API built using ASP.NET Core 
(.NET 8) and Dapper ORM, fully deployed to Microsoft Azure 
with automated CI/CD pipeline via GitHub Actions.

![Deploy to Azure](https://github.com/sanjanasrinath29/EmployeeManagement-Azure-Blob/actions/workflows/deploy.yml/badge.svg)

## 🌐 Live API
🔗 Swagger UI: https://employeecloudapi123-hecgdedrcqcjgrcj.centralindia-01.azurewebsites.net/swagger/index.html

## 🚀 Features
- Full CRUD operations for Employee management
- Profile image upload to Azure Blob Storage
- Secure image URL stored in Azure SQL Database
- File upload handled via multipart/form-data
- Live API hosted on Azure App Service
- Swagger UI enabled for API documentation and testing
- Automated CI/CD pipeline via GitHub Actions
- Credentials secured via GitHub Secrets and Azure 
  Environment Variables

## 🛠 Tech Stack
- ASP.NET Core Web API (.NET 8)
- C#
- Dapper ORM
- Azure App Service (Free F1 tier)
- Azure SQL Database (Free Serverless tier)
- Azure Blob Storage
- GitHub Actions (CI/CD)
- Swagger (Swashbuckle)
- Git

## ☁️ Azure Architecture
- Azure App Service hosts the Web API
- Azure SQL Database stores structured employee data
- Azure Blob Storage stores and serves profile images
- Automated deployment via GitHub Actions CI/CD pipeline
- Connection strings secured in Azure Environment Variables

## 🔄 CI/CD Pipeline
- Automated build and deployment on every push to main branch
- GitHub Actions workflow: restore → build → publish → deploy
- Azure credentials stored securely in GitHub Secrets
- No sensitive credentials ever committed to source control

## 🔐 Security Practices
- Real connection strings stored in Azure Environment Variables
- GitHub Secrets used for deployment credentials
- appsettings.json contains only placeholder values
- appsettings.Development.json gitignored — never pushed

## 📸 Screenshots
- Swagger UI running on Azure (Live URL)
- GitHub Actions workflow — successful deployment
- Azure Storage container showing uploaded images
- Azure SQL table with ProfileImageUrl column
- Azure App Service deployment overview
- Azure Environment Variables configuration

## 👩‍💻 Author
Sanjana Srinath
Full Stack .NET Developer
📍 Bengaluru, India
🔗 LinkedIn: https://www.linkedin.com/in/sanjana-srinath-s2901/
