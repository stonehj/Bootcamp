# Implementing back-end functionality

## Contents

- [Objective](#Objective)
- [Step 1 - Create the controller logic](#Step-1---Create-the-controller-logic)
- [Step 2 - Configure Verbs and Routing](#Step-2---Configure-Verbs-and-Routing)
- [Step 3 - Configure connection to CosmosDB](#Step-3---Configure-connection-to-CosmosDB)
- [External Materials](#External-Materials)

## Objective

Implement the core back-end functionality on the existing Web API, pulling data from an actual data store. All features should be implemented observing the RESTful architecture, as defined below:

|HTTP Verb|Feature|Path
|----|----|----|
|GET|Retrieves all the TO-DO items.|/todo/items
|GET|Retrieves single TO-DO item.|/todo/items/{item-id}
|POST|Creates a new TO-DO item.|/todo/items
|PATCH|Amends an existing TO-DO item.|/todo/items/{item-id}
|DELETE|Deletes an existing TO-DO item.|/todo/items/{item-id}

## Step 1 - Create the controller logic

The implementation of each of the operations above will be driven by their test - as we will be taking a Test Driven Development approach.

#### Create a failing test following AAA (Arrange, Act, Assert)

1. Add a new ToDoControllerTests.cs to your test project.
2. Create a test method, giving it a meaningful name. 

```csharp
private void Be_able_to_return_all_items()
{    
}
```

3. Update the ```using``` section with all namespaces you are referencing from outside this class

```csharp
using Moq;
using NUnit.Framework;
using System.Web.Http.Results;
using System.Collections.Generic;
using Asos.MiniProject.ToDo.Backend.Api.Adaptor;
using Asos.MiniProject.ToDo.Backend.Api.Controllers;
using Asos.MiniProject.ToDo.Backend.Api.Models;
```
Generally you would not do this step manually, instead you would get ReSharper or Visual Studio to add those automatically as you type the name of the classes you need to use.

4. Arrange all dependencies for the test.

Both the data store instance and the subject under test (ToDoController) will be used in several tests. Therefore, create them at class level, which is normaly referred to as Fields.

```csharp
private Mock<IToDoItemAdaptor> todoAdapter;
private ToDoController toDoController;
```

Instanciate them before each test is executed, so you don't share state in between tests. This will ensure you don't get false positives/negatives.

```csharp
[SetUp]
public void Setup()
{
    this.todoAdapter = new Mock<IToDoItemAdaptor>();
    this.toDoController = new ToDoController(this.todoAdapter.Object);
}
```

Now inside of your actual test method you need to setup the mocked data store. So when you execute your controller you know exactly what to expect as a result.

```csharp
var items = new List<ToDoItem> { new ToDoItem(), new ToDoItem() };
this.todoAdapter.Setup(x => x.GetAllItemsAsync()).ReturnsAsync(items);
```

5. Act by calling the method on the controller that executes the action being tested, in this case ```GetItems```.

```csharp
var result = this.toDoController.GetItems().GetAwaiter().GetResult();
```

 6. Assert the results.  

The end test code would look similar to this:

```csharp
Assert.That(resultItems, Is.EqualTo(items));
```

Now do this for all the other 4 actions. :)

## Step 2 - Configure Verbs and Routing

## Step 3 - Configure connection to CosmosDB

To connect to your CosmosDB Database locally you will need to amend the Web.config file in the Asos.MiniProject.ToDo.Backend.Api project.

    1.  To get the Database address and Access Key, navigate to the Cosmos DB account blade in the Azure Portal, and click Keys. 
        The endpoint address is the field in the "URI" box and the access key is in the "PRIMARY KEY" box. There is a useful copy to clipboard
        button to the right of each of these text boxes.
    2.  Change the "value" of the appSetting "DocumentDatabase/EndpointAddress" to the endpoint address of your database.
    3.  Change the "value" of the appSetting "DocumentDatabase/Key" to the Primary Key generated in the azure portal.

These values should be substituted with variables when the application is deployed at a later point.



## External Materials

* [Getting started with ASP.Net Web API](https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api)
* [Web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api)
* [MVC explained through ordering a drink at the bar](https://medium.freecodecamp.org/model-view-controller-mvc-explained-through-ordering-drinks-at-the-bar-efcba6255053)
* [Beginners guide to REST](https://code.tutsplus.com/tutorials/a-beginners-guide-to-http-and-rest--net-16340)
