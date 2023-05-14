using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Enums;
public enum DeletionSource
{
    DeletedByUser,
    DeletedByEdit, // it is used when we update a record so we delete the old one and create a new one
    DeletedBySystemAdmin
}
