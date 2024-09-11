# CurrencyConverter

## About
I have created a REST API that is consuming the public Frankfurter API
### ENDPOINTS
1. /latest-rates
   This will return the latest rates for a base currency EUR
2. /convert
   This is used to convert an amount from one currency to other. This will take 3 parameters: Currency to convert from, 
   currency to convert to and the amout to convert
3. /historical-rates
   This returns a set of historical rates in a specified date range. Base currency used is EUR. Pagination is supported.
   This will take start and end date as input parameters as well as the currencies against which exchange rate is needed.
   Page Number and Page size can also be specified.

 ### Assumptions
1. The end points for retrieving latest and historical rates are doing them for EUR currency.
2. It will be a public api so no authentication - authorization logic has been added.
3. The base Frankfurter API will be mostly responding.

 ### Enhancements
 1. The end points can be modified to get latest and historical rates for any given currency.
 2. Adding logging at key points
 3. Implementing monitoring and alerts to observe the behaviour and performance of API. For example, we can monitor the 
    number of requests and the average time taken to respond to optimize the performance of API.
 4. Implementing caching. We can cache the results from Frankfurter API to reduce the number of requests made to that API.
 5. Rate Limiter - Currently we have set the permit limit of requests to downstream API as 50. We can use the 
    monitored metrics to update this limit. Can also use load balancing techniques.
 6. Circuit Breaker - We can add circuit break strategy in case downstream API is not working so that a backlog of requests 
    is not created.
    
### Running the application
1. Clone the code from repo
2. Open the Project in Visual Studio:
      1. Open Visual Studio 2022.
      2. Select Open a project or solution.
      3. Navigate to the cloned project folder and select the .sln file.
3. Restore Dependencies:
         Visual Studio should automatically restore all NuGet packages, but if it doesn't, right-click on the solution and select Restore NuGet Packages.
4. Build the code
         Use CTRL+SHIFT+B to build the solution.
6. Run the Application:
         Press F5 or click on the Run button to start the API.(https mode)
