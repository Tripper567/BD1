using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace BD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComboUpdates();
            TableUpdate();
        }

        int GetDirCode(string Table, string ToFind, int cell) // Вернуть код (итератор) из справочника
        {
            DB database = new DB(Credentials);
            dataGridViewListReturner.DataSource = database.ReturnTable("*", Table, null).Tables[0].DefaultView;
            for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
            {
                if (dataGridViewListReturner.Rows[i].Cells[cell].Value.ToString() == ToFind)
                {
                    return Convert.ToInt32(dataGridViewListReturner.Rows[i].Cells[0].Value);
                }
            }
            return -1;
        }

        private void заказыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            switch (tabControl1.SelectedIndex)
            {
                /*case 2:
                    if (номер_арендатора_юрTextBox.Text != "" && номер_арендатора_физTextBox.Text != "")
                    {
                        Masseng formMass = new Masseng();
                        formMass.Show();

                        //MessageBox.Show("Для заполнения необходимо выбрать одно из полей!\nНомер арендатора юр или Номер арендатора физ");
                        break;
                    }


                    this.adresBindingSource.EndEdit();
                    adresTableAdapter.Update(dataSet1);
                    break;

                case 0:
                    //SqlCommand command = new SqlCommand($"INSERT INTO Organization (Код_организации, Имя организации, Кр_имя_организации, Контактные_телефоны, Email) VALUES ('{код_организацииTextBox1}', '{имя_организацииTextBox}', '{кр_имя_организацииTextBox}', '{контактные_телефоныTextBox}', '{emailTextBox}')");
                    this.organizationBindingSource.EndEdit();
                    organizationTableAdapter.Update(dataSet1);
                    break;

               /* case 1:

                    switch (tabControl3.SelectedIndex)
                    {
                        case 0:
                            this.fizLitsoBindingSource.EndEdit();
                            fizLitsoTableAdapter.Update(dataSet1);
                            break;
                        case 1:
                            // this.tipYurLitsBindingSource.EndEdit();
                            // tipYurLitsTableAdapter.Update(dataSet1);
                            this.yurLitsoBindingSource.EndEdit();
                            yurLitsoTableAdapter.Update(dataSet1);

                            break;
                    }
                    break;*/

                /*case 3:
                    //this.arendPlatBindingSource.EndEdit(); arendPlatTableAdapter.Update(dataSet1);
                  if (код_физического_лицаTextBox2.Text != "" && код_юридического_лицаTextBox2.Text != "")
                    {
                        MessageBox.Show("Для заполнения необходимо выбрать одно из полей!\nФизическое лицо или Юридическое лицо ");
                        код_физического_лицаTextBox2.Text = ""; код_юридического_лицаTextBox2.Text = "";
                        //MessageBox.Show("Для заполнения необходимо выбрать одно из полей!\nНомер арендатора юр или Номер арендатора физ");
                        break;
                    }
                    this.улицаBindingSource.EndEdit(); this.улицаTableAdapter.Update(dataSet1);
                    break;
               /* case 4:
                    this.characterPomeschBindingSource.EndEdit();
                    characterPomeschTableAdapter.Update(dataSet1);
                    break;
               */
            }
            // this.заказыBindingSource.EndEdit();
            // this.tableAdapterManager.UpdateAll(this.dataSet1); */

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void заказыDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void населенный_пунктDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 2:
                //this.tip_UlizBindingSource.AddNew();
                //this.ulizaBindingSource.AddNew();
                /* this.adresBindingSource.AddNew();
                 break;

             case 0:
                 this.organizationBindingSource.AddNew();

                 break;

             case 1:

                 switch (tabControl3.SelectedIndex)
                 {
                     case 0:
                         this.fizLitsoBindingSource.AddNew();
                         break;
                     case 1:
                         this.yurLitsoBindingSource.AddNew();
                         //this.tipYurLitsBindingSource.AddNew();
                         break;
                 }
                 break;*/
