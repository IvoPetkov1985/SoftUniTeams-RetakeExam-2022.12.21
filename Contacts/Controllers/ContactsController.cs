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

            await service.CreateNewContactEntityAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool isExisting = await service.IsContactExisting(id);

            if (isExisting == false)
            {
                return BadRequest();
            }

            bool isAuthorized = service.CheckDeleteOrEditByIdAsync(id);

            if (isAuthorized == false)
            {
                return Unauthorized();
            }

            ContactFormModel model = await service.CreateEditContactModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ContactFormModel model)
        {
            bool isExisting = await service.IsContactExisting(id);

            if (isExisting == false)
            {
                return BadRequest();
            }

            bool isAuthorized = service.CheckDeleteOrEditByIdAsync(id);

            if (isAuthorized == false)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await service.EditExistingContactAsync(id, model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {
            string userId = GetUserId();

            IEnumerable<ContactViewModel> model = await service.GetTeamContactsAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int id)
        {
            bool isExisting = await service.IsContactExisting(id);

            if (isExisting == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await service.AddContactToTeamAsync(userId, id);

            return RedirectToAction(nameof(Team));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int id)
        {
            bool isExisting = await service.IsContactExisting(id);

            if (isExisting == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await service.RemoveContactFromTeamAsync(userId, id);

            return RedirectToAction(nameof(Team));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            bool isExisting = await service.IsContactExisting(id);

            if (isExisting == false)
            {
                return BadRequest();
            }

            bool isAuthorized = service.CheckDeleteOrEditByIdAsync(id);

            if (isAuthorized == false)
            {
                return Unauthorized();
            }

            await service.DeleteContactAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
