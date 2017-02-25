``` ini

BenchmarkDotNet=v0.10.1, OS=Windows
Processor=?, ProcessorCount=8
Frequency=3312782 Hz, Resolution=301.8611 ns, Timer=TSC
dotnet cli version=1.0.0-preview2-1-003177
  [Host] : .NET Core 4.6.24628.01, 64bit RyuJIT
  Core   : .NET Core 4.6.24628.01, 64bit RyuJIT

Job=Core  Runtime=Core  Gen 0=0.0484  
Allocated=255 B  

```
             Method |        Mean |    StdDev |
------------------- |------------ |---------- |
 DecrementUserValue | 308.7138 ns | 1.9158 ns |
 IncrementUserValue | 316.2314 ns | 4.7549 ns |
