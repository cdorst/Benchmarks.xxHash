using System.Data.HashFunction.xxHash;
using System.Text;

namespace Benchmarks
{
    internal static class Constants
    {
        public const int Zero = 0;

        public static readonly byte[] MessageData = Encoding.UTF8.GetBytes("This text is intentionally longer than 900 characters and is representative of the data intended to be stored in a varchar(max) data-column. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eu mauris posuere, eleifend neque egestas, pharetra elit. Ut bibendum luctus volutpat. Maecenas lacinia tortor scelerisque diam vestibulum euismod. Sed ut velit eget lectus congue ornare. Mauris facilisis, urna id ornare porta, libero turpis dictum arcu, sit amet aliquam nunc ligula eget libero. Fusce porta semper sodales. Vivamus interdum sit amet risus volutpat fringilla. Aenean a dolor ut leo placerat viverra vel quis eros. Etiam scelerisque, nulla vel condimentum pulvinar, est tortor vestibulum lorem, id hendrerit est ligula in arcu. Nulla malesuada, mi vel sodales elementum, nisl arcu pulvinar nunc, ac hendrerit dolor justo at quam. Praesent vestibulum ornare dui quis tempus. Etiam ut est sit amet nulla hendrerit porttitor. Pellentesque semper dui et dui vulputate posuere. Praesent ornare eros vel neque pulvinar, vitae semper eros rhoncus. Ut venenatis justo ac metus consequat pellentesque. Sed convallis, ligula nec placerat sagittis, arcu urna porttitor risus, vitae malesuada dolor lorem ac tellus. Cras dapibus, leo at auctor placerat, augue risus venenatis odio, vehicula tincidunt urna lacus sit amet lacus. Nullam velit metus, sollicitudin eget condimentum sed, commodo a ipsum. Vivamus et augue enim. Etiam id nisi sed elit tristique rutrum. Suspendisse malesuada at tortor vitae fringilla. Donec suscipit, est in consequat blandit, dolor justo commodo enim, et convallis augue erat a ligula. Mauris eget arcu quis tortor semper tincidunt at eu dui. Proin odio nibh, hendrerit nec blandit et, facilisis id metus. Nullam venenatis blandit massa. Vivamus scelerisque, odio eu euismod pretium, orci mauris molestie leo, non porta velit nisl non nisl.");

        public static readonly IxxHash XxHash32 = xxHashFactory.Instance.Create(new xxHashConfig { HashSizeInBits = 32 });

        public static readonly IxxHash XxHash64 = xxHashFactory.Instance.Create(new xxHashConfig { HashSizeInBits = 64 });

        public static readonly IxxHash XxHashDefault = xxHashFactory.Instance.Create();
    }
}
