
namespace NewInCSharp7.BetterLiterals
{
    public class BetterLiterals
    {
        // A binary number with separators.
        public const int TwoFiftySixBinary = 0b_0001_0000_0000;

        // A hex number with separators.
        public const int TwoFiftySixHex = 0x_01_00;

        // A decimal number with separators.
        public const int BigNumber = 100_500_255;

        // Separators can be used anywhere. They are just ignored.
        public const double BigDecimal = 100500_2_5_5.1_0_5;
    }
}
