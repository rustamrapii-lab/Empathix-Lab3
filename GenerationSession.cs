using System;
using System.Collections.Generic;
namespace EmpathixProject;
public class GenerationSession
{
    private static readonly List<string> ValidTones = new List<string> { "friendly", "professional", "empathetic" };
    public string Tone { get; private set; }

    public GenerationSession(string tone)
    {
        if (!ValidTones.Contains(tone))
        {
            throw new ArgumentException($"Недопустимий тон: '{tone}'.");
        }
        Tone = tone;
    }

    public string ProcessText(string text)
    {
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text), "Вхідні дані повинні бути рядком!");
        }

        string strippedText = text.Trim();
        if (strippedText.Length == 0)
        {
            throw new ArgumentException("Текст не може бути порожнім!");
        }
        if (strippedText.Length > 100)
        {
            throw new ArgumentException("Текст занадто довгий! Максимум 100 символів.");
        }

        if (Tone == "friendly")
        {
            return $"😊 {strippedText}";
        }
        else if (Tone == "professional")
        {
            return $"💼 {strippedText}";
        }
        else
        {
            return $"❤️ {strippedText}";
        }
    }
}