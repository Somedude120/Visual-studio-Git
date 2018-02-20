namespace RouletteGame.Legacy
{
    public abstract class Bet
    {
        protected Bet(string name, uint amount)
        {
            PlayerName = name;
            Amount = amount;
        }


        public string PlayerName { get; }
        public uint Amount { get; }

        public virtual uint WonAmount(Field field)
        {
            return 0;
        }
    }

    public class FieldBet : Bet
    {
        private readonly uint _fieldNumber;

        public FieldBet(string name, uint amount, uint fieldNumber) : base(name, amount)
        {
            _fieldNumber = fieldNumber;
        }

        public override uint WonAmount(Field field)
        {
            if (field.Number == _fieldNumber) return 36*Amount;
            return 0;
        }

        public override string ToString()
        {
            return $"{Amount}$ field bet on {_fieldNumber}";
        }
    }

    public class ColorBet : Bet
    {
        private readonly uint _color;

        public ColorBet(string name, uint amount, uint color) : base(name, amount)
        {
            _color = color;
        }

        public override uint WonAmount(Field field)
        {
            if (field.Color == _color) return 2*Amount;
            return 0;
        }

        public override string ToString()
        {
            string colorString;

            switch (_color)
            {
                case Field.Red:
                    colorString = "red";
                    break;
                case Field.Black:
                    colorString = "black";
                    break;
                default:
                    colorString = "green";
                    break;
            }

            return $"{Amount}$ color bet on {colorString}";
        }
    }

    public class EvenOddBet : Bet
    {
        private readonly bool _even;

        public EvenOddBet(string name, uint amount, bool even) : base(name, amount)
        {
            _even = even;
        }

        public override uint WonAmount(Field field)
        {
            if (field.Even == _even) return 2*Amount;
            return 0;
        }

        public override string ToString()
        {
            var evenOddString = _even ? "even" : "odd";

            return $"{Amount}$ even/odd bet on {evenOddString}";
        }
    }
}