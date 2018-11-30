using HotChocolate.Types;
using CashmereServer.Database.Models;

namespace CashmereServer.GraphQL.Types
{
    public class UserType
        : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            //descriptor.Interface<IMixCommonType>();

            descriptor.Name("User");

            descriptor.Field(t => t.Id).Type<NonNullType<IdType>>();
            descriptor.Field(t => t.GivenName).Type<StringType>();
            descriptor.Field(t => t.CreationTime).Type<DateTimeType>();
            descriptor.Field(t => t.ModifyTime).Type<DateTimeType>();

            descriptor.Field(t => t.Name).Type<StringType>();
            descriptor.Field(t => t.FamilyName).Type<StringType>();
            descriptor.Field(t => t.GivenName).Type<StringType>();
            descriptor.Field(t => t.Password).Type<StringType>();
            
            descriptor.Field(t => t.PhoneNumber).Type<StringType>();
            descriptor.Field(t => t.Email).Type<StringType>();

            descriptor.Field(t => t.BirthDate).Type<IntType>();
            
            descriptor.Field(t=>t.Sex).Type<IntType>();            
        }
    }
}