using System;
namespace EmpathixProject;
public class Guest
{
    private const int DefaultMaxLimit = 3;

    public int RequestsCount { get; set; } = 0;
    
    
    public int MaxLimit { get; set; } = DefaultMaxLimit;
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
//..
}
