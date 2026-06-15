using System;

public class Guest
{
    public int RequestsCount { get; set; } = 0;
    public int MaxLimit { get; set; } = 3;

    public bool CheckGuestLimit()
    {
        if (RequestsCount < 0)
        {
            throw new ArgumentException("Кількість запитів не може бути негативною!");
        }

        if (RequestsCount >= MaxLimit)
        {
            return false;
        }
        return true;
    }

    public void IncrementRequests()
    {
        RequestsCount++;
    }
}
