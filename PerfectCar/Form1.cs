using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfectCar
{
    public partial class Form1 : Form
    {
        int counter = 0;
        string line;

        int sum = 0;
        int max = 0;

        List<int> sumowanko = new List<int>();
        List<int> index = new List<int>();
        List<int> result = new List<int>();
        List<string> ChoosenValues = new List<string>();
        List<int> ChoosenValuesNumbers = new List<int>();
        List<string> NumberOfCar = new List<string>();

        string[] array_NumberOfCar;
        string[] lines = System.IO.File.ReadAllLines("data.txt");
        string[,] ZeroAndOne;
        string[] temp = null;

        string[] E = new string[] {"BMW","Audi","Mercedes","Volkswagen","Opel","Fiat","Ford","Bentley","Dacia",
                                           "Lamborghini","Porsche","Dodge","Ferrari","Hyundai","Infiniti","Jeep","Kia","Lexus",
                                           "Maserati","Mazda","McLaren","Mitsubishi","Nissan","Peugeot","Renault","Seat",
                                           "Skoda","Smart","Subaru","Suzuki","Tesla","Toyota","Volvo","Czarny","Bialy","Zielony","Czerwony","Zolty","Fioletowy","Niebieski","Szary",
                                           "Pomaranczowy","Granatowy","Brozowy", "Diesel", "LPG", "Benzyna","Welurowa", "Skora",
                                           "Manualna", "Automatyczna", "SUV", "Kabriolet", "Kombi", "Sedan","Klimatyzacja", "Bez klimatyzacji",
                                            "Tani", "Drogi","Sybki", "Ekonomiczy","Tak", "Nie","2/3", "4/5"};

        string[] marka = new string[] {"BMW","Audi","Mercedes","Volkswagen","Opel","Fiat","Ford","Bentley","Dacia",
                                           "Lamborghini","Porsche","Dodge","Ferrari","Hyundai","Infiniti","Jeep","Kia","Lexus",
                                           "Maserati","Mazda","McLaren","Mitsubishi","Nissan","Peugeot","Renault","Seat",
                                           "Skoda","Smart","Subaru","Suzuki","Tesla","Toyota","Volvo"};

        string[] kolor = new string[] {"Czarny","Bialy","Zielony","Czerwony","Zolty","Fioletowy","Niebieski","Szary",
                                           "Pomaranczowy","Granatowy","Brozowy"};

        string[] paliwo = new string[] { "Diesel", "LPG", "Benzyna" };

        string[] tapicerka = new string[] { "Welurowa", "Skora" };

        string[] biegi = new string[] { "Manualna", "Automatyczna" };

        string[] typ = new string[] { "SUV", "Kabriolet", "Kombi", "Sedan" };

        string[] dodatki = new string[] { "Klimatyzacja", "Bez klimatyzacji" };

        string[] cena = new string[] { "Tani", "Drogi" };

        string[] moc = new string[] { "Szybki", "Ekonomiczy" };

        string[] uszkodzony = new string[] { "Tak", "Nie" };

        string[] drzwi = new string[] { "2/3", "4/5" };

        public Form1()
        {
            InitializeComponent();

            //Set of U
            //Set of objects, in this case cars
            array_NumberOfCar = NumberOfCar.ToArray();

            try
            {
                // Read the file and display it line by line.  
                System.IO.StreamReader file = new System.IO.StreamReader("data.txt");
                while ((line = file.ReadLine()) != null)
                {
                    NumberOfCar.Add("SM" + (counter));
                    counter++;
                }

                file.Close();
                System.Console.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            //////////////////////////////////////////////////////
            //Filling combobox with cars
            List<ComboBox> boxy = new List<ComboBox>() { comboBox_marka, comboBox_kolor, comboBox_paliwo,
                                                         comboBox_tapicerka, comboBox_biegi,comboBox_typ,
                                                         comboBox_dodatki, comboBox_cena, comboBox_moc,
                                                         comboBox_uszkodzony, comboBox_drzwi};

            List<string[]> kategorie = new List<string[]>() { marka, kolor, paliwo, tapicerka, biegi, typ, dodatki,
                                                              cena, moc, uszkodzony, drzwi};

            for (int i = 0; i < boxy.Count; i++)
            {
                boxy[i].Items.AddRange(kategorie[i]);
            }

            //////////////////////////////////////////////////////
            //Fill Array ZeroAndOne
             ZeroAndOne = new string[NumberOfCar.Count, E.Length];

            for (int i = 0; i < NumberOfCar.Count; i++)
            {
                temp = lines[i].Split('\t');

                for (int j = 0; j < E.Length; j++)
                    ZeroAndOne[i, j] = temp[j];
            }
        }

        private void button_submit_Click(object sender, EventArgs e)
        {

            if (comboBox_marka.SelectedItem == null || comboBox_kolor.SelectedItem == null ||
                comboBox_paliwo.SelectedItem == null || comboBox_tapicerka.SelectedItem == null ||
                comboBox_biegi.SelectedItem == null || comboBox_typ.SelectedItem == null ||
                comboBox_dodatki.SelectedItem == null || comboBox_cena.SelectedItem == null ||
                comboBox_moc.SelectedItem == null || comboBox_uszkodzony.SelectedItem == null ||
                comboBox_drzwi.SelectedItem == null)
            {
                MessageBox.Show("Prosze wypelnic wszystkie pola!!!");
                return;
            }
            else
            {
                ChoosenValues.Add(comboBox_marka.SelectedItem.ToString());
                ChoosenValues.Add(comboBox_kolor.SelectedItem.ToString());
                ChoosenValues.Add(comboBox_paliwo.SelectedItem.ToString());
                ChoosenValues.Add(comboBox_tapicerka.SelectedItem.ToString());
                ChoosenValues.Add(comboBox_biegi.SelectedItem.ToString());
                ChoosenValues.Add(comboBox_typ.SelectedItem.ToString());
                ChoosenValues.Add(comboBox_dodatki.SelectedItem.ToString());
                ChoosenValues.Add(comboBox_cena.SelectedItem.ToString());
                ChoosenValues.Add(comboBox_moc.SelectedItem.ToString());
                ChoosenValues.Add(comboBox_uszkodzony.SelectedItem.ToString());
                ChoosenValues.Add(comboBox_drzwi.SelectedItem.ToString());
            }

            for (int i = 0; i < ChoosenValues.Count; i++)
            {
                var index = Array.FindIndex(E, x => x == ChoosenValues[i]);
                {
                    if(ChoosenValuesNumbers.Contains(index) == false)
                    ChoosenValuesNumbers.Add(index);
                }
            }

            //Print features by user choose
            //foreach (var feature_number in ChoosenValuesNumbers)
            //{
            //    Console.WriteLine(E[feature_number]);
            //}

            //Sum only columns that contains values(0 and 1) by features choosen in combobox
            for (int i = 0; i < NumberOfCar.Count; i++)
            {
                for (int j = 0; j < temp.Length; j++)
                {
                    for (int x = 0; x < ChoosenValuesNumbers.Count; x++)
                    {
                        if (j == ChoosenValuesNumbers[x])
                        {
                            if (x==0)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j])*Convert.ToInt32(numericUpDown_marka.Value);
                            else if (x == 1)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j]) * Convert.ToInt32(numericUp_kolor.Value);
                            else if (x == 2)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j]) * Convert.ToInt32(numericUpDown_paliwo.Value);
                            else if (x == 3)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j]) * Convert.ToInt32(numericUpDown_tapicera.Value);
                            else if (x == 4)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j]) * Convert.ToInt32(numericUpDown_biegi.Value);
                            else if (x == 5)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j]) * Convert.ToInt32(numericUpDown_typ.Value);
                            else if (x == 6)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j]) * Convert.ToInt32(numericUpDown_dodatki.Value);
                            else if (x == 7)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j]) * Convert.ToInt32(numericUpDown_cena.Value);
                            else if (x == 8)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j]) * Convert.ToInt32(numericUpDown_moc.Value);
                            else if (x == 9)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j]) * Convert.ToInt32(numericUpDown_uszkodzony.Value);
                            else if (x == 10)
                                sum = sum + Convert.ToInt32(ZeroAndOne[i, j]) * Convert.ToInt32(numericUpDown_drzwi.Value);
                        }
                    }
                }
                sumowanko.Add(sum);
                sum = 0;
            }

            //Print content of array sumowanko
            //for (int i = 0; i < sumowanko.Count; i++)
            //{
            //    Console.WriteLine(sumowanko[i]);
            //}

            resultFunction();
            PrintFeatures();
            ClearAll();
        }

        private void resultFunction()
        {
            max = sumowanko[0];

            for (int i = 0; i < sumowanko.Count - 1; i++)
            {
                if (sumowanko[i + 1] > max)
                {
                    max = sumowanko[i + 1];
                }
            }

            for (int i = 0; i < sumowanko.Count; i++)
            {
                if (sumowanko[i] == max)
                {
                    result.Add(sumowanko[i]);
                    index.Add(i);
                }
            }

            textBox_result.Text = "Najlepsze wybory samochodow: ";
            foreach (var x in index)
            {
                //Console.Write(NumberOfCar[x] + " ");
                textBox_result.Text += NumberOfCar[x] + " ";
            }
            // result.ForEach(Console.WriteLine);
        }

        private void ClearAll()
        {
            //Clear all tables, arrays and lists
            ChoosenValues.Clear();
            ChoosenValuesNumbers.Clear();
            result.Clear();
            sumowanko.Clear();
            index.Clear();

        }

        private void PrintFeatures()
        {
            textBox_result.Text += System.Environment.NewLine;
            textBox_result.Text += System.Environment.NewLine;

            foreach (var x in index)
            {
                textBox_result.Text += NumberOfCar[x] + ": ";
                for (int j = 0; j < 65; j++)
                {
                    if (ZeroAndOne[x, j] == "1")
                    {
                        textBox_result.Text += E[j] + ", ";
                    }
                }
                textBox_result.Text += System.Environment.NewLine;
            }
        }

        //////////////////////////////////////////////////////
        //Print Array ZeroAndOne
        void PrintArray_ZeroAndOne()
        {
            for (int i = 0; i < NumberOfCar.Count; i++)
            {
                for (int j = 0; j < E.Length; j++)
                {
                    Console.Write(ZeroAndOne[i, j]);

                }
                Console.WriteLine();

            }
        }

        //////////////////////////////////////////////////////
        //Print Array NumberOfCar
        void PrintArray_NumberOfCar()
        {
            for (int i = 0; i <= counter - 1; i++)
            {
                Console.WriteLine(NumberOfCar[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Clear all tables, arrays and lists
            ClearAll();
        }
    }
}