using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using Finisar.SQLite;
using SQLLite;

namespace SQLLiteDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : Form
	{
		private DataGrid dataGridView1;
		private TextBox txtDesc;
		private Label lblDesc;
		
		private int i=0;

		
		private SQLiteConnection sql_con;
		private SQLiteCommand sql_cmd;
		private SQLiteDataAdapter DB;
		private DataSet DS = new DataSet();
		private DataTable dt = new DataTable();
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;




        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;
        private float sum=0;

        public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

		

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.dataGridView1 = new System.Windows.Forms.DataGrid();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridView1.CaptionBackColor = System.Drawing.Color.DarkKhaki;
            this.dataGridView1.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.CaptionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.DataMember = "";
            this.dataGridView1.FlatMode = true;
            this.dataGridView1.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.dataGridView1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.GridLineColor = System.Drawing.Color.Silver;
            this.dataGridView1.HeaderBackColor = System.Drawing.Color.Black;
            this.dataGridView1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.HeaderForeColor = System.Drawing.Color.White;
            this.dataGridView1.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridView1.Location = new System.Drawing.Point(12, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ParentRowsBackColor = System.Drawing.Color.LightGray;
            this.dataGridView1.ParentRowsForeColor = System.Drawing.Color.Black;
            this.dataGridView1.PreferredColumnWidth = 120;
            this.dataGridView1.PreferredRowHeight = 25;
            this.dataGridView1.SelectionBackColor = System.Drawing.Color.Firebrick;
            this.dataGridView1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.Size = new System.Drawing.Size(715, 350);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.Click += new System.EventHandler(this.Grid_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(837, 16);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(152, 48);
            this.txtDesc.TabIndex = 2;
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(741, 24);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(88, 32);
            this.lblDesc.TabIndex = 7;
            this.lblDesc.Text = "Desc (no special chars)";
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.Location = new System.Drawing.Point(733, 120);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(655, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(744, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(837, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(918, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "total gen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1001, 399);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "SQLLiteDemo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		private void LoadData()
		{
			SetConnection(); 
			sql_con.Open();

			sql_cmd = sql_con.CreateCommand();
			string CommandText = "select STT,monan, dvt,dg,sl,TT from  bangmonan";
			DB = new SQLiteDataAdapter(CommandText,sql_con);
            DS.Reset();
			DB.Fill(DS);
            //dt= DS.Tables[0];

            for (int i = 0; i < 6; i++)
            {
                dt.Columns.Add(new DataColumn(DS.Tables[0].Columns[i].ColumnName, typeof(string)));
            }
            
      
            //dt.Rows.Add(txt_personalNo.Text, txt_name.Text, txt_date.Text, Convert.ToInt32(txt_quantity.Text), cmb_type.SelectedItem.ToString());
            dataGridView1.DataSource = dt;

            List<String> stringArr = new List<String>();

            // Classic version :-)
            for (int a = 0; a < DS.Tables[0].Rows.Count; a++)
            {
                stringArr.Add(DS.Tables[0].Rows[a]["monan"].ToString());
            }
            this.textBox1.AutoCompleteCustomSource.AddRange(stringArr.ToArray());

            sql_con.Close();
			
		}
        private void SetConnection()
        {
			sql_con = new SQLiteConnection("Data Source=DemoT.db;Version=3;New=False;Compress=True;");
			
        }
		private void ExecuteQuery(string txtQuery)
		{
			SetConnection();
			sql_con.Open();
          
			sql_cmd = sql_con.CreateCommand();
			sql_cmd.CommandText=txtQuery;
		
			sql_cmd.ExecuteNonQuery();
			sql_con.Close();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void Add()
		{
			

		    string txtSQLQuery = "insert into  mains (desc) values ('"+txtDesc.Text+"')";
		    ExecuteQuery(txtSQLQuery);
			
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
		
		Add();
        LoadData();
    

		txtDesc.Text = string.Empty;
		
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
		
			txtDesc.Enabled = true;

			txtDesc.Text = string.Empty;
			
		}

		private void Grid_Click(object sender, EventArgs e)
		{
   //         i = Convert.ToInt32(dt.Rows[dataGridView1.CurrentRowIndex]["id"]);
			
		 //   btnDel.Enabled = true;
			//btnEdit.Enabled = true;
			//txtDesc.Text = dt.Rows[dataGridView1.CurrentRowIndex]["desc"].ToString();
		}

		private void Delete()
		{
			
			string txtSQLQuery = "delete from  mains where id ="+i;

			ExecuteQuery(txtSQLQuery);
			
			txtDesc.Text = string.Empty;
			
		}
       private void Edit()
	   {
		
		string txtSQLQuery = "update  mains set  desc =\""+txtDesc.Text+"\" where id ="+i;
		ExecuteQuery(txtSQLQuery);

	   
	   }
  		private void btnDel_Click(object sender, EventArgs e)
		{
		Delete();
	    LoadData();

		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
		
		Edit();
		LoadData();
		}

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                String selItem = this.textBox1.Text;
                DataRow[] foundAuthors = DS.Tables[0].AsEnumerable().Where(r => (r.Field<string>("monan")) == selItem).ToArray();
                foundAuthors[0]["STT"] = dt.Rows.Count + 1;
                foundAuthors[0]["sl"] = 1;
                foundAuthors[0]["TT"] = String.Format("{0:0,0}", float.Parse(foundAuthors[0]["sl"].ToString(), CultureInfo.InvariantCulture) * float.Parse(foundAuthors[0]["dg"].ToString().Replace(".", ""), CultureInfo.InvariantCulture));

                dt.Rows.Add(foundAuthors[0].ItemArray);

                updateTotalValue();
            }
        }

        private void updateTotalValue()
        {
            //update total
            sum = 0;
            DataRow[] all = dt.AsEnumerable().ToArray();
            foreach (var item in all)
            {
                sum += float.Parse(item["TT"].ToString().Replace(".", ""), CultureInfo.InvariantCulture);
            }
            label2.Text = sum.ToString("#,##0");
        }

     

    

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowNumber-1;
                dt.Rows[rowIndex]["TT"] = String.Format("{0:0,0}", float.Parse(dt.Rows[rowIndex]["sl"].ToString(), CultureInfo.InvariantCulture) * float.Parse(dt.Rows[rowIndex]["dg"].ToString().Replace(".", ""), CultureInfo.InvariantCulture)); updateTotalValue();
                updateTotalValue();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt.Clear();
            sum = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("Sample.xml");

            CrystalReport2 cr = new CrystalReport2();
            cr.SetDataSource(ds);
            cr.SetParameterValue("total", label2.Text);
            cr.PrintToPrinter(1, false, 0, 0);
            //cr.PrintOptions.PaperSize = PaperSize.PaperA5;
            //cr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            ds.Tables.Remove(dt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float totalprice = float.Parse(this.txtDesc.Text)*1000;

            do
            {
                sum = 0;
                while (totalprice != sum)
                {
                    dt.Clear();

                    //random 1 phan ruou hoac thuoc hoac ko 
                    Random rnd = new Random();
                    int month = rnd.Next(1, 26);
                    if (rnd.Next(0, 10)%2==0)
                    {
                        DataRow[] foundAuthors = DS.Tables[0].AsEnumerable().Skip(month - 1).ToArray();
                        foundAuthors[0]["STT"] = dt.Rows.Count + 1;
                        foundAuthors[0]["sl"] = 1;
                        foundAuthors[0]["TT"] = String.Format("{0:0,0}", float.Parse(foundAuthors[0]["sl"].ToString(), CultureInfo.InvariantCulture) * float.Parse(foundAuthors[0]["dg"].ToString().Replace(".", ""), CultureInfo.InvariantCulture));

                        dt.Rows.Add(foundAuthors[0].ItemArray);
                        updateTotalValue();
                    }
                    //dau,banh trang, trung cut

                    month = rnd.Next(28, 30);
                    {

                        DataRow[] foundAuthors = DS.Tables[0].AsEnumerable().Skip(month - 1).ToArray();
                        foundAuthors[0]["STT"] = dt.Rows.Count + 1;
                        foundAuthors[0]["sl"] = (int)totalprice / 1000000;
                        foundAuthors[0]["TT"] = String.Format("{0:0,0}", float.Parse(foundAuthors[0]["sl"].ToString(), CultureInfo.InvariantCulture) * float.Parse(foundAuthors[0]["dg"].ToString().Replace(".", ""), CultureInfo.InvariantCulture));

                        dt.Rows.Add(foundAuthors[0].ItemArray);
                        updateTotalValue();
                    }



                    //tien mon an 90%
                    while ((sum / totalprice) < 0.85)
                    {
                        Thread.Sleep(1000);
                        rnd = new Random();
                        month = rnd.Next(40, 183);

                        DataRow[] foundAuthors = DS.Tables[0].AsEnumerable().Skip(month).ToArray();
                        foundAuthors[0]["STT"] = dt.Rows.Count + 1;
                        float sl = (int)totalprice / 1800000 + rnd.Next(0, 2);

                        //dvt la kg thi them so thap phan
                        if (foundAuthors[0]["dvt"].ToString().ToLower().Equals("kg"))
                        {
                            sl = sl + (float)rnd.Next(0, 3) / (float)4;
                        }
                        foundAuthors[0]["sl"] = sl;
                        foundAuthors[0]["TT"] = String.Format("{0:0,0}", float.Parse(foundAuthors[0]["sl"].ToString(), CultureInfo.InvariantCulture) * float.Parse(foundAuthors[0]["dg"].ToString().Replace(".", ""), CultureInfo.InvariantCulture));

                        dt.Rows.Add(foundAuthors[0].ItemArray);
                        updateTotalValue();
                    }

                    if ((sum / totalprice) > 0.90)
                    {
                        continue;
                    }
                    //nc ngot,suoi
                    month = rnd.Next(31, 32);
                    {

                        DataRow[] foundAuthors = DS.Tables[0].AsEnumerable().Skip(month - 1).ToArray();
                        foundAuthors[0]["STT"] = dt.Rows.Count + 1;
                        foundAuthors[0]["sl"] = rnd.Next(3, 5);
                        foundAuthors[0]["TT"] = String.Format("{0:0,0}", float.Parse(foundAuthors[0]["sl"].ToString(), CultureInfo.InvariantCulture) * float.Parse(foundAuthors[0]["dg"].ToString().Replace(".", ""), CultureInfo.InvariantCulture));

                        dt.Rows.Add(foundAuthors[0].ItemArray);
                        updateTotalValue();
                    }

                    //con lai tien bia
                    for (int i = 33; i < 38; i++)
                    {
                        DataRow[] foundAuthors = DS.Tables[0].AsEnumerable().Skip(i - 1).ToArray();

                        if ((totalprice - sum) % (float.Parse(foundAuthors[0]["dg"].ToString())) == 0)
                        {

                            foundAuthors[0]["STT"] = dt.Rows.Count + 1;
                            foundAuthors[0]["sl"] = (totalprice - sum) / (float.Parse(foundAuthors[0]["dg"].ToString()));
                            foundAuthors[0]["TT"] = String.Format("{0:0,0}", float.Parse(foundAuthors[0]["sl"].ToString(), CultureInfo.InvariantCulture) * float.Parse(foundAuthors[0]["dg"].ToString().Replace(".", ""), CultureInfo.InvariantCulture));

                            dt.Rows.Add(foundAuthors[0].ItemArray);
                            updateTotalValue();
                            break;
                        }
                    }
                } 
            } while (dt.Rows.Count>11|| dt.Rows.Count < 6);
            Console.Beep();
        }
    }
}
