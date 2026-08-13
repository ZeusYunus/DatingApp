# Steps to creating a new feature

1. Create an Entities like Message.cs
2. Confiure it in the Member entities (An entity in .NET is a C# class that represents a database table, where each object represents a row in that table)
3. Register it in AppDbContext.cs (class that manages the connection between your .NET application and the database)
4. Run a migrations example. dotnet ef migrations add MessageEntityAdded (migrations track changes to your data model and update the database schema without losing existing data)
5. Create the Repository. Interface(class with only function calls) in interface folder first then implementation(all the logic) in data folder next (A Repository manages database operations, and an interface defines the methods it must implement.)
6. Create a MessageDto.cs (simple object used to transfer data between layers or systems without exposing the entity directly.)
7. Confiure the repository in the program class
8. Start adding the logic to MessageRepository.cs
9. Need an MessageExtensions methods (Methods or classes that add extra functionality to existing types without modifying their source code.)
10. New CreateMessageDto.cs
11. New MessagesController.cs
12. Create a new helper called MessageParams.cs. Use to get a person messages
13. Implement the client side