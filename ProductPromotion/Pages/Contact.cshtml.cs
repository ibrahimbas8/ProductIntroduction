using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductPromotion.Entities;
using System.Threading.Tasks;
using System;
using ProductPromotion.Repositories;

namespace ProductPromotion.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IContactRepository _contactRepository;

        public ContactModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [BindProperty]
        public Contact Contact { get; set; }
        public string Message { get; private set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _contactRepository.SendMessage(Contact);
            return RedirectToPage("Confirmation", "Contact");
        }

        public async Task<IActionResult> OnPostSubscribeAsync(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return Page();
            }

            await _contactRepository.Subscribe(address);
            return RedirectToPage("Confirmation", "Subscribe");
        }
    }
}
