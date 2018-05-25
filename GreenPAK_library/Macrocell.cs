using System;
using System.Collections.Generic;

namespace GreenPAK_library
{
    public class Macrocell
    {
        public string name;

        public List<block_input> inputs = new List<block_input>();
        public List<block_output> outputs = new List<block_output>();
        public List<GreenPAK.matrix_connection> input_connections = new List<GreenPAK.matrix_connection>();
        public List<GreenPAK.matrix_connection> output_connections = new List<GreenPAK.matrix_connection>();


        public struct block_output
        {
            public string name;
            public Macrocell Macrocell;
            public byte output_address;

            public block_output(string name, Macrocell Macrocell, byte output_address)
            {
                this.name = name;
                this.Macrocell = Macrocell;
                this.output_address = output_address;


                ////////////////////////////////////////////////////////////////////////////////
                // Add this block_output to the dictionary
                ////////////////////////////////////////////////////////////////////////////////
                //this.Macrocell.myHashtable.Add(output_address, this);
                GreenPAK.myDictionary.Add(output_address, this);
            }
        }

        public struct block_input
        {
            public string name;
            public Macrocell Macrocell;
            public int register_address;

            public block_input(string name, Macrocell Macrocell, int register_address)
            {
                this.name = name;
                this.Macrocell = Macrocell;
                this.register_address = register_address;
            }
        }

        // Constructor for Macrocells adds each one to the list of macrocells
        public Macrocell()
        {
            GreenPAK.Macrocell_list.Add(this);
        }
    }


    ////////////////////////////////////////////////////////////////////////////////
    // A class to hold configuration information to be used in the individual macrocell 
    // constructors
    ////////////////////////////////////////////////////////////////////////////////
    public class Macrocell_config : GreenPAK
    {
        // Name of the block
        public string name;

        // Inputs = block inputs (matrix outputs)
        public List<UInt16> inputs;

        // Outputs = block outputs (matrix inputs)
        public List<Macrocell.block_output> outputs;

        // List of bits used to configure the macrocell
        public List<UInt16> config_bits;

        

    }

    ////////////////////////////////////////////////////////////////////////////////
    // LUTs
    ////////////////////////////////////////////////////////////////////////////////
    public class LUT : Macrocell
    {
        protected bool[] truthtable;

        public LUT()
        {

        }
    }

    public class LUT_2_bit : LUT { }

    public class LUT_3_bit : LUT { }

    public class LUT_4_bit : LUT { }


    ////////////////////////////////////////////////////////////////////////////////
    // DFFs
    ////////////////////////////////////////////////////////////////////////////////
    public class DFF : Macrocell { }

    public class DFF_2_bit : DFF { }

    public class Latch_2_bit : DFF { }

    public class DFF_3_bit : DFF { }

    public class Latch_3_bit : DFF { }

    public class DFF_2_bit_nQ : DFF { }

    public class Latch_2_bit_nQ : DFF { }

    public class DFF_3_bit_nQ : DFF { }

    public class Latch_3_bit_nQ : DFF { }


    ////////////////////////////////////////////////////////////////////////////////
    // Pipe Delay
    ////////////////////////////////////////////////////////////////////////////////
    public class Pipe_delay : Macrocell { }


    ////////////////////////////////////////////////////////////////////////////////
    // GPIOs
    ////////////////////////////////////////////////////////////////////////////////
    public class GPI : Macrocell { }

    public class GPIO : Macrocell { }

    public class GPIO_OE : Macrocell { }


    ////////////////////////////////////////////////////////////////////////////////
    // Counters
    ////////////////////////////////////////////////////////////////////////////////
    public class Counter_8_bit : Macrocell { }

    public class Delay_8_bit : Macrocell { }


    ////////////////////////////////////////////////////////////////////////////////
    // Oscillators
    ////////////////////////////////////////////////////////////////////////////////
    public class Oscillator : Macrocell { }


    ////////////////////////////////////////////////////////////////////////////////
    // PDLY / Filter
    ////////////////////////////////////////////////////////////////////////////////
    public class Pdly : Macrocell { }

    public class Filter : Macrocell { }


    ////////////////////////////////////////////////////////////////////////////////
    // Power Supply
    ////////////////////////////////////////////////////////////////////////////////
    public class Power : Macrocell { }

}