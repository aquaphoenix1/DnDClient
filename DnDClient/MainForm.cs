﻿using DnDClient.Client_Elements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            /*int port = 9999;
            string ipAdress = "82.179.48.155";

            Client client = new Client(port, ipAdress);
            client.ActivityHandler += ActivityHandler;*/
        }

        private void ActivityHandler(object sender, String message)
        {
            var client = sender as Client;

            string[] msg = message.Split(new char[] { ' ' });

            int code = Int32.Parse(msg[0]);

            switch (code)
            {
                case (int)Codes.Code.GetMessageChat:
                    {
                        Console(msg[1]);
                        break;
                    }
            }
        }
        private void Console(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => richTextBoxChat.AppendText(message + Environment.NewLine)));
            }
            else
            {
                richTextBoxChat.AppendText(message + Environment.NewLine);
            }
        }

        private void ButtonSendChatMessage_Click(object sender, EventArgs e)
        {

        }

        private void CreateCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreateCharacterForm().ShowDialog();
        }

        private void LoadCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите имя персонажа",
                       "Загрузка персонажа");

            if(input != "")
            {
                string path = Directory.GetCurrentDirectory() + "\\" + input;

                if (File.Exists(path))
                {
                    var text = File.ReadAllText(path);

                    dynamic element = JsonConvert.DeserializeObject(text);
                }
            }
        }
    }
}
