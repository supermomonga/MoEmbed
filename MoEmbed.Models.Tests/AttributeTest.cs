using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

using Xunit;

namespace MoEmbed.Models
{
    public sealed class AttributeTest
    {
        [Theory]
        [InlineData(typeof(EmbedData))]
        [InlineData(typeof(Media))]
        [InlineData(typeof(ImageInfo))]
        public void ShouldSerializeTest(Type type)
        {
            var target = Activator.CreateInstance(type);

            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(target))
            {
                Assert.False(pd.ShouldSerializeValue(target));
            }
        }

        [Theory]
        [InlineData(typeof(EmbedData))]
        [InlineData(typeof(Media))]
        [InlineData(typeof(ImageInfo))]
        public void DataMemberAttributeTest(Type type)
        {
            foreach (var pi in type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var attr = pi.GetCustomAttribute<DataMemberAttribute>();
                Assert.NotNull(attr);
            }
        }

        [Theory]
        [InlineData(typeof(EmbedData))]
        [InlineData(typeof(Media))]
        [InlineData(typeof(ImageInfo))]
        public void JsonPropertyAttributeTest(Type type)
        {
            foreach (var pi in type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var attr = pi.GetCustomAttribute<JsonPropertyAttribute>();
                Assert.NotNull(attr);

                Assert.Equal(pi.Name.ToSnakeCase(), attr.PropertyName);
            }
        }

        [Theory]
        [InlineData(typeof(EmbedData))]
        [InlineData(typeof(Media))]
        [InlineData(typeof(ImageInfo))]
        public void JsonConverterAttributeTest(Type type)
        {
            foreach (var pi in type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (pi.PropertyType.GetTypeInfo().IsEnum)
                {
                    var attr = pi.GetCustomAttribute<JsonConverterAttribute>();
                    Assert.Equal(typeof(StringEnumConverter), attr?.ConverterType);
                }
            }
        }
    }
}