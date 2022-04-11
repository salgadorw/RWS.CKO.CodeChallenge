RWS.CKO.CodeChallenge

Solution run requirements:

    To run application you will need the Visual Studio 2022 Communit and the .net framework 6.+.
    Install the community version with web development tools:
   https://devblogs.microsoft.com/dotnet/announcing-net-6/
   
   ![image](https://user-images.githubusercontent.com/4457435/162660958-7efd1ed3-a040-471d-af24-7bbafadc752a.png)
    
   ****https://visualstudio.microsoft.com/free-developer-offers/****

Solution run:

    Set the startup project PaymentGateway.Presentation.API and start the project clicking on green arrow:

   ![image](https://user-images.githubusercontent.com/4457435/162650623-84fbdc0e-9e6f-4f3c-bb96-6ffb3cc2901a.png)

    Or
    You can run using PaymentGateway.Integration.Tests using the test explorer:

   ![image](https://user-images.githubusercontent.com/4457435/162654568-21026474-2396-4035-b1c9-2efd3347d0a8.png)


Solution description:

    The solution layers structure follows the DDD Microservices together with the Clean Architeture solution patterns:

    That is Explained on the first 15min of this tutorial:

https://www.youtube.com/watch?v=lkmvnjypENw

    And on this article:

   https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice

The solution layers structure motivation:

    Implementing a microservice using DDD architecture pattern leads you for implementing the business roles 
    and its validation inside a domain model entity which is totally independ of the infrastructure and user interaction actions
    (Application Layer that suports the Presenter Layer that interacts with the user), allowing the microservice domain business 
    rules be implemented without external interferences like users input validation or user friendly results, data persistence, 
    and adptation of data for interaction with a third part application;


Business Requirements Implemented:

    Process payments requests persistency and retrievement of his data with their status

    Card info data persistency, retrievement and validation

    Acquiring bank Implementation as a Infrastructure dependency so it has pseudo-implementation which contains the payments 
    persistency and the payment status changes function


Improvements suggested:

    Implementation of the the unit tests for Payment.Gateway Appplication.Services and Domain.Entities

    Implementation of integrations tests adding the validations for the payments on the acquiring 
    bank regarding status changes data 

    Implementation of validations for payment gateway on CardInfo and Payment application services 
    regarding the user input data

    Implementation of the preferred user credit card property and its business rules

    Improvement of the implementation of the infrastructure acquiring bank



  
