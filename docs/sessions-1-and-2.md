# Implementing back-end functionality

Implement functionality in the backend Web API to
 · GET all the todo items
 · POST a new todo item
 · PATCH an existing todo item

Create an Adapter with Get, Create and Overwrite operations against a data store 
Wire up an IoC container to inject an Adapter 
Adapter and Controller unit tests

To connect to your CosmosDB Database locally you will need to amend the Web.config file in the Asos.MiniProject.ToDo.Backend.Api project.

    1.  To get the Database address and Access Key, navigate to the Cosmos DB account blade in the Azure Portal, and click Keys. 
        The endpoint address is the field in the "URI" box and the access key is in the "PRIMARY KEY" box. There is a useful copy to clipboard
        button to the right of each of these text boxes.
    2.  Change the "value" of the appSetting "DocumentDatabase/EndpointAddress" to the endpoint address of your database.
    3.  Change the "value" of the appSetting "DocumentDatabase/Key" to the Primary Key generated in the azure portal.

These values should be substituted with variables when the application is deployed at a later point.