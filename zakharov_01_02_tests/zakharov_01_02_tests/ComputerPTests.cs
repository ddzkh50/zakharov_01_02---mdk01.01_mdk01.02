using zakharov_01_02;

namespace zakharov_01_02_tests
{
    public class ComputerPTests
    {
        [Theory]
        [InlineData(1000, 3.0, 8, 809.5)]
        [InlineData(100, 2.0, 4, 85.0)]
        [InlineData(1500, 3.0, 8, 1209.5)]
        [InlineData(0.5, 1.0, 1, 1.9)]
        public void q_check_not_greater1500(
            double p, double clockSpeed, int ram, double expected)
        {
            var computer = new ComputerP(p, "Intel Core i5", clockSpeed, ram);

            double actual = computer.Q();

            Assert.Equal(expected, actual, 2);
        }

        [Theory]
        [InlineData(2000, 3.0, 8, -990.5)]
        [InlineData(1600, 2.0, 4, 5.0 - 800.0)]
        [InlineData(3000, 4.0, 16, 18.0 - 1500.0)]
        public void q_check_greater1500(
            double p, double clockSpeed, int ram, double expected)
        {
            var computer = new ComputerP(p, "AMD Ryzen 7", clockSpeed, ram);

            double actual = computer.Q();

            Assert.Equal(expected, actual, 2);
        }

        [Fact]
        public void q_check_two_decimal()
        {
            var computer = new ComputerP(333.33, "Intel Core i3", 2.2, 4);

            double actual = computer.Q();

            Assert.Equal(5.1 + 266.664, actual, 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-0.01)]
        public void p_below_zero(double p)
        {
            var exception = Assert.Throws<ArgumentException>(
                () => new ComputerP(p, "Intel Core i5", 3.2, 16));

            Assert.Contains("винчестера", exception.Message);
        }

        [Fact]
        public void invalid_arguments()
        {
            Assert.Throws<ArgumentException>(
                () => new ComputerP(1000, "", 3.2, 16));
            Assert.Throws<ArgumentException>(
                () => new ComputerP(1000, "CPU", 0, 16));
            Assert.Throws<ArgumentException>(
                () => new ComputerP(1000, "CPU", 3.2, 0));
        }

        [Fact]
        public void min_p()
        {
            var computer = new ComputerP(0.01, "CPU", 2.0, 4);

            Assert.Equal(5.008, computer.Q(), 2);
        }
    }
}
