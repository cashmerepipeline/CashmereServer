using HotChocolate.Types;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Resolvers;
using CashmereServer.GraphQL.DataLoaders;

namespace CashmereServer.GraphQL.Types
{
    public class UserType
        : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Name("User");

            descriptor.Interface<BaseEntityType<User>>();

            descriptor.Field(t => t.AccountId).Ignore();
            descriptor.Field(t => t.CreatorId).Ignore();
            descriptor.Field(t => t.ModifierId).Ignore();

            descriptor.Field(t => t.Id).Type<NonNullType<UuidType>>();

            descriptor.Field(t => t.Creator).Ignore();
            descriptor.Field<BaseResolver<User>>(t => t.GetCreator(default, default));
            descriptor.Field(t => t.CreationTime).Type<DateTimeType>();


            descriptor.Field(t => t.Modifier).Ignore();
            descriptor.Field<BaseResolver<User>>(t => t.GetModifier(default, default));
            descriptor.Field(t => t.ModifiedTime).Type<DateTimeType>();

            descriptor.Field(t => t.Name).Type<StringType>();
            descriptor.Field(t => t.FamilyName).Type<StringType>();
            descriptor.Field(t => t.GivenName).Type<StringType>();

            descriptor.Field(t => t.BirthDate).Type<IntType>();

            descriptor.Field(t => t.Sex).Type<IntType>();
        }
    }
}