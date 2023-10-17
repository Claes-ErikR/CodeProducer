using System.Collections.Generic;
using Utte.Code.Code.Helpers;

namespace Utte.Code.Code.SupportClasses
{
    public class MemberWriter
    {
        private List<Member> _members;

        /// <summary>
        /// Initializes basic parameters
        /// </summary>
        public MemberWriter()
        {
            _members = new List<Member>();
        }

        public bool HasProperties(bool staticproperties)
        {
            for (int i = 0; i < _members.Count; i++)
                if (_members[i].GetProperty && (_members[i].Static == staticproperties))
                    return true;

            return false;
        }

        public void WriteProperties(CodeWriter codeWriter, bool staticproperties)
        {
            List<Member> members = new List<Member>();
            foreach (Member member in _members)
                if (member.GetProperty && (member.Static == staticproperties))
                    members.Add(member);
            foreach (Member member in members)
            {
                string description;
                if (member.Description == "")
                    if (member.SetProperty)
                        description = "Returns or sets " + member.Name.ToLower();
                    else if (member.ProtectedSetProperty)
                        description = "Returns or protected sets " + member.Name.ToLower();
                    else
                        description = "Returns " + member.Name.ToLower();
                else
                    description = member.Description;
                codeWriter.ProduceDescription(description);
                codeWriter.ProduceAttributes(member.Attributes);
                codeWriter.Write("public ", true);
                if (staticproperties)
                    codeWriter.Write("static ");
                codeWriter.Write(member.Type);
                if (member.ValueIsNullable)
                    codeWriter.Write("?");
                codeWriter.Write(" ");

                if(member.PrivateProtected || !string.IsNullOrEmpty(member.GetText) || !string.IsNullOrEmpty(member.SetText))
                {
                    codeWriter.WriteLine(member.Name);
                    codeWriter.WriteLine("{", true);
                    codeWriter.AddIndentation();
                    codeWriter.WriteLine("get", true);
                    codeWriter.WriteLine("{", true);
                    codeWriter.AddIndentation();
                    if (!string.IsNullOrEmpty(member.GetText))
                        codeWriter.WriteLine(member.GetText, true);
                    else if (member.PrivateProtected)
                    {
                        codeWriter.Write("return _", true);
                        codeWriter.Write(member.Name.ToLower());
                        codeWriter.WriteLine(";");
                    }
                    else
                        NotImplemented(codeWriter);
                    codeWriter.SubtractIndentation();
                    codeWriter.WriteLine("}", true);
                    if (member.ProtectedSetProperty)
                        codeWriter.WriteLine("protected", true);
                    if (member.SetProperty || member.ProtectedSetProperty)
                    {
                        codeWriter.WriteLine("set", true);
                        codeWriter.WriteLine("{", true);
                        codeWriter.AddIndentation();
                        if (!string.IsNullOrEmpty(member.SetText))
                            codeWriter.WriteLine(member.SetText, true);
                        else if (member.PrivateProtected)
                        {
                            codeWriter.Write("_", true);
                            codeWriter.Write(member.Name.ToLower());
                            codeWriter.WriteLine(" = value;");
                        }
                        else
                            NotImplemented(codeWriter);
                        codeWriter.SubtractIndentation();
                        codeWriter.WriteLine("}", true);
                    }
                    codeWriter.SubtractIndentation();
                    codeWriter.WriteLine("}", true);
                }
                else
                {
                    codeWriter.Write(member.Name);
                    if (member.ProtectedSetProperty)
                        codeWriter.WriteLine(" { get; protected set; }");
                    else if (member.SetProperty)
                        codeWriter.WriteLine(" { get; set; }");
                    else
                        codeWriter.WriteLine(" { get; }");
                }
                codeWriter.WriteLine("");
            }
        }

        public bool HasPrivateProtectedMembers(bool staticmembers)
        {
            foreach (Member member in _members)
                if (member.PrivateProtected && (member.Static == staticmembers))
                    return true;

            return false;
        }

        public void WritePrivateProtectedMembers(CodeWriter codeWriter, bool staticmembers)
        {
            foreach (Member member in _members)
                if (member.PrivateProtected && (member.Static == staticmembers))
                {
                    if (member.Static)
                        codeWriter.Write("private static ", true);
                    else
                        codeWriter.Write("private ", true);
                    codeWriter.Write(member.Type);
                    if (member.ValueIsNullable)
                        codeWriter.Write("?");
                    codeWriter.Write(" _");
                    codeWriter.Write(member.Name.ToLower());
                    codeWriter.WriteLine(";");
                }
            codeWriter.WriteLine("");
        }

        public bool HasPublicMembers(bool staticmembers)
        {
            foreach (Member member in _members)
                if (member.Public && (member.Static == staticmembers))
                    return true;

            return false;
        }

        public void WritePublicMembers(CodeWriter codeWriter, bool staticmembers)
        {
            foreach (Member member in _members)
            {
                if (member.Public && (member.Static == staticmembers))
                {
                    codeWriter.Write("public ", true);
                    if(member.Static)
                        codeWriter.Write("static ");
                    if (member.ReadOnly)
                        codeWriter.Write("readonly ");
                    codeWriter.Write(member.Type);
                    if (member.ValueIsNullable)
                        codeWriter.Write("?");
                    codeWriter.Write(" ");
                    codeWriter.Write(member.Name);
                    codeWriter.WriteLine(";");
                }
            }
            codeWriter.WriteLine("");
        }

