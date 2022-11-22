using FluentValidation;
using FreshMvvm;
using PhoneBookApp.Helpers;
using PhoneBookApp.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace PhoneBookApp.PageModel
{
    public class BaseContactPageModel : FreshBasePageModel
    {
        public Person _person;
        public IValidator _validator;
        public IPhoneBookRepository _phoneBookRepository;
        public List<Person> _Personlist;

        public BaseContactPageModel(IValidator validator, IPhoneBookRepository phoneBookRepository)
        {
            _validator = validator;
            _phoneBookRepository = phoneBookRepository;
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
