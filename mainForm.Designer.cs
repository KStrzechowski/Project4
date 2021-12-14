
namespace Project4
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.optionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.createPolygonButton = new System.Windows.Forms.Button();
            this.createCuboidButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.mainTableLayoutPanel.SuspendLayout();
            this.optionsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.mainTableLayoutPanel.Controls.Add(this.optionsTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.mainPictureBox, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(984, 561);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // optionsTableLayoutPanel
            // 
            this.optionsTableLayoutPanel.ColumnCount = 2;
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optionsTableLayoutPanel.Controls.Add(this.createPolygonButton, 1, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.createCuboidButton, 0, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.addButton, 1, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.deleteButton, 0, 3);
            this.optionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            this.optionsTableLayoutPanel.RowCount = 4;
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.optionsTableLayoutPanel.Size = new System.Drawing.Size(190, 555);
            this.optionsTableLayoutPanel.TabIndex = 0;
            // 
            // createPolygonButton
            // 
            this.createPolygonButton.Location = new System.Drawing.Point(98, 279);
            this.createPolygonButton.Name = "createPolygonButton";
            this.createPolygonButton.Size = new System.Drawing.Size(89, 64);
            this.createPolygonButton.TabIndex = 2;
            this.createPolygonButton.Text = "Create Polygon";
            this.createPolygonButton.UseVisualStyleBackColor = true;
            this.createPolygonButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.createPolygonButton_MouseDown);
            // 
            // createCuboidButton
            // 
            this.createCuboidButton.Location = new System.Drawing.Point(3, 279);
            this.createCuboidButton.Name = "createCuboidButton";
            this.createCuboidButton.Size = new System.Drawing.Size(89, 64);
            this.createCuboidButton.TabIndex = 3;
            this.createCuboidButton.Text = "Create Cuboid";
            this.createCuboidButton.UseVisualStyleBackColor = true;
            this.createCuboidButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.createCuboidButton_MouseDown);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(98, 417);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(89, 49);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.addButton_MouseDown);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(3, 417);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(89, 49);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.deleteButton_MouseDown);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPictureBox.BackColor = System.Drawing.Color.White;
            this.mainPictureBox.Location = new System.Drawing.Point(199, 3);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(782, 555);
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "mainForm";
            this.Text = "Project 4";
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel optionsTableLayoutPanel;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button createPolygonButton;
        private System.Windows.Forms.Button createCuboidButton;
    }
}

