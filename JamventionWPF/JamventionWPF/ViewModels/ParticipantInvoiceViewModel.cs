using JamventionDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionWPF.ViewModels
{
    class ParticipantInvoiceViewModel : BasisViewModel
    {
        private Guest _guest;
        private Residence _residence;
        private Invoice _invoiceCreate;
        private bool _weekendTicket;
        private ObservableCollection<TicketType> _ticketTypes;
        public ParticipantInvoiceViewModel(Guest guest, Residence residence)
        {
            Guest = guest;
            _residence = residence;
            InvoiceCreate = new Invoice
            {
                InvoiceID = unitOfWork.RepoInvoice.GetMaxPK(x => x.InvoiceID) + 1
            };
        }

        public override void LoadComboboxes()
        {
            IEnumerable<TicketType> ticketTypes = unitOfWork.RepoTicketType.Retrieve();

            base.LoadComboboxes();
        }

        #region Properties
        public ObservableCollection<TicketType> TicketTypes
        {
            get
            {
                return _ticketTypes;
            }
            set
            {
                _ticketTypes = value;
                NotifyPropertyChanged();
            }
        }
        public Guest Guest
        {
            get
            {
                return _guest;
            }
            set
            {
                _guest = value;
                NotifyPropertyChanged();
            }
        }
        public Invoice InvoiceCreate
        {
            get
            {
                return _invoiceCreate;
            }
            set
            {
                _invoiceCreate = value;
                WeekendTicket = (_invoiceCreate.TicketType.OnSaturday == true && _invoiceCreate.TicketType.OnFriday == true && _invoiceCreate.TicketType.OnSunday == true);
                NotifyPropertyChanged();
            }
        }
        public bool WeekendTicket
        {
            get
            {
                return _weekendTicket;
            }
            set
            {
                _weekendTicket = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
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
