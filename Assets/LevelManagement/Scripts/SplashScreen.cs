using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LevelManagement
{
    [RequireComponent(typeof(ScreenFader))]
    public class SplashScreen : MonoBehaviour
    {

        [SerializeField]
        private ScreenFader _screenFader;

        [SerializeField]
        private float delay = 1f;

        private void Awake()
        {
            _screenFader = GetComponent<ScreenFader>();
        }

        private void Start()
        {
            _screenFader.FadeOn();
        }

        public void FadeAndLoad()
        {
            StartCoroutine(FadeAndLoadRoutine());
        }

        private IEnumerator FadeAndLoadRoutine()
        {

            yield return new WaitForSeconds(delay);
            LevelLoader.LoadMainMenuLevel();
            _screenFader.FadeOff();
            var time = _screenFader.FadeOnDuration;
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }



    }
}