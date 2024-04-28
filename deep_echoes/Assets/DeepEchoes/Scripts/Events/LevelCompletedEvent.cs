namespace DeepEchoes.Scripts.Events
{
    public enum CompletionStates
    {
        CompletionState_WIN,
        CompletionState_LOSE_BY_OXYGEN,
        CompletionState_LOSE_BY_HEALTH
    }
    public struct LevelCompletedEvent
    {

        public LevelCompletedEvent(CompletionStates state)
        {
            CompletionState = state;
        }

        public CompletionStates CompletionState;

    }
}