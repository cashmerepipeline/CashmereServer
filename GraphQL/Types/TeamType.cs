using HotChocolate.Types;
using CashmereServer.Database.Models;

namespace CashmereServer.GraphQL.Types
{
    public class TeamType
        : ObjectType<Team>
    {
        protected override void Configure(IObjectTypeDescriptor<Team> descriptor)
        {
            descriptor.Name("Team");

            descriptor.Interface<BaseEntityType<Team>>();

            descriptor.Field(t => t.Id).Type<NonNullType<IdType>>();
            descriptor.Field(t => t.Uuid).Type<StringType>(); 
           descriptor.Field(t=>t.CreatorId).Type<IntType>();
            descriptor.Field(t => t.CreationTime).Type<DateTimeType>();
            descriptor.Field(t=>t.ModifierId).Type<IntType>();
            descriptor.Field(t => t.ModifiedTime).Type<DateTimeType>();

            descriptor.Field(t => t.Name).Type<StringType>();
        }
    }
}