/*
                case 3:
                    this.тип_улицыBindingSource.AddNew();
                    //this.arendPlatBindingSource.AddNew();
                    this.тип_населенного_пунктаBindingSource.AddNew();
                    this.улицаBindingSource.AddNew();
                    this.населенный_пунктBindingSource.AddNew();
                    this.адресBindingSource.AddNew();
                    break;*/
                case 4:
                    //   this.characterPomeschBindingSource.AddNew();
                    break;
            }
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        string Credentials =
          "Server = localhost;" +
          "Integrated security = SSPI;" +
          "database = BD";

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableUpdate();
        }

        void TableUpdate()
        {
            DB dB = new DB(Credentials);
            заказыDataGridView.DataSource = dB.ReturnTable("*", "Заказы", null).Tables[0].DefaultView;
            физические_лицаDataGridView.DataSource = dB.ReturnTable("*", "[Паспортные данные], Физические_лица", null).Tables[0].DefaultView;
            юридические_лицаDataGridView.DataSource = dB.ReturnTable("*", "Юридические_лица", null).Tables[0].DefaultView;
            dataGridViewПреприятия.DataSource = dB.ReturnTable("*", "Предприятия", null).Tables[0].DefaultView;
            dataGridViewTest.DataSource = dB.ReturnTable("*", "Товар", null).Tables[0].DefaultView;

        }

        void ComboUpdates()
        {
            предпритиеCB.Items.Clear();
            вид_товараCB.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();// При добавлении нас.пункта
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();

           
            foreach (string i in BufferListUpdate(0))
            {
                comboBox3.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(1))
            {
                comboBox4.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(2))
            {
                comboBox5.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(3))
            {
                comboBox6.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(4))
            {
                comboBox7.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(5))
            {
                comboBox8.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(6))
            {
                предпритиеCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(7))
            {
                вид_товараCB.Items.Add(i);
            }

        }

        List<string> BufferListUpdate(int Index)
        {
            DB database = new DB(Credentials);
            List<string> Temp = new List<string>();
            switch (Index)
            {
                case 0: // Заполнение кода типа улицы
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название_типа_улицы", "Тип_улицы ", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 1: // Заполнение кода типа нас пункта
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название_типа_нас_пункта", "Тип_населенного_пункта ", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 2: // Заполнение улицы
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название", "Улица", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 3: // Заполнение населенного пункта
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название", "[Населенный пункт]", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 4: // Заполнение физического лица
                    dataGridViewListReturner.DataSource = database.ReturnTable("Фамилия_физ_лица", "Физические_лица,[Паспортные данные]", "Where Код_физического_лица = Код_паспортных_данных").Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 5: // Заполнение юридического лица
                    dataGridViewListReturner.DataSource = database.ReturnTable("Название_юр_лица", "Юридические_лица", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 6: // Заполнение предприятия
                    dataGridViewListReturner.DataSource = database.ReturnTable("Наименование_предприятия", "Предприятия", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 7: // Заполнение вида товара
                    dataGridViewListReturner.DataSource = database.ReturnTable("Наименование_вида", "Вид_товара", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;



            }
            return Temp;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
           DB dB = new DB(Credentials);
            dB.AddTovar(
               наименование_товараTextBox.Text,
               артикулTextBox1.Text,
               GetDirCode("Предприятия", предпритиеCB.SelectedItem.ToString(), 1).ToString(),
               GetDirCode("Вид_товара", вид_товараCB.SelectedItem.ToString(), 1).ToString(),
               стоимостьTextBox.Text
               );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB dB = new DB(Credentials);
            dB.AddPlist(
               наименование_прайс_листаTextBox.Text,
               артикулTextBox.Text);
            TableUpdate();
        }

        private void tabPage17_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DB dB = new DB(Credentials);
            dB.AddTipU(
               название_типа_улицыTextBox.Text);

            TableUpdate(); ComboUpdates(); 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DB dB = new DB(Credentials);
            dB.AddTipN(
               название_типа_нас_пунктаTextBox.Text);

            TableUpdate(); ComboUpdates();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DB dB = new DB(Credentials);
            dB.AddStreet(
               названиеTextBox.Text);

            TableUpdate(); ComboUpdates();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DB dB = new DB(Credentials);
            dB.AddLocality(
               названиеTextBox1.Text);

            TableUpdate(); ComboUpdates();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.AddAdress(
                корпусTextBox.Text,
                квартираTextBox.Text,
                GetDirCode("Улица", $"{comboBox5.SelectedItem.ToString()}", 1),
                GetDirCode("[Населенный пункт]", $"{comboBox6.SelectedItem.ToString()}", 1),
                GetDirCode("Физические_лица", $"{comboBox7.SelectedItem.ToString()}", 1),
                GetDirCode("Юридические_лица", $"{comboBox8.SelectedItem.ToString()}", 1)
                );
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.AddPasport(
                фамилияtextBox2.Text,
                имяtextBox3.Text,
                отчествоtextBox4.Text,
                серияtextBox5.Text,
                номерtextBox6.Text,
                dateTimePicker2.Value.Date
               // DateTime dat =this.dateTimePicker2.Value.Date
                );
            int a = GetDirCode("[Паспортные данные]", фамилияtextBox2.Text, 1);

            db.AddFizFace(иннTB.Text);
            int b = GetDirCode("Физические_лица", иннTB.Text, 1);
            db.AddPassAndFace(a, b);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.AddLegalFace(
               название_юр_лицаTextBox.Text,
                иННTextBox.Text
                
                );
            TableUpdate(); ComboUpdates();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.AddOrders(
               наименование_заказаTextBox.Text,
                GetDirCode("[Паспортные данные]",код_физического_лицаCB.SelectedItem.ToString(), 1).ToString(),
                GetDirCode("Юридические_лица", код_юридического_лицаCB.SelectedItem.ToString(), 1).ToString(),
                dateTimePicker1.Value.Date
                );
            TableUpdate(); ComboUpdates();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.AddEnterprises(
               Наименование_предприятияTB.Text,
               Фамилия_руководителяTB.Text,
               Имя_руководителяTB.Text,
               Отчество_руководителяTB.Text,
                Телефон_секретаряTB.Text,
               ПочтаTB.Text,
               Телефон_руководителяTB.Text
                );
           

        
            TableUpdate(); ComboUpdates();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            TableUpdate(); ComboUpdates();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.AddVidTov(
               наименование_видаTextBox.Text
                );
            TableUpdate(); ComboUpdates();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            if (tempID != -1) { db.DeleteZak(tempID); tempID = -1; }
            TableUpdate(); ComboUpdates();
        }

        int tempID = - 1;
        private void заказыDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DB db = new DB(Credentials);
            заказыDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tempID = Convert.ToInt32(заказыDataGridView.Rows[e.RowIndex].Cells[0].Value);
            наименование_заказаTextBox.Text = заказыDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            dataGridViewListReturner.DataSource = db.ReturnTable("Фамилия_физ_лица", "[Паспортные_данные]", $"WHERE Код_паспортных_данных = {заказыDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString()}"); код_физического_лицаCB.SelectedItem = dataGridViewListReturner.Rows[0].Cells[0].Value.ToString();
            dataGridViewListReturner.DataSource = db.ReturnTable("Название_юр_лица", "Юридические_лица", $"WHERE Код_юридического_лица = {заказыDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString()}"); код_юридического_лицаCB.SelectedItem = dataGridViewListReturner.Rows[0].Cells[0].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(заказыDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            if(tempID != -1) { db.editZakaz(наименование_заказаTextBox.Text, код_физического_лицаCB.SelectedItem.ToString(), код_юридического_лицаCB.SelectedItem.ToString(), dateTimePicker1.Value, tempID); tempID = -1; }
            TableUpdate(); ComboUpdates();
        }

        private void код_физического_лицаCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void удалить_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            if(tempPassCode != -1 && tempFizCode != -1)
            {
                db.deleteFizLic(tempFizCode);
                db.deletePass(tempPassCode);
                tempPassCode = -1; tempFizCode = -1;
            }
            TableUpdate(); ComboUpdates();

        }
        int tempPassCode = -1, tempFizCode = -1;

        private void button15_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            if (tempPassCode != -1 && tempFizCode != -1)
            {
                db.updateFizLitso(tempID, иннTB.Text);
                db.updatePassport(tempPassCode, фамилияtextBox2.Text, имяtextBox3.Text, отчествоtextBox4.Text, серияtextBox5.Text, номерtextBox6.Text, dateTimePicker2.Value);
                tempPassCode = -1; tempFizCode = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials); 
            if (tempID != -1)
            {
                db.deleteYourLits(tempID);
                tempID = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void юридические_лицаDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            юридические_лицаDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tempID = Convert.ToInt32(юридические_лицаDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            название_юр_лицаTextBox.Text = юридические_лицаDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            иННTextBox.Text = юридические_лицаDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            if (tempID != -1)
            {
                db.updateYourLits(tempID, название_юр_лицаTextBox.Text, иННTextBox.Text);
                tempID = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void физические_лицаDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            физические_лицаDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tempPassCode = Convert.ToInt32(физические_лицаDataGridView.Rows[e.RowIndex].Cells[0].Value);
            tempFizCode = Convert.ToInt32(физические_лицаDataGridView.Rows[e.RowIndex].Cells[7].Value);
            фамилияtextBox2.Text = физические_лицаDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            имяtextBox3.Text = физические_лицаDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            отчествоtextBox4.Text = физические_лицаDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            серияtextBox5.Text = физические_лицаDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            номерtextBox6.Text = физические_лицаDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimePicker2.Value = Convert.ToDateTime(физические_лицаDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString());
            иннTB.Text = физические_лицаDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
    }
}
