using System;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;

namespace CashmereServer.GraphQL.Schemas
{
    public partial class Mutation
    {
        private readonly CashmereRepository _repository;

        public Mutation(CashmereRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }
    }
}