using System;

namespace Backfy.Common.Infra.Helpers
{
    public static class RandomPricesHelper
    {
        public static decimal GetPrice()
        {
            return new Random().Next(1, 50);
        }
    }
}
