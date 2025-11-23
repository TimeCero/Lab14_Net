using System;
using System.Collections.Generic;

namespace Lab11.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }  // 🔁 antes era Guid, cámbialo a int

    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Response> Responses { get; set; } = new List<Response>();
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}