namespace CapaPresentacion
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDePedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.porPeriodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.LemonChiffon;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimientosToolStripMenuItem,
            this.consultasToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(239, 74);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(773, 57);
            this.menuStrip1.TabIndex = 105;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // movimientosToolStripMenuItem
            // 
            this.movimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDePedidosToolStripMenuItem,
            this.devolucionesToolStripMenuItem});
            this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
            this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(148, 55);
            this.movimientosToolStripMenuItem.Text = "Movimientos";
            // 
            // gestiónDePedidosToolStripMenuItem
            // 
            this.gestiónDePedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem1,
            this.consultasToolStripMenuItem});
            this.gestiónDePedidosToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.gestiónDePedidosToolStripMenuItem.Name = "gestiónDePedidosToolStripMenuItem";
            this.gestiónDePedidosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.gestiónDePedidosToolStripMenuItem.Text = "Gestión de pedidos";
            // 
            // registrarToolStripMenuItem1
            // 
            this.registrarToolStripMenuItem1.Name = "registrarToolStripMenuItem1";
            this.registrarToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.registrarToolStripMenuItem1.Text = "Registro";
            this.registrarToolStripMenuItem1.Click += new System.EventHandler(this.registrarToolStripMenuItem1_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fechaToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // fechaToolStripMenuItem
            // 
            this.fechaToolStripMenuItem.Name = "fechaToolStripMenuItem";
            this.fechaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.fechaToolStripMenuItem.Text = "Fecha";
            this.fechaToolStripMenuItem.Click += new System.EventHandler(this.fechaToolStripMenuItem_Click);
            // 
            // devolucionesToolStripMenuItem
            // 
            this.devolucionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem,
            this.consultasToolStripMenuItem1});
            this.devolucionesToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.devolucionesToolStripMenuItem.Name = "devolucionesToolStripMenuItem";
            this.devolucionesToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.devolucionesToolStripMenuItem.Text = "Devoluciones";
            // 
            // registrarToolStripMenuItem
            // 
            this.registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            this.registrarToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.registrarToolStripMenuItem.Text = "Registro";
            this.registrarToolStripMenuItem.Click += new System.EventHandler(this.registrarToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem1
            // 
            this.consultasToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porPeriodoToolStripMenuItem});
            this.consultasToolStripMenuItem1.Name = "consultasToolStripMenuItem1";
            this.consultasToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.consultasToolStripMenuItem1.Text = "Consultas";
            // 
            // porPeriodoToolStripMenuItem
            // 
            this.porPeriodoToolStripMenuItem.Name = "porPeriodoToolStripMenuItem";
            this.porPeriodoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.porPeriodoToolStripMenuItem.Text = "Por periodo";
            this.porPeriodoToolStripMenuItem.Click += new System.EventHandler(this.porPeriodoToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem2
            // 
            this.consultasToolStripMenuItem2.Name = "consultasToolStripMenuItem2";
            this.consultasToolStripMenuItem2.Size = new System.Drawing.Size(119, 55);
            this.consultasToolStripMenuItem2.Text = "Consultas";
            this.consultasToolStripMenuItem2.Click += new System.EventHandler(this.consultasToolStripMenuItem2_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gold;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.lblRol);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.lblUsuario);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(239, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(773, 74);
            this.panel5.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 105;
            this.label1.Text = "Usuario:";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRol.ForeColor = System.Drawing.Color.Black;
            this.lblRol.Location = new System.Drawing.Point(52, 39);
            this.lblRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(40, 19);
            this.lblRol.TabIndex = 104;
            this.lblRol.Text = "ROL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 103;
            this.label2.Text = "Rol:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(89, 20);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(80, 19);
            this.lblUsuario.TabIndex = 102;
            this.lblUsuario.Text = "USUARIO";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 560);
            this.panel1.TabIndex = 103;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 560);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Menu";
            this.Text = "Menú";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDePedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devolucionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porPeriodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem1;
    }
}

