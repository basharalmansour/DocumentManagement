using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities.Forms;
public class Form : BaseEntity<int>, ISoftDeletable, IAuditable, IEntity<int>
{
    public string Name { get; set; }
    public List<Question> Questions { get; set; }
}
