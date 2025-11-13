using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using M3SaveEditor2.Properties;

namespace M3SaveEditor2;

public class frmMain : Form
{
	private IContainer components;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem fileToolStripMenuItem;

	private ToolStripMenuItem mnuOpen;

	private ToolStripMenuItem mnuSave;

	private ToolStripSeparator toolStripMenuItem1;

	private ToolStripMenuItem exitToolStripMenuItem;

	private TabControl tabControl;

	private TabPage tabStats;

	private TabPage tabItems;

	private Label label1;

	private ComboBox cboCharStats;

	private OpenFileDialog dlgOpen;

	private ToolStripMenuItem fileSlotToolStripMenuItem;

	private ToolStripMenuItem mnuFileSlot1;

	private ToolStripMenuItem mnuFileSlot2;

	private TextBox txtName;

	private TextBox txtDef;

	private TextBox txtOff;

	private Label label3;

	private TextBox txtMaxPP;

	private TextBox txtCurPP;

	private Label label2;

	private TextBox txtMaxHP;

	private TextBox txtCurHP;

	private TextBox txtExp;

	private TextBox txtLevel;

	private TextBox txtSpeed;

	private TextBox txtIQ;

	private Label label6;

	private Label label5;

	private Label label4;

	private Label lblAfterHP;

	private Label label13;

	private Label label12;

	private Label label11;

	private Label label10;

	private Label label9;

	private Label label8;

	private Label label7;

	private Label lblAfterSpeed;

	private Label lblAfterIQ;

	private Label lblAfterDef;

	private Label lblAfterOff;

	private Label lblAfterPP;

	private Label lblInventory;

	private Label label14;

	private ComboBox cboCharItems;

	private ToolStripMenuItem mnuClose;

	private Button btnAddItem;

	private ComboBox cboItem;

	private TabPage tabItemGuy;

	private TextBox txtItemGuy;

	private ListBox lstItemGuy;

	private Button btnItemGuyFill;

	private Button btnItemGuySet;

	private Button btnSaveChanges;

	private Label label17;

	private Label label16;

	private Label label15;

	private TextBox txtFavThing;

	private TextBox txtFavFood;

	private TextBox txtPlayerName;

	private TextBox txtHinawa;

	private Label label18;

	private TabPage tabOther;

	private GroupBox grpParty;

	private ListBox lstParty;

	private ComboBox cboParty;

	private GroupBox grpPSI;

	private RadioButton optPSIKumatora;

	private RadioButton optPSILucas;

	private CheckedListBox lstPSI;

	private Button btnPSINone;

	private Button btnPSIAll;

	private Label lblPSICount;

	private Label label19;

	private Mother3SaveFile saver = new Mother3SaveFile();

	private FileStream fSaver;

	private bool isLoaded;

	private int curSlot;

	private int curItem;

	private Label[] lblItem = new Label[16];

	private Label[] lblEquip = new Label[4];

	private Label[] lblEquipLabel = new Label[4];

	private ContextMenu mnuEquipMenu = new ContextMenu();

	private MenuItem[] mnuEquip = new MenuItem[4];

	private MenuItem mnuItemDelete = new MenuItem("Remove");

	private MenuItem mnuEquipDelete = new MenuItem("Remove");

	private ContextMenu mnuEquipDeleteMenu = new ContextMenu();

	private string[] equipLabels = new string[4] { "Weapon", "Body", "Head", "Other" };

	private bool comboThinger1;

