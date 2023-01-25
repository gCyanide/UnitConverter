using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace UnitConverter
{
    /// <summary>
    /// Units: root class for all the units.
    /// </summary>
    [Serializable, XmlRoot("Units")]
    public class Units
    {
        [XmlElement("Unit")]
        public List<Unit> AllUnits { get; set; } = new List<Unit>();

        public Units() { }
    }

    /// <summary>
    /// Unit: single universal class for units.
    /// </summary>
    [Serializable, XmlType("Unit")]
    public class Unit
    {
        [XmlElement("Type")]
        public String Type { get; set; }

        [XmlElement("Name")]
        public String Name { get; set; }

        [XmlArray("ConvertTo")]
        [XmlArrayItem("Value", ElementName = "Value")]
        public List<Value> ConvertTo { get; set; }

        public Unit() { }
    }

    /// <summary>
    /// Value: additional class for converting values.
    /// </summary>
    [Serializable]
    public struct Value
    {
        [XmlAttribute("Name")]
        public String Name { get; set; }
        [XmlText]
        public Double ConvertValue { get; set; }
    }
}