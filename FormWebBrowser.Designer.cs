using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Leaf.Forms
{
    partial class FormWebBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new Container();
            this.webBrowser1 = new WebBrowser();
            this.wb = new WebBrowser();
            this.tmrWatcher = new Timer(this.components);
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = DockStyle.Fill;
            this.webBrowser1.Location = new Point(0, 0);
            this.webBrowser1.MinimumSize = new Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new Size(755, 486);
            this.webBrowser1.TabIndex = 0;
            // 
            // wb
            // 
            this.wb.Dock = DockStyle.Fill;
            this.wb.Location = new Point(0, 0);
            this.wb.MinimumSize = new Size(20, 20);
            this.wb.Name = "wb";
            this.wb.ScriptErrorsSuppressed = true;
            this.wb.Size = new Size(755, 486);
            this.wb.TabIndex = 1;
            // 
            // tmrWatcher
            // 
            this.tmrWatcher.Interval = 250;
            this.tmrWatcher.Tick += new EventHandler(this.tmrWatcher_Tick);
            // 
            // FormWebBrowser
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(755, 486);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.webBrowser1);
            this.Name = "FormWebBrowser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Вход в аккаунт";
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WebBrowser webBrowser1;
        private WebBrowser wb;
        private Timer tmrWatcher;
    }
}
