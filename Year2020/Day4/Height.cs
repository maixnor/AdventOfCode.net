namespace Year2020.Day4
{
    public struct Height
    {
        private int Number { get; init; }
        private string Unit { get; init; }

        public static Height ParseHeight(string height)
        {
            return new()
            {
                Number = int.Parse(height.Substring(0, height.Length - 2)),
                Unit = height.Substring(height.Length - 2)
            };
        }

        public override string ToString()
        {
            return Number + Unit;
        }

        public bool IsValid()
        {
            switch (Unit)
            {
                case "cm":
                    return 150 <= Number && Number <= 193;
                case "in":
                    return 59 <= Number && Number <= 76;
                default:
                    return false;
            }
        }
    }
}