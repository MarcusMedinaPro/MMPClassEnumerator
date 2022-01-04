namespace Sandbox.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.Interfaces;

public class TestA : ITest
{
    public string Name { get; set; }
    public TestA () => Name = "A";
}

public class TestB : ITest
{
    public TestB () => Name = "B";
    public string Name { get; set; }
}

public class TestC : ITest
{
    public TestC () => Name = "C";
    public string Name { get; set; }
}

public class Caca: TestC
{
    public Caca () => Name = "Poop";
}