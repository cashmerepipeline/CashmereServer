
using HotChocolate.Types;
using CashmereServer.GraphQL.Schemas;

namespace CashmereServer.GraphQL.Types
{
    public class MutationType
    : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(t => t.NewUser(default))
                .Type<NonNullType<UserType>>()
                .Argument("name", a => a.Type<StringType>());

            descriptor.Field(t => t.UpdateUser(default, default))
                .Type<NonNullType<UserType>>()
                .Argument("name", a => a.Type<StringType>());
        }
    }
}