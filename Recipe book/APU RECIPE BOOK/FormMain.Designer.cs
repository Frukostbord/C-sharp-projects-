namespace APU_RECIPE_BOOK
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
            this.components = new System.ComponentModel.Container();
            this.grpAddRecipe = new System.Windows.Forms.GroupBox();
            this.txtInstructions = new System.Windows.Forms.TextBox();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.cmbFoodCategory = new System.Windows.Forms.ComboBox();
            this.lblCategoryAdd = new System.Windows.Forms.Label();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.lblNameRecipeAdd = new System.Windows.Forms.Label();
            this.txtNameRecipe = new System.Windows.Forms.TextBox();
            this.lblNameOfAddedRecipes = new System.Windows.Forms.Label();
            this.lblCategoryOfAddedRecipes = new System.Windows.Forms.Label();
            this.lblNrIngredients = new System.Windows.Forms.Label();
            this.lblDoubleClickInformation = new System.Windows.Forms.Label();
            this.btnEditBegin = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEditFinish = new System.Windows.Forms.Button();
            this.lstRecipes = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grpAddRecipe.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAddRecipe
            // 
            this.grpAddRecipe.Controls.Add(this.txtInstructions);
            this.grpAddRecipe.Controls.Add(this.btnAddIngredient);
            this.grpAddRecipe.Controls.Add(this.cmbFoodCategory);
            this.grpAddRecipe.Controls.Add(this.lblCategoryAdd);
            this.grpAddRecipe.Controls.Add(this.btnAddRecipe);
            this.grpAddRecipe.Controls.Add(this.lblNameRecipeAdd);
            this.grpAddRecipe.Controls.Add(this.txtNameRecipe);
            this.grpAddRecipe.Location = new System.Drawing.Point(12, 12);
            this.grpAddRecipe.Name = "grpAddRecipe";
            this.grpAddRecipe.Size = new System.Drawing.Size(310, 462);
            this.grpAddRecipe.TabIndex = 0;
            this.grpAddRecipe.TabStop = false;
            this.grpAddRecipe.Text = "Add new recipe";
            // 
            // txtInstructions
            // 
            this.txtInstructions.Location = new System.Drawing.Point(6, 98);
            this.txtInstructions.Multiline = true;
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.Size = new System.Drawing.Size(295, 321);
            this.txtInstructions.TabIndex = 7;
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Location = new System.Drawing.Point(183, 69);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(118, 23);
            this.btnAddIngredient.TabIndex = 6;
            this.btnAddIngredient.Text = "Add Ingredients";
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // cmbFoodCategory
            // 
            this.cmbFoodCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFoodCategory.FormattingEnabled = true;
            this.cmbFoodCategory.Location = new System.Drawing.Point(61, 70);
            this.cmbFoodCategory.Name = "cmbFoodCategory";
            this.cmbFoodCategory.Size = new System.Drawing.Size(116, 21);
            this.cmbFoodCategory.TabIndex = 5;
            this.cmbFoodCategory.SelectedIndexChanged += new System.EventHandler(this.cmbFoodCategory_SelectedIndexChanged);
            // 
            // lblCategoryAdd
            // 
            this.lblCategoryAdd.AutoSize = true;
            this.lblCategoryAdd.Location = new System.Drawing.Point(6, 73);
            this.lblCategoryAdd.Name = "lblCategoryAdd";
            this.lblCategoryAdd.Size = new System.Drawing.Size(49, 13);
            this.lblCategoryAdd.TabIndex = 4;
            this.lblCategoryAdd.Text = "Category";
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(6, 425);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(295, 23);
            this.btnAddRecipe.TabIndex = 3;
            this.btnAddRecipe.Text = "Add recipe";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // lblNameRecipeAdd
            // 
            this.lblNameRecipeAdd.AutoSize = true;
            this.lblNameRecipeAdd.Location = new System.Drawing.Point(6, 22);
            this.lblNameRecipeAdd.Name = "lblNameRecipeAdd";
            this.lblNameRecipeAdd.Size = new System.Drawing.Size(79, 13);
            this.lblNameRecipeAdd.TabIndex = 1;
            this.lblNameRecipeAdd.Text = "Name of recipe";
            // 
            // txtNameRecipe
            // 
            this.txtNameRecipe.Location = new System.Drawing.Point(91, 19);
            this.txtNameRecipe.Name = "txtNameRecipe";
            this.txtNameRecipe.Size = new System.Drawing.Size(210, 20);
            this.txtNameRecipe.TabIndex = 0;
            // 
            // lblNameOfAddedRecipes
            // 
            this.lblNameOfAddedRecipes.AutoSize = true;
            this.lblNameOfAddedRecipes.Location = new System.Drawing.Point(343, 31);
            this.lblNameOfAddedRecipes.Name = "lblNameOfAddedRecipes";
            this.lblNameOfAddedRecipes.Size = new System.Drawing.Size(35, 13);
            this.lblNameOfAddedRecipes.TabIndex = 1;
            this.lblNameOfAddedRecipes.Text = "Name";
            // 
            // lblCategoryOfAddedRecipes
            // 
            this.lblCategoryOfAddedRecipes.AutoSize = true;
            this.lblCategoryOfAddedRecipes.Location = new System.Drawing.Point(476, 31);
            this.lblCategoryOfAddedRecipes.Name = "lblCategoryOfAddedRecipes";
            this.lblCategoryOfAddedRecipes.Size = new System.Drawing.Size(49, 13);
            this.lblCategoryOfAddedRecipes.TabIndex = 2;
            this.lblCategoryOfAddedRecipes.Text = "Category";
            // 
            // lblNrIngredients
            // 
            this.lblNrIngredients.Location = new System.Drawing.Point(648, 21);
            this.lblNrIngredients.Name = "lblNrIngredients";
            this.lblNrIngredients.Size = new System.Drawing.Size(60, 30);
            this.lblNrIngredients.TabIndex = 4;
            this.lblNrIngredients.Text = "No. of Ingredients";
            this.lblNrIngredients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDoubleClickInformation
            // 
            this.lblDoubleClickInformation.AutoSize = true;
            this.lblDoubleClickInformation.ForeColor = System.Drawing.Color.Teal;
            this.lblDoubleClickInformation.Location = new System.Drawing.Point(387, 461);
            this.lblDoubleClickInformation.Name = "lblDoubleClickInformation";
            this.lblDoubleClickInformation.Size = new System.Drawing.Size(308, 13);
            this.lblDoubleClickInformation.TabIndex = 5;
            this.lblDoubleClickInformation.Text = "Double click on an item for ingredients and cooking instructions!";
            // 
            // btnEditBegin
            // 
            this.btnEditBegin.Location = new System.Drawing.Point(328, 424);
            this.btnEditBegin.Name = "btnEditBegin";
            this.btnEditBegin.Size = new System.Drawing.Size(84, 23);
            this.btnEditBegin.TabIndex = 7;
            this.btnEditBegin.Text = "Edit-Begin";
            this.btnEditBegin.UseVisualStyleBackColor = true;
            this.btnEditBegin.Click += new System.EventHandler(this.btnEditBegin_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(633, 424);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(100, 23);
            this.btnClearSelection.TabIndex = 8;
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(526, 424);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEditFinish
            // 
            this.btnEditFinish.Location = new System.Drawing.Point(427, 424);
            this.btnEditFinish.Name = "btnEditFinish";
            this.btnEditFinish.Size = new System.Drawing.Size(84, 23);
            this.btnEditFinish.TabIndex = 10;
            this.btnEditFinish.Text = "Edit-Finish";
            this.btnEditFinish.UseVisualStyleBackColor = true;
            this.btnEditFinish.Click += new System.EventHandler(this.btnEditFinish_Click);
            // 
            // lstRecipes
            // 
            this.lstRecipes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRecipes.FormattingEnabled = true;
            this.lstRecipes.ItemHeight = 14;
            this.lstRecipes.Location = new System.Drawing.Point(328, 54);
            this.lstRecipes.Name = "lstRecipes";
            this.lstRecipes.Size = new System.Drawing.Size(405, 354);
            this.lstRecipes.TabIndex = 11;
            this.lstRecipes.DoubleClick += new System.EventHandler(this.lstRecipes_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 486);
            this.Controls.Add(this.lstRecipes);
            this.Controls.Add(this.btnEditFinish);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClearSelection);
            this.Controls.Add(this.btnEditBegin);
            this.Controls.Add(this.lblDoubleClickInformation);
            this.Controls.Add(this.lblNrIngredients);
            this.Controls.Add(this.lblCategoryOfAddedRecipes);
            this.Controls.Add(this.lblNameOfAddedRecipes);
            this.Controls.Add(this.grpAddRecipe);
            this.Name = "FormMain";
            this.Text = "Apu Recipe Book Andreas Hägglund";
            this.grpAddRecipe.ResumeLayout(false);
            this.grpAddRecipe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddRecipe;
        private System.Windows.Forms.Label lblNameRecipeAdd;
        private System.Windows.Forms.TextBox txtNameRecipe;
        private System.Windows.Forms.Label lblCategoryAdd;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.Label lblNameOfAddedRecipes;
        private System.Windows.Forms.Label lblCategoryOfAddedRecipes;
        private System.Windows.Forms.Label lblNrIngredients;
        private System.Windows.Forms.Label lblDoubleClickInformation;
        private System.Windows.Forms.ComboBox cmbFoodCategory;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.Button btnEditBegin;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEditFinish;
        private System.Windows.Forms.ListBox lstRecipes;
        private System.Windows.Forms.TextBox txtInstructions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

