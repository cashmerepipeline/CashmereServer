using HotChocolate.Types;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Resolvers;

namespace CashmereServer.GraphQL.Types
{
    public class TeamType
        : ObjectType<Team>
    {
        protected override void Configure(IObjectTypeDescriptor<Team> descriptor)
        {
            descriptor.Name("Team");

            descriptor.Interface<BaseEntityType<Team>>();

            descriptor.Field(t => t.Id).Type<NonNullType<UuidType>>();

            descriptor.Field(t => t.Creator).Ignore();
            descriptor.Field<BaseResolver<Account>>(t => t.GetCreator(default, default));
            descriptor.Field(t => t.CreationTime).Type<DateTimeType>();

            descriptor.Field(t => t.Modifier).Ignore();
            descriptor.Field<BaseResolver<Account>>(t => t.GetModifier(default, default));
            descriptor.Field(t => t.ModifiedTime).Type<DateTimeType>();

            descriptor.Field(t => t.Name).Type<StringType>();
        }
    }
}