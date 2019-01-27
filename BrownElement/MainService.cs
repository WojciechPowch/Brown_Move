/**
 * Author: Wojciech Powch
 * About (PL): Klasa pomocnicza głownego panelu programu.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BrownElement
{
    class MainService
    {
        private static List<Coordinate> result;
        public static void SimulateBrownMovemnts(TextBox input, ref Chart mainChart)
        {
            int count = GetCountFromInput(input);
            if (count <= 0)
            {
                return;
            }
            MakeSimulation(count, ref mainChart);
        }

        private static void MakeSimulation(int count, ref Chart mainChart)
        {
            BrownMovements brownMovements = new BrownMovements(count);
            brownMovements.MakeSimulation();
            result = brownMovements.GetElementWay();
            AddPoints(ref mainChart);
        }

        private static void AddPoints(ref Chart mainChart)
        {
            mainChart.Series[0].Points.Clear();
            foreach (Coordinate coordinate in result)
            {
                mainChart.Series[0].Points.AddXY(coordinate.X, coordinate.Y);
            }
        }

        private static int GetCountFromInput(TextBox input)
        {
            string inputText = input.Text;
            if (inputText != "" && inputText != null)
            {
                return int.Parse(inputText);
            }
            return 0;
        }

        public static void SaveResultToXLXFile()
        {
            if (result != null && result.Count() > 0)
            {
                ProvideFolderDialog();
            } else
            {
                ShowWarningMessage();
            }
        }

        private static void ProvideFolderDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Zapisz plik";
            saveFileDialog.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx | Excel Files(*.xlsm) | *.xlsm";

            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                XLSSaver xLSSaver = new XLSSaver(result, saveFileDialog.FileName);
                xLSSaver.WriteToFile();
            }
        }

        private static void ShowWarningMessage()
        {
            MessageBox.Show("Symulacja nie zawiera żadnych wyników! Proszę wykonaj najpierw symulacje!");
        }
    }
}
