using HotChocolate.Types;
using CashmereServer.Database.Models;

namespace CashmereServer.GraphQL.Types
{
    public class UserType
        : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Name("User");

            descriptor.Interface<BaseEntityType<User>>();

            descriptor.Field(t => t.Id).Type<NonNullType<IdType>>();
            descriptor.Field(t => t.Uuid).Type<StringType>(); 
            descriptor.Field(t=>t.CreatorId).Type<IntType>();
            descriptor.Field(t => t.CreationTime).Type<DateTimeType>();
            descriptor.Field(t=>t.ModifierId).Type<IntType>();
            descriptor.Field(t => t.ModifiedTime).Type<DateTimeType>();

            descriptor.Field(t => t.Name).Type<StringType>();
            descriptor.Field(t => t.FamilyName).Type<StringType>();
            descriptor.Field(t => t.GivenName).Type<StringType>();

            descriptor.Field(t => t.BirthDate).Type<IntType>();

            descriptor.Field(t => t.Sex).Type<IntType>();
        }
    }
}