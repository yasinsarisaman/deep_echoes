using System;
using DeepEchoes.Scripts.Events;
using TMPro;
using UnityEngine;

namespace DeepEchoes.Scripts.Mangers
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _winMenu, _loseMenu ,_gameplayMenu;
        [SerializeField] private TextMeshProUGUI _loseState;

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
            switch (e.CompletionState)
            {
                case CompletionStates.CompletionState_WIN:
                    _winMenu.SetActive(true);
                    break;
                case CompletionStates.CompletionState_LOSE_BY_HEALTH:
                    _loseState.text = "You died!";
                    _loseMenu.SetActive(true);
                    break;
                case CompletionStates.CompletionState_LOSE_BY_OXYGEN:
                    _loseState.text = "You are out of Oxygen!";
                    _loseMenu.SetActive(true);
                    break;
                default:
                    _gameplayMenu.SetActive(false);
                    break;
            }
        }
    }
}