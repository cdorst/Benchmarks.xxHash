``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.300-preview2-008533
  [Host]     : .NET Core 2.0.7 (CoreCLR 4.6.26328.01, CoreFX 4.6.26403.03), 64bit RyuJIT
  Job-WOXCRX : .NET Core 2.0.7 (CoreCLR 4.6.26328.01, CoreFX 4.6.26403.03), 64bit RyuJIT

LaunchCount=10  

```
|                    Method |     Mean |     Error |    StdDev |   Median | Rank |
|-------------------------- |---------:|----------:|----------:|---------:|-----:|
|      XxHash32_AsHexString | 5.612 us | 0.0152 us | 0.0532 us | 5.600 us |    8 |
|            XxHash32_Bytes | 5.213 us | 0.0146 us | 0.0525 us | 5.202 us |    4 |
|       XxHash32_BytesAsInt | 5.356 us | 0.0087 us | 0.0305 us | 5.351 us |    5 |
|      XxHash64_AsHexString | 3.424 us | 0.0060 us | 0.0212 us | 3.421 us |    2 |
|            XxHash64_Bytes | 2.686 us | 0.0052 us | 0.0184 us | 2.684 us |    1 |
|      XxHash64_BytesAsLong | 2.683 us | 0.0047 us | 0.0168 us | 2.683 us |    1 |
| XxHashDefault_AsHexString | 5.595 us | 0.0110 us | 0.0393 us | 5.588 us |    7 |
|       XxHashDefault_Bytes | 5.191 us | 0.0119 us | 0.0432 us | 5.182 us |    3 |
|  XxHashDefault_BytesAsInt | 5.390 us | 0.0245 us | 0.0868 us | 5.359 us |    6 |
