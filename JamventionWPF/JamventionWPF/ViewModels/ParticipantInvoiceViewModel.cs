using JamventionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionWPF.ViewModels
{
    class ParticipantInvoiceViewModel : BasisViewModel
    {
        private Guest _guest;
        private Residence _residence;
        public ParticipantInvoiceViewModel(Guest guest, Residence residence)
        {
            _guest = guest;
            _residence = residence;
        }
        public override string this[string columnName] {
            get
            {
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            return;
        }
    }
}
