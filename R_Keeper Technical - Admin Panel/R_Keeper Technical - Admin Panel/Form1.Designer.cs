
namespace R_Keeper_Technical___Admin_Panel
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStripMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.панельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.админПанельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.логиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.панельРеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.добавитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2ColumnFCs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFCs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeeperLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeeperPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBaseLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBasePassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRestaurant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCheckBoxSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNameRestaurant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnFCs,
            this.ColumnKeeperLogin,
            this.ColumnKeeperPassword,
            this.ColumnBaseLogin,
            this.ColumnBasePassword,
            this.ColumnRestaurant,
            this.ColumnCheckBoxSelect});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStripMenu;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(997, 508);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // contextMenuStripMenu
            // 
            this.contextMenuStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.панельToolStripMenuItem,
            this.toolStripSeparator1,
            this.добавитьToolStripMenuItem1,
            this.удалитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.обновитьToolStripMenuItem});
            this.contextMenuStripMenu.Name = "contextMenuStripMenu";
            this.contextMenuStripMenu.Size = new System.Drawing.Size(129, 120);
            // 
            // панельToolStripMenuItem
            // 
            this.панельToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.админПанельToolStripMenuItem,
            this.логиToolStripMenuItem,
            this.панельРеToolStripMenuItem});
            this.панельToolStripMenuItem.Name = "панельToolStripMenuItem";
            this.панельToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.панельToolStripMenuItem.Text = "Панель";
            // 
            // админПанельToolStripMenuItem
            // 
            this.админПанельToolStripMenuItem.Name = "админПанельToolStripMenuItem";
            this.админПанельToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.админПанельToolStripMenuItem.Text = "Панель Пользователей";
            this.админПанельToolStripMenuItem.Click += new System.EventHandler(this.админПанельToolStripMenuItem_Click);
            // 
            // логиToolStripMenuItem
            // 
            this.логиToolStripMenuItem.Name = "логиToolStripMenuItem";
            this.логиToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.логиToolStripMenuItem.Text = "Логи";
            this.логиToolStripMenuItem.Click += new System.EventHandler(this.логиToolStripMenuItem_Click);
            // 
            // панельРеToolStripMenuItem
            // 
            this.панельРеToolStripMenuItem.Name = "панельРеToolStripMenuItem";
            this.панельРеToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.панельРеToolStripMenuItem.Text = "Панель ресторанов";
            this.панельРеToolStripMenuItem.Click += new System.EventHandler(this.панельРеToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // добавитьToolStripMenuItem1
            // 
            this.добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
            this.добавитьToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.добавитьToolStripMenuItem1.Text = "Добавить";
            this.добавитьToolStripMenuItem1.Click += new System.EventHandler(this.добавитьToolStripMenuItem1_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(997, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Панель Пользователей";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridView2ColumnFCs,
            this.dataGridViewColumnLog,
            this.dataGridViewCheckBoxColumn1});
            this.dataGridView2.ContextMenuStrip = this.contextMenuStripMenu;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView2.Location = new System.Drawing.Point(12, 31);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(997, 508);
            this.dataGridView2.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridView2ColumnFCs
            // 
            this.dataGridView2ColumnFCs.HeaderText = "FCs";
            this.dataGridView2ColumnFCs.Name = "dataGridView2ColumnFCs";
            // 
            // dataGridViewColumnLog
            // 
            this.dataGridViewColumnLog.HeaderText = "Log";
            this.dataGridViewColumnLog.Name = "dataGridViewColumnLog";
            this.dataGridViewColumnLog.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Select";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.ColumnNameRestaurant,
            this.ColumnServerName,
            this.ColumnIP,
            this.ColumnPort,
            this.dataGridViewCheckBoxColumn2});
            this.dataGridView3.ContextMenuStrip = this.contextMenuStripMenu;
            this.dataGridView3.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView3.Location = new System.Drawing.Point(12, 31);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(997, 508);
            this.dataGridView3.TabIndex = 7;
            this.dataGridView3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellDoubleClick);
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            // 
            // ColumnFCs
            // 
            this.ColumnFCs.HeaderText = "FCs";
            this.ColumnFCs.Name = "ColumnFCs";
            this.ColumnFCs.ReadOnly = true;
            // 
            // ColumnKeeperLogin
            // 
            this.ColumnKeeperLogin.HeaderText = "Keeper Login";
            this.ColumnKeeperLogin.Name = "ColumnKeeperLogin";
            this.ColumnKeeperLogin.ReadOnly = true;
            // 
            // ColumnKeeperPassword
            // 
            this.ColumnKeeperPassword.HeaderText = "Keeper Password";
            this.ColumnKeeperPassword.Name = "ColumnKeeperPassword";
            this.ColumnKeeperPassword.ReadOnly = true;
            // 
            // ColumnBaseLogin
            // 
            this.ColumnBaseLogin.HeaderText = "Base Login";
            this.ColumnBaseLogin.Name = "ColumnBaseLogin";
            this.ColumnBaseLogin.ReadOnly = true;
            // 
            // ColumnBasePassword
            // 
            this.ColumnBasePassword.HeaderText = "Base Password";
            this.ColumnBasePassword.Name = "ColumnBasePassword";
            this.ColumnBasePassword.ReadOnly = true;
            // 
            // ColumnRestaurant
            // 
            this.ColumnRestaurant.HeaderText = "Restaurant";
            this.ColumnRestaurant.Name = "ColumnRestaurant";
            this.ColumnRestaurant.ReadOnly = true;
            // 
            // ColumnCheckBoxSelect
            // 
            this.ColumnCheckBoxSelect.HeaderText = "Select";
            this.ColumnCheckBoxSelect.Name = "ColumnCheckBoxSelect";
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "Select";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            // 
            // ColumnPort
            // 
            this.ColumnPort.HeaderText = "Port";
            this.ColumnPort.Name = "ColumnPort";
            this.ColumnPort.ReadOnly = true;
            // 
            // ColumnIP
            // 
            this.ColumnIP.HeaderText = "IP";
            this.ColumnIP.Name = "ColumnIP";
            this.ColumnIP.ReadOnly = true;
            // 
            // ColumnServerName
            // 
            this.ColumnServerName.HeaderText = "ServerName";
            this.ColumnServerName.Name = "ColumnServerName";
            this.ColumnServerName.ReadOnly = true;
            // 
            // ColumnNameRestaurant
            // 
            this.ColumnNameRestaurant.HeaderText = "NameRestaurant";
            this.ColumnNameRestaurant.Name = "ColumnNameRestaurant";
            this.ColumnNameRestaurant.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 551);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMenu;
        private System.Windows.Forms.ToolStripMenuItem панельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem админПанельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem логиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView2ColumnFCs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnLog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.ToolStripMenuItem панельРеToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFCs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKeeperLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKeeperPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBaseLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBasePassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRestaurant;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckBoxSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNameRestaurant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPort;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
    }
}

