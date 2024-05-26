# takealittle
A tiny shopping API

This project demonstrates a few basic functions of a online shopping store which uses Google OAuth.

## Setup

To get started, you'll need to supply the **ClientID** and **ClientSecret** from your **Google Cloud Console**.

This can either be setup in the `appsettings.json` of the API project or directly into SwaggerUI after clicking 'Authorize'.
**Note:** This project requires the email and profile scope to function. This can be selected in SwaggerUI

## Architecture

This project follows Microsoft's [Clean Architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures) model.

Communication between layers is handled by MediatR, following the CQRS (Command and Query Responsibility Segregation) pattern to keep things tidy as the application scales in complexity.

Model Validation is done using FluentValidation

Mapster is the ORM of choice (since it's faster than AutoMapper)
