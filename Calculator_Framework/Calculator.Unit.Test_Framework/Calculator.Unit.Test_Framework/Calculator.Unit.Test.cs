using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Unit.Test
{
    [TestFixture]
    public class Calculator
    {

        [Test]
        public void Add_Add3and4_returns7()
        {
            var uut = new Calculator_Framework.Calculator();
            Assert.That(uut.Add(3, 4), Is.EqualTo(7));
        }

        [Test]
        public void Sub_Sub4and3_returns1()
        {
            var uut = new Calculator_Framework.Calculator();
            Assert.That(uut.Substraction(4, 3), Is.EqualTo(1));
        }
        [Test]
        public void Mul_Mul2and2_returns4()
        {
            var uut = new Calculator_Framework.Calculator();
            Assert.That(uut.Multiply(2, 2), Is.EqualTo(4));
        }
        [Test]
        public void Pow_Pow4and2_returns16()
        {
            var uut = new Calculator_Framework.Calculator();
            Assert.That(uut.Power(4, 2), Is.EqualTo(16));
        }

        [Test]
        public void Pow_Pow2andminus1_returnsE()
        {
            var uut = new Calculator_Framework.Calculator();
            Assert.Throws(typeof(ArithmeticException), () => uut.Power(-3, 2));
        }

        [Test]
        public void Mul_Mul3and3_returns9()
        {
            var uut = new Calculator_Framework.Calculator();
            Assert.That(uut.Multiply(3, 3), Is.EqualTo(9));

        }

        [Test]
        public void Div_Div5And0_ReturnsE()
        {
            var uut = new Calculator_Framework.Calculator();
            Assert.Throws(typeof(DivideByZeroException), () => uut.Divide(4, 0));
        }

        [Test]
        public void Div_Div6And3_Returns2()
        {
            var uut = new Calculator_Framework.Calculator();
            Assert.That(uut.Divide(6, 3), Is.EqualTo(2));
        }

        [Test]
        public void Acc_AccAdd2And2_Returns4()
        {
            var uut = new Calculator_Framework.Calculator();
            uut.Accumulator = uut.Add(1, 1);
            Assert.That(uut.Add(uut.Accumulator,2), Is.EqualTo(4));
        }
    }
    }
