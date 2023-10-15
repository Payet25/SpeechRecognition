namespace Siri
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TimerSpeaking = new System.Windows.Forms.Timer(components);
            LstCommand = new ListBox();
            SuspendLayout();
            // 
            // TimerSpeaking
            // 
            TimerSpeaking.Enabled = true;
            TimerSpeaking.Interval = 1000;
            TimerSpeaking.Tick += TimerSpeaking_Tick;
            // 
            // LstCommand
            // 
            LstCommand.BackColor = SystemColors.InactiveCaptionText;
            LstCommand.Dock = DockStyle.Fill;
            LstCommand.ForeColor = SystemColors.Window;
            LstCommand.FormattingEnabled = true;
            LstCommand.ItemHeight = 20;
            LstCommand.Location = new Point(0, 0);
            LstCommand.Name = "LstCommand";
            LstCommand.Size = new Size(800, 450);
            LstCommand.TabIndex = 0;
            LstCommand.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(LstCommand);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer TimerSpeaking;
        private ListBox LstCommand;
    }
}