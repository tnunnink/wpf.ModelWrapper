﻿using System;
using System.ComponentModel.DataAnnotations;
using EntityObserver;
using EntityObserver.Tests.TestEntities;

namespace EntityObserver.Tests.TestObservers
{
    public class AddressObserver : Observer<Address>
    {
        public AddressObserver(Address entity) : base(entity)
        {
        }

        //overriding validation example
        [Required(ErrorMessage = "Id is required")]
        public Guid Id
        {
            get => GetValue<Guid>();
            set => SetValue(value, validationOption: ValidationOption.All);
        }

        [Required(ErrorMessage = "Street is required")]
        public string Street
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        //Custom getter setter example
        [Required(ErrorMessage = "City is required")]
        public string City
        {
            get => GetValue<string>();
            set => SetValue(value, getter: a => a.City, setter: (a, s) => a.City = s);
        }

        [Required(ErrorMessage = "State is required")]
        [StringLength(2)]
        public string State
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        [Required(ErrorMessage = "Zip is required")]
        [Range(100000, 999999)]
        public int Zip
        {
            get => GetValue<int>();
            set => SetValue(value);
        }
    }
}