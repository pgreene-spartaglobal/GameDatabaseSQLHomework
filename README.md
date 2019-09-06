# GameDatabaseSQLHomework

SQL Database to store information about different games  
* Name
* Genre
* Type
* Review

## CRUD Operations
* Create
* Read
* Update
* Delete

Firstly to access the SQL classes the assembly must use 'System.Data.SqlClient'

To manipulate and read from the database first a connection must be made to an existing database, 
this is achieved by creating a new SqlConnection and passing the connection string of the database as an argument. 
Before then opening the connection. Opening the connection is placed within a try--catch to prevent the program crashing if 
a connection cant be made.

Once a connection has been made commands can be created and executed.

Create: To add new games to the database 
```
string insertString = String.Format("INSERT INTO Games (Name, Genre, Type, Review) " +
                                    "VALUES ('{0}', '{1}', '{2}', '{3}')", 
                                    game.Name, game.Genre, game.Type, game.Review);
```

Read: To retrieve existing records from the database
```
string selectString = "SELECT * FROM Games";
```

Update: To update existing records
```
string updateString = String.Format("UPDATE Games " +
                                    "SET {0} = '{1}' " +
                                    "WHERE ID = '{2}' ", columnName, value, id);
```

Delete: To delete existing records
```
string deleteString = String.Format("DELETE FROM Games " +
                                    "WHERE ID = '{0}' ", id);
```
