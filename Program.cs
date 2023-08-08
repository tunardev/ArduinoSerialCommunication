using System;
using System.IO.Ports;

class Program
{
    static SerialPort serialPort;

    static void Main(string[] args)
    {
        // Port settings for Arduino
        string portName = "/dev/cu.usbserial-1120";
        int baudRate = 9600;

        // Create a new SerialPort object with default settings.
        serialPort = new SerialPort(portName, baudRate);
        serialPort.DataReceived += SerialPort_DataReceived;

        try
        {
            // Open serial port
            serialPort.Open();

            // Send data to Arduino
            while (true)
            {
                // Exit if user enters "exit"
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") {
                    break;
                }
                serialPort.WriteLine(input);
            }
        }
        catch (Exception ex)
        {
            // Error handling
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // Close serial port
            serialPort.Close();
        }
    }

    private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        // Read data from Arduino
        string receivedMessage = serialPort.ReadLine();
        Console.WriteLine("Message from Arduino: " + receivedMessage);
    }
}

