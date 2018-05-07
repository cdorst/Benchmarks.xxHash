using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.IO;
using System.Text;
using static Benchmarks.Constants;

namespace Benchmarks
{
    [SimpleJob(10)]
    [RPlotExporter, RankColumn]
    public class Tests
    {
        [Benchmark]
        public string XxHash32_AsHexString() => XxHash32.ComputeHash(MessageData).AsHexString();

        [Benchmark]
        public byte[] XxHash32_Bytes() => XxHash32.ComputeHash(MessageData).Hash;

        [Benchmark]
        public int XxHash32_BytesAsInt()
            => BitConverter.ToInt32(XxHash32.ComputeHash(MessageData).Hash, Zero);

        [Benchmark]
        public string XxHash64_AsHexString() => XxHash64.ComputeHash(MessageData).AsHexString();

        [Benchmark]
        public byte[] XxHash64_Bytes() => XxHash64.ComputeHash(MessageData).Hash;

        [Benchmark]
        public long XxHash64_BytesAsLong()
            => BitConverter.ToInt64(XxHash64.ComputeHash(MessageData).Hash, Zero);

        [Benchmark]
        public string XxHashDefault_AsHexString() => XxHashDefault.ComputeHash(MessageData).AsHexString();

        [Benchmark]
        public byte[] XxHashDefault_Bytes() => XxHashDefault.ComputeHash(MessageData).Hash;

        [Benchmark]
        public int XxHashDefault_BytesAsInt()
            => BitConverter.ToInt32(XxHashDefault.ComputeHash(MessageData).Hash, Zero);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tests = new Tests();
            var hexString32 = tests.XxHash32_AsHexString();
            var hexString64 = tests.XxHash64_AsHexString();
            var hexStringDefault = tests.XxHashDefault_AsHexString();
            Console.WriteLine($"XxHash32_AsHexString value: {hexString32}");
            Console.WriteLine($"XxHash32_AsHexString length: {hexString32.Length}");
            Console.WriteLine($"XxHash64_AsHexString value: {hexString64}");
            Console.WriteLine($"XxHash64_AsHexString length: {hexString64.Length}");
            Console.WriteLine($"XxHashDefault_AsHexString value: {hexStringDefault}");
            Console.WriteLine($"XxHashDefault_AsHexString length: {hexStringDefault.Length}");
            var hexString32Bytes = tests.XxHash32_Bytes();
            var hexString64Bytes = tests.XxHash64_Bytes();
            var hexStringDefaultBytes = tests.XxHashDefault_Bytes();
            Console.WriteLine($"XxHash32_Bytes length: {hexString32Bytes.Length}");
            Console.WriteLine($"XxHash32_Bytes length: {hexString64Bytes.Length}");
            Console.WriteLine($"XxHash32_Bytes length: {hexStringDefaultBytes.Length}");
            Console.WriteLine($"XxHash32_BytesAsInt value: {tests.XxHash32_BytesAsInt()}");
            Console.WriteLine($"XxHash64_BytesAsInt value: {tests.XxHash64_BytesAsLong()}");
            Console.WriteLine($"XxHashDefault_BytesAsInt value: {tests.XxHashDefault_BytesAsInt()}");

            var summary = BenchmarkRunner.Run<Tests>();
            var dataTable = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "BenchmarkDotNet.Artifacts", "results", "Tests-report-github.md"));
            var readme = new StringBuilder()
                .Append("# xxHash benchmarks")
                .AppendLine()
                .AppendLine("Run `./run.ps1` or `./run.sh` at the repository root to repeat the experiment")
                .AppendLine()
                .AppendLine("## Question")
                .AppendLine()
                .AppendLine("What is the most performant method of hashing using xxHash?")
                .AppendLine()
                .AppendLine("## Variables")
                .AppendLine()
                .AppendLine("Three implementations of xxHash are tested:")
                .AppendLine()
                .AppendLine("- Default (32-bit)")
                .AppendLine("- 32-bit (explicitly configured)")
                .AppendLine("- 64-bit")
                .AppendLine()
                .AppendLine("Results are returned as `byte[]`, `AsHexString`, and as `int` or `long` (depending on 32/64-bit hash) for comparison.")
                .AppendLine()
                .AppendLine("## Hypothesis")
                .AppendLine()
                .AppendLine("Given that `AsHexString` adds an operation, returning the `byte[]` value should be more performant (with `int`/`long` conversion as a close second). The 64-bit implementation is expected to outperform the 32-bit implementation given that the test scenario uses a relatively large string.")
                .AppendLine()
                .AppendLine("## Results")
                .AppendLine();
            foreach (var line in dataTable) readme.AppendLine(line);
            readme.AppendLine();
            readme
                .AppendLine("## Conclusion")
                .AppendLine()
                .AppendLine("As hypothesized, the 64-bit `byte[]` and `long` implementations outperformed the 32-bit & `AsHexString` implementations.")
                .AppendLine();
            File.WriteAllText("../README.md", readme.ToString());
        }
    }
}
