namespace Apu_Animal_Park_4
{
    partial class FormMain
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
            this.grpAnimalSpecifications = new System.Windows.Forms.GroupBox();
            this.lstvFoodItems = new System.Windows.Forms.ListView();
            this.foodName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.foodItems = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.picAnimal = new System.Windows.Forms.PictureBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.cboxListAnimals = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grpGenderType = new System.Windows.Forms.GroupBox();
            this.lstGenderType = new System.Windows.Forms.ListBox();
            this.lstAnimalSpecie = new System.Windows.Forms.ListBox();
            this.lstAnimalCategory = new System.Windows.Forms.ListBox();
            this.grpSpecifications = new System.Windows.Forms.GroupBox();
            this.txtSpecification2 = new System.Windows.Forms.TextBox();
            this.txtSpecification1 = new System.Windows.Forms.TextBox();
            this.lblSpecification2 = new System.Windows.Forms.Label();
            this.lblSpecification1 = new System.Windows.Forms.Label();
            this.lblAnimalSpecie = new System.Windows.Forms.Label();
            this.lblCategoryType = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSpecieInfo = new System.Windows.Forms.Label();
            this.lstvAnimals = new System.Windows.Forms.ListView();
            this.idAnimals = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameAnimals = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.weightAnimals = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ageAnimals = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.genderAnimals = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSortBy = new System.Windows.Forms.Button();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.grpAnimals = new System.Windows.Forms.GroupBox();
            this.lstvAnimalDiet = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDiet = new System.Windows.Forms.Label();
            this.lblAnimalDiet = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.grpAnimalSpecifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimal)).BeginInit();
            this.grpGenderType.SuspendLayout();
            this.grpSpecifications.SuspendLayout();
            this.grpAnimals.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAnimalSpecifications
            // 
            this.grpAnimalSpecifications.Controls.Add(this.lstvFoodItems);
            this.grpAnimalSpecifications.Controls.Add(this.btnAddFood);
            this.grpAnimalSpecifications.Controls.Add(this.btnChange);
            this.grpAnimalSpecifications.Controls.Add(this.btnDelete);
            this.grpAnimalSpecifications.Controls.Add(this.btnAddPicture);
            this.grpAnimalSpecifications.Controls.Add(this.picAnimal);
            this.grpAnimalSpecifications.Controls.Add(this.txtWeight);
            this.grpAnimalSpecifications.Controls.Add(this.lblWeight);
            this.grpAnimalSpecifications.Controls.Add(this.cboxListAnimals);
            this.grpAnimalSpecifications.Controls.Add(this.btnAdd);
            this.grpAnimalSpecifications.Controls.Add(this.txtAge);
            this.grpAnimalSpecifications.Controls.Add(this.txtName);
            this.grpAnimalSpecifications.Controls.Add(this.grpGenderType);
            this.grpAnimalSpecifications.Controls.Add(this.lstAnimalSpecie);
            this.grpAnimalSpecifications.Controls.Add(this.lstAnimalCategory);
            this.grpAnimalSpecifications.Controls.Add(this.grpSpecifications);
            this.grpAnimalSpecifications.Controls.Add(this.lblAnimalSpecie);
            this.grpAnimalSpecifications.Controls.Add(this.lblCategoryType);
            this.grpAnimalSpecifications.Controls.Add(this.lblAge);
            this.grpAnimalSpecifications.Controls.Add(this.lblName);
            this.grpAnimalSpecifications.ForeColor = System.Drawing.Color.Green;
            this.grpAnimalSpecifications.Location = new System.Drawing.Point(12, 38);
            this.grpAnimalSpecifications.Name = "grpAnimalSpecifications";
            this.grpAnimalSpecifications.Size = new System.Drawing.Size(1017, 294);
            this.grpAnimalSpecifications.TabIndex = 0;
            this.grpAnimalSpecifications.TabStop = false;
            this.grpAnimalSpecifications.Text = "Animal Specifications";
            // 
            // lstvFoodItems
            // 
            this.lstvFoodItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.foodName,
            this.foodItems});
            this.lstvFoodItems.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvFoodItems.FullRowSelect = true;
            this.lstvFoodItems.HideSelection = false;
            this.lstvFoodItems.Location = new System.Drawing.Point(703, 35);
            this.lstvFoodItems.MultiSelect = false;
            this.lstvFoodItems.Name = "lstvFoodItems";
            this.lstvFoodItems.Size = new System.Drawing.Size(308, 157);
            this.lstvFoodItems.TabIndex = 19;
            this.lstvFoodItems.UseCompatibleStateImageBehavior = false;
            this.lstvFoodItems.View = System.Windows.Forms.View.Details;
            this.lstvFoodItems.SelectedIndexChanged += new System.EventHandler(this.lstvFoodItems_SelectedIndexChanged);
            // 
            // foodName
            // 
            this.foodName.Text = "Name";
            this.foodName.Width = 83;
            // 
            // foodItems
            // 
            this.foodItems.Text = "Food items";
            this.foodItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foodItems.Width = 220;
            // 
            // btnAddFood
            // 
            this.btnAddFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnAddFood.Location = new System.Drawing.Point(809, 198);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(120, 23);
            this.btnAddFood.TabIndex = 18;
            this.btnAddFood.Text = "Add food item";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnChange.Location = new System.Drawing.Point(421, 265);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(94, 23);
            this.btnChange.TabIndex = 17;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnDelete.Location = new System.Drawing.Point(318, 265);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPicture.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnAddPicture.Location = new System.Drawing.Point(541, 198);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(120, 23);
            this.btnAddPicture.TabIndex = 9;
            this.btnAddPicture.Text = "Add Picture";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // picAnimal
            // 
            this.picAnimal.Location = new System.Drawing.Point(509, 35);
            this.picAnimal.Name = "picAnimal";
            this.picAnimal.Size = new System.Drawing.Size(188, 157);
            this.picAnimal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnimal.TabIndex = 15;
            this.picAnimal.TabStop = false;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(74, 83);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(84, 20);
            this.txtWeight.TabIndex = 2;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblWeight.Location = new System.Drawing.Point(6, 83);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(62, 13);
            this.lblWeight.TabIndex = 13;
            this.lblWeight.Text = "Weight (kg)";
            // 
            // cboxListAnimals
            // 
            this.cboxListAnimals.AutoSize = true;
            this.cboxListAnimals.Location = new System.Drawing.Point(318, 194);
            this.cboxListAnimals.Name = "cboxListAnimals";
            this.cboxListAnimals.Size = new System.Drawing.Size(93, 17);
            this.cboxListAnimals.TabIndex = 8;
            this.cboxListAnimals.Text = "List all animals";
            this.cboxListAnimals.UseVisualStyleBackColor = true;
            this.cboxListAnimals.CheckedChanged += new System.EventHandler(this.cboxListAnimals_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnAdd.Location = new System.Drawing.Point(374, 231);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(74, 56);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(84, 20);
            this.txtAge.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(105, 20);
            this.txtName.TabIndex = 0;
            // 
            // grpGenderType
            // 
            this.grpGenderType.Controls.Add(this.lstGenderType);
            this.grpGenderType.Location = new System.Drawing.Point(9, 108);
            this.grpGenderType.Name = "grpGenderType";
            this.grpGenderType.Size = new System.Drawing.Size(149, 103);
            this.grpGenderType.TabIndex = 7;
            this.grpGenderType.TabStop = false;
            this.grpGenderType.Text = "Gender Type";
            // 
            // lstGenderType
            // 
            this.lstGenderType.FormattingEnabled = true;
            this.lstGenderType.Location = new System.Drawing.Point(6, 32);
            this.lstGenderType.Name = "lstGenderType";
            this.lstGenderType.Size = new System.Drawing.Size(137, 56);
            this.lstGenderType.TabIndex = 3;
            // 
            // lstAnimalSpecie
            // 
            this.lstAnimalSpecie.FormattingEnabled = true;
            this.lstAnimalSpecie.Location = new System.Drawing.Point(347, 35);
            this.lstAnimalSpecie.Name = "lstAnimalSpecie";
            this.lstAnimalSpecie.Size = new System.Drawing.Size(120, 147);
            this.lstAnimalSpecie.TabIndex = 5;
            this.lstAnimalSpecie.SelectedIndexChanged += new System.EventHandler(this.lstAnimal_SelectedIndexChanged);
            // 
            // lstAnimalCategory
            // 
            this.lstAnimalCategory.FormattingEnabled = true;
            this.lstAnimalCategory.Location = new System.Drawing.Point(188, 35);
            this.lstAnimalCategory.Name = "lstAnimalCategory";
            this.lstAnimalCategory.Size = new System.Drawing.Size(120, 147);
            this.lstAnimalCategory.TabIndex = 4;
            this.lstAnimalCategory.SelectedIndexChanged += new System.EventHandler(this.lstCategoryType_SelectedIndexChanged);
            // 
            // grpSpecifications
            // 
            this.grpSpecifications.Controls.Add(this.txtSpecification2);
            this.grpSpecifications.Controls.Add(this.txtSpecification1);
            this.grpSpecifications.Controls.Add(this.lblSpecification2);
            this.grpSpecifications.Controls.Add(this.lblSpecification1);
            this.grpSpecifications.Location = new System.Drawing.Point(9, 211);
            this.grpSpecifications.Name = "grpSpecifications";
            this.grpSpecifications.Size = new System.Drawing.Size(284, 80);
            this.grpSpecifications.TabIndex = 6;
            this.grpSpecifications.TabStop = false;
            this.grpSpecifications.Text = "N/A";
            // 
            // txtSpecification2
            // 
            this.txtSpecification2.Location = new System.Drawing.Point(164, 50);
            this.txtSpecification2.Name = "txtSpecification2";
            this.txtSpecification2.Size = new System.Drawing.Size(114, 20);
            this.txtSpecification2.TabIndex = 7;
            // 
            // txtSpecification1
            // 
            this.txtSpecification1.Location = new System.Drawing.Point(164, 23);
            this.txtSpecification1.Name = "txtSpecification1";
            this.txtSpecification1.Size = new System.Drawing.Size(114, 20);
            this.txtSpecification1.TabIndex = 6;
            // 
            // lblSpecification2
            // 
            this.lblSpecification2.AutoSize = true;
            this.lblSpecification2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblSpecification2.Location = new System.Drawing.Point(17, 50);
            this.lblSpecification2.Name = "lblSpecification2";
            this.lblSpecification2.Size = new System.Drawing.Size(0, 13);
            this.lblSpecification2.TabIndex = 6;
            // 
            // lblSpecification1
            // 
            this.lblSpecification1.AutoSize = true;
            this.lblSpecification1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblSpecification1.Location = new System.Drawing.Point(17, 26);
            this.lblSpecification1.Name = "lblSpecification1";
            this.lblSpecification1.Size = new System.Drawing.Size(0, 13);
            this.lblSpecification1.TabIndex = 5;
            // 
            // lblAnimalSpecie
            // 
            this.lblAnimalSpecie.AutoSize = true;
            this.lblAnimalSpecie.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblAnimalSpecie.Location = new System.Drawing.Point(343, 16);
            this.lblAnimalSpecie.Name = "lblAnimalSpecie";
            this.lblAnimalSpecie.Size = new System.Drawing.Size(74, 13);
            this.lblAnimalSpecie.TabIndex = 4;
            this.lblAnimalSpecie.Text = "Animal Specie";
            // 
            // lblCategoryType
            // 
            this.lblCategoryType.AutoSize = true;
            this.lblCategoryType.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblCategoryType.Location = new System.Drawing.Point(185, 16);
            this.lblCategoryType.Name = "lblCategoryType";
            this.lblCategoryType.Size = new System.Drawing.Size(76, 13);
            this.lblCategoryType.TabIndex = 3;
            this.lblCategoryType.Text = "Category Type";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblAge.Location = new System.Drawing.Point(6, 59);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(60, 13);
            this.lblAge.TabIndex = 1;
            this.lblAge.Text = "Age (years)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblName.Location = new System.Drawing.Point(6, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblSpecieInfo
            // 
            this.lblSpecieInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSpecieInfo.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblSpecieInfo.Location = new System.Drawing.Point(8, 19);
            this.lblSpecieInfo.Name = "lblSpecieInfo";
            this.lblSpecieInfo.Size = new System.Drawing.Size(182, 157);
            this.lblSpecieInfo.TabIndex = 13;
            // 
            // lstvAnimals
            // 
            this.lstvAnimals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idAnimals,
            this.nameAnimals,
            this.weightAnimals,
            this.ageAnimals,
            this.genderAnimals});
            this.lstvAnimals.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvAnimals.FullRowSelect = true;
            this.lstvAnimals.HideSelection = false;
            this.lstvAnimals.Location = new System.Drawing.Point(196, 19);
            this.lstvAnimals.MultiSelect = false;
            this.lstvAnimals.Name = "lstvAnimals";
            this.lstvAnimals.Size = new System.Drawing.Size(473, 157);
            this.lstvAnimals.TabIndex = 14;
            this.lstvAnimals.UseCompatibleStateImageBehavior = false;
            this.lstvAnimals.View = System.Windows.Forms.View.Details;
            this.lstvAnimals.SelectedIndexChanged += new System.EventHandler(this.lstvAnimals_SelectedIndexChanged);
            // 
            // idAnimals
            // 
            this.idAnimals.Text = "ID";
            this.idAnimals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.idAnimals.Width = 56;
            // 
            // nameAnimals
            // 
            this.nameAnimals.Text = "Name";
            this.nameAnimals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameAnimals.Width = 232;
            // 
            // weightAnimals
            // 
            this.weightAnimals.Text = "Weight";
            this.weightAnimals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.weightAnimals.Width = 70;
            // 
            // ageAnimals
            // 
            this.ageAnimals.Text = "Age";
            this.ageAnimals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ageAnimals.Width = 46;
            // 
            // genderAnimals
            // 
            this.genderAnimals.Text = "Gender";
            this.genderAnimals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.genderAnimals.Width = 65;
            // 
            // btnSortBy
            // 
            this.btnSortBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortBy.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnSortBy.Location = new System.Drawing.Point(280, 530);
            this.btnSortBy.Name = "btnSortBy";
            this.btnSortBy.Size = new System.Drawing.Size(120, 23);
            this.btnSortBy.TabIndex = 15;
            this.btnSortBy.Text = "Sort";
            this.btnSortBy.UseVisualStyleBackColor = true;
            this.btnSortBy.Click += new System.EventHandler(this.btnSortBy_Click);
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortBy.FormattingEnabled = true;
            this.cmbSortBy.Location = new System.Drawing.Point(406, 531);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(121, 21);
            this.cmbSortBy.TabIndex = 16;
            // 
            // grpAnimals
            // 
            this.grpAnimals.Controls.Add(this.lstvAnimalDiet);
            this.grpAnimals.Controls.Add(this.lblDiet);
            this.grpAnimals.Controls.Add(this.lblAnimalDiet);
            this.grpAnimals.Controls.Add(this.lblSpecieInfo);
            this.grpAnimals.Controls.Add(this.lstvAnimals);
            this.grpAnimals.ForeColor = System.Drawing.Color.Maroon;
            this.grpAnimals.Location = new System.Drawing.Point(4, 348);
            this.grpAnimals.Name = "grpAnimals";
            this.grpAnimals.Size = new System.Drawing.Size(1019, 182);
            this.grpAnimals.TabIndex = 18;
            this.grpAnimals.TabStop = false;
            this.grpAnimals.Text = "Animal(s)";
            // 
            // lstvAnimalDiet
            // 
            this.lstvAnimalDiet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstvAnimalDiet.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvAnimalDiet.FullRowSelect = true;
            this.lstvAnimalDiet.HideSelection = false;
            this.lstvAnimalDiet.Location = new System.Drawing.Point(692, 46);
            this.lstvAnimalDiet.MultiSelect = false;
            this.lstvAnimalDiet.Name = "lstvAnimalDiet";
            this.lstvAnimalDiet.Size = new System.Drawing.Size(308, 130);
            this.lstvAnimalDiet.TabIndex = 20;
            this.lstvAnimalDiet.UseCompatibleStateImageBehavior = false;
            this.lstvAnimalDiet.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 83;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Food items";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 220;
            // 
            // lblDiet
            // 
            this.lblDiet.AutoSize = true;
            this.lblDiet.ForeColor = System.Drawing.Color.Black;
            this.lblDiet.Location = new System.Drawing.Point(949, 20);
            this.lblDiet.Name = "lblDiet";
            this.lblDiet.Size = new System.Drawing.Size(27, 13);
            this.lblDiet.TabIndex = 17;
            this.lblDiet.Text = "N/A";
            // 
            // lblAnimalDiet
            // 
            this.lblAnimalDiet.AutoSize = true;
            this.lblAnimalDiet.ForeColor = System.Drawing.Color.Black;
            this.lblAnimalDiet.Location = new System.Drawing.Point(689, 20);
            this.lblAnimalDiet.Name = "lblAnimalDiet";
            this.lblAnimalDiet.Size = new System.Drawing.Size(69, 13);
            this.lblAnimalDiet.TabIndex = 16;
            this.lblAnimalDiet.Text = "Animal´s diet:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1041, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.toolStripSeparator1,
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.toolStripSeparator3,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(50, 20);
            this.mnuFile.Text = "Menu";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNew.Size = new System.Drawing.Size(180, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.tstripNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Size = new System.Drawing.Size(180, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(180, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(180, 22);
            this.mnuSaveAs.Text = "Save as";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuExit.Size = new System.Drawing.Size(180, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 566);
            this.Controls.Add(this.grpAnimalSpecifications);
            this.Controls.Add(this.grpAnimals);
            this.Controls.Add(this.btnSortBy);
            this.Controls.Add(this.cmbSortBy);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMain";
            this.Text = "Apu Animal Park - Andreas Hägglund";
            this.grpAnimalSpecifications.ResumeLayout(false);
            this.grpAnimalSpecifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimal)).EndInit();
            this.grpGenderType.ResumeLayout(false);
            this.grpSpecifications.ResumeLayout(false);
            this.grpSpecifications.PerformLayout();
            this.grpAnimals.ResumeLayout(false);
            this.grpAnimals.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAnimalSpecifications;
        private System.Windows.Forms.Label lblAnimalSpecie;
        private System.Windows.Forms.Label lblCategoryType;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ListBox lstAnimalCategory;
        private System.Windows.Forms.GroupBox grpSpecifications;
        private System.Windows.Forms.Label lblSpecification2;
        private System.Windows.Forms.Label lblSpecification1;
        private System.Windows.Forms.GroupBox grpGenderType;
        private System.Windows.Forms.ListBox lstAnimalSpecie;
        private System.Windows.Forms.ListBox lstGenderType;
        private System.Windows.Forms.TextBox txtSpecification1;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox cboxListAnimals;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblSpecieInfo;
        private System.Windows.Forms.TextBox txtSpecification2;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.PictureBox picAnimal;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.ListView lstvAnimals;
        private System.Windows.Forms.Button btnSortBy;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.GroupBox grpAnimals;
        private System.Windows.Forms.ColumnHeader idAnimals;
        private System.Windows.Forms.ColumnHeader nameAnimals;
        private System.Windows.Forms.ColumnHeader weightAnimals;
        private System.Windows.Forms.ColumnHeader ageAnimals;
        private System.Windows.Forms.ColumnHeader genderAnimals;
        private System.Windows.Forms.Label lblDiet;
        private System.Windows.Forms.Label lblAnimalDiet;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lstvFoodItems;
        private System.Windows.Forms.ColumnHeader foodItems;
        private System.Windows.Forms.ColumnHeader foodName;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ListView lstvAnimalDiet;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

