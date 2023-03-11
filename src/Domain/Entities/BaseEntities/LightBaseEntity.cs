using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.BaseEntities;
public class LightBaseEntity<T> where T : IEquatable<T>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; }
}