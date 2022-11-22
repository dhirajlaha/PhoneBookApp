using FluentValidation;
using PhoneBookApp.Helpers;
using PhoneBookApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhoneBookApp.PageModel
{
    class UpdateContactPageModel : BaseContactPageModel
    {
        public ICommand UpdateContactCommand { get; private set; }
        public UpdateContactPageModel(IValidator validator, IPhoneBookRepository phoneBookRepository) : base(validator, phoneBookRepository)
        {
            _person = new Person();

            UpdateContactCommand = new Command(async () => await UpdateContact());
        }
        public override void Init(object initData)
        {
            _person.Id = (int)initData;

            FetchContactDetails();
        }

        void FetchContactDetails()
        {
            _person = _phoneBookRepository.GetPerson(_person.Id);
        }
        private async Task UpdateContact()
        {
            bool isUserAccept = await CoreMethods.DisplayAlert("Contact Details", "Update Contact Details", "OK", "Cancel");
            if (isUserAccept)
            {
                _phoneBookRepository.UpdateContact(_person);
                await CoreMethods.PopPageModel();
            }
        }
        

        
        
        
    }
}
