using System.Collections.Generic;
using UnityEngine;

namespace TaroCards
{
    public static class PlacementCalculator
    {
        private const int MapOffset = 110;
        private const float TotalTwist = 40f;
        private const float ScalingFactor = 3f;

        public static List<CardPlacementData> GetCardPlacements(int cardsAmount, Vector3 rootPosition)
        {
            var result = new List<CardPlacementData>();
            var startPosition = rootPosition;
            var maxIndex = cardsAmount - 1;
            var twistPerCard = TotalTwist / maxIndex;
            const float startTwist = TotalTwist / 2f;

            for (int i = 0; i < cardsAmount; i++)
            {
                var twistForThisCard = startTwist - i * twistPerCard;
                var nudgeThisCard = Mathf.Abs(twistForThisCard) * ScalingFactor;
                result.Add(new CardPlacementData
                {
                    Position = startPosition,
                    Rotation = new Vector3(0, 0, twistForThisCard),
                    Nudge = new Vector3(0, -nudgeThisCard, 0)
                });
                startPosition += new Vector3(MapOffset, 0, 0);
            }

            return result;
        }

        public static Vector3 GetRootOffset(int cardsAmount, float width)
        {
            var offset = width / 2f;
            return new Vector3(-(MapOffset * cardsAmount / 2f) + offset * 0.75f, 0, 0);
        }
    }
}