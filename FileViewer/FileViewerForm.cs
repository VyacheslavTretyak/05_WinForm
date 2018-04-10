using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;

namespace FileViewer
{
	public partial class FileViewerForm : Form
	{
		private ImageList galarySmall;
		private ImageList galaryLarge;
		public FileViewerForm()
		{
			InitializeComponent();
			LoadContextMenu();
			LoadTreeView();
			LoadListView();
			LoadToolStrip();
			LoadRichBox();
		}

		private void LoadRichBox()
		{
			richTextBox1.AllowDrop = true;
			richTextBox1.DragEnter += RichTextBox1_DragEnter;
			richTextBox1.DragDrop += RichTextBox1_DragDrop;

		}

		private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
		{
			ListViewItem item = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
			FileInfo file = item.Tag as FileInfo;
			StreamReader reader = null;
			try
			{
				reader = new StreamReader(file.FullName);
				richTextBox1.Text = reader.ReadToEnd();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				if(reader != null)
				{
					reader.Close();
				}
			}
		}

		private void RichTextBox1_DragEnter(object sender, DragEventArgs e)
		{
			ListViewItem item = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
			FileInfo file = item.Tag as FileInfo;
			if (file != null)
			{
				if (file.Extension.ToUpper() == ".TXT" || file.Extension.ToUpper() == ".RTF" || file.Extension.ToUpper() == ".LOG" || file.Extension.ToUpper() == ".INI" || file.Extension.ToUpper() == ".CS") 
				{
					e.Effect = DragDropEffects.All;
					return;
				}
			}			
			e.Effect = DragDropEffects.None;
			
		}

		private void LoadToolStrip()
		{
			tsbFont.Click += TsbFont_Click;
			tsbFontColor.Click += TsbFontColor_Click;
			tsbBackColor.Click += TsbBackColor_Click;
		}

		private void TsbBackColor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = richTextBox1.SelectionBackColor;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.SelectionBackColor = colorDialog.Color;
			}
		}

		private void TsbFontColor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = richTextBox1.SelectionColor;
			if(colorDialog.ShowDialog()== DialogResult.OK)
			{
				richTextBox1.SelectionColor = colorDialog.Color;
			}			
		}

		private void TsbFont_Click(object sender, EventArgs e)
		{
			FontDialog fontDialog = new FontDialog();
			fontDialog.ShowColor = true;
			fontDialog.Font = richTextBox1.SelectionFont;
			if(fontDialog.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.SelectionFont = fontDialog.Font;
			}
		}

		private void LoadContextMenu()
		{			
			foreach(object val in Enum.GetValues(typeof(View)))
			{
				ToolStripMenuItem item = new ToolStripMenuItem(val.ToString());
				item.Name = val.ToString();
				item.Click += Item_Click;
				contextMenuStrip1.Items.Add(item);
			}			
		}

		private void Item_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = sender as ToolStripMenuItem;
			listView1.View = (View)Enum.Parse(typeof(View), item.Name);
		}

		private void LoadListView()
		{
			galarySmall = new ImageList();
			galarySmall.ImageSize = new Size(32, 32);
			galaryLarge = new ImageList();
			galaryLarge.ImageSize = new Size(64, 64);
			listView1.SmallImageList = galarySmall;
			listView1.LargeImageList = galaryLarge;
			galarySmall.Images.Add("folder", Resource.folder);
			galaryLarge.Images.Add("folder", Resource.folder);

			listView1.View = View.List;
			listView1.DoubleClick += ListView1_DoubleClick;		
			listView1.Columns.Add("Name",150);
			listView1.Columns.Add("CreationTime", 150);
			listView1.Columns.Add("Count Folder", 50);
			listView1.Columns.Add("Count Files", 50);
			listView1.Columns.Add("Size", 75);
			listView1.ItemDrag += ListView1_ItemDrag;
		}

		private void ListView1_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				listView1.DoDragDrop(listView1.SelectedItems[0], DragDropEffects.All);
			}
		}


		private void ListView1_DoubleClick(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0 && listView1.SelectedItems[0].ImageKey == "folder")
			{
				DirectoryInfo tag = listView1.SelectedItems[0].Tag as DirectoryInfo;
				if (tag != null) {
					LoadListView(tag.FullName);
				}
			}
		}

		private void LoadTreeView()
		{
			treeView1.AfterSelect += TreeView1_AfterSelect; 
			Image img = Resource.folder;
			ImageList imList = new ImageList();
			imList.Images.Add(img);
			treeView1.ImageList = imList;
			foreach (DriveInfo drive in DriveInfo.GetDrives())
			{
				if (drive.IsReady)
				{
					treeView1.Nodes.Add(drive.Name);
				}
			}
		}

		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			LoadListView(e.Node.FullPath);
			if (e.Node.Nodes.Count == 0)
			{
				foreach (string dir in Directory.GetDirectories(e.Node.FullPath))
				{
					DirectoryInfo dirInfo = new DirectoryInfo(dir);
					if ((dirInfo.Attributes & FileAttributes.Hidden) == 0)
					{
						TreeNode node = new TreeNode(dirInfo.Name, 0, 0)
						{
							Tag = dirInfo
						};
						e.Node.Nodes.Add(node);						
					}
				}				
			}
		}

		private void LoadListView(string path)
		{			
			listView1.Items.Clear();			
			foreach (string dir in Directory.GetDirectories(path))
			{
				DirectoryInfo dirInfo = new DirectoryInfo(dir);
				if ((dirInfo.Attributes & FileAttributes.Hidden) == 0)
				{
					ListViewItem item = new ListViewItem(dirInfo.Name, "folder");
					item.Tag = dirInfo;					
					item.SubItems.Add(dirInfo.CreationTime.ToString());
					item.SubItems.Add(dirInfo.GetDirectories().Length.ToString());
					item.SubItems.Add(dirInfo.GetFiles().Length.ToString());					
					listView1.Items.Add(item);
				}
			}
			foreach (string file in Directory.GetFiles(path))
			{
				FileInfo fileInfo = new FileInfo(file);			
				if ((fileInfo.Attributes & FileAttributes.Hidden) == 0)
				{					
					string key = fileInfo.Extension;									
					if (key == ".ICO" || key == ".PNG" || key == ".JPG" || key == ".BMP")
					{
						key = fileInfo.FullName;
						if (!galaryLarge.Images.ContainsKey(key))
						{
							galaryLarge.Images.Add(key, Bitmap.FromFile(fileInfo.FullName));
						}
						if (!galarySmall.Images.ContainsKey(key))
						{
							galarySmall.Images.Add(key, Icon.ExtractAssociatedIcon(fileInfo.FullName).ToBitmap());
						}
					}
					else
					{
						if (!galaryLarge.Images.ContainsKey(key))
						{
							galaryLarge.Images.Add(key, Icon.ExtractAssociatedIcon(fileInfo.FullName).ToBitmap());
						}
						if (!galarySmall.Images.ContainsKey(key))
						{
							galarySmall.Images.Add(key, Icon.ExtractAssociatedIcon(fileInfo.FullName).ToBitmap());
						}
					}

					ListViewItem item = new ListViewItem(fileInfo.Name,  key);
					item.Tag = fileInfo;
					item.SubItems.Add(fileInfo.CreationTime.ToString());
					item.SubItems.Add("");
					item.SubItems.Add("");
					item.SubItems.Add($"{(int)fileInfo.Length/1000} KB");
					listView1.Items.Add(item);
				}
			}
		}

	}
}
