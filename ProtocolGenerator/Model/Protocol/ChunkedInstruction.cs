using System.Collections.Generic;
using System.Linq;

namespace ProtocolGenerator.Model.Protocol;

public class ChunkedInstruction : BaseInstruction
{
    public ChunkedInstruction(Xml.ProtocolChunkedInstruction xmlChunkedInstruction)
    {
        Instructions = xmlChunkedInstruction.Instructions.Select(ProtocolInstructionFactory.Transform).ToList();
    }

    public override List<Xml.ProtocolStruct> GetNestedTypes()
    {
        var nestedTypes = new List<Xml.ProtocolStruct>();
        foreach (var i in Instructions.OfType<SwitchInstruction>())
        {
            nestedTypes.AddRange(i.GetNestedTypes());
        }
        return nestedTypes;
    }

    public override void GenerateProperty(GeneratorState state)
    {
        foreach (var inst in Instructions)
        {
            inst.GenerateProperty(state);

            if (inst.HasProperty)
                state.NewLine();
        }
    }
}
