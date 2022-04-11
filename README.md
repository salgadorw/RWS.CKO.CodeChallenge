RWS.CKO.CodeChallenge

Project requirements:

To run application you will need the Visual Studio 2022 Communit and the .net framework 6.+.(Install the community version with web development tools):
Link:
****https://visualstudio.microsoft.com/free-developer-offers/****

And
Set the startup project PaymentGateway.Presentation.API and start the project clicking on green arrow:

![image](https://user-images.githubusercontent.com/4457435/162650623-84fbdc0e-9e6f-4f3c-bb96-6ffb3cc2901a.png)

Or
You Can run using PaymentGateway.Integration.Tests using the test explorer


Project Description

Application layers structure follows the DDD Microservices together with the Clean Architeture:

That is Explained on the first 15min of this tutorial:
https://www.youtube.com/watch?v=lkmvnjypENw

And on this tutorial:

https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice


Business Requirements Implemented:

CardInfo Persist and Validation

Acquiring bank is a Infrastructure dependency project so it has a dummy implementation that contains the payments persistency and the payment status changes

Improvements:

Implement of the the unit tests 
Implementation of integrations tests adding the validation the acquiring bank data status changes

Improvement of validations

Improvement of the acquiring banck implementation



  
