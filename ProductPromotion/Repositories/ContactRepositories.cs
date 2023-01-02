﻿using ProductPromotion.Entities;
using System.Threading.Tasks;
using System;
using ProductPromotion.Data;
using ProductPromotion.Repositories.Interfaces;

namespace ProductPromotion.Repositories
{
    public class ContactRepository : IContactRepository
    {
        protected readonly Context _dbContext;

        public ContactRepository(Context dbContext)
        {
            _dbContext = dbContext ;
        }

        public async Task<Contact> SendMessage(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> Subscribe(string address)
        {
            // implement your business logic
            var newContact = new Contact();
            newContact.Email = address;
            newContact.Message = address;
            newContact.Name = address;

            _dbContext.Contacts.Add(newContact);
            await _dbContext.SaveChangesAsync();

            return newContact;
        }
    }
}
