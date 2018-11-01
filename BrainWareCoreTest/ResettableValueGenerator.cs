using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Threading;

namespace BrainWareCoreTest
{
    // https://github.com/aspnet/EntityFrameworkCore/issues/6872
    // Workaround for issue with in Memory Database testing and autoincrements
    public class ResettableValueGenerator : ValueGenerator<int>
    {
        private int _current;

        public override bool GeneratesTemporaryValues => false;

        public override int Next(EntityEntry entry)
            => Interlocked.Increment(ref _current);

        public void Reset() => _current = 0;
    }
}
