# Accelerex_Restaurant
write a program that takes JJSON-formatted opening hours of a restaurant as  an input and outputs hours in more human readable format


#Technology Used
C#, .Net 6, Swagger UI.

## Reccommended Payload as regard (Part 2)
{
  "daysOfTheWeeks": [
    {
      "day": "string",
      "periods": [
        {
          "type": "string",
          "value": 0
        }
      ]
    }
  ]
}

#Sample Request
{
  "daysOfTheWeeks": [
    {
      "day": "sunday",
      "periods": [
        {
          "type": "open",
          "value": 32400
        },
{
          "type": "close",
          "value": 72000
        }
      ]
    },
    {
      "day": "monday",
      "periods": [
]
    },
    {
      "day": "tuesday",
      "periods": [
        {
          "type": "open",
          "value": 64800
        }
      ]
    },
    {
      "day": "thursday",
      "periods": [
        {
          "type": "open",
          "value": 57600
        },
{
          "type": "close",
          "value": 82800
        }
      ]
    },
{
      "day": "friday",
      "periods": [
       {
          "type": "open",
          "value": 57600
        },
{
          "type": "close",
          "value": 82800
        }
      ]
    },
{
      "day": "saturday",
      "periods": [
      ]
    }
  ]
}


#Sample Response
{
  "isSuccess": true,
  "result": "SUNDAY:  09:00 AM  -  08:00 PM  MONDAY: CLOSED  TUESDAY:  06:00 PM  -   WEDNESDAY:  09:00 AM  -  11:00 AM, 04:00 PM - 11:00 PM  THURSDAY:  04:00 PM  -    11:00 PM , FRIDAY:  04:00 PM  -  11:00 PM  SATURDAY: CLOSED ",
  "displayMessage": null,
  "errorMessages": null
}
