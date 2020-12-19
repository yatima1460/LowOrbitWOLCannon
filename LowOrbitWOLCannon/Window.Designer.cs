
namespace LowOrbitWOLCannon
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pingStatusUIRefresherTick = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mac = new System.Windows.Forms.TextBox();
            this.turnOn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.workstation = new System.Windows.Forms.TextBox();
            this.broadcast = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openRDP = new System.Windows.Forms.Button();
            this.bootingProgress = new System.Windows.Forms.ProgressBar();
            this.bootingTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pingStatusUIRefresherTick
            // 
            this.pingStatusUIRefresherTick.Enabled = true;
            this.pingStatusUIRefresherTick.Tick += new System.EventHandler(this.pingStatusUIRefresher_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(540, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 32);
            this.label3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(499, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Workstation";
            // 
            // mac
            // 
            this.mac.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mac.Location = new System.Drawing.Point(504, 101);
            this.mac.Name = "mac";
            this.mac.Size = new System.Drawing.Size(182, 30);
            this.mac.TabIndex = 8;
            this.mac.Text = "A4-BB-6D-60-5A-2C";
            this.mac.TextChanged += new System.EventHandler(this.mac_TextChanged);
            // 
            // turnOn
            // 
            this.turnOn.BackColor = System.Drawing.Color.White;
            this.turnOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.turnOn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnOn.ForeColor = System.Drawing.Color.Black;
            this.turnOn.Location = new System.Drawing.Point(504, 212);
            this.turnOn.Name = "turnOn";
            this.turnOn.Size = new System.Drawing.Size(182, 36);
            this.turnOn.TabIndex = 12;
            this.turnOn.Text = "FIRE!";
            this.turnOn.UseVisualStyleBackColor = false;
            this.turnOn.Click += new System.EventHandler(this.FIRE_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(499, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "MAC";
            // 
            // workstation
            // 
            this.workstation.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workstation.Location = new System.Drawing.Point(504, 34);
            this.workstation.Name = "workstation";
            this.workstation.Size = new System.Drawing.Size(182, 30);
            this.workstation.TabIndex = 11;
            this.workstation.Text = "ws-zit-203";
            this.workstation.TextChanged += new System.EventHandler(this.IP_TextChanged);
            // 
            // broadcast
            // 
            this.broadcast.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.broadcast.Location = new System.Drawing.Point(504, 163);
            this.broadcast.Name = "broadcast";
            this.broadcast.Size = new System.Drawing.Size(182, 30);
            this.broadcast.TabIndex = 14;
            this.broadcast.Text = "192.168.90.255";
            this.broadcast.TextChanged += new System.EventHandler(this.broadcast_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(499, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Broadcast";
            // 
            // openRDP
            // 
            this.openRDP.BackColor = System.Drawing.Color.White;
            this.openRDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openRDP.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openRDP.ForeColor = System.Drawing.Color.Black;
            this.openRDP.Location = new System.Drawing.Point(504, 347);
            this.openRDP.Name = "openRDP";
            this.openRDP.Size = new System.Drawing.Size(182, 36);
            this.openRDP.TabIndex = 16;
            this.openRDP.Text = "Open RDP";
            this.openRDP.UseVisualStyleBackColor = false;
            this.openRDP.Click += new System.EventHandler(this.openRDP_Click);
            // 
            // bootingProgress
            // 
            this.bootingProgress.Location = new System.Drawing.Point(12, 347);
            this.bootingProgress.Name = "bootingProgress";
            this.bootingProgress.Size = new System.Drawing.Size(486, 36);
            this.bootingProgress.TabIndex = 17;
            // 
            // bootingTimer
            // 
            this.bootingTimer.Interval = 10;
            this.bootingTimer.Tick += new System.EventHandler(this.bootingTimer_Tick);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LowOrbitWOLCannon.Properties.Resources.danzaiver;
            this.ClientSize = new System.Drawing.Size(698, 395);
            this.Controls.Add(this.bootingProgress);
            this.Controls.Add(this.openRDP);
            this.Controls.Add(this.broadcast);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mac);
            this.Controls.Add(this.turnOn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.workstation);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Window";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LowOrbitWOLCannon - Seingreed is online!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer pingStatusUIRefresherTick;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mac;
        private System.Windows.Forms.Button turnOn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox workstation;
        private System.Windows.Forms.TextBox broadcast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button openRDP;
        private System.Windows.Forms.ProgressBar bootingProgress;
        private System.Windows.Forms.Timer bootingTimer;
    }
}

