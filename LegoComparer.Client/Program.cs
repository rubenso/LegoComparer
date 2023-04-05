// See https://aka.ms/new-console-template for more information

using LegoComparer.ApiSource;
using LegoComparer.Client.Workers;

const string serverUrl = "https://d16m5wbro86fg2.cloudfront.net/api";
LegoApiService apiService= new LegoApiService(serverUrl);

Console.WriteLine("Initialization finished");

//Task 1
//-------------------------------------------------------------------
string currentUser = "brickfan35";
Console.WriteLine($"Task 1 started for user '{currentUser}'");

var task1 = new Task1(apiService);
var result = task1.Work(currentUser);

if (result.Any())
{
    Console.WriteLine($"Possible Lego sets which can be made by {currentUser} user");
    foreach (var possibleSet in result)
    {
        Console.WriteLine(possibleSet);
    }
}
else
{
    Console.WriteLine($"No possible set found for user {currentUser}"); 

}
//--------------------------------------------------------------------

Console.WriteLine(string.Empty);

//Task 2
//-------------------------------------------------------------------
currentUser = "landscape-artist";
string currentSet = "tropical-island";

Console.WriteLine($"Task 2 started for user '{currentUser}'");

var task2 = new Task2(apiService);
var result2 = task2.Work(currentUser, currentSet);

Console.WriteLine($"Possible collaborating users to build '{currentSet}'");
if (result2 != null)
{
    foreach (var possibleSet in result2)
    {
        Console.WriteLine(possibleSet);
    }
}
else{ Console.WriteLine($"Nobody is possible for collaboration to build '{currentSet}'");}
//--------------------------------------------------------------------

//Console.WriteLine(string.Empty);

////Task 3
////-------------------------------------------------------------------
//currentUser = "megabuilder99";

//Console.WriteLine($"Task 3 started for user '{currentUser}'");

//var task3 = new Task3(apiService);
//var result3 = task3.Work(currentUser);

//Console.WriteLine($" '{currentUser}'");
//if (result3 != null)
//{
//    foreach (var possibleSet in result3)
//    {
//        Console.WriteLine(possibleSet);
//    }
//}
//else { Console.WriteLine($" '{currentUser}'"); }
////--------------------------------------------------------------------