# ClassEnumerator

This project is a small class with the only purpose to provide the coder with a list of classes implemmenting a specific interface. This is done by asking for classes that match a specific Interface or classes that inherit from a specific class.  The whole idea is to make it easier to use plugins or solutions of that kind.

* The main reason I made it a nuget was to show my students how to create and publis nugets. *

## Getting Started

You can either use the Nuget manager in Visual Studio, or install it from the package-manager.
For more information see [docs.microsoft.com](https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio).

### Prerequisites

If you need a list of classes without having to code a control to create an instance of each of them.
```cs
for(int i=0; i<MyStuff.Count; i++)
    Console.WriteLine($"{i:00} {MyStuff[i].Name}");

Console.Write("Select a topic: ");
var input = Console.ReadLine();
_ = int.TryParse(input, out var choice);

ITopic topic;
switch(choice())
{
    case 0: topic=new Topic0(); break;
    // A long list of cases follows....
}
```

### Installing

You can use the Nuget manager in visual studio or simply type
```
install-package MMPClassEnumerator
```

## Using the nuget

To get a list of instansiated classes that match your interface, you type
```cs
var listOfStuff = EnumerateClasses<IStuff>.GetClassesByInterface();
```
If you only want the name of the classes that match your interface, you type
```cs
var listOfStuff = EnumerateClasses<IStuff>.ListClassesByInterface();
```
To list the classes you could use
```cs
ListOfStuff.ForEach(i => Console.WriteLine(i.Name));
```
The nuget provides you with four methods
```cs
// Gets instances of classes that match the given parent class
GetClassesByInheritance<T>()

// Gets instances of classes that match the given Interface
GetClassesByInterface<T>()

// Gets definitons of classes that match the given parent class
ListClassesByInheritance<T>()

// Gets definitons of classes that match the given Interface
ListClassesByInterface<T>()
```
## Usage example
```cs
var listOfStuff = EnumerateClasses<IStuff>.GetClassesByInterface();
for(int i=0; i<MyStuff.Count; i++)
    Console.WriteLine($"{i:00} {MyStuff[i].Name}");```

Console.Write("Select a topic: ");
var input = Console.ReadLine();
_ = int.TryParse(input, out var choice);

ITopic topic=MyStuff[choice];
```

Other example, to list all classes in a project
```cs
var lst = EnumerateClasses<object>.GetClassesByInheritance().ToList();
lst.ForEach(i => Console.WriteLine(" class " + i.GetType().Name + "()"));
```

## Deployment

The deployment to a nuget is triggered by scripts on GitHub after PR to the main repository.

## Built With

* C#, .net 6 
  
## Authors
* **Marcus Medina** - *Initial project*

## License
Since I found the reflection-Linq-code on [StackOverflow](https://stackoverflow.com/a/699871) I am publishing this project according to the license they use.

This work is licensed under a [Creative Commons Attribution-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-sa/4.0/).
## Acknowledgments

* Inspiration code: https://stackoverflow.com/a/699871
* Template for Readme file is from https://gist.github.com/PurpleBooth
* Icon from https://iconarchive.com/show/ios7-icons-by-icons8/Programming-Cls-icon.html

## Source code
The source code for this project is available at https://github.com/MarcusMedinaPro/MMPClassEnumerator
