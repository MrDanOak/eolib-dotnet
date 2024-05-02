using System.Collections.Generic;
using ProtocolGenerator.Model.Xml;

namespace ProtocolGenerator.Model.Protocol;

public class BaseInstruction : IProtocolInstruction
{
    public string Name { get; protected set; } = string.Empty;

    public string TypeName { get; protected set; } = string.Empty;

    public string Comment { get; protected set; } = string.Empty;

    public bool HasProperty => !string.IsNullOrWhiteSpace(Name);

    public List<IProtocolInstruction> Instructions { get; protected set; } = new();

    public virtual List<ProtocolStruct> GetNestedTypes() => new();

    public virtual void GenerateProperty(GeneratorState state)
    {
        if (!HasProperty)
            return;

        state.Comment(Comment);
        state.Property(GeneratorState.Visibility.Public, TypeName, Name);
        state.BeginBlock();
        state.AutoGet(GeneratorState.Visibility.None);
        state.AutoSet(GeneratorState.Visibility.None);
        state.EndBlock();
    }

    public virtual void GenerateSerialize(GeneratorState state) { }

    public virtual void GenerateDeserialize(GeneratorState state) { }

    public virtual void GenerateToString(GeneratorState state)
    {
        if (!HasProperty)
            return;

        state.Text($"$\"{{nameof({Name})}}={{{Name}}}\"", indented: false);
    }

    public virtual void GenerateEquals(GeneratorState state) { }

    public virtual void GenerateGetHashCode(GeneratorState state) { }
}