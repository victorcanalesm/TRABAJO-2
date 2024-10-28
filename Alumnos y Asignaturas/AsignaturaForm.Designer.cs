namespace Alumnos_y_Asignaturas
{
    partial class AsignaturaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxNomAsignatura = new System.Windows.Forms.TextBox();
            this.BoxCreditos = new System.Windows.Forms.TextBox();
            this.alumnos_y_AsignaturasDataSet = new Alumnos_y_Asignaturas.Alumnos_y_AsignaturasDataSet();
            this.alumnos_y_AsignaturasDataSet1 = new Alumnos_y_Asignaturas.Alumnos_y_AsignaturasDataSet1();
            this.asignaturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.asignaturasTableAdapter = new Alumnos_y_Asignaturas.Alumnos_y_AsignaturasDataSet1TableAdapters.AsignaturasTableAdapter();
            this.CT_mod = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.alumnos_y_AsignaturasDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnos_y_AsignaturasDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asignaturasBindingSource)).BeginInit();
            this.CT_mod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = " Nombre asignatura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = " Creditos";
            // 
            // BoxNomAsignatura
            // 
            this.BoxNomAsignatura.Location = new System.Drawing.Point(68, 118);
            this.BoxNomAsignatura.Name = "BoxNomAsignatura";
            this.BoxNomAsignatura.Size = new System.Drawing.Size(100, 22);
            this.BoxNomAsignatura.TabIndex = 2;
            // 
            // BoxCreditos
            // 
            this.BoxCreditos.Location = new System.Drawing.Point(68, 218);
            this.BoxCreditos.Name = "BoxCreditos";
            this.BoxCreditos.Size = new System.Drawing.Size(100, 22);
            this.BoxCreditos.TabIndex = 3;
            // 
            // alumnos_y_AsignaturasDataSet
            // 
            this.alumnos_y_AsignaturasDataSet.DataSetName = "Alumnos_y_AsignaturasDataSet";
            this.alumnos_y_AsignaturasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // alumnos_y_AsignaturasDataSet1
            // 
            this.alumnos_y_AsignaturasDataSet1.DataSetName = "Alumnos_y_AsignaturasDataSet1";
            this.alumnos_y_AsignaturasDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // asignaturasBindingSource
            // 
            this.asignaturasBindingSource.DataMember = "Asignaturas";
            this.asignaturasBindingSource.DataSource = this.alumnos_y_AsignaturasDataSet1;
            // 
            // asignaturasTableAdapter
            // 
            this.asignaturasTableAdapter.ClearBeforeFill = true;
            // 
            // CT_mod
            // 
            this.CT_mod.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CT_mod.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.CT_mod.Name = "CT_mod";
            this.CT_mod.Size = new System.Drawing.Size(143, 52);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "Insertar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.CT_mod;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(249, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(516, 321);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = " Para modificar o Eliminar segundo click en la tabla ";
            // 
            // AsignaturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BoxCreditos);
            this.Controls.Add(this.BoxNomAsignatura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AsignaturaForm";
            this.Text = "Asignatura";
            this.Load += new System.EventHandler(this.AsignaturaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alumnos_y_AsignaturasDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnos_y_AsignaturasDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asignaturasBindingSource)).EndInit();
            this.CT_mod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoxNomAsignatura;
        private System.Windows.Forms.TextBox BoxCreditos;
        private Alumnos_y_AsignaturasDataSet alumnos_y_AsignaturasDataSet;
        private Alumnos_y_AsignaturasDataSet1 alumnos_y_AsignaturasDataSet1;
        private System.Windows.Forms.BindingSource asignaturasBindingSource;
        private Alumnos_y_AsignaturasDataSet1TableAdapters.AsignaturasTableAdapter asignaturasTableAdapter;
        private System.Windows.Forms.ContextMenuStrip CT_mod;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
    }
}