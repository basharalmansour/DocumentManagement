using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Definitions;
public class UserDetails : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Phone { get; set; }
    public EmailAddressAttribute EmailAddress { get; set; }
    public bool IsPrimary { get; set; }
}
