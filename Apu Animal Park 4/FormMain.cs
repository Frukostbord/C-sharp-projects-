using Apu_Animal_Park_4.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Apu_Animal_Park_4
{

    /// <summary>
    /// This is the Main form of the program. Its´ purpose is to create an object of a animal chosen
    /// by the user and display it on a label. It also allows the user to chose a picture of a animal.
    /// The program completes its´ purpose by:
    /// 
    /// 1. Letting the user pick an animal category and a specific animal.
    /// 1a. All specific animals can be displayed and selected, without selecting an animal category, by
    ///     selecting the checkbox "list all animals".
    /// 
    /// 2. The user enters relevant information for all animals, corresponding to the Animal object.
    /// 2a. Information relevant to the different animal categories and specific animals are displayed 
    ///     seperately.
    /// 
    /// 3. Methods are called to control input.
    /// 
    /// 4. If the input is valid (doesn´t check if a picture is added), an animal object is added to
    ///     the list in the variable animalManager.
    /// 
    /// 5. A listview displays all the animals and allows the user to select any animal object to display
    /// 5a. Extra information of that particular animal.
    /// 5b. Diet of that particular animal.
    /// </summary>

    public partial class FormMain : Form
    {
        AnimalManager animalManager = new AnimalManager();
        FoodManager foodManager = new FoodManager();
        SaveFile file = new SaveFile();

        public FormMain()
        {
            InitializeComponent();

            // Sets up GUI for user in FormMain
            InitializeGUI();

        }

        #region Initialize and Refresh GUI
        /// <summary>
        /// Setting up GUI at run time for the user
        /// </summary>
        private void InitializeGUI()
        {
            lstGenderType.DataSource = Enum.GetValues(typeof(Gender));
            lstAnimalCategory.DataSource = Enum.GetValues(typeof(AnimalType));
            cmbSortBy.DataSource = Enum.GetValues(typeof(SortingEnums));

            txtSpecification1.Enabled = false;
            txtSpecification2.Enabled = false;
            btnSortBy.Enabled = false;
            cmbSortBy.Enabled = false;

            lstGenderType.SelectedIndex = -1;
            lstAnimalCategory.SelectedIndex = -1;

            grpSpecifications.Text = "";
            lblSpecification1.Text = "";

            saveFileDialog.Filter = "Text Files|*.txt|JavaScript Object Notation (JSON)|*.json|Binary Serialization|*.bin|XML format|*.xml"; // Information to user
            saveFileDialog.DefaultExt = "txt"; // File format
            saveFileDialog.Title = "Saving current animal park"; // Title
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory + @"\Example files";



            openFileDialog.Filter = "Text Files|*.txt|JavaScript Object Notation (JSON)|*.json|Binary Serialization|*.bin|XML format|*.xml"; // Information to user
            openFileDialog.DefaultExt = "txt"; // File format
            openFileDialog.Title = "Opening current animal park"; // Title
            openFileDialog.FileName = string.Empty;
            openFileDialog.InitialDirectory = Environment.CurrentDirectory + @"\Example files";

        }

        /// <summary>
        /// Refreshes GUI. Resets all selections and all text.
        /// </summary>
        private void ClearAnimalInput()
        {

            lstGenderType.SelectedIndex = -1;
            lstAnimalSpecie.SelectedIndex = -1;
            lstAnimalCategory.SelectedIndex = -1;
            cboxListAnimals.Checked = false;


            txtSpecification1.Enabled = false;
            lblSpecification1.Text = string.Empty;
            grpSpecifications.Text = string.Empty;
            txtName.Clear();
            txtAge.Clear();
            txtWeight.Clear();
            txtSpecification1.Clear();
            txtSpecification2.Clear();
            lstAnimalSpecie.Items.Clear();

        }

        #endregion
        #region Adjusting GUI to user choices

        /// <summary>
        /// Adjusts GUI if a new animal in the animal category has been chosen.
        /// </summary>

        private void lstCategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAnimalSpecie.Items.Clear();
            lblSpecification2.Text = string.Empty;
            txtSpecification2.Enabled = false;

            if (!cboxListAnimals.Checked && lstAnimalCategory.SelectedIndex != -1)
            {
                AddSpecificAnimalsListbox(); // What specific animals to the category should be added

                // What information should be displayed on the label, next to textbox
                AnimalCategorySpecification((AnimalType)lstAnimalCategory.SelectedItem);

            }

        }


        /// <summary>
        /// Controls if the textbox for the specification for a animal category should be enabled.
        /// </summary>
        private void AnimalCategorySpecification(AnimalType animalType)
        {
            txtSpecification1.Enabled = true;

            switch (animalType)
            {
                case (AnimalType.Mammal):
                    grpSpecifications.Text = "Mammal: ";
                    lblSpecification1.Text = "Number of teeth";
                    break;
                case (AnimalType.Insect):
                    grpSpecifications.Text = "Insect: ";
                    lblSpecification1.Text = "Number of limbs";
                    break;
                case (AnimalType.Reptile):
                    grpSpecifications.Text = "Reptile: ";
                    lblSpecification1.Text = "Egg size diameter (cm)";
                    break;
                case (AnimalType.Fish):
                    grpSpecifications.Text = "Fish: ";
                    lblSpecification1.Text = "Preferred depth (m)";
                    break;
            }

        }

        /// <summary>
        /// Controls if the textbox for the specification for a specific animal should be enabled.
        /// </summary>

        private void lstAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool index = lstAnimalSpecie.SelectedIndex != -1;
            if (!cboxListAnimals.Checked)
            {

                if (index)
                {
                    AnimalSpecificSpecification();
                    txtSpecification2.Enabled = true;
                    txtSpecification2.Text = "";
                }

                else
                {
                    txtSpecification2.Enabled = false;
                    lblSpecification2.Text = "";
                }
            }

            if (cboxListAnimals.Checked)
            {
                if (index)
                {
                    AnimalSpecificSpecification();
                    txtSpecification1.Enabled = true;
                    txtSpecification2.Enabled = true;
                }


            }
        }

        /// <summary>
        /// Each block of "if" statement does:
        /// 1. Controls what category of animal the specific animal belongs to
        /// 2. Adds specific text for the label of the animal category (e.g eggsize)
        /// 3. Controls, with a switch statement, which enum in the relevant category.
        ///     e.g animal category = mammal, the switch statement goes through all mammals
        /// 4. Updates groupbox information and relevant information on label
        /// </summary>
        private void AnimalSpecificSpecification()
        {


            // Checking if selected animal is a mammal type
            if (Enum.IsDefined(typeof(MammalTypes), lstAnimalSpecie.SelectedItem))
            {
                // Convert it to a enum
                MammalTypes mammal = (MammalTypes)Enum.Parse(typeof(MammalTypes), lstAnimalSpecie.SelectedItem.ToString());
                lblSpecification1.Text = "Number of teeth"; // Mammal specific information

                // Switch statement
                switch (mammal)
                {

                    case MammalTypes.Cat:
                        lblSpecification2.Text = "Fur color"; // Specific information for specific animal
                        UpdateGroupbox(AnimalType.Mammal, "Cat"); // Update groupbox information
                        break;

                    case MammalTypes.Dog:
                        lblSpecification2.Text = "Breed";
                        UpdateGroupbox(AnimalType.Mammal, "Dog");
                        break;

                }
            }

            if (Enum.IsDefined(typeof(InsectTypes), lstAnimalSpecie.SelectedItem))
            {
                InsectTypes insect = (InsectTypes)Enum.Parse(typeof(InsectTypes), lstAnimalSpecie.SelectedItem.ToString());
                lblSpecification1.Text = "Number of limbs";

                switch (insect)
                {
                    case InsectTypes.Bee:
                        lblSpecification2.Text = "Preferred flower";
                        UpdateGroupbox(AnimalType.Insect, "Bee");
                        break;

                    case InsectTypes.Ant:
                        lblSpecification2.Text = "Number of queens";
                        UpdateGroupbox(AnimalType.Insect, "Ant");
                        break;

                }

            }

            if (Enum.IsDefined(typeof(ReptileTypes), lstAnimalSpecie.SelectedItem))
            {
                ReptileTypes reptile = (ReptileTypes)Enum.Parse(typeof(ReptileTypes), lstAnimalSpecie.SelectedItem.ToString());
                lblSpecification1.Text = "Egg size diameter (cm)";

                switch (reptile)
                {
                    case ReptileTypes.Lizard:
                        lblSpecification2.Text = "Preferred terrain";
                        UpdateGroupbox(AnimalType.Reptile, "Lizard");
                        break;

                    case ReptileTypes.Snake:
                        lblSpecification2.Text = "Effects of venom";
                        UpdateGroupbox(AnimalType.Reptile, "Snake");
                        break;

                }
            }


            if (Enum.IsDefined(typeof(FishTypes), lstAnimalSpecie.SelectedItem))
            {
                FishTypes fish = (FishTypes)Enum.Parse(typeof(FishTypes), lstAnimalSpecie.SelectedItem.ToString());
                lblSpecification1.Text = "Preferred depth (m)";

                switch (fish)
                {
                    case FishTypes.Goldfish:
                        lblSpecification2.Text = "Seconds of memory";
                        UpdateGroupbox(AnimalType.Fish, "Goldfish");
                        break;

                    case FishTypes.Clownfish:
                        lblSpecification2.Text = "Number of stripes";
                        UpdateGroupbox(AnimalType.Fish, "Clownfish");
                        break;
                }
            }
        }

        /// <summary>
        /// Adds specific animals to the listbox depending on which animal category has been chosen.
        /// </summary>
        private void AddSpecificAnimalsListbox()
        {

            switch ((AnimalType)lstAnimalCategory.SelectedItem)
            {

                case AnimalType.Fish:
                    lstAnimalSpecie.Items.AddRange(Enum.GetNames(typeof(FishTypes)));
                    break;
                case AnimalType.Insect:
                    lstAnimalSpecie.Items.AddRange(Enum.GetNames(typeof(InsectTypes)));
                    break;
                case AnimalType.Mammal:
                    lstAnimalSpecie.Items.AddRange(Enum.GetNames(typeof(MammalTypes)));
                    break;
                case AnimalType.Reptile:
                    lstAnimalSpecie.Items.AddRange(Enum.GetNames(typeof(ReptileTypes)));
                    break;
            }

            lstAnimalSpecie.SelectedIndex = -1;

        }

        /// <summary>
        /// Sets the groupbox text to the animal category and specific animal selected by the user,
        /// if the checkbox "list all animals" is selected. Also enables and updates textbox (txtSpecification1) and label
        /// (lblSpecification1).
        /// </summary>
        /// <param name="specAnimal">Specific animal chosen in the listbox, as a string</param>
        /// <param name="animalType">AnimalType (mammal, fish etc)</param>
        private void UpdateGroupbox(AnimalType animalType, string specAnimal)
        {

            switch (animalType)
            {
                case (AnimalType.Insect):
                    grpSpecifications.Text = "Insect: " + specAnimal;
                    break;

                case (AnimalType.Fish):
                    grpSpecifications.Text = "Fish: " + specAnimal;
                    break;

                case (AnimalType.Reptile):
                    grpSpecifications.Text = "Reptile: " + specAnimal;
                    break;

                case (AnimalType.Mammal):
                    grpSpecifications.Text = "Mammal: " + specAnimal;
                    break;
            }


        }

        /// <summary>
        /// This method set the GUI depending if the checkbox for "list all animals" has been selected or
        /// deselected.
        /// </summary>

        private void cboxListAnimals_CheckedChanged(object sender, EventArgs e)
        {
            // Clears selection, which indirectly calls other methods (lstbox index changed) to
            // clear the current input by the user.
            lstAnimalCategory.SelectedIndex = -1;

            txtSpecification1.Enabled = false;
            txtSpecification2.Enabled = false;
            lblSpecification1.Text = "";
            lblSpecification2.Text = "";

            grpSpecifications.Text = "";
            lstAnimalSpecie.Items.Clear();

            // Adds all animals to listbox
            if (cboxListAnimals.Checked)
            {
                lstAnimalSpecie.Items.AddRange(Enum.GetNames(typeof(FishTypes)));
                lstAnimalSpecie.Items.AddRange(Enum.GetNames(typeof(MammalTypes)));
                lstAnimalSpecie.Items.AddRange(Enum.GetNames(typeof(InsectTypes)));
                lstAnimalSpecie.Items.AddRange(Enum.GetNames(typeof(ReptileTypes)));

                lstAnimalCategory.Enabled = false;
            }

            else
            {
                lstAnimalCategory.Enabled = true;
            }

        }


        #endregion

        #region Methods for creating Animal object

        /// <summary>
        /// This method:
        /// 
        /// 1. Controls if correct input is given
        /// 2. Get information related to creating the animal and creates it.
        /// 3. If an animal object is successfully created:
        ///     3a. Lets you add a picture
        ///     3b. Displays information related to the created object in the label
        ///     3c. Refreshes GUI, as a visual cue for the user
        /// </summary>

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Animal animal = null;

            if (ControlUserInput())
            {
                CreateAnimal(out animal);

                if (animal != null)
                {
                    animalManager.AddAnimal(animal);
                    UpdateAnimalListview();
                    ClearAnimalInput();
                    ClearSelectedAnimalInfo();
                    ControlSortingBtn();
                }
            }
        }



        /// <summary>
        /// This method has the main responsibility of creating an animal object.
        /// 
        /// 1. It controls if the checkbox "list all animals" has been selected.
        /// 2. It controls what has been selected by the user, according to the checkbox.
        /// 3. It calls other methods to create an animal object.
        /// 4. It returns the animal object in the out parameter
        /// </summary>
        /// <param name="animal">Animal object to be created</param>

        private void CreateAnimal(out Animal animal)
        {
            int age = int.Parse(txtAge.Text);
            string name = txtName.Text;
            float weight = float.Parse(txtWeight.Text);
            string imagePath = picAnimal.ImageLocation;
            Gender gender = (Gender)lstGenderType.SelectedItem;

            string txtSpec1 = txtSpecification1.Text;
            string lblSpec1 = lblSpecification1.Text;
            string txtSpec2 = txtSpecification2.Text;
            string lblSpec2 = lblSpecification2.Text;

            if (!cboxListAnimals.Checked)
            {
                switch ((AnimalType)lstAnimalCategory.SelectedItem)
                {
                    case AnimalType.Mammal:
                        animal = CreateMammal(txtSpec1, lblSpec1, txtSpec2, lblSpec2,
                            age, name, weight, gender, imagePath);
                        break;

                    case AnimalType.Fish:
                        animal = CreateFish(txtSpec1, lblSpec1, txtSpec2, lblSpec2,
                            age, name, weight, gender, imagePath);
                        break;

                    case AnimalType.Insect:
                        animal = CreateInsect(txtSpec1, lblSpec1, txtSpec2, lblSpec2,
                            age, name, weight, gender, imagePath);
                        break;

                    case AnimalType.Reptile:
                        animal = CreateReptile(txtSpec1, lblSpec1, txtSpec2, lblSpec2,
                            age, name, weight, gender, imagePath);
                        break;

                    default:
                        animal = null;
                        break;

                }

            }

            else
            {
                if (Enum.IsDefined(typeof(MammalTypes), lstAnimalSpecie.SelectedItem))
                {
                    animal = CreateMammal(txtSpec1, lblSpec1, txtSpec2, lblSpec2, age, name, weight, gender, imagePath);
                }

                else if (Enum.IsDefined(typeof(ReptileTypes), lstAnimalSpecie.SelectedItem))
                {
                    animal = CreateReptile(txtSpec1, lblSpec1, txtSpec2, lblSpec2, age, name, weight, gender, imagePath);
                }

                else if (Enum.IsDefined(typeof(FishTypes), lstAnimalSpecie.SelectedItem))
                {
                    animal = CreateFish(txtSpec1, lblSpec1, txtSpec2, lblSpec2, age, name, weight, gender, imagePath);
                }

                else if (Enum.IsDefined(typeof(InsectTypes), lstAnimalSpecie.SelectedItem))
                {
                    animal = CreateInsect(txtSpec1, lblSpec1, txtSpec2, lblSpec2, age, name, weight, gender, imagePath);
                }


                else
                {
                    animal = null;
                }

            }


        }
        /// <summary>
        /// Creates an object of Mammal with information of the animal category.
        /// </summary>
        /// <param name="txtSpec1">Specification given of the animal category, e.g "Months in utero"</param>
        /// <param name="lblSpec1">Specification of the animal category of e.g Mammal or Insect</param>
        /// <param name="txtSpec2">Specification given of the specific animal, e.g "Russell Terrier"</param>
        /// <param name="lblSpec2">Specification of the specific animal of e.g Cat or Dog</param>
        /// <param name="age">Age in years</param>
        /// <param name="name">String name of object</param>
        /// <param name="weight">Weight in kilograms</param>
        /// <param name="gender">Gender enum</param>
        /// <returns>An object of a specific mammal</returns>

        private Animal CreateMammal(string txtSpec1, string lblSpec1, string txtSpec2, string lblSpec2,
            int age, string name, float weight, Gender gender, string imagePath)
        {
            Animal animal = null;

            bool spec1 = ControlSpecificationInteger(txtSpec1, out int nrOfTeeth, lblSpec1);

            MammalTypes type = (MammalTypes)Enum.Parse(typeof(MammalTypes), lstAnimalSpecie.SelectedItem.ToString());


            if (spec1)
            {
                switch (type)
                {
                    case MammalTypes.Cat:
                        if (ControlSpecificationString(txtSpec2, lblSpec2))
                            animal = new Cat(txtSpec2, nrOfTeeth, age, name, weight, gender, imagePath);

                        return animal;

                    case MammalTypes.Dog:
                        if (ControlSpecificationString(txtSpec2, lblSpec2))
                            animal = new Dog(txtSpec2, nrOfTeeth, age, name, weight, gender, imagePath);
                        return animal;


                }
            }
            return animal;

        }


        /// <summary>
        /// Creates an object of Fish with information of the animal category.
        /// </summary>
        /// <param name="txtSpec1">Specification given of the animal category, e.g "Months in utero"</param>
        /// <param name="lblSpec1">Specification of the animal category of e.g Mammal or Insect</param>
        /// <param name="txtSpec2">Specification given of the specific animal, e.g "Russell Terrier"</param>
        /// <param name="lblSpec2">Specification of the specific animal of e.g Cat or Dog</param>
        /// <param name="age">Age in years</param>
        /// <param name="name">String name of object</param>
        /// <param name="weight">Weight in kilograms</param>
        /// <param name="gender">Gender enum</param>
        /// <returns>An object of a specific fish</returns>
        private Animal CreateFish(string txtSpec1, string lblSpec1, string txtSpec2, string lblSpec2,
            int age, string name, float weight, Gender gender, string imagePath)
        {
            Animal animal = null;
            bool spec1 = ControlSpecificationInteger(txtSpec1, out int prefDepth, lblSpec1);

            FishTypes type = (FishTypes)Enum.Parse(typeof(FishTypes), lstAnimalSpecie.SelectedItem.ToString());


            if (spec1)
            {
                switch (type)
                {
                    case FishTypes.Goldfish:
                        if (ControlSpecificationInteger(txtSpec2, out int memory, lblSpec2))
                            animal = new Goldfish(memory, prefDepth, age, name, weight, gender, imagePath);

                        return animal;

                    case FishTypes.Clownfish:
                        if (ControlSpecificationInteger(txtSpec2, out int stripes, lblSpec2))
                            animal = new Clownfish(stripes, prefDepth, age, name, weight, gender, imagePath);
                        return animal;


                }
            }
            return animal;

        }


        /// <summary>
        /// Creates an object of Reptile with information of the animal category.
        /// </summary>
        /// <param name="txtSpec1">Specification given of the animal category, e.g "Months in utero"</param>
        /// <param name="lblSpec1">Specification of the animal category of e.g Mammal or Insect</param>
        /// <param name="txtSpec2">Specification given of the specific animal, e.g "Russell Terrier"</param>
        /// <param name="lblSpec2">Specification of the specific animal of e.g Cat or Dog</param>
        /// <param name="age">Age in years</param>
        /// <param name="name">String name of object</param>
        /// <param name="weight">Weight in kilograms</param>
        /// <param name="gender">Gender enum</param>
        /// <returns>An object of a specific reptile</returns>

        private Animal CreateReptile(string txtSpec1, string lblSpec1, string txtSpec2, string lblSpec2,
            int age, string name, float weight, Gender gender, string imagePath)
        {
            Animal animal = null;
            bool spec1 = ControlSpecificationInteger(txtSpec1, out int eggsize, lblSpec1);

            ReptileTypes rType = (ReptileTypes)Enum.Parse(typeof(ReptileTypes), lstAnimalSpecie.SelectedItem.ToString());


            if (spec1)
            {
                switch (rType)
                {
                    case ReptileTypes.Lizard:
                        if (ControlSpecificationString(txtSpec2, lblSpec2))
                            animal = new Lizard(txtSpec2, eggsize, age, name, weight, gender, imagePath);

                        return animal;

                    case ReptileTypes.Snake:
                        if (ControlSpecificationString(txtSpec2, lblSpec2))
                            animal = new Snake(txtSpec2, eggsize, age, name, weight, gender, imagePath);
                        return animal;


                }
            }
            return animal;
        }


        /// <summary>
        /// Creates an object of Insect with information of the animal category.
        /// </summary>
        /// <param name="txtSpec1">Specification given of the animal category, e.g "Months in utero"</param>
        /// <param name="lblSpec1">Specification of the animal category of e.g Mammal or Insect</param>
        /// <param name="txtSpec2">Specification given of the specific animal, e.g "Russell Terrier"</param>
        /// <param name="lblSpec2">Specification of the specific animal of e.g Cat or Dog</param>
        /// <param name="age">Age in years</param>
        /// <param name="name">String name of object</param>
        /// <param name="weight">Weight in kilograms</param>
        /// <param name="gender">Gender enum</param>
        /// <returns>An object of a specific insect</returns>
        private Animal CreateInsect(string txtSpec1, string lblSpec1, string txtSpec2, string lblSpec2,
            int age, string name, float weight, Gender gender, string imagePath)
        {
            Animal animal = null;
            bool spec1 = ControlSpecificationInteger(txtSpec1, out int nrOfLimbs, lblSpec1);

            InsectTypes iType = (InsectTypes)Enum.Parse(typeof(InsectTypes), lstAnimalSpecie.SelectedItem.ToString());

            if (spec1)
            {
                switch (iType)
                {
                    case InsectTypes.Ant:
                        if (ControlSpecificationInteger(txtSpec2, out int nrQueens, lblSpec2))
                            animal = new Ant(nrQueens, nrOfLimbs, age, name, weight, gender, imagePath);

                        return animal;

                    case InsectTypes.Bee:
                        if (ControlSpecificationString(txtSpec2, lblSpec2))
                            animal = new Bee(txtSpec2, nrOfLimbs, age, name, weight, gender, imagePath);
                        return animal;

                }
            }
            return animal;

        }


        /// <summary>
        /// Controls if any speficiation is written by the user.
        /// </summary>
        /// <param name="str">String to be controlled</param>
        /// <param name="unit">Specific unit related to the object, displayed in error message</param>
        /// <returns>Boolean value if string != null or empty</returns>
        private bool ControlSpecificationString(string str, string unit)
        {
            bool ok = !String.IsNullOrEmpty(str);

            if (!ok) { MessageBox.Show($"Please look over your input for {unit}!"); }

            return ok;
        }

        /// <summary>
        /// Controls if an integer given is valid. Else returns a error message, showing which value
        /// needs to be edited.
        /// </summary>
        /// <param name="str">String to be converted to an Integer.</param>
        /// <param name="result">Integer to be returned</param>
        /// <param name="unit">Specific unit related to the object, displayed in error message</param>
        /// <returns>Boolean value if unit is correct. Out parameter (result) is an integer</returns>
        private bool ControlSpecificationInteger(string str, out int result, string unit)
        {
            bool ok = int.TryParse(str, out result);

            if (!ok || result < -1) { MessageBox.Show($"Please look over your input for {unit}!"); }

            if (ok && result > -1) { return ok; }
            return false;
        }

        /// <summary>
        /// 1. Calls method from class "Imagehandler".
        /// 2. If a picture file is selected, add it to the picture box in FormMain.
        /// </summary>
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            if (ImageHandler.GetImagePath(out string path)) { picAnimal.Image = Image.FromFile(path); }
        }


        #endregion
        #region Control user input - Animal Object

        /// <summary>
        /// Calls other controlling methods. Returns a boolean value with different controls
        /// if the checkbox for "list all animals" has been selected.
        /// </summary>
        /// <returns>Boolean value if all user input relating to the Animals object has been given.</returns>
        private bool ControlUserInput()
        {
            bool name = ControlName();
            bool age = ControlAge();
            bool gender = ControlGender();
            bool weight = ControlWeight();
            bool category = ControlCategory();
            bool animal = ControlAnimal();

            return name && age && gender && weight && category && animal;
        }

        /// <summary>
        /// Controls if a valid weight (in kilograms) has been given by the user.
        /// </summary>
        /// <returns>Boolean value if a valid weight has been given</returns>
        private bool ControlWeight()
        {
            float result;
            bool kilogram = float.TryParse(txtWeight.Text, out result);

            if (!kilogram || result < 0.0) { MessageBox.Show("Please insert a valid weight in Kilograms!"); }

            if (kilogram && result > 0.0)
                return kilogram;
            return kilogram;
        }

        /// <summary>
        /// Controls if a animal category (e.g Insect, Fish etc) has been selected in the listbox).
        /// </summary>
        /// <returns>Boolean value if a category of animal has been selected.</returns>
        private bool ControlCategory()
        {
            bool category = lstAnimalCategory.SelectedIndex != -1;

            if (!category) { MessageBox.Show("Please select a category of animal!"); }

            return category;

        }

        /// <summary>
        /// Controls if a specific animal (e.g Lion, Cat etc) has been selected in the listbox).
        /// </summary>
        /// <returns>Boolean value if a specific animal has been selected.</returns>
        private bool ControlAnimal()
        {
            bool animal = lstAnimalSpecie.SelectedIndex != -1;

            if (!animal) { MessageBox.Show("Please select an animal!"); }

            return animal;

        }

        /// <summary>
        /// Controls if a valid age has been written by the user.
        /// </summary>
        /// <returns>Boolean value if a valid age has been written.</returns>
        private bool ControlAge()
        {
            int result;
            bool age = int.TryParse(txtAge.Text, out result);

            if (!age) { MessageBox.Show("Please insert a valid whole number (ingeter)"); }

            return age;
        }

        /// <summary>
        /// Controls if a name has been written by the user.
        /// </summary>
        /// <returns>Boolean value if a name has been written.</returns>
        private bool ControlName()
        {
            bool name = !String.IsNullOrEmpty(txtName.Text);

            if (!name) { MessageBox.Show("Please write a name!"); }

            return name;
        }

        /// <summary>
        /// Controls if a gender has been selected by the user.
        /// </summary>
        /// <returns>Boolean value if a gender is selected.</returns>
        private bool ControlGender()
        {
            bool gender = lstGenderType.SelectedIndex != -1;

            if (!gender) { MessageBox.Show("Please select a gender!"); }

            return gender;
        }


        #endregion

        #region GUI and sorting for all animals

        /// <summary>
        /// Updates Listview with all the created animal objects in animalManager.
        /// </summary>
        private void UpdateAnimalListview()
        {
            //List of array of strings (string[]) of animal information
            List<string[]> animalInfo = animalManager.ToListStringArray();

            lstvAnimals.Items.Clear(); // Clears all items

            foreach (string[] animal in animalInfo)
            {
                // Create a new item to add
                ListViewItem item = new ListViewItem(animal);
                lstvAnimals.Items.Add(item); // Add array of string to listview
            }
        }



        /// <summary>
        /// If an animal is selected in the Listview, it gets that animal object´s information regarding
        /// 1. Food schedule
        /// 2. Extra information about the animal category and specific type of animal.
        /// 
        /// Nr.1 is displayed to the right in a listbox in FormMain.
        /// Nr.2 is displayed in a label to the left in FormMain.
        /// </summary>
        private void lstvAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelectedAnimalInfo();
            cboxListAnimals.Checked = false;
            Animal animal;

            int index;

            if (lstvAnimals.SelectedItems.Count == 1 && lstvAnimals.FocusedItem.Index != -1)
            {
                index = lstvAnimals.FocusedItem.Index;

                animal = animalManager.GetAt(index);

                SelectedAnimalFoodSchedule(animal);
                DisplayAnimalInformation(animal);
                DisplaySpecieInfo(animal);

                ControlChangeDeleteBtn();
                ControlFoodAndAnimal();
            }

            else { ClearAnimalInput(); }
        }


        private void DisplaySpecieInfo(Animal animal)
        {
            string info;
            string[] arrayInfo = animal.GetSpecieInfo();

            for (int i = 0; i < arrayInfo.Length; i++)
            {
                info = arrayInfo[i];
                lblSpecieInfo.Text += info;
            }
        }


        /// <summary>
        /// Displays fooditems for animal
        /// </summary>
        /// <param name="animal">Animal´s food item to display</param>
        private void SelectedAnimalFoodSchedule(Animal animal)
        {
            lblDiet.Text = animal.AnimalDiet.ToString();

            FoodItem foodItem;
            string[] food;
            List<string[]> foodInfo = foodManager.ToListStringArray();

            for (int i = 0; i < foodManager.Count; i++)
            {
                foodItem = foodManager.GetAt(i);
                if (foodManager.ControlAnimalHasFoodItem(foodItem, animal))
                {
                    food = foodInfo[i];
                    ListViewItem item = new ListViewItem(food);
                    lstvAnimalDiet.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Clear all information regarding the specific animal.
        /// </summary>
        private void ClearSelectedAnimalInfo()
        {
            lblSpecieInfo.Text = string.Empty;
            lstvAnimalDiet.Items.Clear();
            lblDiet.Text = "N/A";

        }


        /// <summary>
        /// Controls if there are one or more animal objects in animal manager to be sorted.
        /// Else, disables button and combo box for sorting in FormMain.
        /// </summary>
        private void ControlSortingBtn()
        {
            if (animalManager.Count > 0)
            {
                btnSortBy.Enabled = true;
                cmbSortBy.Enabled = true;
                cmbSortBy.SelectedIndex = -1;
            }
            else
            {
                btnSortBy.Enabled = false;
                cmbSortBy.Enabled = false;
            }

        }

        /// <summary>
        /// If an animal object exist and a sorting method has been chosen, this method sorts all the
        /// animal objects in animalManager by calling other methods. After that it refreshes the listview.
        /// </summary>
        private void btnSortBy_Click(object sender, EventArgs e)
        {
            if (animalManager.Count > 0 && cmbSortBy.SelectedIndex != -1)
            {
                SortAnimalManager();
                UpdateAnimalListview();
            }
        }

        /// <summary>
        /// This method sorts all animals in the variable animalManager, containing objects of the class Animal.
        /// </summary>
        private void SortAnimalManager()
        {

            switch (cmbSortBy.SelectedItem) // Selected item to sort by
            {
                case (SortingEnums.Gender):
                    animalManager.SortObjects(new Animal_SortByGender());
                    break;
                case (SortingEnums.Age):
                    animalManager.SortObjects(new Animal_SortByAge());
                    break;
                case (SortingEnums.Weight):
                    animalManager.SortObjects(new Animal_SortByWeight());
                    break;
                case (SortingEnums.Name):
                    animalManager.SortObjects(new Animal_SortByName());
                    break;
            }
        }


        #endregion
        #region GUI and Button for Changing and Deleting animal
        /// <summary>
        /// Controls if Delete and Change button should be enabled depending upon selection and
        /// number of animal objects exisiting.
        /// </summary>

        private void ControlChangeDeleteBtn()
        {
            if (lstvAnimals.SelectedItems.Count > 0 && animalManager.Count > 0)
            {
                btnDelete.Enabled = true;
                btnChange.Enabled = true;
            }

            else
            {
                btnDelete.Enabled = false;
                btnChange.Enabled = false;
            }
        }

        /// <summary>
        /// Deletes animal object selected by the user.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstvAnimals.FocusedItem.Index;
            if (index != -1) animalManager.DeleteAt(index); // Deletes at the given index

            // Refreshing GUI
            UpdateAnimalListview();
            ClearAnimalInput();
            ClearSelectedAnimalInfo();
        }

        /// <summary>
        /// Replaces selected animal if the button is clicked.
        /// </summary>

        private void btnChange_Click(object sender, EventArgs e)
        {
            Animal animal;
            int index = lstvAnimals.FocusedItem.Index;
            Guid id = GetID(index); // Getting ID from other method


            if (ControlUserInput())
            {
                CreateAnimal(out animal); // Create new animal

                if (animal != null)
                {
                    animal.ID = id; // Setting ID
                    animalManager.ChangeAt(animal, index); // Replace animal object at given index

                    // Updating GUI
                    UpdateAnimalListview();
                    ClearAnimalInput();
                    ClearSelectedAnimalInfo();
                    RemoveSelectionAnimalFood();
                }
            }
        }

        /// <summary>
        /// Retreives ID from animal object at given index
        /// </summary>
        /// <param name="index">Index of animal object</param>
        /// <returns>Guid of animal object</returns>
        private Guid GetID(int index)
        {
            Animal animal = animalManager.GetAt(index);
            Guid id = animal.ID;

            return id;

        }

        /// <summary>
        /// Displays basic animal information in the GUI
        /// </summary>
        /// <param name="animal">Animal object´s information to display</param>
        private void DisplayAnimalInformation(Animal animal)
        {
            txtAge.Text = animal.Age.ToString();
            txtName.Text = animal.Name.ToString();
            txtWeight.Text = animal.Weight.ToString();
            lstGenderType.SelectedItem = animal.Gender;

            DisplayAnimalTypeInfo(animal);

        }

        /// <summary>
        /// Displaying relevant information depending on animal category.
        /// Goes through each category to check if the given animal object is of that type.
        /// </summary>
        /// <param name="animal">Animal object to check of which type it is</param>
        private void DisplayAnimalTypeInfo(Animal animal)
        {
            if (animal is Mammal) // Controlling what type
            {
                Mammal mammal = (Mammal)animal; // Typecasting
                lstAnimalCategory.SelectedItem = AnimalType.Mammal;
                txtSpecification1.Text = mammal.NrTeeth.ToString();

                DisplayInfoMammals(mammal); // Controlling what type of mammal it is

            }

            if (animal is Reptile)
            {
                Reptile reptile = (Reptile)animal;

                lstAnimalCategory.SelectedItem = AnimalType.Reptile;
                txtSpecification1.Text = reptile.Eggsize.ToString();

                DisplayInfoReptiles(reptile);

            }

            if (animal is Fish)
            {
                Fish fish = (Fish)animal;

                lstAnimalCategory.SelectedItem = AnimalType.Fish;
                txtSpecification1.Text = fish.PrefDepth.ToString();

                DisplayInfoFish(fish);

            }

            if (animal is Insect)
            {
                Insect insect = (Insect)animal;

                lstAnimalCategory.SelectedItem = AnimalType.Insect;
                txtSpecification1.Text = insect.NrOfLimbs.ToString();

                DisplayInfoInsects(insect);
            }

        }


        /// <summary>
        /// Controls which type of mammal it is and selects it in the listbox
        /// </summary>
        /// <param name="mammal">Mammal object to control which mammal type it is</param>
        private void DisplayInfoMammals(Mammal mammal)
        {
            if (mammal is Dog)
            {
                Dog dog = (Dog)mammal; // Typecasting
                lstAnimalSpecie.SelectedItem = MammalTypes.Dog.ToString();
                txtSpecification2.Text = dog.Breed;
            }

            else if (mammal is Cat)
            {
                Cat cat = (Cat)mammal;

                lstAnimalSpecie.SelectedItem = MammalTypes.Cat.ToString();
                txtSpecification2.Text = cat.FurColor;
            }


        }


        /// <summary>
        /// Controls which type of reptile it is and selects it in the listbox
        /// </summary>
        /// <param name="reptile">Reptile object to control which reptile type it is</param>
        private void DisplayInfoReptiles(Reptile reptile)
        {
            if (reptile is Lizard)

            {
                Lizard lizard = (Lizard)reptile;

                lstAnimalSpecie.SelectedItem = ReptileTypes.Lizard.ToString();
                txtSpecification2.Text = lizard.PrefTerrain.ToString();
            }
            else if (reptile is Snake)
            {
                Snake snake = (Snake)reptile;

                lstAnimalSpecie.SelectedItem = ReptileTypes.Snake.ToString();
                txtSpecification2.Text = snake.Eggsize.ToString();

            }

        }


        /// <summary>
        /// Controls which type of fish it is and selects it in the listbox
        /// </summary>
        /// <param name="fish">Fish object to control which fish type it is</param>
        private void DisplayInfoFish(Fish fish)
        {
            if (fish is Goldfish)
            {
                Goldfish goldfish = (Goldfish)fish;

                lstAnimalSpecie.SelectedItem = FishTypes.Goldfish.ToString();
                txtSpecification2.Text = goldfish.MemoryLength.ToString();

            }
            else if (fish is Clownfish)
            {
                Clownfish clownfish = (Clownfish)fish;

                lstAnimalSpecie.SelectedItem = FishTypes.Clownfish.ToString();
                txtSpecification2.Text = clownfish.NrStripes.ToString();
            }

        }



        /// <summary>
        /// Controls which type of Insect it is and selects it in the listbox
        /// </summary>
        /// <param name="insect">Insect object to control which insect type it is</param>
        private void DisplayInfoInsects(Insect insect)
        {
            if (insect is Bee)
            {
                Bee bee = (Bee)insect;

                lstAnimalSpecie.SelectedItem = InsectTypes.Bee.ToString();
                txtSpecification2.Text = bee.PrefFlowers.ToString();
            }

            else if (insect is Ant)
            {
                Ant Ant = (Ant)insect;

                lstAnimalSpecie.SelectedItem = InsectTypes.Ant.ToString();
                txtSpecification2.Text = Ant.NrQueens.ToString();
            }

        }
        #endregion

        #region Adding food item to animal

        /// <summary>
        /// Adds food item to an animal:
        /// 1. Gets all food items as string[]
        /// 2. Controls if both an food item and animal has been selected.
        /// 3. Gets food item and animal at given index.
        /// 4. Inserts animal´s ID with method from other class in the dictionary of food items, e.g:
        ///     FoodItem object ("Apple pie"): "Guid xxx, Guid xxy"
        /// 5. Displays text message as visual cue to user if adding was successful or not.
        /// 6. Returns true if successfully added, else false.
        /// 
        /// </summary>
        /// <returns>True if food item was added to the animal, else false</returns>
        private bool AddFoodItemToAnimal()
        {
            Animal animal;
            FoodItem foodItem;
            bool ok = false;

            List<string[]> foodInfo = foodManager.ToListStringArray();
            if (ControlFoodAndAnimalSelected())
            {
                animal = animalManager.GetAt(lstvAnimals.FocusedItem.Index);
                foodItem = foodManager.GetAt(lstvFoodItems.FocusedItem.Index);
                if (!foodManager.ControlAnimalHasFoodItem(foodItem, animal))
                {
                    foodManager.AddFoodItemAnimal(animal, foodItem);
                    MessageBox.Show($"Fooditem: {foodItem.Name} added to\nAnimal: {animal.Name}");
                    ok = true;
                }

                else { MessageBox.Show("Animal already has that food in the schedule!"); }
            }

            return ok;

        }

        /// <summary>
        /// Controls if an animal and food item as been selected
        /// </summary>
        /// <returns>True if a food item and animal has been selected in the listviews</returns>
        private bool ControlFoodAndAnimalSelected()
        {
            bool selected =
                lstvAnimals.SelectedItems.Count == 1 && lstvFoodItems.SelectedItems.Count == 1;

            return selected;
        }

        /// <summary>
        /// Clears selection of food item and animal
        /// </summary>
        private void RemoveSelectionAnimalFood()
        {
            lstvFoodItems.SelectedItems.Clear();
            lstvAnimals.SelectedItems.Clear();
        }


        /// <summary>
        /// Opens up new form for the user to create a food item.
        /// </summary>

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            // Opens up new form
            FormFoodItems foodItemForm = new FormFoodItems();

            // If user selects "OK"
            if (foodItemForm.ShowDialog() == DialogResult.OK)
            {
                FoodItem fooditem = foodItemForm.Fooditem; // Get food item from form
                foodManager.Add(fooditem); // Add food item to foodmanager
                foodManager.AddFoodItemDictionary(fooditem); // Add food item to dictionary of food items
                UpdateFoodItemsListView();
            }

        }

        /// <summary>
        /// Adds all the created food items to the "listview food items"
        /// </summary>
        private void UpdateFoodItemsListView()
        {

            List<string[]> foodInfo = foodManager.ToListStringArray();

            lstvFoodItems.Items.Clear(); // Clears all items

            foreach (string[] food in foodInfo)
            {
                // Create a new item to add
                ListViewItem item = new ListViewItem(food);
                lstvFoodItems.Items.Add(item); // Add array of string to listview
            }
        }


        /// <summary>
        /// Calls other methods to control if an animal and food item has been selected.
        /// If so, add the selected food item to the dictionary in foodmanager.
        /// </summary>

        private void lstvFoodItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvFoodItems.SelectedItems.Count == 1 && lstvFoodItems.FocusedItem.Index != -1)
            { ControlFoodAndAnimal(); }
        }

        /// <summary>
        /// Calls two other methods:
        /// 1. To control if user has selected an animal, a food item and if it has been successfully added
        /// 2. If it has been successfully added, remove selection.
        /// </summary>
        private void ControlFoodAndAnimal()
        {
            if (AddFoodItemToAnimal()) { RemoveSelectionAnimalFood(); }
        }
        #endregion
        #region Menu buttons (Saving and Opening) 
        
        /// <summary>
        /// If there´s no saved file, user is asked to confirm creating a new form.
        /// Calls other methods to clear all data and refresh GUI for user.
        /// </summary>

        private void tstripNew_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult;

            if (String.IsNullOrEmpty(file.FilePath)) // Checking if file is saved
            {
                dialogResult = MessageBox.Show("You will lose all unsaved data.", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.OK)
                {
                    ResetFormMain(); // Resets entire form
                }
            }

            else { ResetFormMain(); } // Resets entire form

        }

        /// <summary>
        /// Clears all data in the form and resets GUI.
        /// </summary>
        private void ResetFormMain()
        {
            // Removing all animals and food 
            animalManager = new AnimalManager();
            foodManager = new FoodManager();
            file = new SaveFile();

            // Refreshing GUI
            RefreshGUI();
            InitializeGUI();
        }

        /// <summary>
        /// Refreshes the entire GUI (textboxes, listboxes, labels etc.) by calling other methods.
        /// </summary>
        private void RefreshGUI()
        {
            UpdateFoodItemsListView();
            UpdateAnimalListview();
            ClearAnimalInput();
            ClearSelectedAnimalInfo();
        }



        /// <summary>
        /// Asks the user if they want to exit the application. If "OK" is selected, exits the application.
        /// </summary>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;

            if (String.IsNullOrEmpty(file.FilePath))
            {
                dialogResult = MessageBox.Show("You will lose all unsaved data.", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.OK)
                {
                    Close();
                }
            }
            else { Close(); }
        }


        /// <summary>
        /// This method:
        /// 1. Opens a saveFileDialog to the user to select a path.
        /// 2. Saves file in the format selected by the user.
        /// </summary>

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            bool fileSaved = false;
            FileInfo fileInfo;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                file.FilePath = Path.GetFullPath(saveFileDialog.FileName); // Setting path name

                try
                {
                    // Custom exception
                    if (!foodManager.ControlFoodItemHasID()) 
                    {throw new FoodNotAssignedException();}

                    switch (saveFileDialog.FilterIndex) // Saving to different file formats
                    {
                        case 1: // Text file (*.txt)
                            fileSaved = file.SaveAsTextFile(animalManager, foodManager);
                            break;
                        case 2: // Json file (*.json)
                            fileSaved = file.SaveAsJsonSerialized(animalManager);
                            break;
                        case 3: // Binary file (*.bin)
                            fileSaved = file.SaveAsBinarySerialized(animalManager);
                            break;
                        case 4: // XML (*.xml)
                            fileSaved = file.SaveAsXMLSerialized(foodManager);
                            break;

                    }
                    RefreshGUI();


                }
               // Catch of possible exceptions
                catch (FoodNotAssignedException ex)
                {
                    MessageBox.Show("You need to assign atleast one (1) animal to each food item!", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
 

                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("The destination of the save file has been moved or altered", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch (InsufficientMemoryException ex)
                {
                    MessageBox.Show("Not enough memory to save the file.\nTry to close down some applications.", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error occured. Please look over your input an try again.", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            // Displays message to user if the file was successfully saved
            if (fileSaved) 
            { 
                fileInfo = new FileInfo(file.FilePath);
                file.FileExtension = fileInfo.Extension;
                MessageBox.Show(file.FilePath,"File saved successfully");; 
            }
        }

        /// <summary>
        /// This method:
        /// 1. Checks if a file path has been designated, if so saves the file. Else it calls "mnuSaveAs_Click"
        /// to let the user save the file.
        /// 2. Gets the extension of the file that has been saved
        /// 3. Saves the file with a try/catch exception
        /// </summary>

        private void mnuSave_Click(object sender, EventArgs e)
        {
            bool fileSaved = false;

            if (String.IsNullOrEmpty(file.FilePath)) { mnuSaveAs_Click(sender, e); }
            else
            {
                try
                {
                    // Custom exception
                    if (!foodManager.ControlFoodItemHasID())
                    { throw new FoodNotAssignedException(); }

                    switch (file.FileExtension)
                    {
                        case ".txt":
                            fileSaved = file.SaveAsTextFile(animalManager, foodManager);
                            break;
                        case ".json":
                            fileSaved = file.SaveAsJsonSerialized(animalManager);
                            break;
                        case ".bin":
                            fileSaved = file.SaveAsBinarySerialized(animalManager);
                            break;
                        case ".xml":
                            fileSaved = file.SaveAsXMLSerialized(foodManager);
                            break;
                    }

                }

                // Catch of possible exceptions
                catch (FoodNotAssignedException ex)
                {
                    MessageBox.Show("You need to assign atleast one (1) animal to each food item!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch (DirectoryNotFoundException ex)
                {
                    MessageBox.Show("The destination does not exist or has been altered", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch(InsufficientMemoryException ex)
                {
                    MessageBox.Show("Not enough memory to save the file.\nTry to close down some applications.", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch(Exception ex) 
                { 
                    MessageBox.Show("Unknown error occured. Please look over your input an try again.", "Error!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }

            // If file is successfully saved
            if (fileSaved) { MessageBox.Show(file.FilePath, "File saved successfully"); }

        }

        /// <summary>
        /// 1. Warns the user if file hasn´t been saved (no save file path detected).
        /// 3. Calls local OpenFile() method to open file.
        /// </summary>

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            bool fileOpened = false;
            try
            {

                if (!String.IsNullOrEmpty(file.FilePath))
                {
                    dialogResult = MessageBox.Show("You will lose all unsaved data.", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.OK)
                    {
                        fileOpened = OpenFile();
                    }
                }

                else { fileOpened = OpenFile(); }
            }

      

            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Directory couldn´t be found.", "Error!",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            catch (FileNotFoundException ex)
            {
                MessageBox.Show("File couldn´t be found.", "Error!",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Unknown error occured. Please look over your input an try again.", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(fileOpened){ MessageBox.Show("File opened successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            // Updates GUI for user
            UpdateAnimalListview();
            UpdateFoodItemsListView();
        }

        /// <summary>
        /// Method for opening a file.
        /// 1. Lets user select file
        /// 2. Get path name
        /// 3. Delete all current data in FormMain
        /// 4. Try to open file
        /// 5. Return boolean value depending on success.
        /// </summary>
        /// <returns>Returns true if file was successully opened, else false</returns>
        private bool OpenFile()
        {
            bool fileOpened = false;
            OpenFile openFile;
            string path; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                openFile = new OpenFile();
                path = Path.GetFullPath(openFileDialog.FileName);
                ResetFormMain();


                switch (openFileDialog.FilterIndex)
                {
                    case 1: // text format
                        fileOpened = openFile.OpenTextFile(path, animalManager, foodManager);
                        break;
                    case 2: // json format
                        fileOpened = openFile.OpenJsonFile(path, animalManager);
                        break;
                    case 3: // binary format
                        fileOpened = openFile.OpenBinaryFile(path, animalManager);
                        break;
                    case 4: // xml format
                        fileOpened = openFile.OpenXMLFile(path, foodManager);
                        break;
                }

            }

            return fileOpened;
        }

        #endregion


    }
}
