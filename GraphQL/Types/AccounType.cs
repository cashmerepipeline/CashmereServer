using HotChocolate.Types;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.DataLoaders;
using CashmereServer.GraphQL.Resolvers;

namespace CashmereServer.GraphQL.Types
{
    public class AccountType
        : ObjectType<Account>
    {
        protected override void Configure(IObjectTypeDescriptor<Account> descriptor)
        {
            descriptor.Name("Account");

            descriptor.Interface<BaseEntityType<Account>>();

            descriptor.Field(t=>t.AccountGroupIds).Ignore();
            descriptor.Field(t=>t.AccountGroups).Ignore();
            descriptor.Field(t=>t.AccountTeamIds).Ignore();
            descriptor.Field(t=>t.AccountTeams).Ignore();
            // descriptor.Field(t=>t.UserId).Ignore();
            descriptor.Field(t=>t.CreatorId).Ignore();
            descriptor.Field(t=>t.ModifierId).Ignore();

            // descriptor.Field(t=>t.Role).Ignore();

            descriptor.Field(t => t.Id).Type<NonNullType<UuidType>>();

            descriptor.Field(t=>t.Creator).Ignore();
            descriptor.Field<BaseResolver<Account>>(t=>t.GetCreator(default, default));
            descriptor.Field(t => t.CreationTime).Type<DateTimeType>();

            descriptor.Field(t=>t.Modifier).Ignore();
            descriptor.Field<BaseResolver<Account>>(t=>t.GetModifier(default, default));
            descriptor.Field(t => t.ModifiedTime).Type<DateTimeType>();

            descriptor.Field(t => t.Name).Type<StringType>();
            descriptor.Field(t => t.Password).Type<StringType>();

            descriptor.Field(t => t.PhoneNumber).Type<StringType>();
            descriptor.Field(t => t.Email).Type<StringType>();

            // descriptor.Field(t => t.User);
            descriptor.Field<AccountResolver>(t=>t.GetUser(default, default));
                   
            
        }
    }
}