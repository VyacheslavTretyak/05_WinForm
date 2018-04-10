namespace FileViewer
{
	partial class FileViewerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileViewerForm));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.listView1 = new System.Windows.Forms.ListView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbFont = new System.Windows.Forms.ToolStripButton();
			this.tsbFontColor = new System.Windows.Forms.ToolStripButton();
			this.tsbBackColor = new System.Windows.Forms.ToolStripButton();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(221, 502);
			this.treeView1.TabIndex = 0;
			// 
			// listView1
			// 
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
			this.listView1.Location = new System.Drawing.Point(221, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(579, 254);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFont,
            this.tsbFontColor,
            this.tsbBackColor});
			this.toolStrip1.Location = new System.Drawing.Point(221, 254);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(579, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbFont
			// 
			this.tsbFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbFont.Image = ((System.Drawing.Image)(resources.GetObject("tsbFont.Image")));
			this.tsbFont.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbFont.Name = "tsbFont";
			this.tsbFont.Size = new System.Drawing.Size(23, 22);
			this.tsbFont.Text = "tsbFont";
			// 
			// tsbFontColor
			// 
			this.tsbFontColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbFontColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbFontColor.Image")));
			this.tsbFontColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbFontColor.Name = "tsbFontColor";
			this.tsbFontColor.Size = new System.Drawing.Size(23, 22);
			this.tsbFontColor.Text = "tsbFontColor";
			// 
			// tsbBackColor
			// 
			this.tsbBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbBackColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbBackColor.Image")));
			this.tsbBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbBackColor.Name = "tsbBackColor";
			this.tsbBackColor.Size = new System.Drawing.Size(23, 22);
			this.tsbBackColor.Text = "tsbBackColor";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new System.Drawing.Point(221, 279);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(579, 223);
			this.richTextBox1.TabIndex = 4;
			this.richTextBox1.Text = "";
			// 
			// FileViewerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 502);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.treeView1);
			this.Name = "FileViewerForm";
			this.Text = "FileViewer";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbFont;
		private System.Windows.Forms.ToolStripButton tsbFontColor;
		private System.Windows.Forms.ToolStripButton tsbBackColor;
		private System.Windows.Forms.RichTextBox richTextBox1;
	}
}

