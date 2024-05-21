# What's new in C# 10 and .net 6

## .net 6 features

Here are the [new features availables][1] in .net 6 API.

1. [Json source generator](.\Dotnet6\JsonSourceGeneratorShould.cs)
2. [Json DOM](.\Dotnet6\JsonShould.cs)
3. [New LINQ APIs](.\Dotnet6\LinqShould.cs)]
4. [Date and time improvements](.\Dotnet6\DateTimeShould.cs)
5. [Priority queue](.\Dotnet6\PriorityQueueShould.cs)]

## C# 10 features

Here are the [new features availables][2] in C# 10.

1. [Record structs](.\Csharp10\RecordShould.cs)
2. [Improvements of structure types](.\Csharp10\StructShould.cs)
3. [Interpolated string handler](.\Csharp10\InterpolatedStringShould.cs)
4. [Global using directives](.\Csharp10\Using.cs)
5. File-scoped namespace declaration
6. [Extended property patterns](.\Csharp10\ExtendedPropertyPatternsShould.cs)
7. [Lambda expression improvements](.\Csharp10\LambdaExpressionShould.cs)
8. [Constant interpolated strings](.\Csharp10\InterpolatedStringShould.cs)
9. [Record types can seal ToString](.\Csharp10\RecordShould.cs)
10. [Assignment and declaration in same deconstruction](.\Csharp10\DeconstructionShould.cs)
11. [Improved definite assignment](#Improved-definite-assignment)
12. Allow AsyncMethodBuilder attribute on methods
13. CallerArgumentExpression attribute diagnostics

### Improved definite assignment

Previously, some null checking were giving false positives, usually when checking for null in an if statement.

Now in C# 10, the compiler is able to determine that the variable is not null after the null check.

```csharp
if (c?.GetDependentValue(out object obj) == true)
{
   representation = obj.ToString(); // undesired error
}
```


[1]: https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6
[2]: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10
