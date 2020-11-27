using GalaSoft.MvvmLight.Messaging;
using JamventionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionWPF.ViewModels
{
    public class PaymentViewModel : BasisViewModel
    {
        private Invoice _invoice;
        private Payment _payment;
        public PaymentViewModel(Invoice invoice)
        {

        }
        public Payment Payment
        {
            get
            {
                return _payment;
            }
            set 
            {
                _payment = value;
                NotifyPropertyChanged();
            }
        }
        public Invoice Invoice
        {
            get
            {
                return _invoice;
            }
            set
            {
                _invoice = value;
            }
        }
        public override string this[string columnName] => throw new NotImplementedException();

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Submit":
                    Invoice.Payments.Add(Payment);
                    unitOfWork.RepoInvoice.Edit(Invoice);
                    Payment.PaymentDate = DateTime.Today;
                    unitOfWork.RepoPayment.Add(Payment);
                    if (unitOfWork.Save() > 1)
                    {
                        Messenger.Default.Send("Betaling toegevoegd");
                    }
                    else
                    {
                        Messenger.Default.Send("Er is iets foutgegaan");
                    }
                    break;
            }
    }
}
