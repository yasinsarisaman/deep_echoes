using System;
using DeepEchoes.Scripts.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DeepEchoes.Scripts.Mangers
{
    public class LevelManager : MonoBehaviour
    {
        
        private const string levelPrefName = "levelIndexPref";
        
        private int levelIndexer
        {
            get => PlayerPrefs.GetInt(levelPrefName, 1);
            set
            {
                PlayerPrefs.SetInt(levelPrefName,value);
            }
        }
        
        private void OnEnable()
        {
            EventBus<LevelCompletedEvent>.AddListener(OnLevelCompletedEvent);

        }

        private void OnDisable()
        {
            EventBus<LevelCompletedEvent>.RemoveListener(OnLevelCompletedEvent);
        }
        private void OnLevelCompletedEvent(object sender, LevelCompletedEvent e)
        {

            if (e.CompletionState == CompletionStates.CompletionState_WIN)
            {
                levelIndexer++;
            }
        }

        public void GoNextLevel()
        {
            if (levelIndexer > (SceneManager.sceneCountInBuildSettings -1))
            {
                // if last level reload this level
                RestartLevel();
            }
            SceneManager.LoadScene(levelIndexer);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}