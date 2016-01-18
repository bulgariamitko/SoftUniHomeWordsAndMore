using System;
using System.Collections;
using System.Text;

public class GLType2
{
    private readonly string typeName;
    private int stars;

    public GLType2(string glType)
    {
        typeName = GetCsType(glType);
    }

    /** return the generation specific level of this type.
	 *  roughly equal to the number of polymorphic type
	 * it could have. <br>
	 * <b>Note</b> a return type has a maximum of 3 level, anyway. */
    public int Level
    {
        get
        {
            if (stars == 0)
            {
                return 1;
            }

            if (stars == 1 && typeName == "void")
            {
                return 10;
            }

            return 3;
        }
    }

    public bool IsVoid => stars == 0 && typeName == "void";

    /** return the C# representation of a type for a given level.
	 * @param isReturn tell wether or not it is a return argument as
	 * the representation are different
	 * @param codeFriendly to generate a compilable name for CFunction
	 * name. */
    public string ToString(int level, bool isReturn, bool codeFriendly)
    {
        if (stars == 0)
        {
            return typeName;
        }

        if (level == 0) // C - name
        {
            return typeName + StarString(codeFriendly ? 'P' : '*');
        }

        if (stars > 1 || isReturn || level == 1)
        {
            return "IntPtr";
        }

        if (typeName != "void")
        {
            return typeName + "[]";
        }

        switch (level)
        {
            case 2:
                return "byte[]";
            case 3:
                return "sbyte[]";
            case 4:
                return "short[]";
            case 5:
                return "ushort[]";
            case 6:
                return "int[]";
            case 7:
                return "uint[]";
            case 8:
                return "float[]";
            case 9:
                return "double[]";
        }

        return typeName + "[]";
    }

    private string StarString(char c)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < stars; i++)
        {
            sb.Append(c);
        }

        return sb.ToString();
    }

    public bool IsPointer => stars > 0;

    public int Size
    {
        get
        {
            switch (typeName)
            {
                case "void":
                    return 0;
                case "byte":
                case "sbyte": return 1;
                case "short":
                case "ushort":
                    return 2;
                case "int":
                case "uint":
                    return 4;
                case "float":
                    return 4;
                case "double":
                    return 8;
                default:
                    throw new ArgumentException("unknown base type");
            }
        }
    }

    public static Hashtable typeTable;

    public static string GetCsType(string glType)
    {
        if (typeTable == null)
        {
            typeTable = CreateTypeTable();
        }

        var ret = (string)
                 typeTable[glType];
        if (ret != null)
        {
            return ret;
        }

        Console.Error.WriteLine("warning: unknown type \"" + glType + "\" use as is.");
        typeTable[glType] = glType;
        ret = glType;
        return ret;
    }

    static Hashtable CreateTypeTable()
    {
        var ret = new Hashtable
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