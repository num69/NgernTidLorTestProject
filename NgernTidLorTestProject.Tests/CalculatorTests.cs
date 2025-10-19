using Microsoft.Extensions.DependencyInjection;

namespace NgernTidLorTestProject.Tests
{
    public class CalculatorTests
    {
        private ServiceProvider _sp = null!;
        private ExpressionEvaluator _evaluator = null!;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ExpressionEvaluator>();
            _sp = services.BuildServiceProvider();
            _evaluator = _sp.GetRequiredService<ExpressionEvaluator>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sp.Dispose();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PassCase()
        {
            Assert.AreEqual(7, _evaluator.Evaluate("3 + 4"));
            Assert.AreEqual(7, _evaluator.Evaluate("3 + 4 * 1"));       // precedence test
            Assert.AreEqual(21, _evaluator.Evaluate("3 * (4 + 3)"));    // parentheses test
            Assert.AreEqual(2.5, _evaluator.Evaluate("5 / 2"));         // decimal test
            Assert.AreEqual(expected: -2, _evaluator.Evaluate("-5 + 3"));         // negative test
        }

        [Test]
        public void ErrorCase()
        {
            Assert.Throws<DivideByZeroException>(() => _evaluator.Evaluate("5 / 0"));
            Assert.Throws<ArgumentException>(() => _evaluator.Evaluate("3 + "));
        }
    }
}