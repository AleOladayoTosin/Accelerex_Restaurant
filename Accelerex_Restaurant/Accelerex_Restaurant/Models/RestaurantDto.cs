namespace Accelerex_Restaurant.Models
{

    public class RestaurantDto
    {
        public List<DaysOfTheWeek> daysOfTheWeeks { get; set; }
    }
    public class DaysOfTheWeek
    {
        public string Day { get; set; }
        public List<Period> periods { get; set; }
    }
    public class Period
    {
        public string Type { get; set; }
        public double Value { get; set; }
    }

    public enum DayOfWeeks
    {
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday,
        sunday
    }
}
