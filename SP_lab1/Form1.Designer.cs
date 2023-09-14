namespace SP_lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewThreads = new System.Windows.Forms.ListView();
            this.listViewProcesses = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewThreads
            // 
            this.listViewThreads.HideSelection = false;
            this.listViewThreads.Location = new System.Drawing.Point(738, 41);
            this.listViewThreads.Name = "listViewThreads";
            this.listViewThreads.Size = new System.Drawing.Size(155, 412);
            this.listViewThreads.TabIndex = 0;
            this.listViewThreads.UseCompatibleStateImageBehavior = false;
            this.listViewThreads.View = System.Windows.Forms.View.Details;
            // 
            // listViewProcesses
            // 
            this.listViewProcesses.HideSelection = false;
            this.listViewProcesses.Location = new System.Drawing.Point(12, 41);
            this.listViewProcesses.Name = "listViewProcesses";
            this.listViewProcesses.Size = new System.Drawing.Size(720, 412);
            this.listViewProcesses.TabIndex = 1;
            this.listViewProcesses.UseCompatibleStateImageBehavior = false;
            this.listViewProcesses.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "labelTotalProcesses";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "buttonRefresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 462);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewProcesses);
            this.Controls.Add(this.listViewThreads);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewThreads;
        private System.Windows.Forms.ListView listViewProcesses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

