using CashmereServer.Database.Models;
using HotChocolate.Types;

namespace CashmereServer.GraphQL.Types
{
    public class BaseEntityType<TEntity>:InterfaceType
    {
        protected override void Configure(IInterfaceTypeDescriptor descriptor)
        {
            descriptor.Name("BaseEntityType");

            descriptor.Field("id").Type<NonNullType<IdType>>();

            descriptor.Field("uuid").Type<StringType>();

            descriptor.Field("creatorId").Type<IntType>();

            descriptor.Field("creationTime").Type<DateTimeType>();

            descriptor.Field("modifierId").Type<IntType>();

            descriptor.Field("modifiedTime").Type<DateTimeType>();

            // descriptor.Field("extendData").Type<StringType>();
        }
    }
}