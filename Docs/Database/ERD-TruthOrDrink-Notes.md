# ERD – TruthOrDrink

Suggested tables / entities:

- User (UserId, Name, Email, Age, etc.)
- Session (SessionId, HostId, CreatedAt, DaringLevel, etc.)
- Question (QuestionId, Text, CategoryId, Stars, Type, IsStandard)
- Category (CategoryId, Name, Description)
- SessionQuestion (SessionId, QuestionId, Order, WasAnswered, etc.)
- Review (ReviewId, SessionId, FromUserId, ToUserId, Rating, Comment)

Draw your ERD in a tool of your choice (draw.io, Lucidchart, etc.) and export it as
`ERD-TruthOrDrink.png` into this folder.
