using Contacts.Contracts;
using Contacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class ContactsController : BaseController
    {
        private readonly IContactService service;

        public ContactsController(IContactService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<ContactViewModel> model = await service.GetAllContactsAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ContactFormModel model = new();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await service.CreateContactAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await service.IsContactExistingAsync(id) == false)
            {
                return NotFound();
            }

            if (service.IsEditPermitted(id) == false)
            {
                return Unauthorized();
            }

            ContactFormModel model = await service.CreateEditModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactFormModel model, int id)
        {
            if (await service.IsContactExistingAsync(id) == false)
            {
                return NotFound();
            }

            if (service.IsEditPermitted(id) == false)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await service.EditContactAsync(model, id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {
            string userId = GetUserId();

            IEnumerable<ContactViewModel> model = await service.GetAllTeamContactsAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int id)
        {
            if (await service.IsContactExistingAsync(id) == false)
            {
                return NotFound();
            }

            string userId = GetUserId();

            await service.AddContactToTeamAsync(userId, id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int id)
        {
            if (await service.IsContactExistingAsync(id) == false)
            {
                return NotFound();
            }

            string userId = GetUserId();

            await service.RemoveContactFromTeamAsync(userId, id);

            return RedirectToAction(nameof(Team));
        }
    }
}
