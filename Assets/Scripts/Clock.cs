using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public Transform minuteHand;
    public Transform hourHand;
    public Transform secondHand;

    private int _previousSeconds;
    private int _timeInSeconds;
   
    void Update()
    {
        ConvertTimeToSeconds();
        RotateClockHands();
    }

    int ConvertTimeToSeconds()
    {
        int currentSeconds = DateTime.Now.Second;
        int currentMinute = DateTime.Now.Minute;
        int currentHour = DateTime.Now.Hour;

        if (currentHour >= 12)
        {
            currentHour -= 12;
        }

        _timeInSeconds = currentSeconds + (currentMinute * 60) + (currentHour * 60 * 60);
        return _timeInSeconds;

    }

    private void RotateClockHands()
    {
        // Get the current time in Berlin's timezone
        DateTime time = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time"));

        // Calculate the rotation angles for each hand
        float hourRotation = 360f/ (60f * 60f *12f); 
        float minuteRotation = 360f / (60f * 60f); 
        float secondRotation = 360f / 60f; 

        if (_timeInSeconds != _previousSeconds)
        {
            // Apply the rotations to the clock hands
            hourHand.localRotation = Quaternion.Euler( 0, _timeInSeconds * hourRotation, 0);
            minuteHand.localRotation = Quaternion.Euler( 0, _timeInSeconds * minuteRotation, 0);
            secondHand.localRotation = Quaternion.Euler( 0, _timeInSeconds * secondRotation, 0);
        }
        _previousSeconds = _timeInSeconds;
    }

}
