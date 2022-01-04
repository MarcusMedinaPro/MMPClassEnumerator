// See https://aka.ms/new-console-template for more information
using MMPEnumerator;
using Sandbox.Classes;
using Sandbox.Interfaces;

Console.WriteLine("Hello, World!");
EnumerateClasses<ITest>.GetClassesByInterface().ToList().ForEach(i => Console.WriteLine(i.Name));
Console.WriteLine("-------------------------------------------------");
EnumerateClasses<ITest>.ListClassesByInterface().ToList().ForEach(i => Console.WriteLine(i.Name));
Console.WriteLine("-------------------------------------------------");
EnumerateClasses<TestC>.GetClassesByInheritance().ToList().ForEach(i => Console.WriteLine(i.Name));
Console.WriteLine("-------------------------------------------------");
EnumerateClasses<TestC>.ListClassesByInheritance().ToList().ForEach(i => Console.WriteLine(i.Name));
Console.WriteLine("-------------------------------------------------");
EnumerateClasses<Object>.ListClassesByInheritance().ToList().ForEach(i => Console.WriteLine(i.Name));
Console.WriteLine("-------------------------------------------------");
