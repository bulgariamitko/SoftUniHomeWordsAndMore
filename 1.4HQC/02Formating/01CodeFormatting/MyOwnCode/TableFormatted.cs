namespace MyOwnCode
{
    using System;
    using System.Collections;

    public class TableFormatted
    {
        private static Hashtable typeTable;

        public static string GetCsType(string glType)
        {
            if (typeTable == null)
            {
                typeTable = CreateTypeTable();
            }

            string ret = (string)typeTable[glType];
            if (ret == null)
            {
                Console.Error.WriteLine("warning: unknown type \"" + glType + "\" use as is.");
                typeTable[glType] = glType;
                ret = glType;
            }

            return ret;
        }

        private static Hashtable CreateTypeTable()
        {
            Hashtable ret = new Hashtable
            {
                ["void"] = "void",
                ["GLvoid"] = "void",
                ["GLenum"] = "uint",
                ["GLbyte"] = "byte",
                ["GLshort"] = "short",
                ["GLint"] = "int",
                ["GLsizei"] = "int",
                ["GLubyte"] = "byte",
                ["GLuint"] = "uint",
                ["GLfloat"] = "float",
                ["GLushort"] = "ushort",
                ["GLclampf"] = "float",
                ["GLdouble"] = "double",
                ["GLclampd"] = "double",
                ["GLboolean"] = "byte",
                ["GLbitfield"] = "uint"
            };
            return ret;
        }
    }
}