using System;
using System.Collections;
using System.Collections.Generic;

namespace GreenPAK_library
{
    public class GreenPAK
    {
        public byte matrix_address_length;

        //public Hashtable myHashtable = new Hashtable();

        public static readonly Dictionary<int, Macrocell.block_output> myDictionary = 
            new Dictionary<int, Macrocell.block_output>();

        

        public struct matrix_connection
        {
            public Macrocell.block_output output;
            public Macrocell.block_input input;

            public matrix_connection(Macrocell.block_output output, Macrocell.block_input input)
            {
                this.output = output;
                this.input = input;
            }
        }

        public List<matrix_connection> matrix_connections = new List<matrix_connection>();

        static public List<Macrocell> Macrocell_list = new List<Macrocell>();

        public void assign_matrix_connections(byte[] nvm, byte matrix_address_length)
        {
            foreach (Macrocell m in Macrocell_list)
            {
                foreach (Macrocell.block_input input in m.inputs)
                {
                    string myString = "";
                    for (int i = input.register_address; 
                        i < input.register_address + matrix_address_length; i++)
                    {
                        //Console.Write(i + " ");
                        myString = nvm[i].ToString() + myString;
                        //myString.Insert(0, nvm[i].ToString());
                    }
                    //Console.WriteLine("myString: " + myString);

                    int connected_output = Convert.ToInt32(myString, 2);

                    Macrocell.block_output output = myDictionary[connected_output];
                    Console.Write(output.Macrocell.name + " " + output.name);
                    Console.Write(" → ");
                    Console.WriteLine(m.name + " " + input.name);

                    matrix_connections.Add(new matrix_connection(output, input));
                }
            }
        }

        public GreenPAK()
        {
            //Dictionary<int, block_output> myDictionary = new Dictionary<int, block_output>();
        }


    }
}
