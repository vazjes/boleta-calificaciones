namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.miPanelTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpRegistro = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCategoriaRegistro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConcepto = new System.Windows.Forms.TextBox();
            this.rbEgreso = new System.Windows.Forms.RadioButton();
            this.rbIngreso = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCategoriaConsultar = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCantidadConsultar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbConceptoConsultar = new System.Windows.Forms.TextBox();
            this.rbEgresoConsultar = new System.Windows.Forms.RadioButton();
            this.rbAmbosConsultar = new System.Windows.Forms.RadioButton();
            this.rbIngresoConsultar = new System.Windows.Forms.RadioButton();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.cbAccionCategorias = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnRealizarCategoria = new System.Windows.Forms.Button();
            this.tbAgregarCategoria = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.miPanelTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvResultados.Location = new System.Drawing.Point(287, 59);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.Size = new System.Drawing.Size(572, 342);
            this.dgvResultados.TabIndex = 6;
            this.dgvResultados.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvResultados_CellBeginEdit);
            this.dgvResultados.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultados_CellEndEdit);
            this.dgvResultados.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResultados_RowHeaderMouseDoubleClick);
            // 
            // miPanelTab
            // 
            this.miPanelTab.Controls.Add(this.tabPage1);
            this.miPanelTab.Controls.Add(this.tabPage2);
            this.miPanelTab.Controls.Add(this.tabPage3);
            this.miPanelTab.Location = new System.Drawing.Point(12, 39);
            this.miPanelTab.Name = "miPanelTab";
            this.miPanelTab.SelectedIndex = 0;
            this.miPanelTab.Size = new System.Drawing.Size(255, 362);
            this.miPanelTab.TabIndex = 11;
            this.miPanelTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.miPanelTab_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRegistrar);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dtpRegistro);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbCategoriaRegistro);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbCantidad);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbConcepto);
            this.tabPage1.Controls.Add(this.rbEgreso);
            this.tabPage1.Controls.Add(this.rbIngreso);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(247, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Registro";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(25, 286);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(118, 33);
            this.btnRegistrar.TabIndex = 21;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Fecha";
            // 
            // dtpRegistro
            // 
            this.dtpRegistro.Location = new System.Drawing.Point(23, 245);
            this.dtpRegistro.Name = "dtpRegistro";
            this.dtpRegistro.Size = new System.Drawing.Size(200, 20);
            this.dtpRegistro.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Categoría";
            // 
            // cbCategoriaRegistro
            // 
            this.cbCategoriaRegistro.FormattingEnabled = true;
            this.cbCategoriaRegistro.Location = new System.Drawing.Point(22, 198);
            this.cbCategoriaRegistro.Name = "cbCategoriaRegistro";
            this.cbCategoriaRegistro.Size = new System.Drawing.Size(121, 21);
            this.cbCategoriaRegistro.TabIndex = 17;
            this.cbCategoriaRegistro.Click += new System.EventHandler(this.cbCategoriaRegistro_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Cantidad";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(22, 145);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(172, 20);
            this.tbCantidad.TabIndex = 15;
            this.tbCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidad_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Concepto";
            // 
            // tbConcepto
            // 
            this.tbConcepto.Location = new System.Drawing.Point(21, 95);
            this.tbConcepto.Name = "tbConcepto";
            this.tbConcepto.Size = new System.Drawing.Size(172, 20);
            this.tbConcepto.TabIndex = 13;
            this.tbConcepto.TextChanged += new System.EventHandler(this.tbConcepto_TextChanged);
            this.tbConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbConcepto_KeyPress);
            // 
            // rbEgreso
            // 
            this.rbEgreso.AutoSize = true;
            this.rbEgreso.Location = new System.Drawing.Point(102, 31);
            this.rbEgreso.Name = "rbEgreso";
            this.rbEgreso.Size = new System.Drawing.Size(58, 17);
            this.rbEgreso.TabIndex = 12;
            this.rbEgreso.TabStop = true;
            this.rbEgreso.Text = "Egreso";
            this.rbEgreso.UseVisualStyleBackColor = true;
            // 
            // rbIngreso
            // 
            this.rbIngreso.AutoSize = true;
            this.rbIngreso.Location = new System.Drawing.Point(21, 31);
            this.rbIngreso.Name = "rbIngreso";
            this.rbIngreso.Size = new System.Drawing.Size(60, 17);
            this.rbIngreso.TabIndex = 11;
            this.rbIngreso.TabStop = true;
            this.rbIngreso.Text = "Ingreso";
            this.rbIngreso.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.dtpFechaFinal);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dtpFechaInicial);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbCategoriaConsultar);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tbCantidadConsultar);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbConceptoConsultar);
            this.tabPage2.Controls.Add(this.rbEgresoConsultar);
            this.tabPage2.Controls.Add(this.rbAmbosConsultar);
            this.tabPage2.Controls.Add(this.rbIngresoConsultar);
            this.tabPage2.Controls.Add(this.btnConsultar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(247, 336);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consultar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Fecha Final";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(27, 256);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFinal.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Fecha Inicial";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Location = new System.Drawing.Point(26, 214);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicial.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Categoría";
            // 
            // cbCategoriaConsultar
            // 
            this.cbCategoriaConsultar.FormattingEnabled = true;
            this.cbCategoriaConsultar.Location = new System.Drawing.Point(25, 165);
            this.cbCategoriaConsultar.Name = "cbCategoriaConsultar";
            this.cbCategoriaConsultar.Size = new System.Drawing.Size(121, 21);
            this.cbCategoriaConsultar.TabIndex = 25;
            this.cbCategoriaConsultar.Click += new System.EventHandler(this.cbCategoriaConsultar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Cantidad";
            // 
            // tbCantidadConsultar
            // 
            this.tbCantidadConsultar.Location = new System.Drawing.Point(25, 114);
            this.tbCantidadConsultar.Name = "tbCantidadConsultar";
            this.tbCantidadConsultar.Size = new System.Drawing.Size(172, 20);
            this.tbCantidadConsultar.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Concepto";
            // 
            // tbConceptoConsultar
            // 
            this.tbConceptoConsultar.Location = new System.Drawing.Point(24, 71);
            this.tbConceptoConsultar.Name = "tbConceptoConsultar";
            this.tbConceptoConsultar.Size = new System.Drawing.Size(172, 20);
            this.tbConceptoConsultar.TabIndex = 21;
            // 
            // rbEgresoConsultar
            // 
            this.rbEgresoConsultar.AutoSize = true;
            this.rbEgresoConsultar.Location = new System.Drawing.Point(94, 26);
            this.rbEgresoConsultar.Name = "rbEgresoConsultar";
            this.rbEgresoConsultar.Size = new System.Drawing.Size(58, 17);
            this.rbEgresoConsultar.TabIndex = 3;
            this.rbEgresoConsultar.TabStop = true;
            this.rbEgresoConsultar.Text = "Egreso";
            this.rbEgresoConsultar.UseVisualStyleBackColor = true;
            // 
            // rbAmbosConsultar
            // 
            this.rbAmbosConsultar.AutoSize = true;
            this.rbAmbosConsultar.Location = new System.Drawing.Point(158, 26);
            this.rbAmbosConsultar.Name = "rbAmbosConsultar";
            this.rbAmbosConsultar.Size = new System.Drawing.Size(57, 17);
            this.rbAmbosConsultar.TabIndex = 2;
            this.rbAmbosConsultar.TabStop = true;
            this.rbAmbosConsultar.Text = "Ambos";
            this.rbAmbosConsultar.UseVisualStyleBackColor = true;
            // 
            // rbIngresoConsultar
            // 
            this.rbIngresoConsultar.AutoSize = true;
            this.rbIngresoConsultar.Location = new System.Drawing.Point(26, 26);
            this.rbIngresoConsultar.Name = "rbIngresoConsultar";
            this.rbIngresoConsultar.Size = new System.Drawing.Size(60, 17);
            this.rbIngresoConsultar.TabIndex = 1;
            this.rbIngresoConsultar.TabStop = true;
            this.rbIngresoConsultar.Text = "Ingreso";
            this.rbIngresoConsultar.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(150, 295);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(77, 24);
            this.btnConsultar.TabIndex = 0;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.cbAccionCategorias);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.btnRealizarCategoria);
            this.tabPage3.Controls.Add(this.tbAgregarCategoria);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(247, 336);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Categorías";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Acción";
            // 
            // cbAccionCategorias
            // 
            this.cbAccionCategorias.FormattingEnabled = true;
            this.cbAccionCategorias.Location = new System.Drawing.Point(27, 40);
            this.cbAccionCategorias.Name = "cbAccionCategorias";
            this.cbAccionCategorias.Size = new System.Drawing.Size(121, 21);
            this.cbAccionCategorias.TabIndex = 3;
            this.cbAccionCategorias.SelectedIndexChanged += new System.EventHandler(this.cbAccionCategorias_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Categoría";
            // 
            // btnRealizarCategoria
            // 
            this.btnRealizarCategoria.Location = new System.Drawing.Point(27, 123);
            this.btnRealizarCategoria.Name = "btnRealizarCategoria";
            this.btnRealizarCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnRealizarCategoria.TabIndex = 1;
            this.btnRealizarCategoria.Text = "Realizar";
            this.btnRealizarCategoria.UseVisualStyleBackColor = true;
            this.btnRealizarCategoria.Click += new System.EventHandler(this.btnRealizarCategoria_Click);
            // 
            // tbAgregarCategoria
            // 
            this.tbAgregarCategoria.Location = new System.Drawing.Point(27, 91);
            this.tbAgregarCategoria.Name = "tbAgregarCategoria";
            this.tbAgregarCategoria.Size = new System.Drawing.Size(158, 20);
            this.tbAgregarCategoria.TabIndex = 0;
            this.tbAgregarCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAgregarCategoria_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 433);
            this.Controls.Add(this.miPanelTab);
            this.Controls.Add(this.dgvResultados);
            this.Name = "Form1";
            this.Text = "Control de Gastos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.miPanelTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.TabControl miPanelTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpRegistro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCategoriaRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConcepto;
        private System.Windows.Forms.RadioButton rbEgreso;
        private System.Windows.Forms.RadioButton rbIngreso;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCategoriaConsultar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCantidadConsultar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbConceptoConsultar;
        private System.Windows.Forms.RadioButton rbEgresoConsultar;
        private System.Windows.Forms.RadioButton rbAmbosConsultar;
        private System.Windows.Forms.RadioButton rbIngresoConsultar;
        private System.Windows.Forms.Button btnRealizarCategoria;
        private System.Windows.Forms.TextBox tbAgregarCategoria;
        private System.Windows.Forms.ComboBox cbAccionCategorias;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

