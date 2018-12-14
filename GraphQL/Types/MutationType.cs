
using HotChocolate.Types;
using CashmereServer.GraphQL.Schemas;

namespace CashmereServer.GraphQL.Types
{
    public class MutationType
    : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(t=>t.NewAccount(default, default, default, default))
                .Type<NonNullType<AccountType>>()
                .Argument("name", a=>a.Type<StringType>())
                .Argument("phoneNumber", a=>a.Type<StringType>())
                .Argument("email", a=>a.Type<StringType>())
                .Argument("password", a=>a.Type<StringType>());

            descriptor.Field(t=>t.UpdateAccount(default, default))
                .Type<NonNullType<AccountType>>()
                .Argument("id", a=>a.Type<UuidType>())
                .Argument("properties", a=>a.Type<T>());

            descriptor.Field(t => t.NewUser(default))
                .Type<NonNullType<UserType>>()
                .Argument("name", a => a.Type<StringType>());

            descriptor.Field(t => t.UpdateUser(default, default))
                .Type<NonNullType<UserType>>()
                .Argument("name", a => a.Type<StringType>());
        }
    }
}