using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Dtos.CondoLife;

public class CondoLocalizedStringDto
{
    //public int LocalizableStringId { get; set; }
    public int languageId { get; set; }
    // MAX
    public string value { get; set; }
}
