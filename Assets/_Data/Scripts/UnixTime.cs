using UnityEngine;
using System;

public class UnixTime : MonoBehaviour
{
    protected static DateTimeOffset UnixEpoch = new(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

    public static int GetUnixTime()
    {
        return (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
    }

    public static long GetUnixTimeMicro()
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;
        return ToUnixTimeMicroseconds(now);
    }

    public static long ToUnixTimeMicroseconds(DateTimeOffset timestamp)
    {
        TimeSpan duration = timestamp - UnixEpoch;
        return duration.Ticks / 10;
    }

    public static float GetTimeDiffToNow(long startTime)
    {
        long nowTime = UnixTime.GetUnixTimeMicro();
        return (float) (nowTime - startTime)/1000000;
    }
}
