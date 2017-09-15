# Introduction
This is the bootcamp hands-on project and it is intented to help you putting into practice the key concepts you have (hopefully) learned in the last few weeks. 

You will be building and deploying a simple TO-DO List application onto Azure, using some of the technologies we are currently using in production:

We envision the following application components

* Front end web application, Node and Express 
* Backend ASP.NET Web Api
* Storage CosmosDB
* Instrumentation – New Relic for front-end, App Insights for back end

And the following supporting components

* Traffic Manager
* Visual Studio Team Services
* ARM templates for provisioning azure infrastructure

The tasks required to complete this project will be based in sessions, described in more details below.

Throughout this sessions you will be pairing with another Emergent Talent. At the end of the bootcamp, your pair will present your implementation to the PSEs.


# Getting Started

To start you will need to fork this project onto the repository you will be sharing with your pair.

1. Clone the repository from Asos VSTS
	`git clone https://asos.visualstudio.com/DefaultCollection/ASOS%20Core/_git/asos-emergent-talent-material`
2. Add a remote to your own MSDN account VSTS
	`git remote add myfork <uri>`
	You need to get the Uri from the "Clone" option in your VSTS Account
3. Pull the branch you're interested in 
	`git pull origin <branch>`
4. Push the branch to your fork
	`git push myfork <branch>`
	
Whenever you commit you should only push up to the "myfork" remote

Now you should clone the fork repository on your local machine and start going through the sessions.


# Sessions

* [1 and 2: Implement back-end functionality](docs/sessions-1-and-2.md)
* [3 and 4: Creating web page connecting to back-end API](docs/sessions-3-and-4.md)
* [5 and 6: Adding user-input validation and Logging/Monitoring](docs/sessions-5-and-6.md)
* [7 and 8: Continuous Integration and Delivery](docs/sessions-7-and-8.md)
* [9 and 10: Content Delivery Network and Disaster Recovery](docs/sessions-9-and-10.md)