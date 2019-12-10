using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelManagement;

namespace SampleGame
{
    public class GameManager : MonoBehaviour
    {


        private Objective _objective;

        [SerializeField]
        private TransitionFader _endTransitionPrefab;


        private bool _isGameOver;
        public bool IsGameOver { get { return _isGameOver; } }

        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }



        // initialize references
        private void Awake()
        {

            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;

            }

            _objective = Object.FindObjectOfType<Objective>();

        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }


        public void EndLevel()
        {
            if (!_isGameOver)
            {
                _isGameOver = true;

                StartCoroutine(WinRoutine());

            }
        }

        private IEnumerator WinRoutine()
        {
            TransitionFader.PlayTransition(_endTransitionPrefab);

            float fadeDelay = (_endTransitionPrefab != null) ? _endTransitionPrefab.Delay + _endTransitionPrefab.FadeOnDuration : 0f;
            yield return new WaitForSeconds(fadeDelay);
            WinScreen.Open();
        }



        private void Update()
        {
            if (_objective != null && _objective.IsComplete)
            {
                EndLevel();
            }
        }

    }
}