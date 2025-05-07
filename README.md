# MySuperHeroApp
A web based app which list downs different superheroes present at https://www.superheroapi.com/

It is a dotnet Aspire based project having service layer and frontend created using blazor.
it also has a generative AI component using microsoft phi3 model running inside ollama container.

## Introduction
My son is a big fan of comic characters. He is three year old and has lots of questions related different superheroes and villains. So, I decided to create this fun app where he can see his favourite super heroes and villains and ask questions about it. The GenAI powered chatbot answers his questions. 
With dot net stack, it took me less than 15 hours to write it from scratch.

## Pre-requisite
To run the application you would need the follwing:

### Gen AI model up and running.  
You would need docker desktop (if using windows).
Run ollama using command

`docker run -d -v ollama:/root/.ollama -p 11434:11434 --name ollama ollama/ollama`

Once the ontainer is up and running, run a model of your choice (depends upon your computers configuration).
My laptop configuration allowed phi3 model (although not very fast) for this protoype.
Use the folowing command to run the model.

`docker exec -it ollama ollama run phi3`

Alternative, if running a local model is not possible, you can choose online running model from huggingface.co

### Any database
In the application I am syncing the data from https://www.superheroapi.com to my local data store. I have used SQL server developer edition for the protoype. 

## Before you run the application
Before you run the application, you must perform the following steps.

`Update the connection string in service project appSettings.json`

`Apply dotnet migration so that related tables are created`

## Syncing the data
Run the aspire project

You will see the service layer in the aspire dashboard. 

Invoke the sync endpoint (/api/superheroes/sync) 

This should start a background worked job which syncs the data from superhero api to database and will take around 5 min to sync.

## The UI

If all the above steps are successful you can see on homepage, 5 characters per publisher.

Click on the publisher name to list all the characters from the publisher.

Click on the character card to get specific details. 

On the detail page, data from api is shown as it is. Also the description is generated from the AI using the data provided by API as context. 

Once the profile information is generated, you can also chat with AI to get answers to any other question you have.

