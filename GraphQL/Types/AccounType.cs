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

            descriptor.Field(t=>t.AccountGroupIds).Ignore();
            descriptor.Field(t=>t.AccountGroups).Ignore();
            descriptor.Field(t=>t.AccountTeamIds).Ignore();
            descriptor.Field(t=>t.AccountTeams).Ignore();
            descriptor.Field(t=>t.UserId).Ignore();
            descriptor.Field(t=>t.CreatorId).Ignore();
            descriptor.Field(t=>t.ModifierId).Ignore();

            // descriptor.Field(t=>t.Role).Ignore();

            descriptor.Field(t => t.Id).Type<NonNullType<UuidType>>();
            // descriptor.Field(t => t.Uuid).Type<StringType>(); 
            // descriptor.Field(t=>t.Creator).Type<IntType>();
            descriptor.Field(t => t.CreationTime).Type<DateTimeType>();
            // descriptor.Field(t=>t.Modifier).Type<IntType>();
            descriptor.Field(t => t.ModifiedTime).Type<DateTimeType>();

            descriptor.Field(t => t.Name).Type<StringType>();
            descriptor.Field(t => t.Password).Type<StringType>();

            descriptor.Field(t => t.PhoneNumber).Type<StringType>();
            descriptor.Field(t => t.Email).Type<StringType>();

            descriptor.Field(t => t.User).Type<UserType>();
        }
    }
}