# 

This is a demo repository of BDD. The focus here is not the source code, but rather the functional tests written using Specflow.
This is a forked repository from https://github.com/simplcommerce/SimplCommerce.
The ReadMe has been trimmed leaving  "how to run" sections.

## About the original project

A simple, cross platform, modularized ecommerce system built on .NET Core [![Join the chat at https://gitter.im/simplcommerce/SimplCommerce](https://badges.gitter.im/simplcommerce/SimplCommerce.svg)](https://gitter.im/simplcommerce/SimplCommerce?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Online demo (Azure Website)
- Store front: http://demo.simplcommerce.com
- Administration: http://demo.simplcommerce.com/admin Email: admin@simplcommerce.com Password: 1qazZAQ!

## Docker

For testing purpose only `docker run -p 5000:80 simplcommerce/ci-build`

Continuous deployment: https://ci.simplcommerce.com

## Visual Studio 2022 and SQL Server

#### Prerequisites

- SQL Server
- Visual Studio 2022

#### Steps to run

- Update the connection string in appsettings.json in SimplCommerce.WebHost
- Build the whole solution.
- In Solution Explorer, make sure that SimplCommerce.WebHost is selected as the Startup Project
- Open the Package Manager Console Window and make sure that SimplCommerce.WebHost is selected as the Default project. Then type "Update-Database" then press "Enter". This action will create the database schema.
- In Visual Studio, press "Control + F5".
- The back-office can be accessed via /Admin using the following built-in account: admin@simplcommerce.com, 1qazZAQ!

## Mac/Linux with PostgreSQL

#### Prerequisite

- PostgreSQL
- [.NET Core SDK 6.0](https://www.microsoft.com/net/download/all)
- Entity Framework Core (`dotnet tool install --global dotnet-ef`)

#### Steps to run

- Update the connection string in appsettings.json in SimplCommerce.WebHost.
- Run the simpl-build.sh file by issuing the following command: "sudo ./simpl-build.sh". For ubuntu 18: "sudo bash simpl-build.sh"
- In the terminal, navigate to "src/SimplCommerce.WebHost" and type "dotnet run" and then hit "Enter".
- Open http://localhost:5000 in the browser. The back-office can be accessed via /Admin using the following built-in account: admin@simplcommerce.com, 1qazZAQ!

## Technologies and frameworks used:

- ASP.NET MVC Core 6.0
- Entity Framework Core 6.0
- ASP.NET Identity Core 6.0
- Angular 1.6.3
- MediatR 7.0.0 for domain event

## License

SimplCommerce is licensed under the Apache 2.0 license.
