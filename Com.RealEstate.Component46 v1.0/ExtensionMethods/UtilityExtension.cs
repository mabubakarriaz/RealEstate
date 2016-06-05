using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.RealEstate.Component.ExtensionMethods
{
    public static class UtilityExtension
    {
        
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value.ToString(), ignoreCase: true);
        }

        public static T ParseEnum<T>(this int value)
        {
            return (T)Enum.Parse(typeof(T), value.ToString(), ignoreCase: true);
        }

        public static Array EnumArray<T>(){

            return Enum.GetValues(typeof(T));
        }


        public static BindingSource GetEmptyList()
        {
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            HT.Add(-1, "No List Found! ");

            BS.DataSource = HT;
            return BS;
        }

        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }

    }
}
