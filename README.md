# White Automation Test
C# Windows Automation

## Setup
* Install [Visual Studio 2015](https://www.visualstudio.com/downloads/download-visual-studio-vs)
* Go to 'Tools>Extensions and Updates' and install `NUnit3 Test Adapter`

##Creating a Solution
* Create a new C# Project.  The exact project type doesn't really matter since you can add or remove packages later.
* Go to 'Tools>NuGet Package Manager>Manage NuGet Packages for Solution' and install the following packages:
```
TestStack.White (Latest stable 0.13.3)
NUnit (Latest stable 3.0.1)
```

## Creating Test
* Create a new Class in your Project for your tests.  Add `using NUnit.Framework` to the top of the class file.
* Add `[TestFixture]` as a header for your class
* Add `[Test]` as a header to each of the methods you want to use as a test.
* Your Test class should look something like this:
```
using NUnit.Framework;
  [TestFixture]
  public class MyTests{
      [Test]
      public void SearchandBookFlight() {
          //Test Actions/Calls
      }
  }
```
