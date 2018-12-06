using HotChocolate.Types;
using CashmereServer.Database.Models;

namespace CashmereServer.GraphQL.Types
{
    public class AccountType
        : ObjectType<Account>
    {
        protected override void Configure(IObjectTypeDescriptor<Account> descriptor)
        {
            descriptor.Name("Account");

            descriptor.Interface<BaseEntityType<Account>>();

            descriptor.Field(t=>t.Group).Ignore();
            descriptor.Field(t=>t.AccountTeamsIds).Ignore();
            descriptor.Field(t=>t.AccountTeams).Ignore();
            descriptor.Field(t=>t.User).Ignore();

            descriptor.Field(t => t.Id).Type<NonNullType<IdType>>();
            descriptor.Field(t => t.Uuid).Type<StringType>(); 
            descriptor.Field(t => t.CreationTime).Type<DateTimeType>();
            descriptor.Field(t => t.ModifiedTime).Type<DateTimeType>();

            descriptor.Field(t => t.Name).Type<StringType>();
            descriptor.Field(t => t.Password).Type<StringType>();

            descriptor.Field(t => t.PhoneNumber).Type<StringType>();
            descriptor.Field(t => t.Email).Type<StringType>();
        }
    }
}