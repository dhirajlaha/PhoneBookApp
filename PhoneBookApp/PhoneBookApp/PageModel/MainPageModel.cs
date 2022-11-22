using FluentValidation;
using FreshMvvm;
using PhoneBookApp.Helpers;
using PhoneBookApp.Model;
using PhoneBookApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhoneBookApp.PageModel
{
    public class MainPageModel : BaseContactPageModel
    {
        public ICommand GoToContactPage { get; set; }

        public MainPageModel(IValidator validator, IPhoneBookRepository phoneBookRepository) : base(validator, phoneBookRepository)
        {
            GoToContactPage = new Command(async () => await ShowAddContact());
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            FetchContacts();
        }

        private void FetchContacts()
        {
            PersonList = _phoneBookRepository.GetAllContacts();
        }

        private async Task ShowAddContact()
        {
            await CoreMethods.PushPageModel<AddContactPageModel>();
        }
        async void ShowContactDetails(int selectedContactID)
        {
            await CoreMethods.PushPageModel<ContactDetailsPageModel>(selectedContactID);
        }

        Person _selectedContactItem;
        public Person SelectedContactItem
        {
            get => _selectedContactItem;
            set
            {
                if (value != null)
                {
                    _selectedContactItem = value;
                    RaisePropertyChanged("SelectedContactItem");
                    ShowContactDetails(value.Id);
                }
            }
        }
    }
}
