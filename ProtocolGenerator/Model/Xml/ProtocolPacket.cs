using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProtocolGenerator.Model.Xml;

public sealed class ProtocolPacket
{
    [XmlAttribute("family")]
    public string Family { get; set; }

    [XmlAttribute("action")]
    public string Action { get; set; }

    [XmlElement("field", typeof(ProtocolFieldInstruction))]
    [XmlElement("array", typeof(ProtocolArrayInstruction))]
    [XmlElement("length", typeof(ProtocolLengthInstruction))]
    [XmlElement("dummy", typeof(ProtocolDummyInstruction))]
    [XmlElement("switch", typeof(ProtocolSwitchInstruction))]
    [XmlElement("chunked", typeof(ProtocolChunkedInstruction))]
    [XmlElement("break", typeof(ProtocolBreakInstruction))]
    public List<object> Instructions { get; set; }

    [XmlElement("comment")]
    public string Comment { get; set; }
}
