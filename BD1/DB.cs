﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace BD
{
    class DB
    {
     
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
            SqlCommand comment = new SqlCommand($"DELETE FROM Заказы where Код_заказа = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void editZakaz(string name, string codeF, string codeLegal, DateTime dataZ, int id)
        {
            SqlCommand comment = new SqlCommand($"Update Заказы SET (Наименование_заказа = '{name}', код_физического_лица = {codeF}, код_юридического_лица = {codeLegal}, Дата_заказа = '{dataZ}') WHERE Код_заказа = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteFizLic(int id)
        {
            SqlCommand comment = new SqlCommand($"DELETE FROM Физические_лица WHERE Код_физического_лица = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void deletePass(int id)
        {
            SqlCommand comment = new SqlCommand($"DELETE FROM [Паспортные данные] WHERE Код_паспортных_данных = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteYourLits(int id)
        {
            SqlCommand comment = new SqlCommand($"DELETE FROM Юридические_лица WHERE Код_юридического_лица = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteEnterprise(int id)
        {
            SqlCommand comment = new SqlCommand($"DELETE FROM Предприятия WHERE Код_предприятия = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteTovar(int id)
        {
            SqlCommand comment = new SqlCommand($"DELETE FROM Товар WHERE Код_товара = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteVidTov(int id)
        {
            SqlCommand comment = new SqlCommand($"DELETE FROM Вид_товара WHERE Код_вида_товара = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }
        public void updateYourLits(int id, string name, string inn)
        {
            SqlCommand comment = new SqlCommand($"UPDATE Юридические_лица SET(Название_юр_лица = '{name}', ИНН = '{inn}') WHERE Код_юридического_лица = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void updateFizLitso(int id, string Name)
        {
            SqlCommand comment = new SqlCommand($"UPDATE Физические_лица SET (ИНН = '{Name}') WHERE Код_физического_лица = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }
        public void updatePassport(int id, string surname, string Name, string otchestvo, string series, string num, DateTime dataV)
        {
            SqlCommand comment = new SqlCommand($"UPDATE [Паспортные данные] SET (Фамилия_физ_лица = '{surname}', Имя_физ_лица = '{Name}', Отчество_физ_лица = '{otchestvo}', Серия = '{series}', Номер = '{num}', Дата_выдачи = '{dataV}') WHERE Код_паспортных_данных = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void updateEnterprise(int id, string name, string surname, string Rukname, string otch, string phone, string email, string rukPhone)
        {
            SqlCommand comment = new SqlCommand($"UPDATE Предприятия SET (Наименование_предприятия = '{name}', Фамилия_руководителя = '{surname}', Имя_руководителя = '{Rukname}', Отчество_руководителя = '{otch}', Телефон_секретаря = '{phone}', Почта = '{email}', Телефон_руководителя = '{rukPhone}') WHERE Код_предприятия = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void updateTovar(int id, string name, string Article, string FactoryCode, string Kind, string Value)
        {
            SqlCommand comment = new SqlCommand($"UPDATE Товар SET (Наименование_товара = '{name}', Артикул = '{Article}', Код_предприятия = '{FactoryCode}', Код_вида_товара = '{Kind}', Стоимость = '{Value}') WHERE Код_товара = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void updateVidTov(int id, string name)
        {
            SqlCommand comment = new SqlCommand($"UPDATE Вид_товара SET (Наименование_вида = '{name}') WHERE Код_вида_товара = {id}", connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }

        public void executeQuery(string query)
        {
            SqlCommand comment = new SqlCommand(query, connection);
            connection.Open();
            comment.ExecuteNonQuery();
            connection.Close();
        }
    }
}
