# Import-DLL-netcore
This repository contain sample of how to include .dll file into main dll. Using Assembly class in System.Reflection.

## Framework require for this repo
* .NET CORE 2.1

## Usage
Clone this project and compile using the following command.
    
    dotnet build -c release

Then go to the bin/release/netstandard and use the following command to run
    
    dotnet capp1.dll
    
> Please copy `trymodule.dll` file into the same directory of capp1.dll before run above command.

