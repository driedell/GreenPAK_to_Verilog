using System;
using System.Collections.Generic;
using System.Text;

namespace GreenPAK_library
{
    public class SLG46108 : GreenPAK
    {

        public SLG46108(byte[] nvm)
        {
            matrix_address_length = 5;

            ////////////////////////////////////////////////////////////////////////////////
            // I/O Pads
            ////////////////////////////////////////////////////////////////////////////////
            Power VDD = new Power();
            VDD.outputs.Add(new Macrocell.block_output("VDD", VDD, 31));

            GPI PIN2 = new GPI();
            PIN2.outputs.Add(new Macrocell.block_output("Pin2 EXTERNAL INPUT", PIN2, 1));

            GPIO PIN3 = new GPIO();
            PIN3.inputs.Add(new Macrocell.block_input("Pin3 EXTERNAL OUTPUT", PIN3, 0));
            PIN3.outputs.Add(new Macrocell.block_output("Pin3 EXTERNAL INPUT", PIN3, 2));

            GPIO_OE PIN4 = new GPIO_OE();
            PIN4.inputs.Add(new Macrocell.block_input("Pin4 EXTERNAL OUTPUT", PIN4, 5));
            PIN4.inputs.Add(new Macrocell.block_input("Pin4 OE", PIN4, 10));
            PIN4.outputs.Add(new Macrocell.block_output("Pin4 EXTERNAL INPUT", PIN4, 3));

            Power GND = new Power();
            GND.outputs.Add(new Macrocell.block_output("GND", GND, 0));

            GPIO PIN6 = new GPIO();
            PIN6.inputs.Add(new Macrocell.block_input("Pin6 EXTERNAL OUTPUT", PIN6, 180));
            PIN6.outputs.Add(new Macrocell.block_output("Pin6 EXTERNAL INPUT", PIN6, 24));

            GPIO PIN7 = new GPIO();
            PIN7.inputs.Add(new Macrocell.block_input("Pin7 EXTERNAL OUTPUT", PIN7, 185));
            PIN7.outputs.Add(new Macrocell.block_output("Pin7 EXTERNAL INPUT", PIN7, 25));

            GPIO_OE PIN8 = new GPIO_OE();
            PIN8.inputs.Add(new Macrocell.block_input("Pin8 EXTERNAL OUTPUT", PIN8, 190));
            PIN8.inputs.Add(new Macrocell.block_input("Pin8 OE", PIN8, 195));
            PIN8.outputs.Add(new Macrocell.block_output("Pin8 EXTERNAL INPUT", PIN8, 26));


            ////////////////////////////////////////////////////////////////////////////////
            // Combinatorial Logic
            ////////////////////////////////////////////////////////////////////////////////
            LUT_2_bit LUT2_2 = new LUT_2_bit();
            LUT2_2.inputs.Add(new Macrocell.block_input("LUT2_2 IN0", LUT2_2, 35));
            LUT2_2.inputs.Add(new Macrocell.block_input("LUT2_2 IN1", LUT2_2, 40));
            LUT2_2.outputs.Add(new Macrocell.block_output("LUT2_2 OUT", LUT2_2, 6));

            LUT_2_bit LUT2_3 = new LUT_2_bit();
            LUT2_3.inputs.Add(new Macrocell.block_input("LUT2_3 IN0", LUT2_3, 45));
            LUT2_3.inputs.Add(new Macrocell.block_input("LUT2_3 IN1", LUT2_3, 50));
            LUT2_3.outputs.Add(new Macrocell.block_output("LUT2_3 OUT", LUT2_3, 7));

            LUT_3_bit LUT3_2 = new LUT_3_bit();
            LUT3_2.inputs.Add(new Macrocell.block_input("LUT3_2 IN0", LUT3_2, 85));
            LUT3_2.inputs.Add(new Macrocell.block_input("LUT3_2 IN1", LUT3_2, 90));
            LUT3_2.inputs.Add(new Macrocell.block_input("LUT3_2 IN1", LUT3_2, 95));
            LUT3_2.outputs.Add(new Macrocell.block_output("LUT3_2 OUT", LUT3_2, 10));

            LUT_3_bit LUT3_3 = new LUT_3_bit();
            LUT3_3.inputs.Add(new Macrocell.block_input("LUT3_3 IN0", LUT3_3, 100));
            LUT3_3.inputs.Add(new Macrocell.block_input("LUT3_3 IN1", LUT3_3, 105));
            LUT3_3.inputs.Add(new Macrocell.block_input("LUT3_3 IN1", LUT3_3, 115));
            LUT3_3.outputs.Add(new Macrocell.block_output("LUT3_3 OUT", LUT3_3, 11));


            ////////////////////////////////////////////////////////////////////////////////
            // Counters/Delays  
            ////////////////////////////////////////////////////////////////////////////////
            Macrocell CNT0 = new Macrocell();
            CNT0.inputs.Add(new Macrocell.block_input("CNT0 IN", CNT0, 150));
            CNT0.inputs.Add(new Macrocell.block_input("CNT0/1 EXT CLK IN", CNT0, 160));
            CNT0.outputs.Add(new Macrocell.block_output("CNT0 OUT", CNT0, 15));

            Macrocell CNT1 = new Macrocell();
            CNT1.inputs.Add(new Macrocell.block_input("CNT1 input", CNT1, 155));
            CNT1.inputs.Add(new Macrocell.block_input("CNT0/1 EXT CLK IN", CNT1, 160));
            CNT1.outputs.Add(new Macrocell.block_output("CNT1 OUT", CNT1, 16));

            Macrocell CNT3 = new Macrocell();
            CNT3.inputs.Add(new Macrocell.block_input("CNT3 IN", CNT3, 165));
            CNT3.outputs.Add(new Macrocell.block_output("CNT3 OUT", CNT3, 17));
            CNT3.outputs.Add(new Macrocell.block_output("CNT3 EDGE DET OUT", CNT3, 18));


            ////////////////////////////////////////////////////////////////////////////////
            // Special Components
            ////////////////////////////////////////////////////////////////////////////////
            Oscillator OSC = new Oscillator();
            OSC.inputs.Add(new Macrocell.block_input("OSC POWER DOWN", OSC, 175));
            OSC.outputs.Add(new Macrocell.block_output("OSC OUT0", OSC, 20));
            OSC.outputs.Add(new Macrocell.block_output("OSC OUT1", OSC, 21));

            Power POR = new Power();
            POR.outputs.Add(new Macrocell.block_output("POR", POR, 23));


            ////////////////////////////////////////////////////////////////////////////////
            // Combination Function components
            ////////////////////////////////////////////////////////////////////////////////
            Macrocell LUT2_0 = new Macrocell();
            LUT2_0.inputs.Add(new Macrocell.block_input("LUT2_0 IN0 / DFF0 CLK", LUT2_0, 15));
            LUT2_0.inputs.Add(new Macrocell.block_input("LUT2_0 IN1 / DFF0 DATA", LUT2_0, 20));
            LUT2_0.outputs.Add(new Macrocell.block_output("LUT2_0 OUT / DFF0 Q", LUT2_0, 4));
            LUT2_0.outputs.Add(new Macrocell.block_output("DFF0 nQ", LUT2_0, 27));

            Macrocell LUT2_1 = new Macrocell();
            LUT2_1.inputs.Add(new Macrocell.block_input("LUT2_1 IN0 / DFF1 CLK", LUT2_1, 25));
            LUT2_1.inputs.Add(new Macrocell.block_input("LUT2_1 IN1 / DFF1 DATA", LUT2_1, 30));
            LUT2_1.outputs.Add(new Macrocell.block_output("LUT2_1 OUT / DFF1 Q", LUT2_1, 5));
            LUT2_1.outputs.Add(new Macrocell.block_output("DFF1 nQ", LUT2_1, 28));

            Macrocell LUT3_0 = new Macrocell();
            LUT3_0.inputs.Add(new Macrocell.block_input("LUT3_0 IN0 / DFF2 CLK", LUT3_0, 55));
            LUT3_0.inputs.Add(new Macrocell.block_input("LUT3_0 IN1 / DFF2 DATA", LUT3_0, 60));
            LUT3_0.inputs.Add(new Macrocell.block_input("LUT3_0 IN2 / DFF2 RST", LUT3_0, 65));
            LUT3_0.outputs.Add(new Macrocell.block_output("LUT3_0 OUT / DFF2 Q", LUT3_0, 8));
            LUT3_0.outputs.Add(new Macrocell.block_output("DFF2 nQ", LUT2_1, 29));

            Macrocell LUT3_1 = new Macrocell();
            LUT3_1.inputs.Add(new Macrocell.block_input("LUT3_1 IN0 / DFF3 CLK", LUT3_1, 70));
            LUT3_1.inputs.Add(new Macrocell.block_input("LUT3_1 IN1 / DFF3 DATA", LUT3_1, 75));
            LUT3_1.inputs.Add(new Macrocell.block_input("LUT3_1 IN2 / DFF3 RST", LUT3_1, 80));
            LUT3_1.outputs.Add(new Macrocell.block_output("LUT3_1 OUT / DFF3 Q", LUT3_1, 9));
            LUT3_1.outputs.Add(new Macrocell.block_output("DFF3 nQ", LUT2_1, 30));

            Macrocell LUT3_4 = new Macrocell();
            LUT3_4.inputs.Add(new Macrocell.block_input("LUT3_4 IN0 / Pipe Delay IN", LUT3_4, 115));
            LUT3_4.inputs.Add(new Macrocell.block_input("LUT3_4 IN1 / Pipe Delay nRST", LUT3_4, 120));
            LUT3_4.inputs.Add(new Macrocell.block_input("LUT3_4 IN2 / Pipe Delay CLK", LUT3_4, 125));
            LUT3_4.outputs.Add(new Macrocell.block_output("LUT3_4 OUT / Pipe Delay OUT0", LUT3_4, 12));
            LUT3_4.outputs.Add(new Macrocell.block_output("Pipe Delay OUT1", LUT3_4, 13));

            Macrocell LUT4_0 = new Macrocell();
            LUT4_0.inputs.Add(new Macrocell.block_input("LUT4_0 IN0 / CNT2 EXT CLK input", LUT4_0, 130));
            LUT4_0.inputs.Add(new Macrocell.block_input("LUT4_0 IN1 / CNT2 input", LUT4_0, 135));
            LUT4_0.inputs.Add(new Macrocell.block_input("LUT4_0 IN2 / CNT2 KEEP input", LUT4_0, 140));
            LUT4_0.inputs.Add(new Macrocell.block_input("LUT4_0 IN3 / CNT2 UP input", LUT4_0, 145));
            LUT4_0.outputs.Add(new Macrocell.block_output("LUT4_0 OUT / CNT2 OUT", LUT4_0, 14));


            ////////////////////////////////////////////////////////////////////////////////
            // Assign Matrix connections
            ////////////////////////////////////////////////////////////////////////////////
            assign_matrix_connections(nvm, matrix_address_length);


            Console.WriteLine("\n\n\n\n");

            foreach (matrix_connection m in matrix_connections)
            {
                Console.WriteLine(m.output.name + "     " + m.input.name);
            }
        }
    }
}
