using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace MoEmbed.Models
{
    public sealed class AttributeTest
    {
        [Test]
        [Arguments(typeof(EmbedData))]
        [Arguments(typeof(Media))]
        [Arguments(typeof(ImageInfo))]
        public async Task ShouldSerializeTest(Type type)
        {
            var target = Activator.CreateInstance(type);

            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(target))
            {
                await Assert.That(pd.ShouldSerializeValue(target)).IsFalse();
            }
        }

        [Test]
        [Arguments(typeof(EmbedData))]
        [Arguments(typeof(Media))]
        [Arguments(typeof(ImageInfo))]
        public async Task DataMemberAttributeTest(Type type)
        {
            foreach (var pi in type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var attr = pi.GetCustomAttribute<DataMemberAttribute>();
                await Assert.That(attr).IsNotNull();
            }
        }

        [Test]
        [Arguments(typeof(EmbedData))]
        [Arguments(typeof(Media))]
        [Arguments(typeof(ImageInfo))]
        public async Task JsonPropertyAttributeTest(Type type)
        {
            foreach (var pi in type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var attr = pi.GetCustomAttribute<JsonPropertyAttribute>();
                await Assert.That(attr).IsNotNull();

                await Assert.That(attr.PropertyName).IsEqualTo(pi.Name.ToSnakeCase());
            }
        }

        [Test]
        [Arguments(typeof(EmbedData))]
        [Arguments(typeof(Media))]
        [Arguments(typeof(ImageInfo))]
        public async Task JsonConverterAttributeTest(Type type)
        {
            foreach (var pi in type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (pi.PropertyType.GetTypeInfo().IsEnum)
                {
                    var attr = pi.GetCustomAttribute<JsonConverterAttribute>();
                    await Assert.That(attr?.ConverterType).IsEqualTo(typeof(StringEnumConverter));
                }
            }
        }
    }
}
