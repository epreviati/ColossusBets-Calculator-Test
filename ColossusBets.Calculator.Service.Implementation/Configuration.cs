using System.Collections.Generic;
using ColossusBets.Calculator.Service.Data;
using ColossusBets.Calculator.Service.Data.Models;

namespace ColossusBets.Calculator.Service.Implementation
{
    public static class Configuration
    {
        public static IList<IMoney> AllMoneyValues = new List<IMoney>
        {
            new Note(50),
            new Note(20),
            new Note(10),
            new Note(5),
            new Coin(MoneyType.IntegerCoin, 2),
            new Coin(MoneyType.IntegerCoin, 1),
            new Coin(MoneyType.DecimalCoin, 50),
            new Coin(MoneyType.DecimalCoin, 20),
            new Coin(MoneyType.DecimalCoin, 10),
            new Coin(MoneyType.DecimalCoin, 5),
            new Coin(MoneyType.DecimalCoin, 2),
            new Coin(MoneyType.DecimalCoin, 1)
        };
    }
}