namespace Ofertownik.Data.Model
{
    public class CalcullationSetting
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double EnergyPrice { get; set; }
        public int ProductMargin { get; set; }
        public int MaterialMargin { get; set; }
        public double WorkerHourPrice { get; set; }

    }
}
