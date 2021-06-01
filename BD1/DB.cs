using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BD
{
    class DB
    {
        //саси
        SqlConnection connection;

        public DB(string Credentials)
        {
            connection = new SqlConnection(Credentials);
        }

        public DataSet ReturnTable(string Col, string Tab, string Arguments)
        {
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT {Col} FROM {Tab} {Arguments}", connection);
            DataSet Tmp = new DataSet();
            adapter.Fill(Tmp);
            return Tmp;
        }

        public void AddTovar(string Name, string Article, string FactoryCode, string Kind, string Value)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO Товар (Наименование_товара, Артикул, Код_предприятия, Код_вида_товара, Стоимость) VALUES ( '{Name}', '{Article}', {FactoryCode}, {Kind}, {Value})", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }
        public void AddPlist(string Name, string Article)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO Прайс_лист ( Наименование_прайс_листа, Артикул) VALUES ( '{Name}', '{Article}')", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void AddTipU(string Name)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO Тип_улицы ( Название_типа_улицы) VALUES ( '{Name}' )", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void AddTipN(string Name)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO Тип_населенного_пункта ( Название_типа_нас_пункта) VALUES ( '{Name}' )", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }


        public void AddStreet(string Name)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO Улица ( Название) VALUES ( '{Name}' )", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void AddLocality(string Name)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO [Населенный пункт] (Название) VALUES ( '{Name}' )", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }


        public void AddFizFace(string Name)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO Физические_лица (ИНН) VALUES ( '{Name}' )", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void AddLegalFace(string Name,string inn)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO Юридические_лица (Название_юр_лица, ИНН) VALUES ( '{Name}','{inn}' )", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void AddAdress(string corpus, string kvartira, int streetCode, int hoodCode, int physFaceCode, int jurFaceCode)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO Адрес (Корпус, Квартира, Код_улицы, Код_населенного_пункта, Код_физического_лица, Код_юридического_лица) VALUES ('{corpus}', '{kvartira}', {streetCode}, {hoodCode}, {physFaceCode}, {jurFaceCode})", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddPasport(string surname, string Name, string otchestvo, string series, string num, DateTime dataV )
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO [Паспортные данные] (Фамилия_физ_лица, Имя_физ_лица, Отчество_физ_лица, Серия, Номер, Дата_выдачи) VALUES ( '{surname}', '{Name}','{otchestvo}','{series}','{num}','{dataV}' )", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }
        public void AddOrders(string name, string codeF, string codeLegal , DateTime dataZ)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO Заказы (Наименование_заказа, код_физического_лица, код_юридического_лица, Дата_заказа) VALUES ( '{name}', '{codeF}','{codeLegal}','{dataZ}' )", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void AddEnterprises(string nameEnterprises, string surname, string name, string otchestvo, string phoneSecretary, string mail, string phoneLeader)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO Предприятия  (Наименование_предприятия, Фамилия_руководителя, Имя_руководителя, Отчество_руководителя,Телефон_секретаря, Почта, Телефон_руководителя) VALUES('{nameEnterprises}', '{surname}','{name}', '{otchestvo}','{phoneSecretary}', '{mail}','{phoneLeader}') ", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }



        public void AddPassAndFace(int a, int b)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO [Паспортные_данные и Физ_лица] (Код_паспортных_данных, Код_физического_лица) VALUES ( {a}, {b})", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void AddVidTov(string name)
        {
            SqlCommand comment = new SqlCommand($"INSERT INTO Вид_товара (Наименование_вида) VALUES ( '{name}')", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteZak(int id)
        {
            SqlCommand comment = new SqlCommand($"DELETE FROM  Заказы where Код_заказа = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }





    }
}
