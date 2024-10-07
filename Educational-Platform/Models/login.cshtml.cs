using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Email { get; set; }
    
    [BindProperty]
    public string Password { get; set; }

    public IActionResult OnPost()
    {
        // Här kan du lägga till logik för autentisering
        if (Email == "test@example.com" && Password == "password")
        {
            // Exempel på enkel inloggningslogik
            return RedirectToPage("/Index");
        }

        ModelState.AddModelError("", "Invalid login attempt.");
        return Page();
    }
}
