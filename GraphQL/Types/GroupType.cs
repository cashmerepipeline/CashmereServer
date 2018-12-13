using HotChocolate.Types;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Resolvers;

namespace CashmereServer.GraphQL.Types
{
    public class GroupType
        : ObjectType<Group>
    {
        protected override void Configure(IObjectTypeDescriptor<Group> descriptor)
        {
            descriptor.Interface<BaseEntityType<Group>>();

            descriptor.Name("Group");

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