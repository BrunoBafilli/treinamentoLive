﻿using Domain.ArchPatterns.Repositories;
using Domain.Entities.Client;
using Domain.Validations;
using Infrastructure.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.ArchPatterns.Repositories
{
    public sealed class ClientRepository : IClientRepository
    {
        private readonly DataContext _datacontext;

        public ClientRepository(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task Create(Client client)
        {
            var findedUser = await _datacontext.Clients.FirstOrDefaultAsync(c => c.Email == client.Email);

            ValidationDefaultException.IsNotNullOrEmpty(findedUser, nameof(findedUser));

            _datacontext.Add(client);

            //await _datacontext.SaveChangesAsync();
        }

        public async Task<List<Client>> ReadAll()
        {
            var findedClients = _datacontext.Clients.ToList();

            ValidationDefaultException.IsNullOrEmpty(findedClients, nameof(findedClients));

            return findedClients;
        }

        public async Task<Client> ReadById(int clientId)
        {
            var findedClient = await _datacontext.Clients.FindAsync(clientId);

            ValidationDefaultException.IsNullOrEmpty(findedClient, nameof(findedClient));

            return findedClient;
        }

        public async Task Update(Client client)
        {
            var findedClient = await _datacontext.Clients.FindAsync(client.Id);

            ValidationDefaultException.IsNullOrEmpty(findedClient, nameof(findedClient));

            _datacontext.Entry(findedClient).CurrentValues.SetValues(client);

            //await _datacontext.SaveChangesAsync();
        }

        public async Task Delete(int clientId)
        {
            var findedClient = await _datacontext.Clients.FindAsync(clientId);

            ValidationDefaultException.IsNullOrEmpty(findedClient, nameof(findedClient));

            _datacontext.Clients.Remove(findedClient);

            //await _datacontext.SaveChangesAsync();
        }
    }
}