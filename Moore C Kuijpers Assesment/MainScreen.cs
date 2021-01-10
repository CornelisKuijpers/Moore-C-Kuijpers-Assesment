
/* Thank you for the oppurtunity to present my test.
 * Date : 07/01/2021
 * V 1.0
 * Copyright, this application is only intended for moore and only for the purpose of the test.
 * Developer : Cornelis Kuijpers
 */


using MathNet.Numerics.Statistics;
using Moore_C_Kuijpers_Assesment.Functions;
using SqlConnectionDialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moore_C_Kuijpers_Assesment
{
    public partial class MainScreen : Form
    {

        //Global Variables

        private DataTable mOutputTable = new DataTable();
        private string SDTag = "";
        private double SDValue = 0.0;
        private string RMSTag = "";
        private double RMSValue = 0.0;
        private string ROCTag = "";
        private double ROCValue = 0.0;

        //Delegates for cross-threading

        #region "Delegate Methods"

        delegate void SetGridDataSource(DataTable dataTable);
        delegate void SetButtonEnabled(Button control, bool enabled);
        delegate void SetVisibility(bool visible);

        private void SetDataSource(DataTable dataTable)
        {
            if (dGridOutput.InvokeRequired)
            {
                SetGridDataSource d = new SetGridDataSource(SetDataSource);
                this.Invoke(d, new object[] { dataTable });

            }
            else
            {
                this.dGridOutput.DataSource = dataTable;
            }

        }

        private void SetButtonEnable(Button control, bool enabled)
        {
            if (control.InvokeRequired)
            {
                SetButtonEnabled d = new SetButtonEnabled(SetButtonEnable);
                this.Invoke(d, new object[] { control, enabled });
            }
            else
            {
                control.Enabled = enabled;
            }
        }

        private void SetVisibilityProgressbar(bool visible)
        {

            if (WaitingBar.InvokeRequired)
            {
                SetVisibility d = new SetVisibility(SetVisibilityProgressbar);
                this.Invoke(d, new object[] { visible });
            }
            else
            {
                this.WaitingBar.Visible = visible;
            }

        }

        #endregion

        public MainScreen()
        {
            InitializeComponent();
        }

        private void SetWaiting(bool enabled)
        {
            SetButtonEnable(btnLoadCSV, enabled);
            SetButtonEnable(btnSortBy, enabled);
            SetButtonEnable(btnStandardDeviation, enabled);
            SetButtonEnable(btnRMS, enabled);
            SetButtonEnable(btnRateOfchange, enabled);
            SetButtonEnable(btnSaveToSQL, enabled);
            SetButtonEnable(btnSaveToCSV, enabled);
            SetButtonEnable(btnRunReport, enabled);

        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            //Call open file dialog to get path to csv file. If path is empty exit subroutine 

            oCSVFile.ShowDialog();
            if (oCSVFile.FileName != "")
            {
                try
                {
                    //Disable all buttons until done

                    SetWaiting(false);
                    SetVisibilityProgressbar(true);

                    //Lets not hold up user and start background task for importing of csv data
                    new Thread(() =>
                    {
                        try
                        {
                            mOutputTable = Functions.Functions.GetDataTabletFromCSVFile(oCSVFile.FileName);
                            SetDataSource(mOutputTable);

                            //Enable the buttons
                            SetWaiting(true);
                            SetVisibilityProgressbar(false);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            SetWaiting(false);
                            SetVisibilityProgressbar(true);
                        }


                    }).Start();


                }
                catch (Exception ex)
                {
                    SetWaiting(true);
                    SetVisibilityProgressbar(false);
                    MessageBox.Show(ex.Message, "Oops this was not suppose to happen");
                }
            }

        }

        private void btnSortBy_Click(object sender, EventArgs e)
        {

            try
            {
                string myTag = "TAG1";
                if (MyControls.InputBox("Tag to sort by", "Enter Tag to sort by", ref myTag) == DialogResult.OK)
                {
                    if (mOutputTable.Columns.Contains(myTag))
                    {
                        dGridOutput.Sort(dGridOutput.Columns[myTag.ToUpper()], ListSortDirection.Descending);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Column specified");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnStandardDeviation_Click(object sender, EventArgs e)
        {

            try
            {

                string myTag = "TAG1";
                if (MyControls.InputBox("Tag to calculate by", "Enter Tag to calculate by", ref myTag) == DialogResult.OK)
                {
                    if (mOutputTable.Columns.Contains(myTag))
                    {

                        SDTag = myTag;

                        List<double> myValues = new List<double>();

                        foreach (DataRow row in mOutputTable.Rows)
                        {

                            double value;
                            bool isDouble = Double.TryParse(row[myTag].ToString(), out value);
                            if (isDouble)
                            {
                                myValues.Add(value);
                            }

                        }

                        var StdDev = myValues.StandardDeviation();

                        SDValue = StdDev;

                        MessageBox.Show($"The standard Deviation for the column = {StdDev}");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Column specified");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnRMS_Click(object sender, EventArgs e)
        {
            try
            {

                string myTag = "TAG1";
                if (MyControls.InputBox("Tag to calculate by", "Enter Tag to calculate by", ref myTag) == DialogResult.OK)
                {
                    if (mOutputTable.Columns.Contains(myTag))
                    {

                        RMSTag = myTag;

                        List<int> myValues = new List<int>();

                        foreach (DataRow row in mOutputTable.Rows)
                        {

                            int value;
                            bool isDouble = int.TryParse(row[myTag].ToString(), out value);
                            if (isDouble)
                            {
                                myValues.Add(value);
                            }

                        }

                        string myCount = (myValues.Count - 1).ToString();

                        if (MyControls.InputBox("Amount of rows to calculate", "Amount of rows to calculate", ref myCount) == DialogResult.OK)
                        {
                            int value;
                            bool isInt = int.TryParse(myCount, out value);

                            if (isInt)
                            {
                                var RMS = Functions.Functions.CalculateRMS(myValues.ToArray(), value);
                                MessageBox.Show($"The RMS value for the column = {RMS}");
                                RMSValue = RMS;
                            }
                        }
                        else
                        {
                            var RMS = Functions.Functions.CalculateRMS(myValues.ToArray(), myValues.Count - 1);
                            MessageBox.Show($"The RMS value for the column = {RMS}");
                            RMSValue = RMS;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Column specified");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnRateOfchange_Click(object sender, EventArgs e)
        {
            try
            {

                string myTag = "TAG1";
                if (MyControls.InputBox("Tag to calculate by", "Enter Tag to calculate by", ref myTag) == DialogResult.OK)
                {
                    if (mOutputTable.Columns.Contains(myTag))
                    {

                        ROCTag = myTag;

                        List<double> myValues = new List<double>();

                        foreach (DataRow row in mOutputTable.Rows)
                        {

                            double value;
                            bool isDouble = double.TryParse(row[myTag].ToString(), out value);
                            if (isDouble)
                            {
                                myValues.Add(value);
                            }

                        }

                        string myCount = (myValues.Count - 1).ToString();

                        if (MyControls.InputBox("Amount of rows to calculate", "Amount of rows to calculate", ref myCount) == DialogResult.OK)
                        {
                            int value;
                            bool isInt = int.TryParse(myCount, out value);

                            if (isInt)
                            {
                                var rateOfChange = Functions.Functions.CalculateRateOfChange(myValues[0], myValues[value - 1], value);
                                MessageBox.Show($"The Rate Of Change value for the column = {rateOfChange}");

                                ROCValue = rateOfChange;
                            }
                            else
                            {
                                MessageBox.Show("Invalid amount using all values");
                                var rateOfChange = Functions.Functions.CalculateRateOfChange(myValues[0], myValues[myValues.Count - 1], myValues.Count - 1);
                                MessageBox.Show($"The Rate Of Change value for the column = {rateOfChange}");

                                ROCValue = rateOfChange;
                            }
                        }
                        else
                        {
                            var rateOfChange = Functions.Functions.CalculateRateOfChange(myValues[0],myValues[myValues.Count - 1], myValues.Count - 1);
                            MessageBox.Show($"The Rate Of Change value for the column = {rateOfChange}");

                            ROCValue = rateOfChange;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Column specified");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Oops something went wrong");
            }
        }

        private void btnSaveToSQL_Click(object sender, EventArgs e)
        {

            try { 
            var factory = new ConnectionStringFactory();
            var connectionString = factory.BuildConnectionString();

                if (connectionString != null && connectionString != "")
                {

                    string sql = @"/* Thank you for the oppurtunity to present my test.
                            * Date : 07 / 01 / 2021
                            * V 1.0
                            * Copyright, this application is only intended for moore and only for the purpose of the test.
                            * Developer : Cornelis Kuijpers
                            */

                                 CREATE PROCEDURE Cornelis_Assesment


                                @SDTag VARCHAR(30)
                                , @SDValue DECIMAL(10, 9)
                                , @RMSTag VARCHAR(30)
                                , @RMSValue DECIMAL(10, 9)
                                , @ROCTag VARCHAR(30)
                                , @ROCValue DECIMAL(10, 9)


                                AS

                                   BEGIN


                                         IF object_id('CornelisCalculations') is null

                                           BEGIN

                                               CREATE TABLE CornelisCalculations
                                                 (
                                                    id         INTEGER NOT NULL IDENTITY(1, 1) PRIMARY KEY,
                                                    SDTag      VARCHAR(30),
                                                    SDValue    DECIMAL(10, 9),
                                                    RMSTag     VARCHAR(30),
                                                    RMSValue   DECIMAL(10, 9),
                                                    ROCTag     VARCHAR(20),
                                                    ROCValue   DECIMAL(10, 9),
                                                    CreateDate DATETIME DEFAULT GETDATE()
                                                 )

                                           END


                                       INSERT INTO CornelisCalculations
                                       (SDTag
                                       , SDValue
                                       , RMSTag
                                       , RMSValue
                                       , ROCTag
                                       , ROCValue)

                                       VALUES
                                       (
                                       @SDTag
                                       , @SDValue
                                       , @RMSTag
                                       , @RMSValue
                                       , @ROCTag
                                       , @ROCValue
                                       )

                                   END";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        SqlCommand cmd;

                        conn.Open();

                        //Run Stored Procedure create to make sure that it exists in Database

                        try
                        {
                            cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            //if it fails here it is because it already exists in the database
                        }

                        //Run Stored Procedure

                        // 1.  create a command object identifying the stored procedure
                        cmd = new SqlCommand("Cornelis_Assesment", conn);

                        // 2. set the command object so it knows to execute a stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // 3. add parameter to command, which will be passed to the stored procedure
                        cmd.Parameters.Add(new SqlParameter("@SDTag", SDTag));
                        cmd.Parameters.Add(new SqlParameter("@SDValue", SDValue));
                        cmd.Parameters.Add(new SqlParameter("@RMSTag", RMSTag));
                        cmd.Parameters.Add(new SqlParameter("@RMSValue", RMSValue));
                        cmd.Parameters.Add(new SqlParameter("@ROCTag", ROCTag));
                        cmd.Parameters.Add(new SqlParameter("@ROCValue", ROCValue));

                        // execute the command
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            Console.WriteLine("SQL Completed");
                            MessageBox.Show("Data has been saved"); 
                        }
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Oops Something went wrong!");
            }

        }

        private void btnSaveToCSV_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Select Path for Datatable");

                sCSVFile.ShowDialog();

                if (sCSVFile.FileName != "") {
                    Functions.Functions.ToCSV(mOutputTable, sCSVFile.FileName);
                }

                MessageBox.Show("Select Path for Calculated Data");

                sCSVFile.ShowDialog();

                if (sCSVFile.FileName != "")
                {
                    StreamWriter sw = new StreamWriter(sCSVFile.FileName, false);
                    //headers    
                    sw.Write("SDTag,SDValue,RMSTag,RMSValue,ROCTag,ROCValue");
                    
                    sw.Write(sw.NewLine);
                    sw.Write($"{SDTag},{SDValue},{RMSTag},{RMSValue},{ROCTag},{ROCValue}");

                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Oops Something went wrong!");
            }
        }
    }
}
