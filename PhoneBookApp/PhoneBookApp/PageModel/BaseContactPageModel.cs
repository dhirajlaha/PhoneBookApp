using FluentValidation;
using FreshMvvm;
using PhoneBookApp.Helpers;
using PhoneBookApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PhoneBookApp.PageModel
{
    public class BaseContactPageModel : FreshBasePageModel
    {
        public Person _person;
        public IValidator _validator;
        public IPhoneBookRepository _phoneBookRepository;
        public List<Person> _Personlist;
        public ICommand AttachPhoto { get; private set; }

        public BaseContactPageModel(IValidator validator, IPhoneBookRepository phoneBookRepository)
        {
            _validator = validator;
            _phoneBookRepository = phoneBookRepository;
            AttachPhoto = new Command(async () => await PickPhoto());
        }

        

        public string Name
        {
            get => _person.Name;
            set
            {
                _person.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        public string Email
        { get => _person.Email;
            set
            {
                _person.Email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }
        public string PhoneNumber
        {
            get => _person.PhoneNumber;
            set
            {
                _person.PhoneNumber = value;
                RaisePropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Address
        {
            get => _person.Address; 
            set
            {
                _person.Address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }
      
        
        public string PhotoUrl
        {
            get => _person.PhotoUrl;
            set
            {
                _person.PhotoUrl = value;
                RaisePropertyChanged(nameof(PhotoUrl));
            }
        }
        private async Task PickPhoto()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                await LoadPhotoAsync(photo);
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Access Denied", "Sorry you can't access the storage", "Ok");
            }
            
        }

        private async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                PhotoUrl = null;
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            {
                using (var newStream = File.OpenWrite(newFile))
                {
                    await stream.CopyToAsync(newStream);
                }
            }
            PhotoUrl = newFile;
        }
        public List<Person> PersonList
        {
            get => _Personlist;
            set
            {
                _Personlist = value;
                RaisePropertyChanged(nameof(PersonList));
            }
        }
        
    }
}
