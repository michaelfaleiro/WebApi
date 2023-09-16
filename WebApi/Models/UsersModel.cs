﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class UsersModel
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }
        
    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Roles { get; set; }
}
