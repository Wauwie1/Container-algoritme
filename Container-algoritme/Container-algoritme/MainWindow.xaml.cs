using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Container_algoritme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Container> _containers;
        private Ship Ship { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _containers = new List<Container>();
            FillComboBox();
            GenerateRandomContainers();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            AddContainer();
        }

        private void GenerateRandomContainers()
        {
            Random rand = new Random();

            for (int i = 0; i < 200; i++)
            {
                int randomType = rand.Next(0, 3);

                Types.ContainerType type;

                if (randomType == 0)
                {
                    type = Types.ContainerType.Regular;
                }
                else if (randomType == 1)
                {
                    type = Types.ContainerType.Cooled;
                }
                else
                {
                    type = Types.ContainerType.Precious;
                }

                Container container = new Container(rand.Next(4, 31), type);
                _containers.Add(container);
                Listbox_containers.Items.Add(container);
            }
        }
        private void AddContainer()
        {
            try
            {
                int weight = Convert.ToInt32(TextBox_weight.Text);
                var type = ComboBox_Type.SelectedItem;

                //Check wether they fields are filled in correctly
                if(weight >= 4 && weight <= 120 && type != null)
                {
                    Container container = new Container(weight, (Types.ContainerType)type);
                    _containers.Add(container);
                    Listbox_containers.Items.Add(container);
                }
                else
                {
                    throw new Exception("Incorrect weight or type selected.");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Not all fields were filled out correctly.");
            }
        }

        private void FillComboBox()
        {
            //Add types to combobox
            ComboBox_Type.Items.Add(Types.ContainerType.Regular);
            ComboBox_Type.Items.Add(Types.ContainerType.Cooled);
            ComboBox_Type.Items.Add(Types.ContainerType.Precious);
            
        }

        private void Button_CreateShip_Click(object sender, RoutedEventArgs e)
        {
            CreateShip();
        }

        private void CreateShip()
        {
                decimal shipLength = Convert.ToInt32(Textbox_Ship_Length.Text);
                decimal shipWidth = Convert.ToInt32(Textbox_Ship_Width.Text);
                int shipMaxWeight = Convert.ToInt32(Textbox_Ship_MaxWeight.Text);

                decimal containerLength = Convert.ToInt32(Textbox_Container_Length.Text);
                decimal containerWidth = Convert.ToInt32(Textbox_Container_Width.Text);

                if(IsDifferenceCorrect(shipLength, shipWidth, containerLength, containerWidth))
                {
                    decimal rows = Math.Ceiling(shipLength / containerLength);
                    decimal columns = Math.Ceiling(shipWidth / containerWidth);

                    Ship = new Ship((int)rows, (int)columns, shipMaxWeight);
                    ShipYard shipYard = new ShipYard(Ship);
                    shipYard.CreateStacks(_containers);
                    shipYard.CreateColumns();
                    Ship.PlaceColumns(shipYard.ContainerColumns);
                    VisualizeShip();
                }
              
        }

        private bool IsDifferenceCorrect(decimal shipLength, decimal shipWidth, decimal containerLength, decimal containerWidth)
        {
            if(shipLength - containerLength > 0 && shipWidth - containerWidth > 0)
            {
                return true;
            }else
            {
                throw new Exception("Incorrect values given.");
            }
        }

        private void VisualizeShip()
        {

            
            for(int i = 0; i < Ship.ColumnsAmount; i++)
            {
                ListBox listBox = new ListBox();
                listBox.Tag = i;

                int index = 0;
                foreach(ContainerStack cs in Ship.ColumnGrid[i].ContainerStacks)
                {
                    Button buttonStack = new Button();
                    buttonStack.Tag = index;
                    index++;

                    buttonStack.Content = cs.ToString();
                    buttonStack.Click += new RoutedEventHandler(buttonStack_Click);
                    listBox.Items.Add(buttonStack);

                }
                Stackpanel_columns.Children.Add(listBox);
            }
        }

        private void buttonStack_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int stackIndex = (int)button.Tag;

            var parent = button.Parent as ListBox;
            int parentIndex = (int)parent.Tag;

            ContainerStack selectedStack = Ship.ColumnGrid[parentIndex].ContainerStacks[stackIndex];
            string contentsSelectedStack = selectedStack.GetContentsAsString();
            MessageBox.Show(contentsSelectedStack);
            
        }
    }

}
