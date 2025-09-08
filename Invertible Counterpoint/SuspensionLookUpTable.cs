using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invertible_Counterpoint
{
    internal class SuspensionLookUpTable
    {
        private readonly Dictionary<SuspensionTreatmentEnum, string> _suspensionLookUpTable =
            new Dictionary<SuspensionTreatmentEnum, string>()
            {
                { SuspensionTreatmentEnum.CannotFormSuspension, "(-)" },
                { SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension, "-" },
                { SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, "x" },
                { SuspensionTreatmentEnum.NoteOfResolutionIsFree, "---" },
                { SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant, "-x" }
            };

        public string this[SuspensionTreatmentEnum key] => _suspensionLookUpTable[key];
    }
}

