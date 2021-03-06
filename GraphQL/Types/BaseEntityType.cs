using CashmereServer.Database.Models;
using HotChocolate.Types;

namespace CashmereServer.GraphQL.Types
{
    public class BaseEntityType<TEntity>:InterfaceType
    {
        protected override void Configure(IInterfaceTypeDescriptor descriptor)
        {
            descriptor.Name("BaseEntityType");
            

            descriptor.Field("id").Type<NonNullType<UuidType>>();

            // descriptor.Field("uuid").Type<StringType>();

            // descriptor.Field("creator").Type<AccountType>();

            descriptor.Field("creationTime").Type<DateTimeType>();

            // descriptor.Field("modifier").Type<AccountType>();

            descriptor.Field("modifiedTime").Type<DateTimeType>();

            // descriptor.Field("extendData").Type<StringType>();
        }
    }
}