# CommandKeeper

REST API to save different commands in a SQL database


|Methods               |URL               |Request    |Description                                      |
|----------------------|------------------|-----------|-------------------------------------------------|
|GetAllCommands        |api/commands      |**GET**    |Retrieve all commands from DB
|GetCommandById        |api/commands/{id} |**GET**    |Retrieve a specific command from DB by ID
|CreateCommand         |api/commands      |**POST**   |Insert a command in DB
|UpdateCommand         |api/commands/{id} |**PUT**    |Change a command from DB
|PartialCommandUpdate  |api/commands/{id} |**PATCH**  |Change only a part of a command from DB
|DeleteCommand         |api/commands/{id} |**DELETE** |Delete a command from DB
