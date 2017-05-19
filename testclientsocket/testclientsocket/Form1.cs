using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace testclientsocket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Send(string value)
        {
            byte[] data = Encoding.ASCII.GetBytes(value);
            try
            {
                using (TcpClient client = new TcpClient("172.26.45.205", 9100))
                {
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);

                    //client.Close();
                }
            }
            catch (Exception err)
            {
                //MessageBox.Show("Connection could not be made! ");
                // Log the error
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strSend = "PP 200,200:";
            strSend = strSend + "PT \"Printing\":";
            strSend = strSend + "PF\r\n";
            Send(strSend);

            
        }
    }
}