using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;

namespace Demo.JsonSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new JSchemaGenerator
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                SchemaIdGenerationHandling = SchemaIdGenerationHandling.TypeName
            };
            var schema1 = generator.Generate(typeof(v1.Person));
            Console.WriteLine(schema1);

            var schemaJson = @"{
  '$id': 'Person',
  'type': 'object',
  'properties': {
    'name': {
      'type': [
        'string',
        'null'
      ]
    },
    'age': {
      'type': 'integer',
      'null'
    }
  }
}";

            var schema = JSchema.Parse(schemaJson);
            Console.WriteLine("Person Schema:");
            Console.WriteLine(schema);

            var person = new v2.Person {Name = "Yoda", City = "Degoba"};
            var settings = new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()};
            var json = JsonConvert.SerializeObject(person, Formatting.Indented, settings);
            Console.WriteLine("\nPerson JSON:");
            Console.WriteLine(json);

            var jobj = JObject.Parse(json);
            var valid = jobj.IsValid(schema, out IList<string> errorMessages);
            Console.WriteLine($"\nIs Valid: {valid}");
            if (!valid)
            {
                foreach (var errorMessage in errorMessages)
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
    }
}