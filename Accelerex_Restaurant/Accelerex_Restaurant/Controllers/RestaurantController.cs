using Accelerex_Restaurant.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace Accelerex_Restaurant.Controllers
{
    [ApiController]
    [Route("api/restaurant")]
    public class RestaurantController : Controller
    {
        protected ResponseDto _response;
        public RestaurantController()
        {
            this._response = new ResponseDto();
        }
        [HttpPost("GetReadableTimeFormat")]
        public object GetReadableTimeFormat([FromBody]RestaurantDto restaurantDto)
        {
            try
            {
                StringBuilder result = new();
                foreach (var item in restaurantDto.daysOfTheWeeks)
                {
                    if(item != null)
                    {
                        switch (item.Day.Trim().ToLower())
                        {
                            case "sunday":
                                var resp = ComputeTime(item.periods, item.Day);
                                result.Append($"{resp}");
                                result.Append(" ");
                                break;
                            case "monday":
                                result.Append(" ");
                                var respm = ComputeTime(item.periods, item.Day);
                                result.Append($"{respm}");
                                result.Append(" ");
                                break;
                            case "tuesday":
                                result.Append(" ");
                                var respt = ComputeTime(item.periods, item.Day);
                                result.Append($"{respt}");
                                result.Append(" ");
                                break;
                            case "wednesday":
                                result.Append(" ");
                                var respw = ComputeTime(item.periods, item.Day);
                                result.Append($"{respw}");
                                result.Append(" ");
                                break;
                            case "thursday":
                                result.Append(" ");
                                var respth = ComputeTime(item.periods, item.Day);
                                result.Append($"{respth}");
                                result.Append(" ");
                                break;
                            case "friday":
                                result.Append(", ");
                                var respf = ComputeTime(item.periods , item.Day);
                                result.Append($"{respf}");
                                result.Append(" ");
                                break;
                            case "saturday":
                                result.Append(" ");
                                var resps = ComputeTime(item.periods, item.Day);
                                result.Append($"{resps}");
                                result.Append(" ");
                                break;

                            default:
                                break;
                        }
                        
                        
                    }
                    else
                    {
                        result.Append($"Closed");
                    }
                    
                   
                }
                _response.IsSuccess = true;
                _response.Result = result.ToString();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        private string ComputeTime(List<Period> periods, string day) 
        {
            if(periods?.Count == 0)
                return $"{day.ToUpper()}: CLOSED";
            
            string openCloseFormat = "DAYS: ";
            int open = 0, close = 0;

            foreach (var itemDetails in periods)
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(itemDetails.Value).ToLocalTime();
                openCloseFormat =  openCloseFormat.Replace("DAYS", day.ToUpper());
                if (itemDetails.Type.Trim().ToLower() == "open")
                {
                    if(open > 0)
                    {
                        openCloseFormat += ", OPEN";
                        openCloseFormat = openCloseFormat.Replace("OPEN", dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        openCloseFormat += " OPEN  - ";
                        openCloseFormat = openCloseFormat.Replace("OPEN", dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    }
                    open = open + 1;
                    //openCloseFormat = $"{dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)} -";

                }
                if(itemDetails.Type.Trim().ToLower() == "close")
                {
                    
                    if(close > 0)
                    {
                        openCloseFormat += " - CLOSE";
                        openCloseFormat = openCloseFormat.Replace("CLOSE", dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        openCloseFormat += " CLOSE";
                        openCloseFormat = openCloseFormat.Replace("CLOSE", dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    }
                    close = close + 1;
                    //openCloseFormat += $" {dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)}";

                }

                

                //if (close == 0)
                //    openCloseFormat = openCloseFormat.Remove(openCloseFormat.Length - 1, 1);


            }
            return openCloseFormat;
        }
    }
}
