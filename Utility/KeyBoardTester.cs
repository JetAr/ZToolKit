/******************************************************************************
*
* Keyboard Tester
*
* KeyBoardTester.cs.F1361350668
*
* 
*
*                                       (c) BG57IV3#gmail.com 2010-2014
*                                       https://github.com/as2120/ZToolKit
*
*
******************************************************************************/

using System;
//using System.Collections.Generic;
using System.Text;

public class ConsoleKeyExample
{
    public static void Main()
    {
        ConsoleKeyInfo input;

        Console.WriteLine("Press a key, together with Alt, Ctrl, or Shift.");
        Console.WriteLine("Press Esc to exit.");

        do
        {
            input = Console.ReadKey(true);

            StringBuilder output = new StringBuilder(
                          String.Format("{0}", input.Key.ToString()));
            bool modifiers = false;

            if ((input.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt)
            {
                output.Append("," + ConsoleModifiers.Alt.ToString());
                modifiers = true;
            }
            if ((input.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
            {
                if (modifiers)
                {
                    output.Append(",");
                }
                else
                {
                    output.Append(",");
                    modifiers = true;
                }
                output.Append(ConsoleModifiers.Control.ToString());
            }
            if ((input.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift)
            {
                if (modifiers)
                {
                    output.Append(",");
                }
                else
                {
                    output.Append(",");
                    modifiers = true;
                }
                output.Append(ConsoleModifiers.Shift.ToString());
            }
            output.Append(".");
            Console.WriteLine(output.ToString());
        } while (input.Key != ConsoleKey.Escape);
    }
}

/*
[DllImport("user32.dll")]static extern short VkKeyScan(char ch);

static void Main(string[] args)
{
    var helper = new Helper { Value = VkKeyScan('(') };

    byte virtualKeyCode = helper.Low;
    byte shiftState = helper.High;

    Console.WriteLine("{0}|{1}", virtualKeyCode, (Keys)virtualKeyCode);
    Console.WriteLine("SHIFT pressed: {0}", (shiftState & 1) != 0);
    Console.WriteLine("CTRL pressed: {0}", (shiftState & 2) != 0);
    Console.WriteLine("ALT pressed: {0}", (shiftState & 4) != 0);
    Console.WriteLine();

    Keys key = (Keys)virtualKeyCode;

    key |= (shiftState & 1) != 0 ? Keys.Shift : Keys.None;
    key |= (shiftState & 2) != 0 ? Keys.Control : Keys.None;
    key |= (shiftState & 4) != 0 ? Keys.Alt : Keys.None;

    Console.WriteLine(key);
    Console.WriteLine(new KeysConverter().ConvertToString(key));
}

[StructLayout(LayoutKind.Explicit)]
struct Helper
{
    [FieldOffset(0)]public short Value;
    [FieldOffset(0)]public byte Low;
    [FieldOffset(1)]public byte High;
}

// 56|D8
// SHIFT pressed: True
// CTRL pressed: False
// ALT pressed: False
// 
// D8, Shift
// Shift+8
*/