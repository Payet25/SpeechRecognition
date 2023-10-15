using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace Siri
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer Siri = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        int RecTimeOut = 0;
        DateTime TimeNow = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommand.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);

            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommand.txt")))));
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);
        }

        private void Default_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;

            if (speech == "Hello")
            {
                Siri.SpeakAsync("Hey,How can I help");
            }
            if (speech == "How are you")
            {
                Siri.SpeakAsync("I'm all good, how about you");
            }
            if (speech == "What time is it")
            {
                Siri.SpeakAsync(DateTime.Now.ToString("h mm tt"));
            }
            if (speech == "Stop talking")
            {
                Siri.SpeakAsyncCancelAll();
                ranNum = rnd.Next(1, 2);
                if (ranNum == 1)
                {
                    Siri.SpeakAsync("ok, byeeeeee");
                }
                if (ranNum == 2)
                {
                    Siri.SpeakAsync("there is no need for that");
                }



            }
            if (speech == "Stop Listening")
            {
                Siri.SpeakAsync("See you later");
                _recognizer.RecognizeAsyncCancel();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
            }
            if (speech == "Show Commands")
            {
                string[] commands = (File.ReadAllLines(@"DefaultCommand.txt"));
                LstCommand.Items.Clear();
                LstCommand.SelectionMode = SelectionMode.None;
                LstCommand.Visible = true;
                foreach (string command in commands)
                {
                    LstCommand.Items.Add(command);
                }

            }
            if (speech == "Hide Commands")
            {
                LstCommand.Visible = false;
            }

        }

        private void _recognizer_SpeechRecognized(object? sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }

        private void startlistening_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Wake up")
            {
                startlistening.RecognizeAsyncCancel();
                Siri.SpeakAsync("I am awake");
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void TimerSpeaking_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 0)
            {
                _recognizer.RecognizeAsyncCancel();
            }
            else if (RecTimeOut == 11)
            {
                TimerSpeaking.Stop();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }
    }
}