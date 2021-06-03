# KolmeoProductApi

A REST API providing access to different products.

## Running the code

To run the code, either:

Open *../KolmeoProductApi.sln* using Visual Studio and build and run it from there

*or*

Run from the command line using `dotnet run --project KolmeoProductApi.csproj`

## Design

The implementation uses a 3-tier architecture.

Controllers <--> Services <--> Data Store

### Controllers

These provide the REST API endpoints to interact with products. They use the *Services* to create and retrieve data from the *Data Store*

### Services

These objects interact with the Data Store.

### Data Store

This is where the product data is stored. For this demo project, and in memory database is being used.

### Other items

#### Request models

These objects represent the objects used by users of the API to create and retrieve data.

#### Data transfer objects (Dtos)

The controllers return Dtos to users of the API. Whilst the Data Store model and the Dto are currently identical, Dtos were used to avoid coupling users of the API to the Data Store model.

#### Options (Services.Options)

These objects are used by users of the *Services* to specify what to create and retrieve from the *DataStore*.

#### Models

These objects represent the entities stored in the *Data Store*.


## Assumptions

The following assumptions were made:
- A product's name is required and can contain any characters.
- A product's description is optional.
- A product's price is specified in USD and can be any non-negative value.

## Tests

The associated test project can be found in the *../KolmeoProductApi.Tests* directory.