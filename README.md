# MyBasketStats
Web API that allows coaches, players and fans to track various data and players' performance statistics of local basketball league.  Currently under development.

1. My idea
   I wanted to create a tool for basketball enthusiasts. There are many fans passionate about numbers in sports and my
   web application is supposed to serve their needs and provide tooling for officials to post game data. Assuming
   my league gets big there would be some betting websites interacting with my league events. Thats why I opted for
   web api based idea. Every game event is updated in api project as soon as possible to keep delay to the minimum for
   fans experience tracking live score and safe betting.

2. Solution consists of 2 projects so far:
 
   a). Web Api.(Mostly finished)
    -Is the core of entire project that uses MSSql server db to store league's data.
    -Implemented GET, POST, DELETE methods for all classes:
    Contract - Players' deals with teams are public,
    Game - This is by far the most complex class with variety of live game operations and its interacting with almost every other class,
    Player - Players achievements and physical attributes,
    Season - Games, contracts and some statsheets are connected to a certain seasons,
    Statsheet - Contains teams/players statistics,
    Team - Has its name and Collection of signed players

   b). Client App.(Recently started development)
    -Created typed HttpClient MyBasketStatsAPIClient. Methods return serialized content
    -My concept is to keep Client class complexity to minimum and flexibility to the maximum to avoid creating multiple clients and eliminate code duplication at the same time. I will deserialize content in services based on my needs.
