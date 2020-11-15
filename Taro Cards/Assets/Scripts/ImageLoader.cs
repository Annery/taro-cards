using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace TaroCards
{
    public class ImageLoader : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void LoadImage(int seed)
        {
            var random = new Random(seed);
            var randomId = random.Next(0, 100);
            var url = $"https://picsum.photos/id/{randomId}/200/300";
            StartCoroutine(DownloadingRoutine(url));
        }

        private IEnumerator DownloadingRoutine(string url)
        {
            var www = new WWW(url);
            yield return www;

            _image.material = new Material(_image.material)
            {
                mainTexture = www.texture
            };
            www.Dispose();
        }
    }
}