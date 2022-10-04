Console.WriteLine("Input number");
int value = int.Parse(Console.ReadLine());

bool isgreaterthan10 = false;
Console.WriteLine("take1");
// if statement to decide what to put in a variable called is greater than 10 
if (value > 10)
{
    isgreaterthan10 = true;
}
else
{
    isgreaterthan10 = false;
}
Console.WriteLine(isgreaterthan10);
Console.WriteLine();
Console.WriteLine("take 2");

isgreaterthan10 = value > 10 ? true : false;

Console.WriteLine(isgreaterthan10);


string response = value > 10 ? "greater than 10" : "Not greater than 10";

Console.WriteLine(response);