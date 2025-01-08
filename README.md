
<h1 style="font-weight: bold;">ThriveWell</h1>

<p>
<a href="#tech">Technologies</a>
<a href="#started">Getting Started</a>
<a href="#routes">API Endpoints</a>

 
</p>


<p>ThriveWell API provides the tools needed to track daily changes in chronic health conditions and to establish patterns for those symptoms. Doctors and patients can use the daily journal and symptom logs to track symptoms and their severity every day as well as the potential environmental and physiological triggers for those symptoms.

Overtime, patients and care providers can see which triggers and most likely linked to symptom flair ups and tailor health management plans around those triggers.

This documentation provides detailed information on all API endpoints and request / response formats. To make things easier, examples of request and response has been provided.
</p>


<p align="center">
<a href="https://documenter.getpostman.com/view/31905233/2sAYBViC5M">View Postman Documentation</a>
</p>

<h2 id="tech">💻 Technologies</h2>

- C#
- EF Core
- .NET
- pgAdmin
- Visual Studio
- Swagger
- Postman

<h2 id="started">🚀 Getting started</h2>

To get started with the Cocktail Club API, follow these steps:
Set Up Postman:

1. Download and install Postman
Import the ThriveWell Postman collection into Postman by using the Import button and selecting the provided JSON file

2. Next, fork this repository and clone it to your local machine. Note: This repository uses EF Core and PgAdmin.
After that, you'll need to run the following commands inside you project terminal in Visual studio:
```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0
dotnet user-secrets init
dotnet user-secrets set "ThriveWellDbConnectionString" "Host=localhost;Port=5432;Username=postgres;Password=<your_postgresql_password>;Database=ThriveWell"
dotnet ef database update
```
3. Run the solution in Visual Studio to launch Swagger and copy your localhost URI to use in Postman.

4. Configure Environment Variables:
Set the url variable to the base URL of your API. This is typically http://localhost:7069 for local development.
Set the uid variable to the user ID you will be using for testing.

5. Explore the Endpoints:
The collection includes pre-configured requests for various API operations. You can use these requests to interact with the API and see how it works.

### Authentication
The primary database entities for this API are user-specific. A UID is required for CRUD capabilties. This can be accomplished one of two ways:
Creating a unique UID for each user, comprised of letters and numbers. This is only recommended for API testing purposes.
Creating a client-side application which user's Google Authentication. Google will give each user's a unique UID which can then be passed to the API for use as the database UID. This is highly recommended for security and privacy when using in a published application.




<h3>Prerequisites</h3>

Here you list all prerequisites necessary for running your project. For example:

- Postman
- .NET 8
- pgAdmin
- Visual Studio

<h3>Cloning</h3>

How to clone your project

```bash
git clone your-project-url-in-github
```

<h2 id="routes">📍 API Endpoints</h2>

The following endpoints are available in the ThriveWell API.
​
### Daily Journal
| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /journals/user/{uid}</kbd>     | retrieves all of a user's journal entries
| <kbd>GET /journals/user/{uid}/{year}/{month}</kbd>     | retrieves all of a user's journal entries from a specific month and year
| <kbd>GET /journals/{id}</kbd>     | retrieves a user's specific journal entry
| <kbd>POST /journals</kbd>     | creates a new journal entry for a user
| <kbd>PUT /journals/{id}</kbd>     | edits a user's journal entry
| <kbd>DELETE /journals/{id}</kbd>     | deletes a specific journal entry 


### Symptom

| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /symptoms/user/{uid}</kbd>     | retrieves all of a user's symptom
| <kbd>GET /symptoms/{id}</kbd>     | retrieves a user's specific symptom
| <kbd>POST /symptoms</kbd>     | creates a new symptom for a user
| <kbd>PUT /symptoms/{id}</kbd>     | edits a specific symptom
| <kbd>DELETE /symptoms/{id}</kbd>     | deletes a specific symptom 

### Trigger

| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /triggers/user/{uid}</kbd>     | retrieves all of a user's trigger
| <kbd>GET /triggers/{id}</kbd>     | retrieves a user's specific trigger
| <kbd>GET /triggers/user/{uid}/topfive</kbd>     | retrieves a user's top five recurring triggers from the last 30 days
| <kbd>POST /triggers</kbd>     | creates a new trigger for a user
| <kbd>PUT /triggers/{id}</kbd>     | edits a specific trigger
| <kbd>DELETE /triggers/{id}</kbd>     | deletes a specific trigger

### Symptom Log

| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /logs/user/{uid}</kbd>     | retrieves all of a user's symptom logs
| <kbd>GET /logs/{uid}/date/{year}/{month}/{day}</kbd>     | retrieves all of a user's symptom logs by a specific date
| <kbd>GET /logs/{uid}/thirydays</kbd>     | retrieves all of a user's symptom logs from the last 30 days
| <kbd>GET /logs/{id}</kbd>     | retrieves a user's specific symptom log
| <kbd>POST /logs</kbd>     | creates a new symptom log for a user
| <kbd>PUT /logs/{id}</kbd>     | edits a specific log
| <kbd>DELETE /logs/{id}</kbd>     | deletes a specific log


### SymptomTrigger

| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>POST /symptom-trigger</kbd>     | create a new symptom trigger for a user's symptom log
| <kbd>DELETE /symptom-trigger/{id}</kbd>     | deletes a specific symptom trigger from a symptom log


<h3>Documentations that might help</h3>

[📝 Postman Documentation](https://documenter.getpostman.com/view/31905233/2sAYBViC5M)

[💻 Project ERD](https://dbdiagram.io/d/ThriveWell-66fc7ed5fb079c7ebd04de50)
