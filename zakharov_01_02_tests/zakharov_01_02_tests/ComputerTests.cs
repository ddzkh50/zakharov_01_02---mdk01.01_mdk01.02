using zakharov_01_02;

namespace zakharov_01_02_tests
{
    public class ComputerTests
    {
        [Theory]
        [InlineData(3.2, 16, 17.6)]
        [InlineData(2.5, 8, 9.25)]
        [InlineData(1, 1, 1.5)]
        [InlineData(4.8, 32, 34.4)]
        public void Q_clock_decimal(double clockSpeed, int ram, double expected)
        {
            var computer = new Computer("Intel Core i5", clockSpeed, ram);

            double actual = computer.Q();

            Assert.Equal(expected, actual, 2);
        }

        [Fact]
        public void Q_two_decimal()
        {
            var computer = new Computer("AMD Ryzen 7", 3.7, 16);

            double actual = computer.Q();

            Assert.Equal(17.85, actual, 2);
        }

        [Fact]
        public void GetInfo_check_contains()
        {
            var computer = new Computer("Intel Core i7", 3.6, 16);

            string info = computer.GetInfo();

            Assert.Contains("Intel Core i7", info);
            Assert.Contains(3.6.ToString(), info);
            Assert.Contains("16", info);
            Assert.Contains(computer.Q().ToString(), info);
        }

        [Fact]
        public void GetInfo_check_contains_Q()
        {
            var computer = new Computer("AMD Ryzen 5", 4.0, 8);

            string info = computer.GetInfo();

            Assert.Contains($"Q = {computer.Q()}", info);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void empty_name(string? processorName)
        {
            var exception = Assert.Throws<ArgumentException>(
                () => new Computer(processorName!, 3.2, 16));

            Assert.Contains("процессора", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-3.5)]
        public void clock_below_zero(double clockSpeed)
        {
            var exception = Assert.Throws<ArgumentException>(
                () => new Computer("Intel Core i5", clockSpeed, 16));

            Assert.Contains("Тактовая частота", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-16)]
        public void ram_below_zero(int ram)
        {
            var exception = Assert.Throws<ArgumentException>(
                () => new Computer("Intel Core i5", 3.2, ram));

            Assert.Contains("оперативной памяти", exception.Message);
        }

        [Fact]
        public void min_values()
        {
            var computer = new Computer("CPU", 0.1, 1);

            Assert.Equal(1.05, computer.Q(), 2);
        }
    }
}
