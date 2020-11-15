using System.Collections.Generic;
using UnityEngine;

namespace TaroCards
{
    public static class CardDatabase
    {
        private static readonly CardConfig[] CardConfigs =
        {
            new CardConfig("Любитель проскочить",
                "Ваши карты со свойством «Изгой» стоят на (1) меньше."),
            new CardConfig("Счастливая победительница",
                "Боевой клич: вы раскапываете секрет."),
            new CardConfig("Танцующая кобра",
                "Порча: получает «Яд»."),
            new CardConfig("Кондитерский смерч",
                "Боевой клич: вы кладете в руку двух сахарных элементалей 1/2."),
            new CardConfig("Неистовый люторог",
                "Натиск. После атаки и убива другого существа, наносит остаток урона герою противника."),
            new CardConfig("Шипучий элементаль",
                "Натиск Провокация"),
            new CardConfig("Ненасытная гончая",
                "Провокация Порча: получает +1/+1   и «Похищение жизни»."),
            new CardConfig("Стальной палач",
                "Порча: становится оружием."),
            new CardConfig("Серокрон",
                "Провокация. Ваше случайное существо получает «Предсмертный хрип: призывает Серокрона»."),
            new CardConfig("Ходулеходец",
                "Боевой клич: герой получает +4 к атаке до конца хода.")
        };

        public static List<CardConfig> GetCardConfigs(int amount)
        {
            var result = new List<CardConfig>();
            while (result.Count < amount)
            {
                var randomConfig = CardConfigs[Random.Range(0, CardConfigs.Length)];
                if (!result.Contains(randomConfig))
                {
                    result.Add(randomConfig);
                }
            }

            return result;
        }
    }
}