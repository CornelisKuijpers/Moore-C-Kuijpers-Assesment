/* Thank you for the oppurtunity to present my test.
 * Date : 07/01/2021
 * V 1.0
 * Copyright, this application is only intended for moore and only for the purpose of the test.
 * Developer : Cornelis Kuijpers
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;


namespace Moore_C_Kuijpers_Assesment.Functions
{
    public static class Functions
    {
        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                if (csv_file_path.EndsWith(".csv"))
                {
                    using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] {
                    ","
                });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        //read column  
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exce " + ex);
            }
            return csvData;
        }

        public static float CalculateRateOfChange(double todayValue, double periodsAgoValue, int periods)
        {

            float rateOfChange = (float)(((todayValue - periodsAgoValue) / periods) * 100);

            return rateOfChange;

        }

        public static float CalculateRMS(int[] arr, int n)
        {
            int square = 0;
            float mean, root = 0;

            // Calculate square
            for (int i = 0; i < n; i++)
            {
                square += (int)Math.Pow(arr[i], 2);
            }

            // Calculate Mean
            mean = (square / (float)(n));

            // Calculate Root
            root = (float)Math.Sqrt(mean);

            return root;
        }



        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }



    }
}
