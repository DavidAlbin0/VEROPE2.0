﻿namespace ManagerCont
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rANDOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aRCHIVOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rANDOMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gUARDARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gUARDARRANDOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gUARDARCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarSaldosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button9 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.Location = new System.Drawing.Point(743, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(693, 553);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(30, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Seleccione un archivo";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(240, 66);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.Text = "Mes";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.White;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(383, 66);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 24);
            this.comboBox3.TabIndex = 5;
            this.comboBox3.Text = "Empresa";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button7.Location = new System.Drawing.Point(1318, 31);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(125, 44);
            this.button7.TabIndex = 7;
            this.button7.Text = "Subir Archivo";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button8.Location = new System.Drawing.Point(1268, 704);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(168, 44);
            this.button8.TabIndex = 8;
            this.button8.Text = "Guardar Archivo";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1319, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "ARCHIVO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(1319, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "ARCHIVO";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rANDOMToolStripMenuItem,
            this.cSVToolStripMenuItem,
            this.toolStripComboBox1});
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.Size = new System.Drawing.Size(182, 84);
            // 
            // rANDOMToolStripMenuItem
            // 
            this.rANDOMToolStripMenuItem.Name = "rANDOMToolStripMenuItem";
            this.rANDOMToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.rANDOMToolStripMenuItem.Text = "RANDOM";
            // 
            // cSVToolStripMenuItem
            // 
            this.cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            this.cSVToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.cSVToolStripMenuItem.Text = "CSV";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subirArchivoToolStripMenuItem,
            this.gUARDARToolStripMenuItem,
            this.borrarSaldosToolStripMenuItem,
            this.buscarToolStripMenuItem,
            this.borrarToolStripMenuItem,
            this.aRCHIVOToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1455, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aRCHIVOToolStripMenuItem
            // 
            this.aRCHIVOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rANDOMToolStripMenuItem1});
            this.aRCHIVOToolStripMenuItem.Name = "aRCHIVOToolStripMenuItem";
            this.aRCHIVOToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.aRCHIVOToolStripMenuItem.Text = "Archivo";
            // 
            // rANDOMToolStripMenuItem1
            // 
            this.rANDOMToolStripMenuItem1.Name = "rANDOMToolStripMenuItem1";
            this.rANDOMToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.rANDOMToolStripMenuItem1.Text = "Random";
            this.rANDOMToolStripMenuItem1.Click += new System.EventHandler(this.rANDOMToolStripMenuItem1_Click);
            // 
            // gUARDARToolStripMenuItem
            // 
            this.gUARDARToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gUARDARRANDOMToolStripMenuItem,
            this.gUARDARCSVToolStripMenuItem});
            this.gUARDARToolStripMenuItem.Name = "gUARDARToolStripMenuItem";
            this.gUARDARToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.gUARDARToolStripMenuItem.Text = "Guardar";
            // 
            // gUARDARRANDOMToolStripMenuItem
            // 
            this.gUARDARRANDOMToolStripMenuItem.Name = "gUARDARRANDOMToolStripMenuItem";
            this.gUARDARRANDOMToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gUARDARRANDOMToolStripMenuItem.Text = "Random";
            this.gUARDARRANDOMToolStripMenuItem.Click += new System.EventHandler(this.gUARDARRANDOMToolStripMenuItem_Click);
            // 
            // gUARDARCSVToolStripMenuItem
            // 
            this.gUARDARCSVToolStripMenuItem.Name = "gUARDARCSVToolStripMenuItem";
            this.gUARDARCSVToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gUARDARCSVToolStripMenuItem.Text = "Csv";
            this.gUARDARCSVToolStripMenuItem.Click += new System.EventHandler(this.gUARDARCSVToolStripMenuItem_Click);
            // 
            // borrarSaldosToolStripMenuItem
            // 
            this.borrarSaldosToolStripMenuItem.Name = "borrarSaldosToolStripMenuItem";
            this.borrarSaldosToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.borrarSaldosToolStripMenuItem.Text = "Borrar Saldos";
            this.borrarSaldosToolStripMenuItem.Click += new System.EventHandler(this.borrarSaldosToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarDatosToolStripMenuItem});
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.buscarToolStripMenuItem.Text = "Buscar";
            // 
            // modificarDatosToolStripMenuItem
            // 
            this.modificarDatosToolStripMenuItem.Name = "modificarDatosToolStripMenuItem";
            this.modificarDatosToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.modificarDatosToolStripMenuItem.Text = "Modificar Datos";
            this.modificarDatosToolStripMenuItem.Click += new System.EventHandler(this.modificarDatosToolStripMenuItem_Click);
            // 
            // subirArchivoToolStripMenuItem
            // 
            this.subirArchivoToolStripMenuItem.Name = "subirArchivoToolStripMenuItem";
            this.subirArchivoToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.subirArchivoToolStripMenuItem.Text = "Subir archivo";
            this.subirArchivoToolStripMenuItem.Click += new System.EventHandler(this.subirArchivoToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(1144, 704);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 44);
            this.button1.TabIndex = 16;
            this.button1.Text = "Dar formato";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(902, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 31);
            this.button3.TabIndex = 17;
            this.button3.Text = "Dar formato";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox1.Location = new System.Drawing.Point(1034, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 22);
            this.textBox1.TabIndex = 18;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeight = 29;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView2.Location = new System.Drawing.Point(12, 142);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(693, 556);
            this.dataGridView2.TabIndex = 21;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(30, 704);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(117, 26);
            this.button9.TabIndex = 23;
            this.button9.Text = "ENVIAR";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 24;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(770, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "Actualizar datos";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.BackgroundImage = global::ManagerCont.Properties.Resources.copiar__2_;
            this.button6.Location = new System.Drawing.Point(706, 96);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(41, 41);
            this.button6.TabIndex = 22;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.UseWaitCursor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Image = global::ManagerCont.Properties.Resources.flecha_correcta__2_;
            this.button5.Location = new System.Drawing.Point(1272, 103);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(41, 24);
            this.button5.TabIndex = 20;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::ManagerCont.Properties.Resources.lupappa__1_;
            this.button4.Location = new System.Drawing.Point(1235, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 27);
            this.button4.TabIndex = 19;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.originalToolStripMenuItem,
            this.copiaToolStripMenuItem});
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.borrarToolStripMenuItem.Text = "Borrar";
            // 
            // originalToolStripMenuItem
            // 
            this.originalToolStripMenuItem.Name = "originalToolStripMenuItem";
            this.originalToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.originalToolStripMenuItem.Text = "Original";
            this.originalToolStripMenuItem.Click += new System.EventHandler(this.originalToolStripMenuItem_Click);
            // 
            // copiaToolStripMenuItem
            // 
            this.copiaToolStripMenuItem.Name = "copiaToolStripMenuItem";
            this.copiaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.copiaToolStripMenuItem.Text = "Copia";
            this.copiaToolStripMenuItem.Click += new System.EventHandler(this.copiaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1455, 750);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Veroper 2024";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ToolStripMenuItem rANDOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aRCHIVOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rANDOMToolStripMenuItem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem gUARDARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gUARDARRANDOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gUARDARCSVToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem borrarSaldosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subirArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiaToolStripMenuItem;
    }
}

