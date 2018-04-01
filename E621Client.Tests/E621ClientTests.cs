using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace E621.Tests
{
    public class E621ClientTests
    {
        private readonly ITestOutputHelper _output;

        public E621ClientTests(ITestOutputHelper output)
        {
            _output = output;
        }
    }
}
