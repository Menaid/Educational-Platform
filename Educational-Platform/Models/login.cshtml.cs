using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    private readonly string correctEmail = "user@gmail.com";
    private readonly string correctPassword = "12345";

    [BindProperty]
    public string Email { get; set; }
    
    [BindProperty]
    public string Password { get; set; }

    public IActionResult OnPost()
    {
        if (Email == correctEmail && Password == correctPassword)
        {
            // Använd kortare sökväg efter att ha flyttat LoggedIn-sidan
            return RedirectToPage("/Shared/KalleMadePages/LoggedIn");
        }

        ModelState.AddModelError("", "Felaktigt användarnamn eller lösenord.");
        return Page();
    }
}
