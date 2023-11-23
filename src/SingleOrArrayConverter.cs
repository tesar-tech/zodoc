namespace Zodoc;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Converters;
using System;
using System.Collections.Generic;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

/// <summary>
/// makes sure that also single value in an array is converted to a list
/// authors: ["author 1"]
/// authors: "author 1" #this will be converted to a list
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleOrArrayConverter<T> : IYamlTypeConverter 
{
    public bool Accepts(Type type)
    {
        return type == typeof(T);
    }

    public object ReadYaml(IParser parser, Type type)
    {
        // Check if the next token is a sequence (array)
        if (parser.Current is SequenceStart)
        {
            parser.MoveNext(); // Move past SequenceStart
            var list = new List<string>();
            while (!(parser.Current is SequenceEnd))
            {
                list.Add(parser.Consume<Scalar>().Value);
            }
            parser.MoveNext(); // Move past SequenceEnd
            return list;
        }

        // Otherwise, read a single item
        return new List<string> { parser.Consume<Scalar>().Value };
    }


    public void WriteYaml(IEmitter emitter, object? value, Type type)
    {
        throw new NotImplementedException();
    }
}

