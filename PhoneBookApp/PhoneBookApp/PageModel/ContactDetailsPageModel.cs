using FluentValidation;
using PhoneBookApp.Helpers;
using PhoneBookApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PhoneBookApp.PageModel
{
    public class ContactDetailsPageModel : BaseContactPageModel
    {
        public ICommand UpdatePageCommand { get; set; }
        public ICommand DeleteContactCommand { get; private set; }
        public ICommand GoToDialer { get; private set; }
        public ICommand GoToSMS { get; private set; }

        public ContactDetailsPageModel(IValidator validator,IPhoneBookRepository phoneBookRepository) : base(validator, phoneBookRepository)
        {
            _person = new Person();

            UpdatePageCommand = new Command(async () => await ShowContactDetails(_person.Id));
            DeleteContactCommand = new Command(async () => await DeleteContact());
            GoToDialer = new Command( () =>  PlaceCall(_person.PhoneNumber));
            GoToSMS = new Command(async () => await SendSMS("Hello World",_person.PhoneNumber));
        }

        private async Task SendSMS(string messageText,string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, recipient);
                await Sms.ComposeAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PlaceCall(string number)
        {
            try
            {
                 PhoneDialer.Open(number);
            }
            catch(Exception ex)
            {
                CoreMethods.DisplayAlert("Unable to make call", "Pleas enter a number", "Ok");
            }
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            _person.Id = (int)initData;
            FetchDetail();
        }

        private void FetchDetail()
        {
            _person =_phoneBookRepository.GetPerson(_person.Id);
            
        }

        async Task DeleteContact()
        {
            bool isUserAccept = await CoreMethods.DisplayAlert("Contact Details", "Delete Contact Details", "OK", "Cancel");
            if (isUserAccept)
            {
                _phoneBookRepository.DeletePerson(_person.Id);
                await CoreMethods.PopPageModel();
            }
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
         async Task ShowContactDetails(int selectedContactID)
        {
            await CoreMethods.PushPageModel<UpdateContactPageModel>(selectedContactID);
        }
    }
}