        /// <summary>
        /// Adds a Member to the end of the list
        /// </summary>
        /// <param name="member"></param>
        public void Add(Member member)
        { 
            _members.Add(member); 
        }

        /// <summary>
        /// Adds a range of Members to the end of the list
        /// </summary>
        /// <param name="members"></param>
        public void AddRange(IEnumerable<Member> members)
        {
            _members.AddRange(members);
        }

        public void AddEmptyMember(string className)
        {
            Member member = new Member();
            member.ConstructorSet = false;
            member.Description = "Returns empty instance";
            member.GetProperty = true;
            member.SetProperty = false;
            member.Name = "Empty";
            member.PrivateProtected = false;
            member.Static = true;
            member.Type = className;
            member.ConstructorSet = true;
            member.ReadOnly = true;
            _members.Add(member);
        }

        public void AddListWrapperMembers(string type)
        {
            Member member = new Member();
            member.ConstructorSet = false;
            member.Description = "";
            member.GetProperty = false;
            member.SetProperty = false;
            member.Name = "list";
            member.PrivateProtected = true;
            member.Static = false;
            member.Type = "List<" + type + ">";
            member.ValueType = false;
            _members.Add(member);

            member = new Member();
            member.ConstructorSet = false;
            member.Description = "Returns number of elements in the list";
            member.GetProperty = true;
            member.GetText = "return _list.Count;";
            member.SetProperty = false;
            member.Name = "Count";
            member.PrivateProtected = false;
            member.Static = false;
            member.Type = "int";
            member.ValueType = true;
            _members.Add(member);

            member = new Member();
            member.ConstructorSet = false;
            member.Description = "Returns indexed item";
            member.GetProperty = true;
            member.GetText = "return _list[index];";
            member.SetProperty = false;
            member.Name = "this[int index]";
            member.PrivateProtected = false;
            member.Static = false;
            member.Type = type;
            member.ValueType = true;
            _members.Add(member);
        }

        public void AddIXmlSaveMember()
        {
            Member member = new Member();
            member.Attributes = new List<string>();
            member.Attributes.Add("Category(\"Behavior\")");
            member.Attributes.Add("Description(\"Returns or sets inclusion in XmlSave\")");
            member.ConstructorSet = false;
            member.Description = "Decides wether the object should be saved in XmlSave";
            member.GetProperty = true;
            member.SetProperty = true;
            member.Name = "IncludeXmlSave";
            member.PrivateProtected = true;
            member.Static = false;
            member.Type = "bool";
            member.ValueType = true;
            _members.Add(member);
        }

        public void AddIValidMember()
        {
            Member member = new Member();
            member.Attributes = new List<string>();
            member.Attributes.Add("Browsable(false)");
            member.ConstructorSet = false;
            member.Description = "Returns if input data is valid";
            member.GetProperty = true;
            member.GetText = "return true;";
            member.SetProperty = false;
            member.Name = "Valid";
            member.PrivateProtected = false;
            member.Static = false;
            member.Type = "bool";
            member.ValueType = true;
            member.ReadOnly = true;
            _members.Add(member);
        }

        public void AddISphericaloordinatesMembers()
        {
            _members.Add(GetCoordinateMember("R"));
            _members.Add(GetCoordinateMember("Phi", "AngleMeasurement", false));
            _members.Add(GetCoordinateMember("Theta", "AngleMeasurement", false));
        }

        /// <summary>
        /// Implements ICylindricalCoordinates interface
        /// </summary>
        public void AddICylindricalCoordinatesMembers()
        {
            _members.Add(GetCoordinateMember("R"));
            _members.Add(GetCoordinateMember("Phi", "AngleMeasurement", false));
            _members.Add(GetCoordinateMember("z"));
        }

        /// <summary>
        /// Implements IEuclidean3D interface
        /// </summary>
        public void AddIEuclidean3DMembers()
        {
            _members.Add(GetCoordinateMember("x"));
            _members.Add(GetCoordinateMember("y"));
            _members.Add(GetCoordinateMember("z"));
        }

        public void AddIEuclidean2DMembers()
        {
            _members.Add(GetCoordinateMember("x"));
            _members.Add(GetCoordinateMember("y"));
        }

        public void AddICircularCoordinatesMembers()
        {
            _members.Add(GetCoordinateMember("R"));
            _members.Add(GetCoordinateMember("Phi", "AngleMeasurement", false));
        }

        public List<Member> List
        { 
            get
            {
                return _members;
            }
        }

        /// <summary>
        /// Builds member for coordinate interface
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Member GetCoordinateMember(string name)
        {
            return GetCoordinateMember(name, "double", true);
        }

        /// <summary>
        /// Builds member for coordinate interface
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="valuetype"></param>
        /// <returns></returns>
        private Member GetCoordinateMember(string name, string type, bool valuetype)
        {
            Member member = new Member();
            member.ConstructorSet = false;
            member.Description = "Returns coordinate " + name;
            member.GetProperty = true;
            member.SetProperty = false;
            member.Name = name;
            member.PrivateProtected = true;
            member.Static = false;
            member.Type = type;
            member.ValueType = valuetype;
            member.ReadOnly = true;
            return member;
        }

        private void NotImplemented(CodeWriter codeWriter)
        {
            codeWriter.WriteLine("throw new NotImplementedException();", true);
        }
    }
}
