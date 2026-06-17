using System;
using Xunit;
namespace EmpathixProject;
public class EmpathixTests
{
    [Fact]
    public void TestGuestUnderLimit()
    {
        var guest = new Guest();
        guest.RequestsCount = 0;
        var result = guest.CheckGuestLimit();
        Assert.True(result);
    }

    [Fact]
    public void TestGuestAtBoundaryAllow()
    {
        var guest = new Guest();
        guest.RequestsCount = 2;
        var result = guest.CheckGuestLimit();
        Assert.True(result);
    }

    [Fact]
    public void TestGuestAtLimitBlock()
    {
        var guest = new Guest();
        guest.RequestsCount = 3;
        var result = guest.CheckGuestLimit();
        Assert.False(result);
    }

    [Fact]
    public void TestGuestNegativeRequests()
    {
        var guest = new Guest();
        guest.RequestsCount = -1;
        Assert.Throws<ArgumentException>(new Action(() => guest.CheckGuestLimit()));
    }

    [Fact]
    public void TestGuestIncrementRequests()
    {
        var guest = new Guest();
        guest.IncrementRequests();
        Assert.Equal(1, guest.RequestsCount);
    }

    [Fact]
    public void TestSessionValidTone()
    {
        var session = new GenerationSession("friendly");
        Assert.Equal("friendly", session.Tone);
    }

    [Fact]
    public void TestSessionInvalidTone()
    {
        Assert.Throws<ArgumentException>(new Action(() => new GenerationSession("angry")));
    }

    [Fact]
    public void TestProcessEmptyText()
    {
        var session = new GenerationSession("friendly");
        Assert.Throws<ArgumentException>(new Action(() => session.ProcessText("")));
    }

    [Fact]
    public void TestProcessValidText()
    {
        var session = new GenerationSession("friendly");
        var result = session.ProcessText("Hello");
        Assert.Equal("😊 Hello", result);
    }

    [Fact]
    public void TestProcessProfessionalTone()
    {
        var session = new GenerationSession("professional");
        var result = session.ProcessText("Hello");
        Assert.Equal("💼 Hello", result);
    }

    [Fact]
    public void TestProcessEmpatheticTone()
    {
        var session = new GenerationSession("empathetic");
        var result = session.ProcessText("Hello");
        Assert.Equal("❤️ Hello", result);
    }

    [Fact]
    public void TestProcessMaxLengthText()
    {
        var session = new GenerationSession("friendly");
        string longText = new string('A', 100);
        var result = session.ProcessText(longText);
        Assert.Equal($"😊 {longText}", result);
    }

    [Fact]
    public void TestProcessTooLongText()
    {
        var session = new GenerationSession("friendly");
        string tooLongText = new string('A', 101);
        Assert.Throws<ArgumentException>(new Action(() => session.ProcessText(tooLongText)));
    }

    [Fact]
    public void TestProcessInvalidType()
    {
        var session = new GenerationSession("friendly");
        Assert.Throws<ArgumentNullException>(new Action(() => session.ProcessText(null)));
    }
}