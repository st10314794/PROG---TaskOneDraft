﻿using Microsoft.AspNetCore.Identity;

namespace TaskOneDraft.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    // user profile -- additional features
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

