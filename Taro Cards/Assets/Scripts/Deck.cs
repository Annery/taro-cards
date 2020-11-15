using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TaroCards
{
    public class Deck : MonoBehaviour
    {
        [SerializeField] private Card _card;
        [SerializeField] private RectTransform _cardRoot;

        private const int CardsAmountMin = 4;
        private const int CardsAmountMax = 7;

        private readonly List<Card> _cardsInPlay = new List<Card>();
        private int _cardOrderIndex;

        private void Awake() => FillDeck();

        private void FillDeck()
        {
            var cardsAmount = GetCardsAmount();
            var configs = CardDatabase.GetCardConfigs(cardsAmount);
            var placements = PlacementCalculator.GetCardPlacements(cardsAmount, _cardRoot.transform.position);
            for (int i = 0; i < cardsAmount; i++)
            {
                var placement = placements[i];
                var card = Instantiate(_card, _cardRoot);
                card.transform.position = placement.Position;
                card.transform.Rotate(placement.Rotation);
                card.transform.Translate(placement.Nudge);
                card.Initialize(configs[i]);
                _cardsInPlay.Add(card);
            }
            _cardRoot.position += PlacementCalculator.GetRootOffset(cardsAmount, ((RectTransform)_card.transform).rect.width);
        }

        private static int GetCardsAmount() => Random.Range(CardsAmountMin, CardsAmountMax);

        private void ChangeCardOrderIndex()
        {
            _cardOrderIndex++;
            if (_cardOrderIndex > _cardsInPlay.Count - 1)
            {
                _cardOrderIndex = 0;
            }
        }

        private void ModifyRandomStat()
        {
            var currentCard = _cardsInPlay[_cardOrderIndex];
            var statToModify = Random.Range(0, 3);
            switch (statToModify)
            {
                case 0:
                    currentCard.ModifyHealth();
                    break;
                case 1:
                    currentCard.ModifyAttack();
                    break;
                case 2:
                    currentCard.ModifyMana();
                    break;
                default:
                    throw new IndexOutOfRangeException("Stat is not found");
            }
        }

        public void Play()
        {
            ModifyRandomStat();
            ChangeCardOrderIndex();
        }
    }
}