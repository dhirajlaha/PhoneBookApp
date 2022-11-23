using FluentValidation;
using FreshMvvm;
using PhoneBookApp.Helpers;
using PhoneBookApp.Model;
using PhoneBookApp.Page;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhoneBookApp.PageModel
{

    public class AddContactPageModel : BaseContactPageModel
    {

        public ICommand SaveContactCommand { get; private set; }
        public ICommand ViewAllContactsCommand { get; private set; }
        public AddContactPageModel(IValidator validator, IPhoneBookRepository phoneBookRepository) : base(validator,phoneBookRepository)
        {
            _person = new Person();

            SaveContactCommand = new Command(async () => await AddContact());
            ViewAllContactsCommand = new Command(async () => await ShowContactList());
        }

        private async Task AddContact()
        {
            
                bool isUserAccept = await CoreMethods.DisplayAlert("Add Contact", "Do you want to save Contact details?", "OK", "Cancel");
                if (isUserAccept)
                {
                    _phoneBookRepository.InsertContact(_person);
                    await App.Current.MainPage.Navigation.PopAsync();
                //     await CoreMethods.PopPageModel(null, true);
            }
             
        }

        private async Task ShowContactList()
        {
            try
            {
                await CoreMethods.PopPageModel(null, true);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }
        public bool IsViewAll => _phoneBookRepository.GetAllContacts().Count > 0 ? true : false;
    }
}
