/**
 * Author: Wojciech Powch
 * About (PL): Klasa odpowiedzialna za zapisych pozyskanych danych do pliku XLS.
 * */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownElement
{
    class XLSSaver
    {
        private List<Coordinate> coordinateList;
        private String filePath;

        private FileStream fileStream;
        private StreamWriter streamWriter;

        private const String TABULATOR = "\t";

        public XLSSaver(List<Coordinate> coordinateList, String filePath)
        {
            this.coordinateList = coordinateList;
            this.filePath = filePath;
        }

        public void WriteToFile()
        {
            InitStreamWriter();
            WriteCoordinateListToFile();
            CloseFileStreams();
        }

        private void InitStreamWriter()
        {
            fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            streamWriter =  new StreamWriter(fileStream);
        }

        private void WriteCoordinateListToFile()
        {
            foreach (Coordinate coordinate in coordinateList)
            {
                streamWriter.WriteLine(GetLineToWrite(coordinate));
            }
        }

        private String GetLineToWrite(Coordinate coordinate)
        {
            return String.Concat(coordinate.X,
                                 TABULATOR,
                                 coordinate.Y);
        }

        private void CloseFileStreams()
        {
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
