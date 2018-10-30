using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_BookStore.Factories.DiscountFactory_
{
    public class DiscountStrategy
    {
        public static IDiscountStrategy Discount5() => new Apply5();
        public static IDiscountStrategy Discount10() => new Apply10();
        public static IDiscountStrategy Discount20() => new Apply20();
        public static IDiscountStrategy Discount25() => new Apply25();
        public static IDiscountStrategy Discount0() => new Apply0();

    }
}
