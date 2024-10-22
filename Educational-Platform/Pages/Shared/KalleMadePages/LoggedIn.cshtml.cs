using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class LoggedInModel : PageModel
{
    public bool ShowQuiz { get; set; }
    public bool ShowResults { get; set; }
    public int CorrectAnswers { get; set; }
    public int TotalQuestions => _correctAnswers.Length;
    public string Feedback { get; set; }

    private readonly string[] _correctAnswers = new[]
    {
        "Virtuell Privat Nätverk", 
        "Använda långa, komplexa lösenord", 
        "En form av dataintrång där angripare använder bedrägliga e-postmeddelanden", 
        "För att kunna återställa data efter ett intrång", 
        "Att använda flera metoder för att verifiera en användares identitet", 
        "En hårdvara eller programvara som övervakar och kontrollerar nätverkstrafik", 
        "Skadlig programvara som kan skada datorer eller nätverk", 
        "Ett e-postmeddelande som ber dig att bekräfta din kontoinformation", 
        "X$4Gf@7hP!2a", 
        "Att manipulera människor att avslöja konfidentiell information"
    };

    public void OnGet()
    {
        ShowQuiz = false;
        ShowResults = false;
    }

    public IActionResult OnPostStartQuiz()
    {
        ShowQuiz = true;
        ShowResults = false;
        return Page();
    }

    public IActionResult OnPostSubmitQuiz(string[] answers)
    {
        CorrectAnswers = 0;
        ShowQuiz = false;
        ShowResults = true;

        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i] == _correctAnswers[i])
            {
                CorrectAnswers++;
            }
        }

        Feedback = $"Du svarade korrekt på {CorrectAnswers} av {TotalQuestions} frågor.";
        if (CorrectAnswers == TotalQuestions)
        {
            Feedback += " Utmärkt arbete!";
        }
        else if (CorrectAnswers >= TotalQuestions / 2)
        {
            Feedback += " Bra jobbat, men det finns utrymme för förbättring.";
        }
        else
        {
            Feedback += " Försök igen för att förbättra dina kunskaper.";
        }

        return Page();
    }

    public IActionResult OnPostRestartQuiz()
    {
        ShowQuiz = false;
        ShowResults = false;
        CorrectAnswers = 0;
        Feedback = string.Empty;
        return Page();
    }
}