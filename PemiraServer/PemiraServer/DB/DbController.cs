using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace PemiraServer
{
    public class dbQBilik2Controller
    {
        public static PemiraDBDataSetTableAdapters.QBilik2TableAdapter QBilik2TableAdapter = new PemiraDBDataSetTableAdapters.QBilik2TableAdapter();
        public static PemiraDBDataSet.QBilik2DataTable dt = new PemiraDBDataSet.QBilik2DataTable();
        public static SqlCommand cmd = new SqlCommand();

        public bool isExistInDB(string nim)
        {
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            if (foundRows.Length != 0)
            {
                return true;
            }
            return false;
        }

        public dbQBilik2Controller()
        {
            try
            {
                cmd.Connection = QBilik2TableAdapter.Connection;
                QBilik2TableAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public void addNim(string nim)
        {
            string query = "INSERT INTO QBilik2 (nim) VALUES (" + nim + ")";
            this.execute(query);
            QBilik2TableAdapter.Fill(dt);
        }

        public void delNim(string nim)
        {
            string query = "DELETE FROM QBilik2 WHERE nim = '" + nim + "'";
            this.execute(query);
            QBilik2TableAdapter.Fill(dt);
        }

        public bool execute(string query)
        {
            cmd.CommandText = query;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error\nmessage: " + e.Message + "\n\nsource:" + e.Source);
                return false;
            }
        }

        public void printDB()
        {
            string printOut = "";
            QBilik2TableAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    printOut += dr[dc].ToString();
                    printOut += " ";
                }
                printOut += "\n";
            }
            printOut += "Size: " + dt.Rows.Count;
            MessageBox.Show(printOut);
        }
    }

    public class dbQBilik1Controller
    {
        public static PemiraDBDataSetTableAdapters.QBilik1TableAdapter QBilik1TableAdapter = new PemiraDBDataSetTableAdapters.QBilik1TableAdapter();
        public static PemiraDBDataSet.QBilik1DataTable dt = new PemiraDBDataSet.QBilik1DataTable();
        public static SqlCommand cmd = new SqlCommand();

        public bool isExistInDB(string nim)
        {
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            if (foundRows.Length != 0)
            {
                return true;
            }
            MessageBox.Show("Not Found");
            return false;
        }

        public dbQBilik1Controller()
        {
            try
            {
                cmd.Connection = QBilik1TableAdapter.Connection;
                QBilik1TableAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public void addNim(string nim)
        {
            string query = "INSERT INTO QBilik1 (nim) VALUES (" + nim + ")";
            this.execute(query);
            QBilik1TableAdapter.Fill(dt);
        }

        public void delNim(string nim)
        {
            string query = "DELETE FROM QBilik1 WHERE nim = '" + nim + "'";
            this.execute(query);
            QBilik1TableAdapter.Fill(dt);
        }

        public bool execute(string query)
        {
            cmd.CommandText = query;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error\nmessage: " + e.Message + "\n\nsource:" + e.Source);
                return false;
            }
        }

        public void printDB()
        {
            string printOut = "";
            QBilik1TableAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    printOut += dr[dc].ToString();
                    printOut += " ";
                }
                printOut += "\n";
            }
            printOut += "Size: " + dt.Rows.Count;
            MessageBox.Show(printOut);
        }
    }



    public class dbWaitingListController
    {
        public static PemiraDBDataSetTableAdapters.WaitingListTableAdapter waitingListTableAdapter = new PemiraDBDataSetTableAdapters.WaitingListTableAdapter();
        public static PemiraDBDataSet.WaitingListDataTable dt = new PemiraDBDataSet.WaitingListDataTable();
        public static SqlCommand cmd = new SqlCommand();

        public bool isExistInDB(string nim)
        {
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            if (foundRows.Length != 0)
            {
                return true;
            }
            return false;
        }

        public dbWaitingListController()
        {
            try
            {
                cmd.Connection = waitingListTableAdapter.Connection;
                waitingListTableAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public void addNim(string nim)
        {
            string query = "INSERT INTO WaitingList (nim) VALUES (" + nim + ")";
            this.execute(query);
            waitingListTableAdapter.Fill(dt);
        }

        public void delNim(string nim)
        {
            string query = "DELETE FROM WaitingList WHERE nim = '" + nim + "'";
            this.execute(query);
            waitingListTableAdapter.Fill(dt);
        }

        public bool execute(string query)
        {
            cmd.CommandText = query;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error\nmessage: " + e.Message + "\n\nsource:" + e.Source);
                return false;
            }
        }

        public void printDB()
        {
            string printOut = "";
            waitingListTableAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    printOut += dr[dc].ToString();
                    printOut += " ";
                }
                printOut += "\n";
            }
            printOut += "Size: " + dt.Rows.Count;
            MessageBox.Show(printOut);
        }
    }

    public class dbDPTController
    {
        public static PemiraDBDataSetTableAdapters.DPTTableAdapter dptTableAdapter = new PemiraDBDataSetTableAdapters.DPTTableAdapter();
        //public static SqlConnection conn = new SqlConnection(dptTableAdapter.Connection.ConnectionString);
        public static PemiraDBDataSet.DPTDataTable dt = new PemiraDBDataSet.DPTDataTable();
        public static SqlCommand cmd = new SqlCommand();

        public dbDPTController()
        {
            try
            {
                //conn.Open();
                cmd.Connection = dptTableAdapter.Connection;
                dptTableAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public bool exportCSVkm(string path)
        {
            var dtRandom = new PemiraDBDataSet.DPTDataTable();
            bool isSuccess = true;
            DataTable dtExport = new DataTable();
            try
            {
                dptTableAdapter.FillRandomKM(dtRandom);
                DataView dv = new DataView(dtRandom);
                //DATA LENGKAP:
                dtExport = dv.ToTable(false, "nim", "nama", "nomorPilihanKM");
                //DATA HANYA PILIHAN:
                //dtExport = dv.ToTable(false, "nomorPilihanKM");
                try
                {
                    WriteToFile(dtExport, path, false, ",");
                    MessageBox.Show("Export Successful\nNumber of rows: " + dtExport.Rows.Count);
                    isSuccess = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Export Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
                    isSuccess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
            }

            dptTableAdapter.Fill(dt);
            return isSuccess;
        }

        public bool exportCSVmwawm(string path)
        {
            var dtRandom = new PemiraDBDataSet.DPTDataTable();
            bool isSuccess = true;
            DataTable dtExport = new DataTable();
            try
            {
                dptTableAdapter.FillRandomMWAWM(dtRandom);
                DataView dv = new DataView(dtRandom);
                //DATA LENGKAP:
                dtExport = dv.ToTable(false, "nim", "nama", "nomorPilihanMWAWM");
                //DATA HANYA PILIHAN:
                //dtExport = dv.ToTable(false, "nomorPilihanMWAWM");
                try
                {
                    WriteToFile(dtExport, path, false, ",");
                    MessageBox.Show("Export Successful\nNumber of rows: " + dtExport.Rows.Count);
                    isSuccess = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Export Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
                    isSuccess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query Error\nMesage: " + e.Message + "\n\nSource: " + e.Source);
            }

            dptTableAdapter.Fill(dt);
            return isSuccess;
        }

        public bool importCSV(string path)
        {
            bool isSuccess = true;
            string query = "TRUNCATE TABLE DPT_staging";
            isSuccess &= this.execute(query);

            query =
                @"BULK INSERT DPT_staging
                    FROM '" + path + @"'
                    WITH
                        (
                            FIRSTROW = 0,
                            FIELDTERMINATOR = ',',
                            ROWTERMINATOR = '\n',
                            TABLOCK
                        )";

            if (this.execute(query))
            {
                query = @"TRUNCATE TABLE DPT";
                isSuccess &= this.execute(query);

                query = @"INSERT INTO DPT(nama, nim) 
                           SELECT nama, nim
                           FROM DPT_staging
                        ";
                isSuccess &= this.execute(query);
                dptTableAdapter.Fill(dt);
                MessageBox.Show("Import Successful\nNumber of rows: " + dt.Count);
                return isSuccess;
            }
            else
            {
                MessageBox.Show("Import aborted");
                return false;
            }
        }

        public void printDB()
        {
            string printOut = "";
            dptTableAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    printOut += dr[dc].ToString();
                    printOut += " ";
                }
                printOut += "\n";
            }
            printOut += "Size: " + dt.Rows.Count;
            MessageBox.Show(printOut);
        }

        public bool isExistInDB(string nim)
        {
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            if (foundRows.Length != 0)
            {
                return true;
            }
            return false;
        }

        public bool isAlreadyPickedKM(string nim)
        {
            //nim harus sudah ada dalam db
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            return (foundRows[0].Field<string>("nomorPilihanKM") != "0");
        }

        public bool isAlreadyPickedMWAWM(string nim)
        {
            //nim harus sudah ada dalam db
            string find = "nim = '" + nim + "'";
            DataRow[] foundRows = dt.Select(find);
            return (foundRows[0].Field<string>("nomorPilihanMWAWM") != "0");
        }

        /*public void setAlreadyPicked(string nim, bool isAlreadyPicked)
        {
            string sAlreadyPicked;
            if (isAlreadyPicked)
            {
                sAlreadyPicked = "1";
            }
            else
            {
                sAlreadyPicked = "0";
            }
            string query = @"UPDATE DPT SET isSudahPilih = " + sAlreadyPicked + " WHERE nim = '" + nim + "'";
            this.execute(query);
            dptTableAdapter.Fill(dt);
        }*/

        public void setChoiceKM(string nim, string nomorPilihanKM)
        {
            string query = @"UPDATE DPT SET nomorPilihanKM = " + nomorPilihanKM + " WHERE nim = '" + nim + "'";
            this.execute(query);
            dptTableAdapter.Fill(dt);
        }

        public void setChoiceMWAWM(string nim, string nomorPilihanKM)
        {
            string query = @"UPDATE DPT SET nomorPilihanMWAWM = " + nomorPilihanKM + " WHERE nim = '" + nim + "'";
            this.execute(query);
            dptTableAdapter.Fill(dt);
        }

        public bool execute(string query)
        {
            cmd.CommandText = query;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error\nmessage: " + e.Message + "\n\nsource:" + e.Source);
                return false;
            }
        }

        //FUNGSI UNTUK EXPORT DOANG
        public void WriteToFile(DataTable dataSource, string fileOutputPath, bool firstRowIsColumnHeader = false, string seperator = ";")
        {
            var sw = new StreamWriter(fileOutputPath, false);
            int icolcount = dataSource.Columns.Count;
            if (!firstRowIsColumnHeader)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    sw.Write(dataSource.Columns[i]);
                    if (i < icolcount - 1)
                        sw.Write(seperator);
                }

                sw.Write(sw.NewLine);
            }
            foreach (DataRow drow in dataSource.Rows)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    if (!Convert.IsDBNull(drow[i]))
                        sw.Write(drow[i].ToString());
                    if (i < icolcount - 1)
                        sw.Write(seperator);
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }
}
