using UnityEngine;
using UnityEngine.UI;

namespace TaroCards
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private Deck _deck;
        [SerializeField] private Button _play;

        private void Awake() => _play.onClick.AddListener(Play);

        private void Play() => _deck.Play();

        private void OnDestroy() => _play.onClick.RemoveListener(Play);
    }
}