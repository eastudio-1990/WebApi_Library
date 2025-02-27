The architectural style used in this application is Domain-Driven Design (DDD). The reasons for choosing this approach are as follows:
Modularity: Changes in one part of the system can be made without affecting other parts.
Dependency Management: Dependency Injection (DI) is easier to implement.
Improved Readability and Testability: Unit tests can be written for BookService without directly connecting to the database.
Reusability of Layers: IBookService and IBookRepository can be reused in other projects.

The security:
Use DataProtection to encrypt sensitive data such as tokens and cookies.
Use Serilog for log events.
Use AspNetCoreRateLimit for DDOS attacks handler.

Simple start : 
Postman => Headers
Key : Authorization
Value :  Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJBZG1pbkBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImlzcyI6Ik15SXNzdWVyIiwiYXVkIjoiTXlBdWRpZW5jZSIsImV4cCI6MTc0MDQ2NzY5M30.xkPi2zIqvkA1qryedV***
