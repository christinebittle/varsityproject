# VarsityProject

A brief demonstration of Entity Framework, Code First, and LINQ. WebAPI Operations done for Creating, Reading, Updating, and Deleting Player Entities.

![Example CURL requests being sent for Create, Read, Update, and Delete.](https://github.com/christinebittle/varsityproject/blob/master/Varsity_Project/assets/curl_example.png)

## To Run This Project
- Clone Codebase
- **Right Click Project > View Project in File Explorer > Create Folder "App_Data"**
- Tools > Nuget Package Manager > Package Manager Console
- enable-migrations
- add-migration {migration_name}
- update-database

## To Add Data
- Add a team through VIEW > SQL SERVER OBJECT EXPLORER > VARSITYPROJECT > TABLES > PLAYERS > VIEW DATA
- Run CURL Requests to add data with
> curl -H "Content-Type: application/json" -d @player.json "https://localhost:xx/api/players/addplayer"
- make sure to have a player.json object, something like this:
{"PlayerName":"Christine Bittle","PlayerBio":"Not very athletic", "TeamID":1}

## To Remove Data
- Run CURL Requests to remove data with
> curl -d "" "https://localhost:xx/api/players/deleteplayer/{playerid}"
- Alternatively, VIEW > SQL SERVER OBJECT EXPLORER > VARSITYPROJECT > TABLES > PLAYERS > VIEW DATA

## To Update Data
- Run CURL Requests to update data with
> curl -H "Content-Type: application/json" -d @player2.json "https://localhost:xx/api/players/updateplayer/{playerid}"
- make sure to have a player2.json object, something like this
{"PlayerID":{playerid},"PlayerName":"Christine Bittle","PlayerBio":"Not very athletic", "TeamID":1}

## To List Data
- Run CURL Requests to list data with
> curl "https://localhost:xx/api/players/getplayers"
- Run CURL Requests to find a player with
> curl "https://localhost:xx/api/players/findplayer/{playerid}"

## Interact with the data directly (similar to PhpMyAdmin)
- VIEW > SQL SERVER OBJECT EXPLORER > VARSITYPROJECT > TABLES > PLAYERS > VIEW DATA

![Navigating to SQL Server Object Explorer](https://github.com/christinebittle/varsityproject/blob/master/Varsity_Project/assets/sqlserver_example.png)

![Manipulating objects directly in the database](https://github.com/christinebittle/varsityproject/blob/master/Varsity_Project/assets/local_sqlserver.png)

## References
- [Entity Framework Tutorial](https://www.entityframeworktutorial.net/what-is-entityframework.aspx)
- [Code First Tutorial](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx)
- [Entity Framework with WebAPI](https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/)

