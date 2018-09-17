namespace CClonePong
{
    partial class PongWindow
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PongWindow));
            this.scoreLabel = new System.Windows.Forms.Label();
            this.spriteRacket1 = new System.Windows.Forms.PictureBox();
            this.spriteRacket2 = new System.Windows.Forms.PictureBox();
            this.spriteBall = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.Button();
            this.cloneButton1 = new System.Windows.Forms.Button();
            this.cloneButton2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spriteRacket1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteRacket2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteBall)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.scoreLabel, "scoreLabel");
            this.scoreLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.scoreLabel.Name = "scoreLabel";
            // 
            // spriteRacket1
            // 
            this.spriteRacket1.BackColor = System.Drawing.Color.LawnGreen;
            resources.ApplyResources(this.spriteRacket1, "spriteRacket1");
            this.spriteRacket1.Name = "spriteRacket1";
            this.spriteRacket1.TabStop = false;
            // 
            // spriteRacket2
            // 
            this.spriteRacket2.BackColor = System.Drawing.Color.LawnGreen;
            resources.ApplyResources(this.spriteRacket2, "spriteRacket2");
            this.spriteRacket2.Name = "spriteRacket2";
            this.spriteRacket2.TabStop = false;
            // 
            // spriteBall
            // 
            this.spriteBall.BackColor = System.Drawing.Color.Aqua;
            resources.ApplyResources(this.spriteBall, "spriteBall");
            this.spriteBall.Name = "spriteBall";
            this.spriteBall.TabStop = false;
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.LawnGreen;
            resources.ApplyResources(this.playButton, "playButton");
            this.playButton.Name = "playButton";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // cloneButton1
            // 
            this.cloneButton1.BackColor = System.Drawing.Color.LawnGreen;
            resources.ApplyResources(this.cloneButton1, "cloneButton1");
            this.cloneButton1.Name = "cloneButton1";
            this.cloneButton1.UseVisualStyleBackColor = false;
            this.cloneButton1.Click += new System.EventHandler(this.cloneButton1_Click);
            // 
            // cloneButton2
            // 
            this.cloneButton2.BackColor = System.Drawing.Color.LawnGreen;
            resources.ApplyResources(this.cloneButton2, "cloneButton2");
            this.cloneButton2.Name = "cloneButton2";
            this.cloneButton2.UseVisualStyleBackColor = false;
            this.cloneButton2.Click += new System.EventHandler(this.cloneButton2_Click);
            // 
            // PongWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cloneButton2);
            this.Controls.Add(this.cloneButton1);
            this.Controls.Add(this.spriteRacket1);
            this.Controls.Add(this.spriteRacket2);
            this.Controls.Add(this.spriteBall);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.scoreLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "PongWindow";
            this.Opacity = 0.95D;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PongWindow_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PongWindow_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PongWindow_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.spriteRacket1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteRacket2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteBall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.PictureBox spriteRacket1;
        private System.Windows.Forms.PictureBox spriteRacket2;
        private System.Windows.Forms.PictureBox spriteBall;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button cloneButton1;
        private System.Windows.Forms.Button cloneButton2;
    }
}

