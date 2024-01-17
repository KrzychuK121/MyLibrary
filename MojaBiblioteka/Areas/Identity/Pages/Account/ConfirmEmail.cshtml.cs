// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using MojaBiblioteka.Models.Entities.Persons;

namespace MojaBiblioteka.Areas.Identity.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public ConfirmEmailModel(
            UserManager<User> userManager,
            IConfiguration configuration
        )
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            
            if (!result.Succeeded)
                return Page();

            IDictionary<string, string> rolesEmails = new Dictionary<string, string>();
            rolesEmails["Admin"] = _configuration["AdminEmail"] ?? string.Empty;
            rolesEmails["Employee"] = _configuration["EmployeeEmail"] ?? string.Empty;

            bool notMatchingAny = true;

            foreach(var (role, email) in rolesEmails)
            {
                if (string.Compare(user.Email, email, true) == 0)
                {   
                    notMatchingAny = false;
                    await _userManager.AddToRoleAsync(user, role);
                }
            }

            if (notMatchingAny)
                await _userManager.AddToRoleAsync(user, "Client");

            return Page();
        }
    }
}
