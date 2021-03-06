﻿using GalaSoft.MvvmLight.Messaging;
using JamventionDAL;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace JamventionWPF.ViewModels
{
    class ParticipantInvoiceViewModel : BasisParticipantViewModel
    {
        private Guest _guest;
        private Residence _residence;
        private Invoice _invoiceCreate;
        private bool _weekendTicket;
        private ObservableCollection<TicketType> _ticketTypes;
        private ObservableCollection<LocalRoom> _localRooms;

        public ParticipantInvoiceViewModel(Guest guest, Residence residence)
        {
            Guest = guest;
            Guest.GuestID = unitOfWork.RepoGuests.GetMaxPK(x => x.GuestID) + 1;
            _residence = residence;
            IsWeekendTicket = new DelegateCommand<SelectionChangedEventArgs>(IsWeekendTicketCommand);
            InvoiceCreate = new Invoice {
                InvoiceID = unitOfWork.RepoInvoice.GetMaxPK(x => x.InvoiceID) + 1
            };
        }
       
        public override void LoadComboboxes()
        {
            IEnumerable<TicketType> ticketTypes = unitOfWork.RepoTicketType.Retrieve();
            TicketTypes = new ObservableCollection<TicketType>(ticketTypes);
            IEnumerable<LocalRoom> localRooms = unitOfWork.RepoLocalRooms.Retrieve(x => x.Beds > x.RoomOccupancy.Count, x => x.RoomType);
            Rooms = new ObservableCollection<LocalRoom>(localRooms.Where(x => x.RoomTypeID < 6));
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
        public ObservableCollection<LocalRoom> Rooms
        {
            get
            {
                return _localRooms;
            }
            set
            {
                _localRooms = value;
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
                NotifyPropertyChanged();
            }
        }
        public ICommand IsWeekendTicket { get; }
        public void IsWeekendTicketCommand(SelectionChangedEventArgs e)
        {
            TicketType currentTicket = null;
            currentTicket = TicketTypes.Where(x => x.TicketTypeID == InvoiceCreate.TicketTypeID).SingleOrDefault();
            if (currentTicket == null)
            {
                WeekendTicket = false;
            }
            WeekendTicket = (currentTicket.OnFriday == true);
          
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

        #region ICommand
        public override bool CanExecute(object parameter)
        {
            if (parameter.ToString() == "AddGuest")
            {
                return InvoiceCreate.IsGeldig();
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "AddGuest":
                    if (SaveGuest() > 2)
                    {
                        Messenger.Default.Send("Klant Toegevoegd");
                    }
                    else
                    {
                        Messenger.Default.Send("Geen aanpassingen doorgegeven");
                    }

                    break;
            }
        }
        #endregion
        public int SaveGuest()
        {
            if (!WeekendTicket)
            {
                Guest.RoomID = null;
                Guest.Room = null;
            }
            unitOfWork.RepoInvoice.Add(InvoiceCreate);
            Guest.InvoiceID = InvoiceCreate.InvoiceID;
            unitOfWork.RepoGuests.Add(Guest);
            unitOfWork.RepoResidence.Add(_residence);
            return unitOfWork.Save();
        }
    }
}
