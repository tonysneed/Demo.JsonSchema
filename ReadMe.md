# Hello JSON Schema

Demo for schema validation with Json.NET Schema

## References
- [Json.NET Schema Home](https://www.newtonsoft.com/jsonschema)
- [Json.NET Schema NuGet](https://www.nuget.org/packages/Newtonsoft.Json.Schema/)
- [Json.NET Schema Docs](https://www.newtonsoft.com/jsonschema/help/html/Introduction.htm)
- [Json.NET Schema Repo](https://github.com/JamesNK/Newtonsoft.Json.Schema)

## Info

- `v1.Person` has `Name` and `Age` properties.
- In generated schema, both `name` and `age` are required.
- Remove required fields in customized schema.
- `v2.Person` removes `Age` and adds `City`.
- Removing `Age` and adding `City` is compatible with customized schema, but not with the generated schema.
