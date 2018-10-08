using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Container_algoritme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Container> containers;
        public MainWindow()
        {
            InitializeComponent();
            containers = new List<Container>();
            FillComboBox();
            GenerateRandomContainers();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            AddContainer();
        }

        private void ComboBox_Type_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //TODO: Delete method
        private void GenerateRandomContainers()
        {
            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                int randomType = rand.Next(0, 3);

                Types.ContainerType type;

                if (randomType == 0)
                {
                    type = Types.ContainerType.regular;
                }
                else if (randomType == 1)
                {
                    type = Types.ContainerType.cooled;
                }
                else
                {
                    type = Types.ContainerType.precious;
                }

                Container container = new Container(rand.Next(4, 121), (Types.ContainerType)type);
                containers.Add(container);
                Listbox_containers.Items.Add(container);
            }
        }
        private void AddContainer()
        {
            try
            {
                int weight = Convert.ToInt32(TextBox_weight.Text);
                var type = ComboBox_Type.SelectedItem;

                if(weight >= 4 && weight <= 120 && type != null)
                {
                    Container container = new Container(weight, (Types.ContainerType)type);
                    containers.Add(container);
                    Listbox_containers.Items.Add(container);
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Not all fields were filled out correctly.");
            }
        }

        private void FillComboBox()
        {
            ComboBox_Type.Items.Add(Types.ContainerType.regular);
            ComboBox_Type.Items.Add(Types.ContainerType.cooled);
            ComboBox_Type.Items.Add(Types.ContainerType.precious);
        }

        private void Button_CreateShip_Click(object sender, RoutedEventArgs e)
        {
            CreateShip();
        }

        private void CreateShip()
        {
            //try
            //{
                decimal shipLength = Convert.ToInt32(Textbox_Ship_Length.Text);
                decimal shipWidth = Convert.ToInt32(Textbox_Ship_Width.Text);
                int shipMaxWeight = Convert.ToInt32(Textbox_Ship_MaxWeight.Text);

                decimal containerLength = Convert.ToInt32(Textbox_Container_Length.Text);
                decimal containerWidth = Convert.ToInt32(Textbox_Container_Width.Text);

                if(IsDifferenceCorrect(shipLength, shipWidth, containerLength, containerWidth))
                {
                    decimal rows = Math.Ceiling(shipLength / containerLength);
                    decimal columns = Math.Ceiling(shipWidth / containerWidth);

                    Ship ship = new Ship(rows, columns, shipMaxWeight);
                    ShipYard shipYard = new ShipYard();
                    shipYard.CreateStacks(containers);
                    shipYard.CreateColumns();
                }
              
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Not all fields were filled out correctly.");
            //}
        }

        private bool IsDifferenceCorrect(decimal shipLength, decimal shipWidth, decimal containerLength, decimal containerWidth)
        {
            if(shipLength - containerLength > 0 && shipWidth - containerWidth > 0)
            {
                return true;
            }else
            {
                throw new Exception();
            }
        }



    }

}
