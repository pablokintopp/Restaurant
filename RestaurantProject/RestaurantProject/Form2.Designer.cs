namespace RestaurantProject
{
    partial class Form2
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
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonNewOrder = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonNewPayment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(163, 35);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(168, 16);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome \"UserName\"";
            // 
            // buttonRegister
            // 
            this.buttonRegister.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.Location = new System.Drawing.Point(166, 117);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(224, 84);
            this.buttonRegister.TabIndex = 1;
            this.buttonRegister.Text = "Management";
            this.buttonRegister.UseVisualStyleBackColor = true;
            // 
            // buttonNewOrder
            // 
            this.buttonNewOrder.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewOrder.Location = new System.Drawing.Point(166, 239);
            this.buttonNewOrder.Name = "buttonNewOrder";
            this.buttonNewOrder.Size = new System.Drawing.Size(224, 84);
            this.buttonNewOrder.TabIndex = 3;
            this.buttonNewOrder.Text = "Manage Orders";
            this.buttonNewOrder.UseVisualStyleBackColor = true;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(384, 25);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(79, 26);
            this.buttonLogout.TabIndex = 4;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            // 
            // buttonNewPayment
            // 
            this.buttonNewPayment.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewPayment.Location = new System.Drawing.Point(166, 360);
            this.buttonNewPayment.Name = "buttonNewPayment";
            this.buttonNewPayment.Size = new System.Drawing.Size(224, 84);
            this.buttonNewPayment.TabIndex = 5;
            this.buttonNewPayment.Text = "New Orders";
            this.buttonNewPayment.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 548);
            this.Controls.Add(this.buttonNewPayment);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonNewOrder);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.labelWelcome);
            this.Name = "Form2";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonNewOrder;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonNewPayment;
    }
}