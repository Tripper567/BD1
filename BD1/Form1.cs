using System;
using System.Collections.Generic;
using BD1;
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

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        string Credentials =
          $"Server = {Program.Server};" +
          $"Integrated security = {Program.Secure};" +
          $"database = {Program.Server}";

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
            вид_товараDataGridView.DataSource = dB.ReturnTable("*", "Вид_товара", null).Tables[0].DefaultView;
            addPriceListDG.DataSource = dB.PriceListItems().Tables[0].DefaultView;
            dataGridView1.DataSource = dB.ReturnTable("*", "Прайс_лист", null).Tables[0].DefaultView;
            switch (tabControl4.SelectedIndex)
            {
                case 0: dataGridViewTypeU.DataSource = dB.ReturnTable("*", "Тип_улицы", null).Tables[0].DefaultView; break;
                case 1: dataGridViewTypeU.DataSource = dB.ReturnTable("*", "Тип_населенного_пункта", null).Tables[0].DefaultView; break;
                case 2: dataGridViewTypeU.DataSource = dB.ReturnTable("*", "Улица", null).Tables[0].DefaultView; break;
                case 3: dataGridViewTypeU.DataSource = dB.ReturnTable("*", "[Населенный пункт]", null).Tables[0].DefaultView; break;
                case 4: dataGridViewTypeU.DataSource = dB.ReturnTable("*", "Адрес", null).Tables[0].DefaultView; break;
            }
            список_товараDataGridView.DataSource = dB.ReturnTable("Наименование_прайс_листа, Наименование_товара", "[Список товара], Прайс_лист, Товар", "WHERE [Список товара].Код_товара = Товар.Код_товара AND [Список товара].Код_прайс_листа = Прайс_лист.Код_прайс_листа").Tables[0].DefaultView;

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
            PriceListCB.Items.Clear();
            ItemCB.Items.Clear();
            orderPriceListCB.Items.Clear();
            код_физического_лицаCB.Items.Clear();
            код_юридического_лицаCB.Items.Clear();

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
                код_физического_лицаCB.Items.Add(i);
                comboBox7.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(5))
            {
                код_юридического_лицаCB.Items.Add(i);
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
            foreach(string i in BufferListUpdate(8))
            {
                PriceListCB.Items.Add(i);
                orderPriceListCB.Items.Add(i);
            }
            foreach (string i in BufferListUpdate(9))
            {
                ItemCB.Items.Add(i);
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
                    dataGridViewListReturner.DataSource = database.ReturnTable("Фамилия_физ_лица", "Физические_лица,[Паспортные данные], [Паспортные_данные и Физ_лица]", null).Tables[0].DefaultView;
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
                case 8: // Заполнение прайс листа
                    dataGridViewListReturner.DataSource = database.ReturnTable("Наименование_прайс_листа", "Прайс_лист", null).Tables[0].DefaultView;
                    for (int i = 0; i < dataGridViewListReturner.Rows.Count - 1; i++)
                    {
                        Temp.Add(dataGridViewListReturner.Rows[i].Cells[0].Value.ToString());
                    }
                    break;
                case 9: // Заполнение товара
                    dataGridViewListReturner.DataSource = database.ReturnTable("Наименование_товара", "Товар", null).Tables[0].DefaultView;
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
               стоимостьTextBox.Text,
               Convert.ToInt32(количествоtextBox1.Text)
               );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB dB = new DB(Credentials);
            dB.AddPlist(
               наименование_прайс_листаTextBox.Text,
               артикулTextBox.Text,
               PriceListDTP.Value);
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
               названиеTextBox.Text,
               GetDirCode("Тип_улицы",$"{comboBox3.SelectedItem.ToString()}",1)
               );
            

            TableUpdate(); ComboUpdates();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DB dB = new DB(Credentials);
            dB.AddLocality(
               названиеTextBox1.Text,
               GetDirCode("Тип_населенного_пункта", $"{comboBox4.SelectedItem.ToString()}", 1)
               );


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
            try
            {
                db.addPassprot(фамилияtextBox2.Text, имяtextBox3.Text, отчествоtextBox4.Text, серияtextBox5.Text, номерtextBox6.Text, dateTimePicker2.Value);
                int passID = GetDirCode("[Паспортные данные]", фамилияtextBox2.Text, 1);
                db.AddFizFace(иннTB.Text);
                int FizFacaceid = GetDirCode("Физические_лица", иннTB.Text, 1);
                db.AddFizFaceAndPass(FizFacaceid, passID);
            }
            catch { }
            ComboUpdates(); TableUpdate();
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
            int passID = GetDirCode("[Паспортные данные]", код_физического_лицаCB.SelectedItem.ToString(), 1);
            dataGridViewListReturner.DataSource = db.ReturnTable("Код_физического_лица", "[Паспортные_данные и Физ_лица]", $"WHERE Код_паспортных_данных = {passID}").Tables[0].DefaultView;
            string fizFaceID = dataGridViewListReturner.Rows[0].Cells[0].Value.ToString();
            db.AddOrders(
               наименование_заказаTextBox.Text,
                fizFaceID,
                GetDirCode("Юридические_лица", код_юридического_лицаCB.SelectedItem.ToString(), 1).ToString(),
                dateTimePicker1.Value,
                GetDirCode("Прайс_лист", orderPriceListCB.SelectedItem.ToString(), 1)
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
            dataGridViewListReturner.DataSource = db.ReturnFizFaceLastName(Convert.ToInt32(заказыDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString())).Tables[0].DefaultView; код_физического_лицаCB.SelectedItem = dataGridViewListReturner.Rows[0].Cells[0].Value.ToString();
            dataGridViewListReturner.DataSource = db.ReturnTable("Название_юр_лица", "Юридические_лица", $"WHERE Код_юридического_лица = {заказыDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString()}").Tables[0].DefaultView; код_юридического_лицаCB.SelectedItem = dataGridViewListReturner.Rows[0].Cells[0].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(заказыDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            int priceListCode = GetDirCode("Прайс_лист", orderPriceListCB.SelectedItem.ToString(), 1);
            if(tempID != -1) { db.editZakaz(наименование_заказаTextBox.Text, код_физического_лицаCB.SelectedItem.ToString(), код_юридического_лицаCB.SelectedItem.ToString(), dateTimePicker1.Value, tempID, priceListCode); ; tempID = -1; }
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

        private void button18_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            if (tempID != -1)
            {
                db.deleteEnterprise(tempID);
                tempID = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void dataGridViewПреприятия_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewПреприятия.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tempID = Convert.ToInt32(dataGridViewПреприятия.Rows[e.RowIndex].Cells[0].Value);
            Наименование_предприятияTB.Text = dataGridViewПреприятия.Rows[e.RowIndex].Cells[1].Value.ToString();
            Фамилия_руководителяTB.Text = dataGridViewПреприятия.Rows[e.RowIndex].Cells[2].Value.ToString();
            Имя_руководителяTB.Text = dataGridViewПреприятия.Rows[e.RowIndex].Cells[3].Value.ToString();
            Отчество_руководителяTB.Text = dataGridViewПреприятия.Rows[e.RowIndex].Cells[4].Value.ToString();
            Телефон_секретаряTB.Text = dataGridViewПреприятия.Rows[e.RowIndex].Cells[5].Value.ToString();
            ПочтаTB.Text = dataGridViewПреприятия.Rows[e.RowIndex].Cells[6].Value.ToString();
            Телефон_руководителяTB.Text = dataGridViewПреприятия.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            if (tempID != -1)
            {
                db.updateEnterprise(tempID, Наименование_предприятияTB.Text, Фамилия_руководителяTB.Text, Имя_руководителяTB.Text, Отчество_руководителяTB.Text, Телефон_секретаряTB.Text, ПочтаTB.Text, Телефон_руководителяTB.Text); ;
                tempID = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void dataGridViewTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DB db = new DB(Credentials);
            dataGridViewTest.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewListReturner.DataSource = db.ReturnTable("Наименование_предприятия", "Предприятия", $"WHERE Код_предприятия = {dataGridViewTest.Rows[e.RowIndex].Cells[3].Value.ToString()}").Tables[0].DefaultView; 
            предпритиеCB.SelectedText = dataGridViewListReturner.Rows[0].Cells[0].Value.ToString();
            dataGridViewListReturner.DataSource = db.ReturnTable("Наименование_вида", "Вид_товара", $"WHERE Код_вида_товара = {dataGridViewTest.Rows[e.RowIndex].Cells[4].Value.ToString()}").Tables[0].DefaultView; вид_товараCB.SelectedText = dataGridViewListReturner.Rows[0].Cells[0].Value.ToString();
            tempID = Convert.ToInt32(dataGridViewTest.Rows[e.RowIndex].Cells[0].Value.ToString());
            наименование_товараTextBox.Text = dataGridViewTest.Rows[e.RowIndex].Cells[1].Value.ToString();
            артикулTextBox1.Text = dataGridViewTest.Rows[e.RowIndex].Cells[2].Value.ToString();
            стоимостьTextBox.Text = dataGridViewTest.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            if (tempID != -1)
            {
                db.deleteTovar(tempID); 
                tempID = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            
            if (tempID != -1)
            {
                int prId = GetDirCode("Предприятия", предпритиеCB.SelectedItem.ToString(), 1);
                int vidID = GetDirCode("Вид_товара", вид_товараCB.SelectedItem.ToString(), 1);

                db.updateTovar(tempID, наименование_товараTextBox.Text,
                артикулTextBox1.Text,
                prId.ToString(),
                vidID.ToString(),
               стоимостьTextBox.Text);
                tempID = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            if (tempID != -1)
            {
                db.deleteVidTov(tempID);
                tempID = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            if (tempID != -1)
            {
                db.updateVidTov(tempID, наименование_видаTextBox.Text);
                tempID = -1;
            }
            TableUpdate(); ComboUpdates();
        }

        private void вид_товараDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            физические_лицаDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tempID = Convert.ToInt32(вид_товараDataGridView.Rows[e.RowIndex].Cells[0].Value);
            наименование_видаTextBox.Text = вид_товараDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void sqlEXECBTN_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            try
            {
                db.executeQuery(sqlTB.Text);
            }
            catch { }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            try
            {
                int PriceListID = GetDirCode("Прайс_лист", PriceListCB.SelectedItem.ToString(), 1);
                int itemID = GetDirCode("Товар", ItemCB.SelectedItem.ToString(), 1);
                db.addItemToPriceList(PriceListID, itemID);
            }
            catch { }
            TableUpdate(); ComboUpdates();
        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            switch (tabControl4.SelectedIndex) 
            {
                case 0: dataGridViewTypeU.DataSource = db.ReturnTable("*", "Тип_улицы", null).Tables[0].DefaultView; break;
                case 1: dataGridViewTypeU.DataSource = db.ReturnTable("*", "Тип_населенного_пункта", null).Tables[0].DefaultView; break;
                case 2: dataGridViewTypeU.DataSource = db.ReturnTable("*", "Улица", null).Tables[0].DefaultView; break;
                case 3: dataGridViewTypeU.DataSource = db.ReturnTable("*", "[Населенный пункт]", null).Tables[0].DefaultView; break;
                case 4: dataGridViewTypeU.DataSource = db.ReturnTable("*", "Адрес", null).Tables[0].DefaultView; break;
            }
        }

        private void Delete_TypeUbutton26_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.DeleteTypeU(Convert.ToInt32(dataGridViewTypeU.SelectedRows[0].Cells[0].Value));
            TableUpdate(); ComboUpdates();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.deleteLocal(Convert.ToInt32(dataGridViewTypeU.SelectedRows[0].Cells[0].Value));
            TableUpdate(); ComboUpdates();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.updateTypeU(название_типа_улицыTextBox.Text, Convert.ToInt32(dataGridViewTypeU.SelectedRows[0].Cells[0].Value));
            TableUpdate(); ComboUpdates();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.deleteU(Convert.ToInt32(dataGridViewTypeU.SelectedRows[0].Cells[0].Value));
            TableUpdate(); ComboUpdates();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.updateU(названиеTextBox.Text, GetDirCode("Тип_улицы", comboBox3.SelectedItem.ToString(), 1), Convert.ToInt32(dataGridViewTypeU.SelectedRows[0].Cells[0].Value));
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

        private void buttonZap1_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            gridZapros1.DataSource = db.ReturnTable(
                "Юридические_Лица.Название_юр_лица, [Паспортные данные].Имя_физ_лица, Товар.Наименование_товара",
                "Заказы, Товар, Физические_Лица, Юридические_Лица, [Паспортные_данные и Физ_лица], [Паспортные данные], [Товары и заказы]",
                "WHERE [Товары и заказы].Код_товара = Товар.Код_товара " +
                "AND [Паспортные_данные и Физ_лица].Код_паспортных_данных = [Паспортные данные].Код_паспортных_данных " +
                "AND [Паспортные_данные и Физ_лица].Код_физического_лица = Физические_Лица.Код_физического_лица " +
                "AND [Товары и заказы].Код_заказа = Заказы.Код_заказа " +
                "AND Заказы.код_физического_лица = Физические_лица.Код_физического_лица " +
                "AND Заказы.код_юридического_лица = Юридические_лица.Код_юридического_лица " +
                $"AND Заказы.Дата_заказа > '{GetSQLFormatDate(dateTimePickerZap1.Value)}' " +
                $"AND Заказы.Дата_заказа < '{GetSQLFormatDate(dateTimePickerZap2.Value)}'").Tables[0].DefaultView;
        }

        private void buttonZap2_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            dataGridViewZap2.DataSource = db.ReturnTable(
                "Товар.Наименование_товара, Вид_товара.Наименование_вида, Товар.Стоимость", 
                "Товар, Вид_товара, Заказы, [Товары и заказы]",
                "WHERE Товар.Код_товара = [Товары и заказы].Код_товара " +
                "AND Заказы.Код_заказа = [Товары и заказы].Код_заказа " +
                $"AND Вид_товара.Код_вида_товара =  Товар.Код_вида_товара " +
                $"AND Заказы.Дата_заказа > '{GetSQLFormatDate(dateTimePickerZap2From.Value)}' " +
                $"AND Заказы.Дата_заказа < '{GetSQLFormatDate(dateTimePickerZap2To.Value)}'").Tables[0].DefaultView;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.DeleteTypeLocality(Convert.ToInt32(dataGridViewTypeU.SelectedRows[0].Cells[0].Value));
            TableUpdate(); ComboUpdates();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.updateLocality(название_типа_нас_пунктаTextBox.Text, Convert.ToInt32(dataGridViewTypeU.SelectedRows[0].Cells[0].Value));
            TableUpdate(); ComboUpdates();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            DB db = new DB(Credentials);
            db.updateLocal(названиеTextBox1.Text, GetDirCode("Тип_населенного_пункта", comboBox4.SelectedItem.ToString(), 1), Convert.ToInt32(dataGridViewTypeU.SelectedRows[0].Cells[0].Value));
            TableUpdate(); ComboUpdates();
        }

        string GetSQLFormatDate(DateTime Date)
        {
            string Temp = string.Empty;
            foreach (char i in Date.ToString("yyyy/MM/dd"))
            {
                if (i != '.')
                {
                    Temp += i;
                }
            }
            return Temp;
        }

    }
}
