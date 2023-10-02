using System.Runtime.CompilerServices;
using MyDictionary;

var myDictionary = new MyDictionary<int, string>();

myDictionary.AddedPair += (sender, args) => 
    Console.WriteLine($"Pair [{args.key}, {args.value}] has been added");
myDictionary.RemovedPair += (sender, args) => 
    Console.WriteLine($"Pair [{args.key}, {args.value}] has been removed");
myDictionary.ChangedValue += (sender, args) =>
    Console.WriteLine($"Value by key [{args.key}] has been set to [{args.value}]");
myDictionary.Cleared += (sender, args) => 
    Console.WriteLine($"Dictionary has been cleared");


myDictionary.Print();

myDictionary.Add(1, "one");
myDictionary.Add(new KeyValuePair<int, string>(2, "two"));
myDictionary.Add(4, "!five!");
myDictionary[4] = "four";
myDictionary.Print();

myDictionary.Remove(1);
//myDictionary.Remove(9);
myDictionary.Remove(new KeyValuePair<int, string>(2, "two"));
myDictionary.Print();

Console.WriteLine($"Is there a value in the dictionary by the key 2? " +
    $"{myDictionary.TryGetValue(2, out string? two)}");
Console.WriteLine($"Dictionary contains key 4? " +
    $"{myDictionary.ContainsKey(4)}");
Console.WriteLine($"Dictionary contains pair [4, !five]? " +
    $"{myDictionary.Contains(new KeyValuePair<int, string>(4, "!five"))}");


myDictionary.Clear();
myDictionary.Print();
