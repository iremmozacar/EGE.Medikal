using System;
using EgeApp.Frontend.Mvc.Data.Entities;

namespace EgeApp.Frontend.Mvc.Models.Identity;

public class RoleAssignViewModel
{
    public AppRole Role { get; set; }
    public string RoleId { get; set; }
    public List<AppUser> Members { get; set; }
    public List<AppUser> NonMembers { get; set; }
    public string[] IdsAdd { get; set; }
    public string[] IdsRemove { get; set; }
}
