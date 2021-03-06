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

            descriptor.Field(t => t.GetAccount(default, default))
                .Type<AccountType>()
                .Argument("id", a => a.DefaultValue(0));
            
            descriptor.Field(t => t.GetAccount(default))
                .Type<GroupType>()
                .Argument("id", a => a.DefaultValue(0));

            descriptor.Field(t => t.GetAccount(default))
                .Type<TeamType>()
                .Argument("id", a => a.DefaultValue(0));
            
        }
    }
}