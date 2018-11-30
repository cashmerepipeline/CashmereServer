using HotChocolate.Types;
using CashmereServer.GraphQL.Schemas;

namespace CashmereServer.GraphQL.Types
{
    public class QueryType
     :ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetUser(default))
                .Type<UserType>()
                .Argument("id", a => a.DefaultValue(2));
        }
    }
}