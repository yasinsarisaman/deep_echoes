namespace DeepEchoes.Scripts.Events
{
    public struct ResourceGainEvent
    {
        public ResourceGainEvent(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}