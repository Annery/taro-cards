using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace TaroCards
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _descriptionText;
        [SerializeField] private Text _healthText;
        [SerializeField] private Text _attackText;
        [SerializeField] private Text _manaText;
        [SerializeField] private ImageLoader _loader;

        private const int MinStatValue = 0;
        private const int MaxStatValue = 10;
        private const int MinValueDelta = -9;
        private const int MaxValueDelta = -2;
        private const float AnimationTimeMultiplier = 0.25f;

        private int _health;
        private int _attack;
        private int _mana;

        public void Initialize(CardConfig config)
        {
            gameObject.SetActive(true);
            _loader.LoadImage(GetSeed());
            _nameText.text = config.Name;
            _descriptionText.text = config.Description;
            SetHealth(config.Health);
            SetAttack(config.Attack);
            SetMana(config.Mana);

            int GetSeed() => config.Health * 17 + GetHashCode();
        }

        private static void SetWithAnimation(int start, Action<int> action, Text text)
        {
            text.DOKill();
            var delta = GetRandomDelta();
            var animationTime = Math.Abs(delta * AnimationTimeMultiplier);
            var end = Mathf.Clamp(start + delta, MinStatValue, MaxStatValue);
            DOTween.To(() => start, action.Invoke, end, animationTime)
                .OnComplete(() => { action.Invoke(end); })
                .OnKill(() => { action.Invoke(end); });
        }

        private void SetMana(int value)
        {
            _mana = value;
            _manaText.text = value.ToString();
        }

        private void SetAttack(int value)
        {
            _attack = value;
            _attackText.text = value.ToString();
        }

        private void SetHealth(int value)
        {
            _health = value;
            _healthText.text = value.ToString();
        }

        public void ModifyHealth() => SetWithAnimation(_health, SetHealth, _healthText);

        public void ModifyAttack() => SetWithAnimation(_attack, SetAttack, _attackText);

        public void ModifyMana() => SetWithAnimation(_mana, SetMana, _manaText);

        private static int GetRandomDelta() => Random.Range(MinValueDelta, MaxValueDelta);
    }
}
