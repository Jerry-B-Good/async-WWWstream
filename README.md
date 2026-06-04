# Deliverables
Async programming is one of the tougher concepts to understand in software development. As this week's lesson demonstrated, the primary purpose of async programming is to allow you to perform tasks on a separate thread so that your application is not locked up waiting on that process. This is especially important when the task you are performing relies on third-party resources such as web APIs. For this week's homework, you will create a C# console application that demonstrates much of what you have learned in this course including:

+ Retrieving data from a Web API using HttpClient, async, and await.
+ Iterating over the data received from that API.
+ Displaying some portion of that data in the console

For this exercise, it is suggested that you use an API that can be accessed without fighting with the more complex aspects of API consumption like client IDs and client secrets. Here are some examples of APIs you can consume in your C# application without authentication:

+ https://pokeapi.co/api/v2/pokemon
+https://www.reddit.com/r/javascript.json

For DateTime values, you may deserialize them as a string if you are not yet comfortable with working with dates or times in C#.

As always, feel free to get creative. Don't forget to create a Git repository and push your work to GitHub.
