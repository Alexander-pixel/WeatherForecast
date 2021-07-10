namespace XmlParse
{
    public struct Weather
    {
        private int _maxTemp;
        private int _minTemp;
        private string _wind;
        private string _overcast;

        public int MaxTemp
        {
            get => _maxTemp;
            set => _maxTemp = value;
        }
        
        public int MinTemp
        {
            get => _minTemp;
            set => _minTemp = value;
        }

        public string Wind
        {
            get => _wind;
            set => _wind = value;
        }
        
        public string Overcast
        {
            get => _overcast;
            set => _overcast = value;
        }

        public override string ToString()
        {
            return $"Weather:\n" +
                   $"Max temperature: {MaxTemp}\n" +
                   $"Min temperature: {MinTemp}\n" +
                   $"Wind: {Wind}\n" +
                   $"Overcast: {Overcast}";
        }
    }
}