using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsInput;

namespace ConsoleListener
{
    public partial class Form1 : Form
    {
        string dataReceived = "";
        SerialPort comPort = new SerialPort();
        Process process = new Process();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            
            foreach (var port in ports)
            {
                availCOMs.Items.Add(port);
            }
            availCOMs.SelectedItem = "COM3";
        }

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        private void btnListen_Click(object sender, EventArgs e)
        {
            if (availCOMs.SelectedItem == null)
            {
                textResult.AppendText("ERROR: Please select port!\n");
                return;
            }
            comPort.PortName = availCOMs.SelectedItem.ToString();
            comPort.BaudRate =  int.Parse(textBaud.Text);
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.Open();

            if(!comPort.IsOpen)
            {
                textResult.Text = "ERROR: Serial port not open!";
            }
            textResult.AppendText("INFO: Serial port " + comPort.PortName + " open. Baud rate: " + comPort.BaudRate.ToString() + "\n");

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                if (p.ProcessName == "chrome" && p.MainWindowTitle == "FireBoyAndWaterGirl.swf - Google Chrome"
                    && p.MainWindowHandle != IntPtr.Zero)
                {
                    process = p;
                    textResult.AppendText("INFO: Successfully connected to chrome process!\n");
                    return;
                }
            }
            textResult.AppendText("ERROR: Could not connect to chrome process!\n");
        }

        private void comPort_DataReceived (object sender, SerialDataReceivedEventArgs e)
        {
            dataReceived = comPort.ReadLine();
            this.Invoke(new EventHandler(updateText));
        }

        private void updateText(object sender, EventArgs e)
        {
            //Insert code here to emulate keypress into chrome
            textResult.AppendText(dataReceived + "\n");
            switch (dataReceived)
            {
                case "Wd\r":
                    InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_W);
                    break;
                case "Wu\r":
                    InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_W);
                    break;

                case "Ad\r":
                    InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_A);
                    break;
                case "Au\r":
                    InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_A);
                    break;

                case "Dd\r":
                    InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_D);
                    break;
                case "Du\r":
                    InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_D);
                    break;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            comPort.Close();
        }

    }
}
