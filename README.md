# TrueLayer.Pokedex.WebApi

i) Install Visual Studio 2019
ii) Open the TrueLayer.Pokedex.WebApi sln
iii) When you try to run it in docker (which has a play button on top) it will ask you to install docker for windows and restart your machine.
iv) When your machine restarts re run the solution
v) you will get swagger page where you will get try it
vi) you can execute the request like this 
curl -X GET "http://localhost:59528/api/Pokemon/mewtwo" -H  "accept: text/plain"
vii) curl -X GET "http://localhost:59528/api/Pokemon/translated/mewtwo" -H  "accept: text/plain"
