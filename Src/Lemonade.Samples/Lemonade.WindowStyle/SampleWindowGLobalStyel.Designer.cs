﻿namespace Lemonade.Samples.WindowStyle
{
    partial class SampleWindowGLobalStyel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 131);
            this.label1.TabIndex = 0;
            this.label1.Text = "该窗体编码时未设置窗体样式，具有窗体的所有界面元素，包括操作系统任务栏上的图标，看起来是一个独立于系统的窗体界面";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 131);
            this.label2.TabIndex = 0;
            this.label2.Text = "该窗体调用Lemon.WinStyle全局函数设置样式，该函数设置使窗体在风格上融入框架的基础样式.";
            // 
            // SampleWindowGLobalStyel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SampleWindowGLobalStyel";
            this.Text = "全局函数设置样式";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}