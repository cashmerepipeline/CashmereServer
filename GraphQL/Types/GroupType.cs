using HotChocolate.Types;
using CashmereServer.Database.Models;

namespace CashmereServer.GraphQL.Types
{
    public class GroupType
        : ObjectType<Group>
    {
        protected override void Configure(IObjectTypeDescriptor<Group> descriptor)
        {
            descriptor.Name("Group");

            descriptor.Interface<BaseEntityType<Group>>();

            descriptor.Field(t => t.Id).Type<NonNullType<UuidType>>();
            // descriptor.Field(t => t.Uuid).Type<StringType>(); 
            descriptor.Field(t=>t.CreatorId).Type<UuidType>();
            descriptor.Field(t => t.CreationTime).Type<DateTimeType>();
            descriptor.Field(t=>t.ModifierId).Type<UuidType>();
            descriptor.Field(t => t.ModifiedTime).Type<DateTimeType>();

            descriptor.Field(t => t.Name).Type<StringType>();
            
        }
    }
}