using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator_Unit_Test
{
    [TestFixture]
    public class Calculator_Unit_Test
    {
        [Test]
        public void Add_Add3and4_returns7()
        {
            var uut = new Calculator.Calculator();
            Assert.That(uut.Add(3, 4),Is.EqualTo(7));
        }

        [Test]
        public void Sub_Sub4and3_returns1()
        {
            var uut = new Calculator.Calculator();
            Assert.That(uut.Substraction(4,3),Is.EqualTo(1));
        }
        [Test]
        public void Mul_Mul2and2_returns4()
        {
            var uut = new Calculator.Calculator();
            Assert.That(uut.Multiply(2, 2), Is.EqualTo(4));
        }
        [Test]
        public void Pow_Pow4and2_returns8()
        {
            var uut = new Calculator.Calculator();
            Assert.That(uut.Power(4, 2), Is.EqualTo(16));
        }

        public void Mul_Mul3and3_returns9()
        {
            var uut = new Calculator.Calculator();
            Assert.That(uut.Multiply(3, 3),Is.EqualTo(9));
            
        }

        public void Mul_Mul5and5_returns25()
        {
            var uut = new Calculator.Calculator();
            Assert.That(uut.Multiply(5, 5), Is.EqualTo(25));

        }
    }
}
