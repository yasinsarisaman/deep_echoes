namespace DeepEchoes.Scripts.Events
{
    public struct ApplyDamageEvent
    {
        public ApplyDamageEvent(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}