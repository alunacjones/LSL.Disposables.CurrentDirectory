[![Build status](https://img.shields.io/appveyor/ci/alunacjones/lsl-disposables-currentdirectory.svg)](https://ci.appveyor.com/project/alunacjones/lsl-disposables-currentdirectory)
[![Coveralls branch](https://img.shields.io/coverallsCoverage/github/alunacjones/LSL.Disposables.CurrentDirectory)](https://coveralls.io/github/alunacjones/LSL.Disposables.CurrentDirectory)
[![NuGet](https://img.shields.io/nuget/v/LSL.Disposables.CurrentDirectory.svg)](https://www.nuget.org/packages/LSL.Disposables.CurrentDirectory/)

# LSL.Disposables.CurrentDirectory

Provides a disposable current directory via the `Directory.GetCurrentDirectory` and `Directory.SetCurrentDirectory` methods.

```csharp
using LSL.Disposables.CurrentDirectory;
...

var original = Directory.GetCurrentDirectory();

using (var directory = new DisposableCurrentDirectory(@"C:\my-test"))
{
    var newDirectory = Directory.GetCurrentDirectory();
    // newDirectory will be "C:\my-test"
}

var directory = Directory.GetCurrentDirectory();
// directory will now be the same value as the 'original' variable
```
