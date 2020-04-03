using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Becarevic.M_Camping.Models.db
{
    public class ReservierungDB
    {

        private string _connectionString = "Server=localhost;Database=db_reservierung; Uid=root;Pwd=root;";
        private MySqlConnection _connection;

        public void Open()
        {

            if (this._connection == null)
            {
                this._connection = new MySqlConnection(this._connectionString);
            }

            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();
            }
        }

        public void Close()
        {
            if ((this._connection != null) && (this._connection.State != ConnectionState.Closed)){
                this._connection.Close();
            }
        }

        public bool Insert(Reservierung reservierung)
        {
             
            if (reservierung == null)
            {
                return false;
            }
             
            DbCommand cmdInsert = this._connection.CreateCommand();
            cmdInsert.CommandText = "INSERT INTO users VALUES(null,@firstname,@lastname, @street, @phonenumber, @birthdate, @category";
            DbParameter paramFN = cmdInsert.CreateParameter();
            paramFN.ParameterName = "firstname";
            paramFN.Value = reservierung.Firstname;
            paramFN.DbType = DbType.String;

            DbParameter paramLN = cmdInsert.CreateParameter();
            paramLN.ParameterName = "lastname";
            paramLN.Value = reservierung.Lastname;
            paramLN.DbType = DbType.String;

            DbParameter paramSt = cmdInsert.CreateParameter();
            paramSt.ParameterName = "street";
            paramSt.Value = reservierung.Street;
            paramSt.DbType = DbType.String;

            DbParameter paramPn = cmdInsert.CreateParameter();
            paramPn.ParameterName = "phonenumber";
            paramPn.Value = reservierung.Phonenumber;
            paramPn.DbType = DbType.Int32;

            DbParameter parambd = cmdInsert.CreateParameter();
            parambd.ParameterName = "birthdate";
            parambd.Value = reservierung.Birthdate;
            parambd.DbType = DbType.Date;

            DbParameter paramC = cmdInsert.CreateParameter();
            paramC.ParameterName = "category";
            paramC.Value = reservierung.Category;
            paramC.DbType = DbType.String;
            
            //Parameter mit Common verbinden
            cmdInsert.Parameters.Add(paramFN);
            cmdInsert.Parameters.Add(paramLN);
            cmdInsert.Parameters.Add(paramSt);
            cmdInsert.Parameters.Add(paramPn);
            cmdInsert.Parameters.Add(parambd);
            cmdInsert.Parameters.Add(paramC);

            return cmdInsert.ExecuteNonQuery() == 1;
        }
        
    }
}