	private bool comboThinger2 = true;

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(M3SaveEditor2.frmMain));
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
		this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.fileSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuFileSlot1 = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuFileSlot2 = new System.Windows.Forms.ToolStripMenuItem();
		this.tabControl = new System.Windows.Forms.TabControl();
		this.tabStats = new System.Windows.Forms.TabPage();
		this.label18 = new System.Windows.Forms.Label();
		this.label17 = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.txtFavThing = new System.Windows.Forms.TextBox();
		this.txtFavFood = new System.Windows.Forms.TextBox();
		this.txtPlayerName = new System.Windows.Forms.TextBox();
		this.txtHinawa = new System.Windows.Forms.TextBox();
		this.lblAfterSpeed = new System.Windows.Forms.Label();
		this.lblAfterIQ = new System.Windows.Forms.Label();
		this.lblAfterDef = new System.Windows.Forms.Label();
		this.lblAfterOff = new System.Windows.Forms.Label();
		this.lblAfterPP = new System.Windows.Forms.Label();
		this.lblAfterHP = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.txtSpeed = new System.Windows.Forms.TextBox();
		this.txtIQ = new System.Windows.Forms.TextBox();
		this.txtDef = new System.Windows.Forms.TextBox();
		this.txtOff = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.txtMaxPP = new System.Windows.Forms.TextBox();
		this.txtCurPP = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.txtMaxHP = new System.Windows.Forms.TextBox();
		this.txtCurHP = new System.Windows.Forms.TextBox();
		this.txtExp = new System.Windows.Forms.TextBox();
		this.txtLevel = new System.Windows.Forms.TextBox();
		this.txtName = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.cboCharStats = new System.Windows.Forms.ComboBox();
		this.tabItems = new System.Windows.Forms.TabPage();
		this.btnAddItem = new System.Windows.Forms.Button();
		this.cboItem = new System.Windows.Forms.ComboBox();
		this.label14 = new System.Windows.Forms.Label();
		this.cboCharItems = new System.Windows.Forms.ComboBox();
		this.lblInventory = new System.Windows.Forms.Label();
		this.tabItemGuy = new System.Windows.Forms.TabPage();
		this.btnItemGuyFill = new System.Windows.Forms.Button();
		this.btnItemGuySet = new System.Windows.Forms.Button();
		this.txtItemGuy = new System.Windows.Forms.TextBox();
		this.lstItemGuy = new System.Windows.Forms.ListBox();
		this.tabOther = new System.Windows.Forms.TabPage();
		this.grpPSI = new System.Windows.Forms.GroupBox();
		this.lstPSI = new System.Windows.Forms.CheckedListBox();
		this.optPSIKumatora = new System.Windows.Forms.RadioButton();
		this.optPSILucas = new System.Windows.Forms.RadioButton();
		this.grpParty = new System.Windows.Forms.GroupBox();
		this.cboParty = new System.Windows.Forms.ComboBox();
		this.lstParty = new System.Windows.Forms.ListBox();
		this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
		this.btnSaveChanges = new System.Windows.Forms.Button();
		this.btnPSIAll = new System.Windows.Forms.Button();
		this.btnPSINone = new System.Windows.Forms.Button();
		this.lblPSICount = new System.Windows.Forms.Label();
		this.label19 = new System.Windows.Forms.Label();
		this.menuStrip1.SuspendLayout();
		this.tabControl.SuspendLayout();
		this.tabStats.SuspendLayout();
		this.tabItems.SuspendLayout();
		this.tabItemGuy.SuspendLayout();
		this.tabOther.SuspendLayout();
		this.grpPSI.SuspendLayout();
		this.grpParty.SuspendLayout();
		base.SuspendLayout();
		this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.fileToolStripMenuItem, this.fileSlotToolStripMenuItem });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Size = new System.Drawing.Size(456, 24);
		this.menuStrip1.TabIndex = 0;
		this.menuStrip1.Text = "menuStrip1";
		this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.mnuOpen, this.mnuSave, this.mnuClose, this.toolStripMenuItem1, this.exitToolStripMenuItem });
		this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
		this.fileToolStripMenuItem.Text = "File";
		this.mnuOpen.Image = M3SaveEditor2.Properties.Resources.folder;
		this.mnuOpen.Name = "mnuOpen";
		this.mnuOpen.ShortcutKeys = System.Windows.Forms.Keys.O | System.Windows.Forms.Keys.Control;
		this.mnuOpen.Size = new System.Drawing.Size(155, 22);
		this.mnuOpen.Text = "Open...";
		this.mnuOpen.Click += new System.EventHandler(mnuOpen_Click);
		this.mnuSave.Enabled = false;
		this.mnuSave.Image = M3SaveEditor2.Properties.Resources.disk;
		this.mnuSave.Name = "mnuSave";
		this.mnuSave.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;
		this.mnuSave.Size = new System.Drawing.Size(155, 22);
		this.mnuSave.Text = "Save";
		this.mnuSave.Click += new System.EventHandler(mnuSave_Click);
		this.mnuClose.Enabled = false;
		this.mnuClose.Name = "mnuClose";
		this.mnuClose.Size = new System.Drawing.Size(155, 22);
		this.mnuClose.Text = "Close";
		this.mnuClose.Click += new System.EventHandler(mnuClose_Click);
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
		this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
		this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
		this.exitToolStripMenuItem.Text = "Exit";
		this.exitToolStripMenuItem.Click += new System.EventHandler(exitToolStripMenuItem_Click);
		this.fileSlotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.mnuFileSlot1, this.mnuFileSlot2 });
		this.fileSlotToolStripMenuItem.Name = "fileSlotToolStripMenuItem";
		this.fileSlotToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
		this.fileSlotToolStripMenuItem.Text = "File slot";
		this.mnuFileSlot1.Enabled = false;
		this.mnuFileSlot1.Name = "mnuFileSlot1";
		this.mnuFileSlot1.Size = new System.Drawing.Size(80, 22);
		this.mnuFileSlot1.Text = "1";
		this.mnuFileSlot1.Click += new System.EventHandler(mnuFileSlot1_Click);
		this.mnuFileSlot2.Enabled = false;
		this.mnuFileSlot2.Name = "mnuFileSlot2";
		this.mnuFileSlot2.Size = new System.Drawing.Size(80, 22);
		this.mnuFileSlot2.Text = "2";
		this.mnuFileSlot2.Click += new System.EventHandler(mnuFileSlot2_Click);
		this.tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabControl.Controls.Add(this.tabStats);
		this.tabControl.Controls.Add(this.tabItems);
		this.tabControl.Controls.Add(this.tabItemGuy);
		this.tabControl.Controls.Add(this.tabOther);
		this.tabControl.Enabled = false;
		this.tabControl.Location = new System.Drawing.Point(12, 27);
		this.tabControl.Name = "tabControl";
		this.tabControl.SelectedIndex = 0;
		this.tabControl.Size = new System.Drawing.Size(432, 339);
		this.tabControl.TabIndex = 1;
		this.tabStats.Controls.Add(this.label18);
		this.tabStats.Controls.Add(this.label17);
		this.tabStats.Controls.Add(this.label16);
		this.tabStats.Controls.Add(this.label15);
		this.tabStats.Controls.Add(this.txtFavThing);
		this.tabStats.Controls.Add(this.txtFavFood);
		this.tabStats.Controls.Add(this.txtPlayerName);
		this.tabStats.Controls.Add(this.txtHinawa);
		this.tabStats.Controls.Add(this.lblAfterSpeed);
		this.tabStats.Controls.Add(this.lblAfterIQ);
		this.tabStats.Controls.Add(this.lblAfterDef);
		this.tabStats.Controls.Add(this.lblAfterOff);
		this.tabStats.Controls.Add(this.lblAfterPP);
		this.tabStats.Controls.Add(this.lblAfterHP);
		this.tabStats.Controls.Add(this.label13);
		this.tabStats.Controls.Add(this.label12);
		this.tabStats.Controls.Add(this.label11);
		this.tabStats.Controls.Add(this.label10);
		this.tabStats.Controls.Add(this.label9);
		this.tabStats.Controls.Add(this.label8);
		this.tabStats.Controls.Add(this.label7);
		this.tabStats.Controls.Add(this.label6);
		this.tabStats.Controls.Add(this.label5);
		this.tabStats.Controls.Add(this.label4);
		this.tabStats.Controls.Add(this.txtSpeed);
		this.tabStats.Controls.Add(this.txtIQ);
		this.tabStats.Controls.Add(this.txtDef);
		this.tabStats.Controls.Add(this.txtOff);
		this.tabStats.Controls.Add(this.label3);
		this.tabStats.Controls.Add(this.txtMaxPP);
		this.tabStats.Controls.Add(this.txtCurPP);
		this.tabStats.Controls.Add(this.label2);
		this.tabStats.Controls.Add(this.txtMaxHP);
		this.tabStats.Controls.Add(this.txtCurHP);
		this.tabStats.Controls.Add(this.txtExp);
		this.tabStats.Controls.Add(this.txtLevel);
		this.tabStats.Controls.Add(this.txtName);
		this.tabStats.Controls.Add(this.label1);
		this.tabStats.Controls.Add(this.cboCharStats);
		this.tabStats.Location = new System.Drawing.Point(4, 22);
		this.tabStats.Name = "tabStats";
		this.tabStats.Padding = new System.Windows.Forms.Padding(3);
		this.tabStats.Size = new System.Drawing.Size(424, 313);
		this.tabStats.TabIndex = 0;
		this.tabStats.Text = "Stats";
		this.tabStats.UseVisualStyleBackColor = true;
		this.label18.AutoSize = true;
		this.label18.Location = new System.Drawing.Point(230, 256);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(55, 13);
		this.label18.TabIndex = 39;
		this.label18.Text = "Fav. food:";
		this.label17.AutoSize = true;
		this.label17.Location = new System.Drawing.Point(228, 282);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(57, 13);
		this.label17.TabIndex = 38;
		this.label17.Text = "Fav. thing:";
		this.label16.AutoSize = true;
		this.label16.Location = new System.Drawing.Point(217, 230);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(68, 13);
		this.label16.TabIndex = 37;
		this.label16.Text = "Player name:";
		this.label15.AutoSize = true;
		this.label15.Location = new System.Drawing.Point(203, 204);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(82, 13);
		this.label15.TabIndex = 36;
		this.label15.Text = "Hinawa's name:";
		this.txtFavThing.Location = new System.Drawing.Point(291, 279);
		this.txtFavThing.MaxLength = 8;
		this.txtFavThing.Name = "txtFavThing";
		this.txtFavThing.Size = new System.Drawing.Size(121, 20);
		this.txtFavThing.TabIndex = 35;
		this.txtFavFood.Location = new System.Drawing.Point(291, 253);
		this.txtFavFood.MaxLength = 9;
		this.txtFavFood.Name = "txtFavFood";
		this.txtFavFood.Size = new System.Drawing.Size(121, 20);
		this.txtFavFood.TabIndex = 34;
		this.txtPlayerName.Location = new System.Drawing.Point(291, 227);
		this.txtPlayerName.MaxLength = 16;
		this.txtPlayerName.Name = "txtPlayerName";
		this.txtPlayerName.Size = new System.Drawing.Size(121, 20);
		this.txtPlayerName.TabIndex = 33;
		this.txtHinawa.Location = new System.Drawing.Point(291, 201);
		this.txtHinawa.MaxLength = 8;
		this.txtHinawa.Name = "txtHinawa";
		this.txtHinawa.Size = new System.Drawing.Size(121, 20);
		this.txtHinawa.TabIndex = 32;
		this.lblAfterSpeed.AutoSize = true;
		this.lblAfterSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.lblAfterSpeed.Location = new System.Drawing.Point(339, 162);
		this.lblAfterSpeed.Name = "lblAfterSpeed";
		this.lblAfterSpeed.Size = new System.Drawing.Size(0, 13);
		this.lblAfterSpeed.TabIndex = 30;
		this.lblAfterIQ.AutoSize = true;
		this.lblAfterIQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.lblAfterIQ.Location = new System.Drawing.Point(339, 136);
		this.lblAfterIQ.Name = "lblAfterIQ";
		this.lblAfterIQ.Size = new System.Drawing.Size(0, 13);
		this.lblAfterIQ.TabIndex = 29;
		this.lblAfterDef.AutoSize = true;
		this.lblAfterDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.lblAfterDef.Location = new System.Drawing.Point(339, 110);
		this.lblAfterDef.Name = "lblAfterDef";
		this.lblAfterDef.Size = new System.Drawing.Size(0, 13);
		this.lblAfterDef.TabIndex = 28;
		this.lblAfterOff.AutoSize = true;
		this.lblAfterOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.lblAfterOff.Location = new System.Drawing.Point(339, 84);
		this.lblAfterOff.Name = "lblAfterOff";
		this.lblAfterOff.Size = new System.Drawing.Size(0, 13);
		this.lblAfterOff.TabIndex = 27;
		this.lblAfterPP.AutoSize = true;
		this.lblAfterPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.lblAfterPP.Location = new System.Drawing.Point(178, 162);
		this.lblAfterPP.Name = "lblAfterPP";
		this.lblAfterPP.Size = new System.Drawing.Size(0, 13);
		this.lblAfterPP.TabIndex = 26;
		this.lblAfterHP.AutoSize = true;
		this.lblAfterHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.lblAfterHP.Location = new System.Drawing.Point(178, 136);
		this.lblAfterHP.Name = "lblAfterHP";
		this.lblAfterHP.Size = new System.Drawing.Size(0, 13);
		this.lblAfterHP.TabIndex = 25;
		this.label13.AutoSize = true;
		this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.label13.Location = new System.Drawing.Point(293, 59);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(81, 13);
		this.label13.TabIndex = 24;
		this.label13.Text = "Before     (After)";
		this.label12.AutoSize = true;
		this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.label12.Location = new System.Drawing.Point(132, 114);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(81, 13);
		this.label12.TabIndex = 23;
		this.label12.Text = "Before     (After)";
		this.label11.AutoSize = true;
		this.label11.Location = new System.Drawing.Point(244, 162);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(41, 13);
		this.label11.TabIndex = 22;
		this.label11.Text = "Speed:";
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(264, 136);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(21, 13);
		this.label10.TabIndex = 21;
		this.label10.Text = "IQ:";
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(235, 110);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(50, 13);
		this.label9.TabIndex = 20;
		this.label9.Text = "Defense:";
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(238, 84);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(47, 13);
		this.label8.TabIndex = 19;
		this.label8.Text = "Offense:";
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(45, 162);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(24, 13);
		this.label7.TabIndex = 18;
		this.label7.Text = "PP:";
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(45, 136);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(25, 13);
		this.label6.TabIndex = 17;
		this.label6.Text = "HP:";
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(7, 88);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(63, 13);
		this.label5.TabIndex = 16;
		this.label5.Text = "Experience:";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(34, 62);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(36, 13);
		this.label4.TabIndex = 15;
		this.label4.Text = "Level:";
		this.txtSpeed.Location = new System.Drawing.Point(291, 159);
		this.txtSpeed.MaxLength = 3;
		this.txtSpeed.Name = "txtSpeed";
		this.txtSpeed.Size = new System.Drawing.Size(42, 20);
		this.txtSpeed.TabIndex = 14;
		this.txtIQ.Location = new System.Drawing.Point(291, 133);
		this.txtIQ.MaxLength = 3;
		this.txtIQ.Name = "txtIQ";
		this.txtIQ.Size = new System.Drawing.Size(42, 20);
		this.txtIQ.TabIndex = 13;
		this.txtDef.Location = new System.Drawing.Point(291, 107);
		this.txtDef.MaxLength = 3;
		this.txtDef.Name = "txtDef";
		this.txtDef.Size = new System.Drawing.Size(42, 20);
		this.txtDef.TabIndex = 12;
		this.txtOff.Location = new System.Drawing.Point(291, 81);
		this.txtOff.MaxLength = 3;
		this.txtOff.Name = "txtOff";
		this.txtOff.Size = new System.Drawing.Size(42, 20);
		this.txtOff.TabIndex = 11;
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(118, 162);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(12, 13);
		this.label3.TabIndex = 10;
		this.label3.Text = "/";
		this.txtMaxPP.Location = new System.Drawing.Point(130, 159);
		this.txtMaxPP.MaxLength = 3;
		this.txtMaxPP.Name = "txtMaxPP";
		this.txtMaxPP.Size = new System.Drawing.Size(42, 20);
		this.txtMaxPP.TabIndex = 9;
		this.txtCurPP.Location = new System.Drawing.Point(76, 159);
		this.txtCurPP.MaxLength = 3;
		this.txtCurPP.Name = "txtCurPP";
		this.txtCurPP.Size = new System.Drawing.Size(42, 20);
		this.txtCurPP.TabIndex = 8;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(118, 136);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(12, 13);
		this.label2.TabIndex = 7;
		this.label2.Text = "/";
		this.txtMaxHP.Location = new System.Drawing.Point(130, 133);
		this.txtMaxHP.MaxLength = 3;
		this.txtMaxHP.Name = "txtMaxHP";
		this.txtMaxHP.Size = new System.Drawing.Size(42, 20);
		this.txtMaxHP.TabIndex = 6;
		this.txtCurHP.Location = new System.Drawing.Point(76, 133);
		this.txtCurHP.MaxLength = 3;
		this.txtCurHP.Name = "txtCurHP";
		this.txtCurHP.Size = new System.Drawing.Size(42, 20);
		this.txtCurHP.TabIndex = 5;
		this.txtExp.Location = new System.Drawing.Point(76, 85);
		this.txtExp.MaxLength = 7;
		this.txtExp.Name = "txtExp";
		this.txtExp.Size = new System.Drawing.Size(85, 20);
		this.txtExp.TabIndex = 4;
		this.txtLevel.Location = new System.Drawing.Point(76, 59);
		this.txtLevel.MaxLength = 3;
		this.txtLevel.Name = "txtLevel";
		this.txtLevel.Size = new System.Drawing.Size(42, 20);
		this.txtLevel.TabIndex = 3;
		this.txtName.Location = new System.Drawing.Point(76, 33);
		this.txtName.MaxLength = 8;
		this.txtName.Name = "txtName";
		this.txtName.Size = new System.Drawing.Size(121, 20);
		this.txtName.TabIndex = 2;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(14, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(56, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "Character:";
		this.cboCharStats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCharStats.FormattingEnabled = true;
		this.cboCharStats.Location = new System.Drawing.Point(76, 6);
		this.cboCharStats.Name = "cboCharStats";
		this.cboCharStats.Size = new System.Drawing.Size(121, 21);
		this.cboCharStats.TabIndex = 0;
		this.cboCharStats.SelectedIndexChanged += new System.EventHandler(cboCharStats_SelectedIndexChanged);
		this.tabItems.Controls.Add(this.btnAddItem);
		this.tabItems.Controls.Add(this.cboItem);
		this.tabItems.Controls.Add(this.label14);
		this.tabItems.Controls.Add(this.cboCharItems);
		this.tabItems.Controls.Add(this.lblInventory);
		this.tabItems.Location = new System.Drawing.Point(4, 22);
		this.tabItems.Name = "tabItems";
		this.tabItems.Padding = new System.Windows.Forms.Padding(3);
		this.tabItems.Size = new System.Drawing.Size(424, 313);
		this.tabItems.TabIndex = 1;
		this.tabItems.Text = "Inventory";
		this.tabItems.UseVisualStyleBackColor = true;
		this.btnAddItem.Location = new System.Drawing.Point(221, 6);
		this.btnAddItem.Name = "btnAddItem";
		this.btnAddItem.Size = new System.Drawing.Size(38, 21);
		this.btnAddItem.TabIndex = 5;
		this.btnAddItem.Text = "Add";
		this.btnAddItem.UseVisualStyleBackColor = true;
		this.btnAddItem.Click += new System.EventHandler(btnAddItem_Click);
		this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboItem.FormattingEnabled = true;
		this.cboItem.Location = new System.Drawing.Point(265, 6);
		this.cboItem.Name = "cboItem";
		this.cboItem.Size = new System.Drawing.Size(153, 21);
		this.cboItem.TabIndex = 4;
		this.cboItem.SelectedIndexChanged += new System.EventHandler(cboItem_SelectedIndexChanged);
		this.label14.AutoSize = true;
		this.label14.Location = new System.Drawing.Point(14, 9);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(56, 13);
		this.label14.TabIndex = 3;
		this.label14.Text = "Character:";
		this.cboCharItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCharItems.FormattingEnabled = true;
		this.cboCharItems.Location = new System.Drawing.Point(76, 6);
		this.cboCharItems.Name = "cboCharItems";
		this.cboCharItems.Size = new System.Drawing.Size(121, 21);
		this.cboCharItems.TabIndex = 2;
		this.cboCharItems.SelectedIndexChanged += new System.EventHandler(cboCharItems_SelectedIndexChanged);
		this.lblInventory.Location = new System.Drawing.Point(16, 34);
		this.lblInventory.Name = "lblInventory";
		this.lblInventory.Size = new System.Drawing.Size(54, 18);
		this.lblInventory.TabIndex = 0;
		this.lblInventory.Text = "Inventory:";
		this.lblInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.tabItemGuy.Controls.Add(this.btnItemGuyFill);
		this.tabItemGuy.Controls.Add(this.btnItemGuySet);
		this.tabItemGuy.Controls.Add(this.txtItemGuy);
		this.tabItemGuy.Controls.Add(this.lstItemGuy);
		this.tabItemGuy.Location = new System.Drawing.Point(4, 22);
		this.tabItemGuy.Name = "tabItemGuy";
		this.tabItemGuy.Padding = new System.Windows.Forms.Padding(3);
		this.tabItemGuy.Size = new System.Drawing.Size(424, 313);
		this.tabItemGuy.TabIndex = 2;
		this.tabItemGuy.Text = "Item guy";
		this.tabItemGuy.UseVisualStyleBackColor = true;
		this.btnItemGuyFill.Location = new System.Drawing.Point(302, 32);
		this.btnItemGuyFill.Name = "btnItemGuyFill";
		this.btnItemGuyFill.Size = new System.Drawing.Size(38, 20);
		this.btnItemGuyFill.TabIndex = 3;
		this.btnItemGuyFill.Text = "Fill";
		this.btnItemGuyFill.UseVisualStyleBackColor = true;
		this.btnItemGuyFill.Click += new System.EventHandler(btnItemGuyFill_Click);
		this.btnItemGuySet.Location = new System.Drawing.Point(302, 6);
		this.btnItemGuySet.Name = "btnItemGuySet";
		this.btnItemGuySet.Size = new System.Drawing.Size(38, 20);
		this.btnItemGuySet.TabIndex = 2;
		this.btnItemGuySet.Text = "Set";
		this.btnItemGuySet.UseVisualStyleBackColor = true;
		this.btnItemGuySet.Click += new System.EventHandler(btnItemGuySet_Click);
		this.txtItemGuy.Location = new System.Drawing.Point(258, 6);
		this.txtItemGuy.MaxLength = 2;
		this.txtItemGuy.Name = "txtItemGuy";
		this.txtItemGuy.Size = new System.Drawing.Size(38, 20);
		this.txtItemGuy.TabIndex = 1;
		this.lstItemGuy.FormattingEnabled = true;
		this.lstItemGuy.Location = new System.Drawing.Point(6, 6);
		this.lstItemGuy.Name = "lstItemGuy";
		this.lstItemGuy.ScrollAlwaysVisible = true;
		this.lstItemGuy.Size = new System.Drawing.Size(246, 290);
		this.lstItemGuy.TabIndex = 0;
		this.lstItemGuy.SelectedIndexChanged += new System.EventHandler(lstItemGuy_SelectedIndexChanged);
		this.tabOther.Controls.Add(this.grpPSI);
		this.tabOther.Controls.Add(this.grpParty);
		this.tabOther.Location = new System.Drawing.Point(4, 22);
		this.tabOther.Name = "tabOther";
		this.tabOther.Padding = new System.Windows.Forms.Padding(3);
		this.tabOther.Size = new System.Drawing.Size(424, 313);
		this.tabOther.TabIndex = 3;
		this.tabOther.Text = "Other";
		this.tabOther.UseVisualStyleBackColor = true;
		this.grpPSI.Controls.Add(this.label19);
		this.grpPSI.Controls.Add(this.lblPSICount);
		this.grpPSI.Controls.Add(this.btnPSINone);
		this.grpPSI.Controls.Add(this.btnPSIAll);
		this.grpPSI.Controls.Add(this.lstPSI);
		this.grpPSI.Controls.Add(this.optPSIKumatora);
		this.grpPSI.Controls.Add(this.optPSILucas);
		this.grpPSI.Location = new System.Drawing.Point(6, 96);
		this.grpPSI.Name = "grpPSI";
		this.grpPSI.Size = new System.Drawing.Size(287, 211);
		this.grpPSI.TabIndex = 1;
		this.grpPSI.TabStop = false;
		this.grpPSI.Text = "PSI";
		this.lstPSI.FormattingEnabled = true;
		this.lstPSI.Location = new System.Drawing.Point(6, 38);
		this.lstPSI.Name = "lstPSI";
		this.lstPSI.Size = new System.Drawing.Size(179, 169);
		this.lstPSI.TabIndex = 2;
		this.optPSIKumatora.AutoSize = true;
		this.optPSIKumatora.Location = new System.Drawing.Point(145, 19);
		this.optPSIKumatora.Name = "optPSIKumatora";
		this.optPSIKumatora.Size = new System.Drawing.Size(14, 13);
		this.optPSIKumatora.TabIndex = 1;
		this.optPSIKumatora.UseVisualStyleBackColor = true;
		this.optPSIKumatora.CheckedChanged += new System.EventHandler(optPSIKumatora_CheckedChanged);
		this.optPSILucas.AutoSize = true;
		this.optPSILucas.Checked = true;
		this.optPSILucas.Location = new System.Drawing.Point(6, 19);
		this.optPSILucas.Name = "optPSILucas";
		this.optPSILucas.Size = new System.Drawing.Size(14, 13);
		this.optPSILucas.TabIndex = 0;
		this.optPSILucas.TabStop = true;
		this.optPSILucas.UseVisualStyleBackColor = true;
		this.optPSILucas.CheckedChanged += new System.EventHandler(optPSILucas_CheckedChanged);
		this.grpParty.Controls.Add(this.cboParty);
		this.grpParty.Controls.Add(this.lstParty);
		this.grpParty.Location = new System.Drawing.Point(6, 6);
		this.grpParty.Name = "grpParty";
		this.grpParty.Size = new System.Drawing.Size(287, 84);
		this.grpParty.TabIndex = 0;
		this.grpParty.TabStop = false;
		this.grpParty.Text = "Party";
		this.cboParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboParty.FormattingEnabled = true;
		this.cboParty.Location = new System.Drawing.Point(160, 19);
		this.cboParty.Name = "cboParty";
		this.cboParty.Size = new System.Drawing.Size(121, 21);
		this.cboParty.TabIndex = 3;
		this.cboParty.SelectedIndexChanged += new System.EventHandler(cboParty_SelectedIndexChanged);
		this.lstParty.FormattingEnabled = true;
		this.lstParty.Location = new System.Drawing.Point(6, 19);
		this.lstParty.Name = "lstParty";
		this.lstParty.Size = new System.Drawing.Size(148, 56);
		this.lstParty.TabIndex = 0;
		this.lstParty.SelectedIndexChanged += new System.EventHandler(lstParty_SelectedIndexChanged);
		this.dlgOpen.Filter = "Battery saves|*.sa*";
		this.btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnSaveChanges.Enabled = false;
		this.btnSaveChanges.Location = new System.Drawing.Point(330, 372);
		this.btnSaveChanges.Name = "btnSaveChanges";
		this.btnSaveChanges.Size = new System.Drawing.Size(114, 29);
		this.btnSaveChanges.TabIndex = 32;
		this.btnSaveChanges.Text = "Save changes";
		this.btnSaveChanges.UseVisualStyleBackColor = true;
		this.btnSaveChanges.Click += new System.EventHandler(btnSaveChanges_Click);
		this.btnPSIAll.Location = new System.Drawing.Point(191, 38);
		this.btnPSIAll.Name = "btnPSIAll";
		this.btnPSIAll.Size = new System.Drawing.Size(48, 23);
		this.btnPSIAll.TabIndex = 3;
		this.btnPSIAll.Text = "Best";
		this.btnPSIAll.UseVisualStyleBackColor = true;
		this.btnPSIAll.Click += new System.EventHandler(btnPSIAll_Click);
		this.btnPSINone.Location = new System.Drawing.Point(191, 67);
		this.btnPSINone.Name = "btnPSINone";
		this.btnPSINone.Size = new System.Drawing.Size(48, 23);
		this.btnPSINone.TabIndex = 4;
		this.btnPSINone.Text = "None";
		this.btnPSINone.UseVisualStyleBackColor = true;
		this.btnPSINone.Click += new System.EventHandler(btnPSINone_Click);
		this.lblPSICount.AutoSize = true;
		this.lblPSICount.Location = new System.Drawing.Point(188, 104);
		this.lblPSICount.Name = "lblPSICount";
		this.lblPSICount.Size = new System.Drawing.Size(0, 13);
		this.lblPSICount.TabIndex = 5;
		this.label19.AutoSize = true;
		this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.label19.Location = new System.Drawing.Point(191, 157);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(77, 39);
		this.label19.TabIndex = 6;
		this.label19.Text = "* More than 36\r\nwill crash the\r\ngame.";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(456, 413);
		base.Controls.Add(this.btnSaveChanges);
		base.Controls.Add(this.tabControl);
		base.Controls.Add(this.menuStrip1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MainMenuStrip = this.menuStrip1;
		base.MaximizeBox = false;
		base.Name = "frmMain";
		this.Text = "MOTHER 3 Save Editor";
		base.Load += new System.EventHandler(Form1_Load);
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		this.tabControl.ResumeLayout(false);
		this.tabStats.ResumeLayout(false);
		this.tabStats.PerformLayout();
		this.tabItems.ResumeLayout(false);
		this.tabItems.PerformLayout();
		this.tabItemGuy.ResumeLayout(false);
		this.tabItemGuy.PerformLayout();
		this.tabOther.ResumeLayout(false);
		this.grpPSI.ResumeLayout(false);
		this.grpPSI.PerformLayout();
		this.grpParty.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public frmMain()
	{
		InitializeComponent();
		base.FormClosing += frmMain_FormClosing;
		cboCharStats.Click += cboCharStats_Click;
		txtLevel.LostFocus += txtStat_LostFocus;
		txtExp.LostFocus += txtStat_LostFocus;
		txtCurHP.LostFocus += txtStat_LostFocus;
		txtCurPP.LostFocus += txtStat_LostFocus;
		txtMaxHP.LostFocus += txtStat_LostFocus;
		txtMaxPP.LostFocus += txtStat_LostFocus;
		txtOff.LostFocus += txtStat_LostFocus;
		txtDef.LostFocus += txtStat_LostFocus;
		txtIQ.LostFocus += txtStat_LostFocus;
		txtSpeed.LostFocus += txtStat_LostFocus;
		txtName.LostFocus += txtStat_LostFocus;
		txtHinawa.LostFocus += txtStat_LostFocus;
		txtFavFood.LostFocus += txtStat_LostFocus;
		txtFavThing.LostFocus += txtStat_LostFocus;
		txtPlayerName.LostFocus += txtStat_LostFocus;
		lstPSI.ItemCheck += lstPSI_ItemCheck;
		for (int i = 0; i < 16; i++)
		{
			lblItem[i] = new Label();
			lblItem[i].Width = 150;
			lblItem[i].Height = 18;
			lblItem[i].Left = lblInventory.Left + lblInventory.Width + 6 + (i & 1) * (lblItem[i].Width + 6);
			lblItem[i].Top = lblInventory.Top + (i >> 1) * (lblItem[i].Height + 1);
			lblItem[i].Visible = true;
			lblItem[i].Tag = i;
			lblItem[i].MouseClick += lblItem_Click;
			lblItem[i].TextAlign = ContentAlignment.MiddleLeft;
			lblItem[i].ContextMenu = mnuEquipMenu;
			tabItems.Controls.Add(lblItem[i]);
		}
		for (int j = 0; j < 4; j++)
		{
			lblEquipLabel[j] = new Label();
			lblEquipLabel[j].Width = 60;
			lblEquipLabel[j].Height = 18;
			lblEquipLabel[j].Text = equipLabels[j];
			lblEquipLabel[j].Left = lblInventory.Left + lblInventory.Width - lblEquipLabel[j].Width;
			lblEquipLabel[j].Top = lblItem[15].Top + lblItem[15].Height + 12 + j * 19;
			lblEquipLabel[j].TextAlign = ContentAlignment.MiddleRight;
			tabItems.Controls.Add(lblEquipLabel[j]);
			lblEquip[j] = new Label();
			lblEquip[j].Width = 150;
			lblEquip[j].Height = 18;
			lblEquip[j].Left = lblItem[0].Left;
			lblEquip[j].Top = lblEquipLabel[j].Top;
			lblEquip[j].Visible = true;
			lblEquip[j].Tag = j;
			lblEquip[j].TextAlign = ContentAlignment.MiddleLeft;
			lblEquip[j].ContextMenu = mnuEquipDeleteMenu;
			tabItems.Controls.Add(lblEquip[j]);
		}
		for (int k = 0; k < 256; k++)
		{
			cboItem.Items.Add("[" + k.ToString("X2") + "] " + ItemStats.Name(k));
		}
		for (int l = 0; l < 4; l++)
		{
			mnuEquip[l] = new MenuItem("Equip to " + equipLabels[l]);
			mnuEquip[l].Tag = l;
			mnuEquip[l].Click += mnuEquip_Click;
			mnuEquipMenu.MenuItems.Add(mnuEquip[l]);
		}
		mnuEquipMenu.MenuItems.Add("-");
		mnuItemDelete.Click += mnuItemDelete_Click;
		mnuEquipMenu.MenuItems.Add(mnuItemDelete);
		mnuEquipDelete.Click += mnuEquipDelete_Click;
		mnuEquipDeleteMenu.MenuItems.Add(mnuEquipDelete);
		for (int m = 0; m < 64; m++)
		{
			lstPSI.Items.Add(PSIStats.Name(m));
		}
	}

	private void lstPSI_ItemCheck(object sender, ItemCheckEventArgs e)
	{
		if (!comboThinger1)
		{
			saver.SetPSIFlag((!optPSILucas.Checked) ? 1 : 0, e.Index, e.NewValue == CheckState.Checked);
			CountPSI();
		}
	}

	private void cboCharStats_Click(object sender, EventArgs e)
	{
		ApplyStats();
	}

	private void txtStat_LostFocus(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		if (textBox != txtHinawa && textBox != txtName && textBox != txtPlayerName && textBox != txtFavFood && textBox != txtFavThing)
		{
			int result = 0;
			if (!int.TryParse(textBox.Text, out result))
			{
				textBox.Text = "0";
			}
		}
		ApplyStats();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
	}

	private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!CheckSave())
		{
			e.Cancel = true;
		}
	}

	private void EnableControls(bool e)
	{
		ToolStripMenuItem toolStripMenuItem = mnuSave;
		TabControl obj = tabControl;
		ToolStripMenuItem toolStripMenuItem2 = mnuFileSlot1;
		ToolStripMenuItem toolStripMenuItem3 = mnuFileSlot2;
		ToolStripMenuItem toolStripMenuItem4 = mnuClose;
		bool flag = (btnSaveChanges.Enabled = e);
		bool flag3 = (toolStripMenuItem4.Enabled = flag);
		bool flag5 = (toolStripMenuItem3.Enabled = flag3);
		bool flag7 = (toolStripMenuItem2.Enabled = flag5);
		bool enabled = (obj.Enabled = flag7);
		toolStripMenuItem.Enabled = enabled;
	}

	private void LoadFile(string fileName)
	{
		fSaver = new FileStream(fileName, FileMode.Open);
		saver.FileHandle = fSaver;
		comboThinger1 = false;
		comboThinger2 = true;
		EnableControls(e: true);
		mnuFileSlot1_Click(null, null);
		isLoaded = true;
	}

	private void LoadFileData()
	{
		if (saver.SaveExists(curSlot))
		{
			tabControl.Enabled = true;
			cboCharStats.Items.Clear();
			cboCharItems.Items.Clear();
			cboParty.Items.Clear();
			cboParty.Items.Add(saver.GetName(-1));
			for (int i = 0; i < 13; i++)
			{
				cboCharStats.Items.Add(saver.GetName(i));
				cboCharItems.Items.Add(saver.GetName(i));
				cboParty.Items.Add(saver.GetName(i));
			}
			cboCharStats.SelectedIndex = 0;
			lstItemGuy.Items.Clear();
			for (int j = 0; j < 256; j++)
			{
				lstItemGuy.Items.Add(string.Format("[{0:X2}] {1,-23}\t\t{2}", j, ItemStats.Name(j) + ":", saver.GetItemGuy(j)));
			}
			lstItemGuy.SelectedIndex = 0;
			txtHinawa.Text = saver.GetHinawaName();
			txtPlayerName.Text = saver.GetPlayerName();
			txtFavFood.Text = saver.GetFavFood();
			txtFavThing.Text = saver.GetFavThing();
			lstPSI.Items[1] = "PSI " + txtFavThing.Text + " α";
			lstPSI.Items[2] = "PSI " + txtFavThing.Text + " β";
			lstPSI.Items[3] = "PSI " + txtFavThing.Text + " γ";
			lstPSI.Items[4] = "PSI " + txtFavThing.Text + " Ω";
			PopulatePartyBox();
			lstParty.SelectedIndex = 0;
			optPSILucas.Checked = true;
			DoPSIFlags();
		}
		else
		{
			tabControl.Enabled = false;
		}
	}

	private void ApplyStats()
	{
		try
		{
			int num = int.Parse(txtLevel.Text);
			if (num > 99)
			{
				num = 99;
			}
			if (num < 1)
			{
				num = 1;
			}
			int num2 = int.Parse(txtExp.Text);
			if (num2 > 9999999)
			{
				num2 = 9999999;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			int num3 = int.Parse(txtCurHP.Text);
			if (num3 > 999)
			{
				num3 = 999;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			int num4 = int.Parse(txtCurPP.Text);
			if (num4 > 999)
			{
				num4 = 999;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			int num5 = int.Parse(txtMaxHP.Text);
			if (num5 > 999)
			{
				num5 = 999;
			}
			if (num5 < 0)
			{
				num5 = 0;
			}
			int num6 = int.Parse(txtMaxPP.Text);
			if (num6 > 999)
			{
				num6 = 999;
			}
			if (num6 < 0)
			{
				num6 = 0;
			}
			int num7 = int.Parse(txtOff.Text);
			if (num7 > 255)
			{
				num7 = 255;
			}
			if (num7 < 0)
			{
				num7 = 0;
			}
			int num8 = int.Parse(txtDef.Text);
			if (num8 > 255)
			{
				num8 = 255;
			}
			if (num8 < 0)
			{
				num8 = 0;
			}
			int num9 = int.Parse(txtIQ.Text);
			if (num9 > 255)
			{
				num9 = 255;
			}
			if (num9 < 0)
			{
				num9 = 0;
			}
			int num10 = int.Parse(txtSpeed.Text);
			if (num10 > 255)
			{
				num10 = 255;
			}
			if (num10 < 0)
			{
				num10 = 0;
			}
			int selectedIndex = cboCharStats.SelectedIndex;
			saver.SetLevel(selectedIndex, (byte)num);
			saver.SetExp(selectedIndex, (uint)num2);
			saver.SetCurHP(selectedIndex, (ushort)num3);
			saver.SetCurPP(selectedIndex, (ushort)num4);
			saver.SetMaxHP(selectedIndex, (ushort)num5);
			saver.SetMaxPP(selectedIndex, (ushort)num6);
			saver.SetOffense(selectedIndex, (byte)num7);
			saver.SetDefense(selectedIndex, (byte)num8);
			saver.SetIQ(selectedIndex, (byte)num9);
			saver.SetSpeed(selectedIndex, (byte)num10);
			saver.SetName(selectedIndex, txtName.Text);
			cboCharStats.Items[selectedIndex] = txtName.Text;
			cboCharItems.Items[selectedIndex] = txtName.Text;
			int selectedIndex2 = lstParty.SelectedIndex;
			cboParty.Items[selectedIndex + 1] = txtName.Text;
			PopulatePartyBox();
			lstParty.SelectedIndex = selectedIndex2;
			saver.SetHinawaName(txtHinawa.Text);
			saver.SetPlayerName(txtPlayerName.Text);
			saver.SetFavFood(txtFavFood.Text);
			saver.SetFavThing(txtFavThing.Text);
			RedrawStats(selectedIndex);
			txtHinawa.Text = saver.GetHinawaName();
			txtPlayerName.Text = saver.GetPlayerName();
			txtFavFood.Text = saver.GetFavFood();
			txtFavThing.Text = saver.GetFavThing();
			lstPSI.Items[1] = "PSI " + txtFavThing.Text + " α";
			lstPSI.Items[2] = "PSI " + txtFavThing.Text + " β";
			lstPSI.Items[3] = "PSI " + txtFavThing.Text + " γ";
			lstPSI.Items[4] = "PSI " + txtFavThing.Text + " Ω";
		}
		catch
		{
		}
	}

	private void SaveChanges()
	{
		ApplyStats();
		saver.Save();
	}

	private void CloseFile()
	{
		fSaver.Close();
		EnableControls(e: false);
		isLoaded = false;
	}

	private bool CheckSave()
	{
		if (isLoaded)
		{
			if (saver.IsChanged)
			{
				switch (MessageBox.Show("Do you wish to save your changes?", "Save changes", MessageBoxButtons.YesNoCancel))
				{
				case DialogResult.Yes:
					SaveChanges();
					break;
				case DialogResult.Cancel:
					return false;
				}
			}
			CloseFile();
			return true;
		}
		return true;
	}

	private void mnuOpen_Click(object sender, EventArgs e)
	{
		if (dlgOpen.ShowDialog() == DialogResult.OK && CheckSave())
		{
			LoadFile(dlgOpen.FileName);
		}
	}

	private void cboCharStats_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedIndex = cboCharStats.SelectedIndex;
		RedrawStats(selectedIndex);
		if (!comboThinger1)
		{
			comboThinger2 = true;
			cboCharItems.SelectedIndex = selectedIndex;
			comboThinger2 = false;
		}
	}

	private void RedrawStats(int index)
	{
		txtName.Text = saver.GetName(index);
		txtLevel.Text = saver.GetLevel(index).ToString();
		txtExp.Text = saver.GetExp(index).ToString();
		txtCurHP.Text = saver.GetCurHP(index).ToString();
		txtMaxHP.Text = saver.GetMaxHP(index).ToString();
		txtCurPP.Text = saver.GetCurPP(index).ToString();
		txtMaxPP.Text = saver.GetMaxPP(index).ToString();
		txtOff.Text = saver.GetOffense(index).ToString();
		txtDef.Text = saver.GetDefense(index).ToString();
		txtIQ.Text = saver.GetIQ(index).ToString();
		txtSpeed.Text = saver.GetSpeed(index).ToString();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		for (int i = 0; i < 4; i++)
		{
			num += ItemStats.MaxHP(saver.GetEquipment(index, i));
			num2 += ItemStats.MaxPP(saver.GetEquipment(index, i));
			num3 += ItemStats.Offense(saver.GetEquipment(index, i));
			num4 += ItemStats.Defense(saver.GetEquipment(index, i));
			num5 += ItemStats.IQ(saver.GetEquipment(index, i));
			num6 += ItemStats.Speed(saver.GetEquipment(index, i));
		}
		lblAfterHP.Text = "(" + Math.Min(saver.GetMaxHP(index) + num, 999) + ")";
		lblAfterPP.Text = "(" + Math.Min(saver.GetMaxPP(index) + num2, 999) + ")";
		lblAfterOff.Text = "(" + Math.Min(saver.GetOffense(index) + num3, 255) + ")";
		lblAfterDef.Text = "(" + Math.Min(saver.GetDefense(index) + num4, 255) + ")";
		lblAfterIQ.Text = "(" + Math.Min(saver.GetIQ(index) + num5, 255) + ")";
		lblAfterSpeed.Text = "(" + Math.Min(saver.GetSpeed(index) + num6, 255) + ")";
	}

	private void mnuFileSlot1_Click(object sender, EventArgs e)
	{
		mnuFileSlot1.Checked = true;
		mnuFileSlot2.Checked = false;
		saver.bank = 4;
		curSlot = 0;
		LoadFileData();
	}

	private void mnuFileSlot2_Click(object sender, EventArgs e)
	{
		mnuFileSlot1.Checked = false;
		mnuFileSlot2.Checked = true;
		saver.bank = 10;
		curSlot = 1;
		LoadFileData();
	}

	private void cboCharItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		for (int i = 0; i < 16; i++)
		{
			int item = saver.GetItem(cboCharItems.SelectedIndex, i);
			lblItem[i].Text = "[" + item.ToString("X2") + "] " + ItemStats.Name(item);
		}
		for (int j = 0; j < 4; j++)
		{
			int equipment = saver.GetEquipment(cboCharItems.SelectedIndex, j);
			lblEquip[j].Text = "[" + equipment.ToString("X2") + "] " + ItemStats.Name(equipment);
		}
		lblItem_Click(lblItem[0], new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
		if (!comboThinger2)
		{
			comboThinger1 = true;
			cboCharStats.SelectedIndex = cboCharItems.SelectedIndex;
			comboThinger1 = false;
		}
	}

	private void lblItem_Click(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			int num = (int)((Label)sender).Tag;
			lblItem[curItem].BackColor = Color.Transparent;
			curItem = num;
			lblItem[num].BackColor = Color.FromArgb(255, 160, 64);
			comboThinger1 = true;
			cboItem.SelectedIndex = saver.GetItem(cboCharItems.SelectedIndex, num);
			comboThinger1 = false;
		}
	}

	private void mnuEquip_Click(object sender, EventArgs e)
	{
		int num = (int)((MenuItem)sender).Tag;
		int item = saver.GetItem(cboCharItems.SelectedIndex, (int)((ContextMenu)((MenuItem)sender).Parent).SourceControl.Tag);
		saver.SetEquipment(cboCharItems.SelectedIndex, num, (byte)item);
		lblEquip[num].Text = "[" + item.ToString("X2") + "] " + ItemStats.Name(item);
		comboThinger1 = true;
		cboCharStats_SelectedIndexChanged(null, null);
		comboThinger1 = false;
	}

	private void mnuEquipDelete_Click(object sender, EventArgs e)
	{
		int num = (int)((ContextMenu)((MenuItem)sender).Parent).SourceControl.Tag;
		saver.SetEquipment(cboCharItems.SelectedIndex, num, 0);
		lblEquip[num].Text = "[00] " + ItemStats.Name(0);
		comboThinger1 = true;
		cboCharStats_SelectedIndexChanged(null, null);
		comboThinger1 = false;
	}

	private void mnuClose_Click(object sender, EventArgs e)
	{
		CheckSave();
	}

	private void exitToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnAddItem_Click(object sender, EventArgs e)
	{
		int selectedIndex = cboCharItems.SelectedIndex;
		for (int i = 0; i < 16; i++)
		{
			if (saver.GetItem(selectedIndex, i) == 0)
			{
				saver.SetItem(selectedIndex, i, (byte)cboItem.SelectedIndex);
				lblItem[i].Text = "[" + cboItem.SelectedIndex.ToString("X2") + "] " + ItemStats.Name(cboItem.SelectedIndex);
				break;
			}
		}
	}

	private void mnuItemDelete_Click(object sender, EventArgs e)
	{
		int num = (int)((ContextMenu)((MenuItem)sender).Parent).SourceControl.Tag;
		int selectedIndex = cboCharItems.SelectedIndex;
		for (int i = num; i < 15; i++)
		{
			byte item = saver.GetItem(selectedIndex, i + 1);
			saver.SetItem(selectedIndex, i, item);
			lblItem[i].Text = "[" + item.ToString("X2") + "] " + ItemStats.Name(item);
		}
		saver.SetItem(selectedIndex, 15, 0);
		lblItem[15].Text = "[00] " + ItemStats.Name(0);
	}

	private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!comboThinger1)
		{
			saver.SetItem(cboCharItems.SelectedIndex, curItem, (byte)cboItem.SelectedIndex);
			lblItem[curItem].Text = "[" + cboItem.SelectedIndex.ToString("X2") + "] " + ItemStats.Name(cboItem.SelectedIndex);
		}
	}

	private void lstItemGuy_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstItemGuy.SelectedIndex < 0)
		{
			txtItemGuy.Text = "";
			txtItemGuy.Enabled = false;
		}
		else
		{
			txtItemGuy.Enabled = true;
			txtItemGuy.Text = saver.GetItemGuy(lstItemGuy.SelectedIndex).ToString();
		}
	}

	private void btnItemGuySet_Click(object sender, EventArgs e)
	{
		int selectedIndex = lstItemGuy.SelectedIndex;
		byte b;
		try
		{
			b = byte.Parse(txtItemGuy.Text);
		}
		catch
		{
			b = 0;
			txtItemGuy.Text = "0";
		}
		saver.SetItemGuy(selectedIndex, b);
		lstItemGuy.Items[selectedIndex] = string.Format("[{0:X2}] {1,-23}\t\t{2}", selectedIndex, ItemStats.Name(selectedIndex) + ":", b);
	}

	private void btnItemGuyFill_Click(object sender, EventArgs e)
	{
		byte b;
		try
		{
			b = byte.Parse(txtItemGuy.Text);
		}
		catch
		{
			b = 0;
			txtItemGuy.Text = "0";
		}
		for (int i = 0; i < 256; i++)
		{
			saver.SetItemGuy(i, b);
			lstItemGuy.Items[i] = string.Format("[{0:X2}] {1,-23}\t\t{2}", i, ItemStats.Name(i) + ":", b);
		}
	}

	private void btnSaveChanges_Click(object sender, EventArgs e)
	{
		SaveChanges();
	}

	private void mnuSave_Click(object sender, EventArgs e)
	{
		SaveChanges();
	}

	private void btnApplyStats_Click(object sender, EventArgs e)
	{
		ApplyStats();
	}

	private void lstParty_SelectedIndexChanged(object sender, EventArgs e)
	{
		comboThinger1 = true;
		cboParty.SelectedIndex = saver.GetActiveChar(lstParty.SelectedIndex);
		comboThinger1 = false;
	}

	private void cboParty_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!comboThinger1)
		{
			int selectedIndex = lstParty.SelectedIndex;
			int selectedIndex2 = cboParty.SelectedIndex;
			saver.SetActiveChar(selectedIndex, (byte)selectedIndex2);
			PopulatePartyBox();
			lstParty.SelectedIndex = selectedIndex;
		}
	}

	private void PopulatePartyBox()
	{
		lstParty.Items.Clear();
		for (int i = 0; i < 4; i++)
		{
			lstParty.Items.Add(saver.GetName(saver.GetActiveChar(i) - 1));
		}
		optPSILucas.Text = saver.GetName(1);
		optPSIKumatora.Text = saver.GetName(3);
	}

	private void optPSILucas_CheckedChanged(object sender, EventArgs e)
	{
		DoPSIFlags();
	}

	private void optPSIKumatora_CheckedChanged(object sender, EventArgs e)
	{
		DoPSIFlags();
	}

	private void DoPSIFlags()
	{
		comboThinger1 = true;
		int index = ((!optPSILucas.Checked) ? 1 : 0);
		for (int i = 0; i < 64; i++)
		{
			lstPSI.SetItemChecked(i, saver.GetPSIFlag(index, i));
		}
		comboThinger1 = false;
		CountPSI();
	}

	private void CountPSI()
	{
		int num = 0;
		int index = ((!optPSILucas.Checked) ? 1 : 0);
		for (int i = 0; i < 64; i++)
		{
			if (saver.GetPSIFlag(index, i))
			{
				num++;
			}
		}
		lblPSICount.Text = "Count: " + num;
		if (num > 36)
		{
			lblPSICount.ForeColor = Color.Red;
			lblPSICount.Font = new Font(lblPSICount.Font, FontStyle.Bold);
		}
		else
		{
			lblPSICount.ForeColor = Color.Green;
			lblPSICount.Font = new Font(lblPSICount.Font, FontStyle.Regular);
		}
	}

	private void btnPSIAll_Click(object sender, EventArgs e)
	{
		if (optPSILucas.Checked)
		{
			saver.SetNumber(1832 + (saver.bank << 12), 4, 2144093246u);
			saver.SetNumber(1836 + (saver.bank << 12), 4, 693355517u);
		}
		else
		{
			saver.SetNumber(1858 + (saver.bank << 12), 4, 3402629088u);
			saver.SetNumber(1862 + (saver.bank << 12), 4, 1039663785u);
		}
		DoPSIFlags();
	}

	private void btnPSINone_Click(object sender, EventArgs e)
	{
		int num = ((!optPSILucas.Checked) ? 1 : 0);
		saver.SetNumber(1832 + num * 26 + (saver.bank << 12), 4, 0u);
		saver.SetNumber(1836 + num * 26 + (saver.bank << 12), 4, 0u);
		DoPSIFlags();
	}
}
