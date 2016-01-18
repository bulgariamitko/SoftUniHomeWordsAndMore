using System;
using System.Collections;

namespace MyOwnCode
{
    public class Table
    {
        static Hashtable typeTable;
        public static string GetCSType(string GLType)
        {
            if (typeTable == null) typeTable = createTypeTable();
            string ret = (string)
                     typeTable[GLType];
            if (ret
                     ==
                      null)
            {
                Console.Error.WriteLine("warning: unknown type \"" + GLType + "\" use as is.");
                typeTable[GLType] = GLType;
                ret = GLType;
            }
            return ret;
        }
        static Hashtable createTypeTable()
        {
            Hashtable ret = new Hashtable();
            ret["void"] = "void";
            ret["GLvoid"] = "void";
            ret["GLenum"] = "uint";
            ret["GLbyte"] = "byte"; ret["GLshort"] = "short"; ret["GLint"] = "int";
            ret["GLsizei"] = "int"; ret["GLubyte"] = "byte"; ret["GLuint"] = "uint"; ret["GLfloat"] = "float";
            ret["GLushort"] = "ushort";
            ret["GLclampf"] = "float";
            ret["GLdouble"] = "double";


            ret["GLclampd"] = "double";
            ret["GLboolean"] = "byte";
            ret["GLbitfield"] = "uint";
            return ret;
        }
    }
}
}