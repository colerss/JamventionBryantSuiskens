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
            Invoice = invoice;
            Payment = new Payment();
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
                NotifyPropertyChanged();
            }
        }

        public decimal Subtotal()
        {
            decimal subtotal = 0;
            foreach (Payment payment in Invoice.Payments)
            {
                subtotal += payment.Amount;
            }
            return (Invoice.TicketType.TicketPrice - subtotal);
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
                case "AddPayment":
                    if (Subtotal() - Payment.Amount > -0.01m)
                    {

                    
                    Payment.InvoiceID = Invoice.InvoiceID;
                    Payment.PaymentDate = DateTime.Today;
                    unitOfWork.RepoPayment.Add(Payment);
                    if (unitOfWork.Save() != 0)
                    {
                        Messenger.Default.Send("Betaling toegevoegd");
                    }
                    else
                    {
                        Messenger.Default.Send("Er is iets foutgegaan");
                    }
                    }
                    else
                    {
                        Messenger.Default.Send("Betaling is meer dan het uitstaande bedrag");
                    }
                    break;
            }
        }
    }
}
