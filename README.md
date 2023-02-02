# WebApplicationBookStore

only https://localhost:7090/books page added so far. Input adress manually...

Add connection string to user secrets, replace "DatabaseServerName" in string with local server name. Initial Catalog=bookstore is the database.

secrets.json:
-------------------------------------

{
  "ConnectionStrings:WebApplicationBookStore": "Data Source=DatabaseServerName;Initial Catalog=bookstore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;"
}
