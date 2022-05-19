using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    internal class BinaryConverter
    {
       
            //convert string to binary  : Encoding
            public string StringToBinary(string name)
            {
                string binaryverion = "";
                foreach (char c in name)
                {
                    string binary = "";
                    int no = (int)c;
                    while (no > 1)
                    {
                        int remainder = no % 2;
                        binary = Convert.ToString(remainder) + binary;
                        no /= 2;
                    }
                    binary = Convert.ToString(no) + binary;
                    binaryverion = binaryverion + binary.PadLeft(8, '0');
                    //Console.WriteLine("8 bit ASCII for {0} = {1} Binary = {2}", c, (int)c, binary.PadLeft(8, '0'));
                    //Console.WriteLine("7 bit ASCII for {0} = {1} Binary = {2}", c, (int)c, binary.PadLeft(7, '0'));
                    //Console.WriteLine();
                }
                Console.WriteLine($"String = {name} = {binaryverion}");
                return binaryverion.ToString();
            }
            /// DEcoding : Convert a Binary text string to a Text string
            public string BinaryToString(string binarydata)
            {
                //=======================Approach 1
                string result = "";
                for (int i = 0; i < binarydata.Length; i += 8)
                {
                    var first8_bits = binarydata.Substring(i, 8);
                    var number = Convert.ToInt32(first8_bits, 2);
                    result += (char)number;
                }
                Console.WriteLine($"Binary {binarydata} to string ={result}");
                return result;
            }
        }
    
}
