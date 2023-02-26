using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common;
/// <summary>
/// For entity Id's
/// </summary>
/// <typeparam name="T">
/// Your Id type
/// </typeparam>
public interface IEntity<T> where T : IEquatable<T>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; }
}
