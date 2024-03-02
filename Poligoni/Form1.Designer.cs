namespace Poligoni
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
            this.tbYInput = new System.Windows.Forms.TextBox();
            this.tbXInput = new System.Windows.Forms.TextBox();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnConvex = new System.Windows.Forms.Button();
            this.btnPerimetar = new System.Windows.Forms.Button();
            this.btnSurfaceArea = new System.Windows.Forms.Button();
            this.btnIntersection = new System.Windows.Forms.Button();
            this.ConvexHull = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbYInput
            // 
            this.tbYInput.Location = new System.Drawing.Point(688, 12);
            this.tbYInput.Name = "tbYInput";
            this.tbYInput.Size = new System.Drawing.Size(100, 20);
            this.tbYInput.TabIndex = 1;
            // 
            // tbXInput
            // 
            this.tbXInput.Location = new System.Drawing.Point(582, 12);
            this.tbXInput.Name = "tbXInput";
            this.tbXInput.Size = new System.Drawing.Size(100, 20);
            this.tbXInput.TabIndex = 0;
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Location = new System.Drawing.Point(713, 38);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(75, 23);
            this.btnAddPoint.TabIndex = 2;
            this.btnAddPoint.Text = "Dodaj tacku";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddVertex_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(713, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Sacuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(713, 386);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Ucitaj";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(607, 388);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(100, 20);
            this.tbFolder.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(713, 67);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Ocisti";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnConvex
            // 
            this.btnConvex.Location = new System.Drawing.Point(713, 96);
            this.btnConvex.Name = "btnConvex";
            this.btnConvex.Size = new System.Drawing.Size(75, 23);
            this.btnConvex.TabIndex = 4;
            this.btnConvex.Text = "Konveksan";
            this.btnConvex.UseVisualStyleBackColor = true;
            this.btnConvex.Click += new System.EventHandler(this.btnConvex_Click);
            // 
            // btnPerimetar
            // 
            this.btnPerimetar.Location = new System.Drawing.Point(713, 125);
            this.btnPerimetar.Name = "btnPerimetar";
            this.btnPerimetar.Size = new System.Drawing.Size(75, 23);
            this.btnPerimetar.TabIndex = 5;
            this.btnPerimetar.Text = "Obim";
            this.btnPerimetar.UseVisualStyleBackColor = true;
            this.btnPerimetar.Click += new System.EventHandler(this.btnPerimetar_Click);
            // 
            // btnSurfaceArea
            // 
            this.btnSurfaceArea.Location = new System.Drawing.Point(713, 154);
            this.btnSurfaceArea.Name = "btnSurfaceArea";
            this.btnSurfaceArea.Size = new System.Drawing.Size(75, 23);
            this.btnSurfaceArea.TabIndex = 6;
            this.btnSurfaceArea.Text = "Povrsina";
            this.btnSurfaceArea.UseVisualStyleBackColor = true;
            this.btnSurfaceArea.Click += new System.EventHandler(this.btnSurfaceArea_Click);
            // 
            // btnIntersection
            // 
            this.btnIntersection.Location = new System.Drawing.Point(713, 183);
            this.btnIntersection.Name = "btnIntersection";
            this.btnIntersection.Size = new System.Drawing.Size(75, 23);
            this.btnIntersection.TabIndex = 10;
            this.btnIntersection.Text = "Presek";
            this.btnIntersection.UseVisualStyleBackColor = true;
            this.btnIntersection.Click += new System.EventHandler(this.btnIntersection_Click);
            // 
            // ConvexHull
            // 
            this.ConvexHull.Location = new System.Drawing.Point(713, 212);
            this.ConvexHull.Name = "ConvexHull";
            this.ConvexHull.Size = new System.Drawing.Size(75, 23);
            this.ConvexHull.TabIndex = 11;
            this.ConvexHull.Text = "Omotac";
            this.ConvexHull.UseVisualStyleBackColor = true;
            this.ConvexHull.Click += new System.EventHandler(this.ConvexHull_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConvexHull);
            this.Controls.Add(this.btnIntersection);
            this.Controls.Add(this.btnSurfaceArea);
            this.Controls.Add(this.btnPerimetar);
            this.Controls.Add(this.btnConvex);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbFolder);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddPoint);
            this.Controls.Add(this.tbXInput);
            this.Controls.Add(this.tbYInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbYInput;
        private System.Windows.Forms.TextBox tbXInput;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnConvex;
        private System.Windows.Forms.Button btnPerimetar;
        private System.Windows.Forms.Button btnSurfaceArea;
        private System.Windows.Forms.Button btnIntersection;
        private System.Windows.Forms.Button ConvexHull;
    }
}

