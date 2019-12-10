using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;

namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {

        [SerializeField]
        private float _playDelay = 0.5f;

        [SerializeField]
        private TransitionFader startTransitionPrefab;

        public void OnPlayPressed()
        {
            StartCoroutine(OnPlayPressedRoutine());

        }
        private IEnumerator OnPlayPressedRoutine()
        {
            TransitionFader.PlayTransition(startTransitionPrefab);
            LevelLoader.LoadNextLevel();
            GameMenu.Open();
            yield return new WaitForSeconds(_playDelay);
        }

        public void OnSettingsPressed()
        {

            SettingsMenu.Open();
        }
        public void OnCreditsPressed()
        {



            CreditsMenu.Open();
        }

        public override void OnBackPressed()
        {

            Application.Quit();
        }
    }
}