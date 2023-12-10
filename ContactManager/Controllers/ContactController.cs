using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContactManager.Data;
using ContactManager.Models;
using ContactManager.ViewModel;

using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ContactListViewModel> contactListViewModelList = new List<ContactListViewModel>();
            var contactList = _context.Contacts;
            if (contactList != null)
            {
                foreach (var item in contactList)
                {
                    ContactListViewModel contactListViewModel = new ContactListViewModel();
                    {
                        contactListViewModel.Id = item.Id;
                        contactListViewModel.FirstName = item.FirstName;
                        contactListViewModel.LastName = item.LastName;
                        contactListViewModel.Email = item.Email;
                        contactListViewModel.PhoneNumber = item.PhoneNumber;
                        contactListViewModel.CategoryId = item.CategoryId;
                        contactListViewModel.CategoryName = _context.Categories.Where(c => c.CategoryId == item.CategoryId).Select(c => c.CategoryName).FirstOrDefault();
                        
                        contactListViewModelList.Add(contactListViewModel);
                    };
                }
            }
            return View(contactListViewModelList);
        }

        public IActionResult Create()
        {
            ContactViewModel contactCreateViewModel = new ContactViewModel();
              contactCreateViewModel.Category = (IEnumerable<SelectListItem>)_context.Categories.Select(c => new SelectListItem()
              {
                  Text = c.CategoryName,
                  Value = c.CategoryId.ToString()
              });

         
            return View(contactCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactViewModel contactCreateViewModel)
        {
            contactCreateViewModel.Category = (IEnumerable<SelectListItem>)_context.Categories.Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            });

           
                var contact = new Contact
                {
                    FirstName = contactCreateViewModel.FirstName,
                    LastName = contactCreateViewModel.LastName,
                    Email = contactCreateViewModel.Email,
                    PhoneNumber = contactCreateViewModel.PhoneNumber,
                    CategoryId = contactCreateViewModel.CategoryId
                };

            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                TempData["SuccessMsg"] = "Contact (" + contact.FirstName + " " + contact.LastName + ") added successfully.";
                return RedirectToAction("Index");
            }
         
            return View(contactCreateViewModel);
        }


        public IActionResult Edit(int? id)
        {
            var contactToEdit = _context.Contacts.Find(id);
            if (contactToEdit != null)
            {
                var contactViewModel = new ContactViewModel
                {
                    Id = contactToEdit.Id,
                    FirstName = contactToEdit.FirstName,
                    LastName = contactToEdit.LastName,
                    Email = contactToEdit.Email,
                    PhoneNumber = contactToEdit.PhoneNumber,
                    CategoryId = contactToEdit.CategoryId,
                    Category = (IEnumerable<SelectListItem>)_context.Categories.Select(c => new SelectListItem()
                    {
                        Text = c.CategoryName,
                        Value = c.CategoryId.ToString()
                    })
                };

                return View(contactViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContactViewModel contactViewModel)
        {
            contactViewModel.Category = (IEnumerable<SelectListItem>)_context.Categories.Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            });


            var contact = new Contact()

                {
                    Id = contactViewModel.Id,
                    FirstName = contactViewModel.FirstName,
                   LastName = contactViewModel.LastName,
                   Email = contactViewModel.Email,
                   PhoneNumber = contactViewModel.PhoneNumber,
                   CategoryId = contactViewModel.CategoryId
                };
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                _context.Contacts.Update(contact);
                _context.SaveChanges();
                TempData["SuccessMsg"] = "Contact (" + contact.FirstName + " " + contact.LastName + ") updated successfully!";
                return RedirectToAction("Index");
            }
              
            

            return View(contactViewModel);
        }
        public IActionResult Details(int id)
        {
            var contact = _context.Contacts
                .FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            var contactViewModel = new ContactViewModel
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                CategoryId = contact.CategoryId,
                Category = _context.Categories.Select(c => new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                })
            };

            return View(contactViewModel);
        }


        public IActionResult Delete(int? id)
        {
            var contactToDelete = _context.Contacts.Find(id);
            if (contactToDelete != null)
            {
                var contactViewModel = new ContactViewModel
                {
                    Id = contactToDelete.Id,
                    FirstName = contactToDelete.FirstName,
                    LastName = contactToDelete.LastName,
                    Email = contactToDelete.Email,
                    PhoneNumber = contactToDelete.PhoneNumber,
                    CategoryId = contactToDelete.CategoryId,
                    Category = (IEnumerable<SelectListItem>)_context.Categories.Select(c => new SelectListItem()
                    {
                        Text = c.CategoryName,
                        Value = c.CategoryId.ToString()
                    })
                };

                return View(contactViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteContact(int? id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

                _context.Contacts.Remove(contact);
                _context.SaveChanges();
                TempData["SuccessMsg"] = "Contact (" + contact.FirstName + " " + contact.LastName + ") deleted successfully.";
                return RedirectToAction("Index");
            
            
            
        }
    }
}
