using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SampleGame;

namespace LevelManagement
{
    public class GameMenu : Menu<GameMenu>
    {

        public void OnPausePressed()
        {
            Time.timeScale = 0;
            PauseMenu.Open();
        }

    }
}