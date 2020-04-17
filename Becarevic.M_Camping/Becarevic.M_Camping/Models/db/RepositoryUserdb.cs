using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;


namespace Becarevic.M_Camping.Models.db
{
    public class RepositoryUserdb : IRepositoryUser
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
            if ((this._connection != null) && (this._connection.State != ConnectionState.Closed){
                this._connection.Close();
            }
        }

        public bool Delete(int id)
        {

            DbCommand cmdDel = this._connection.CreateCommand();
            cmdDel.CommandText = "DELETE FROM users WHERE id=@userId";


            DbParameter paramId = cmdDel.CreateParameter();
            paramId.ParameterName = "userId";
            paramId.Value = id;
            paramId.DbType = DbType.Int32;


            cmdDel.Parameters.Add(paramId);


            return cmdDel.ExecuteNonQuery() == 1;

        }

        public List<User> GetAllUser()
        {
            List<User> users = new List<User>();

            DbCommand cmdSelect = this._connection.CreateCommand();
            cmdSelect.CommandText = "SELECT * FROM users ";

            using (DbDataReader reader = cmdSelect.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(
                        new User
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Firstname = Convert.ToString(reader["firstname"]),
                            Lastname = Convert.ToString(reader["lastname"]),
                            Gender = (Gender)Convert.ToInt32(reader["gender"]),
                            Birthdate = Convert.ToDateTime(reader["birthdate"]),
                            Username = Convert.ToString(reader["username"]),
                            Password = ""
                        });

                }
            }

            return users;
        }

        public User GetUser(int id)
        {
            DbCommand cmdGetUser = this._connection.CreateCommand();
            cmdGetUser.CommandText = "SELECT * FROM users where id=@id";

            DbParameter paramId = cmdGetUser.CreateParameter();
            paramId.ParameterName = "id";
            paramId.Value = id;
            paramId.DbType = DbType.Int32;

            cmdGetUser.Parameters.Add(paramId);
            using (DbDataReader reader = cmdGetUser.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return null;
                }
                reader.Read();
                return new User
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Firstname = Convert.ToString(reader["firstname"]),
                    Lastname = Convert.ToString(reader["lastname"]),
                    Gender = (Gender)Convert.ToInt32(reader["gender"]),
                    Birthdate = Convert.ToDateTime(reader["birthdate"]),
                    Username = Convert.ToString(reader["username"]),
                    Password = ""
                };

            }

        }

        public bool Insert(User user)
        {
            
            if (user == null)
            {
                return false;
            }
            
            DbCommand cmdInsert = this._connection.CreateCommand();
            cmdInsert.CommandText = "INSERT INTO users VALUES(null,@firstname,@lastname, @gender, @birthdate, @username, sha2(@password,526))";
            DbParameter paramFN = cmdInsert.CreateParameter();
            paramFN.ParameterName = "firstname";
            paramFN.Value = user.Firstname;
            paramFN.DbType = DbType.String;

            DbParameter paramLN = cmdInsert.CreateParameter();
            paramLN.ParameterName = "lastname";
            paramLN.Value = user.Lastname;
            paramLN.DbType = DbType.String;

            DbParameter paramGender = cmdInsert.CreateParameter();
            paramGender.ParameterName = "gender";
            paramGender.Value = user.Gender;
            paramGender.DbType = DbType.Int32;

            DbParameter parambd = cmdInsert.CreateParameter();
            parambd.ParameterName = "birthdate";
            parambd.Value = user.Birthdate;
            parambd.DbType = DbType.Date;

            DbParameter paramUsername = cmdInsert.CreateParameter();
            paramUsername.ParameterName = "username";
            paramUsername.Value = user.Username;
            paramUsername.DbType = DbType.String;

            DbParameter paramPass = cmdInsert.CreateParameter();
            paramPass.ParameterName = "password";
            paramPass.Value = user.Password;
            paramPass.DbType = DbType.String;


            
            cmdInsert.Parameters.Add(paramFN);
            cmdInsert.Parameters.Add(paramLN);
            cmdInsert.Parameters.Add(paramGender);
            cmdInsert.Parameters.Add(parambd);
            cmdInsert.Parameters.Add(paramUsername);
            cmdInsert.Parameters.Add(paramPass);

            return cmdInsert.ExecuteNonQuery() == 1;
        }

        public bool UpdateUserData(int id, User newUserData)
        {

            DbCommand cmdup = this._connection.CreateCommand();
            cmdup.CommandText = "Update users SET firstname=@firstname, lastname=@lastname" +
                "gender=@gender, birthdate=@birthdate, username=@username, password=sha2(@password, 512)" +
                "WHERE id=@uid";


            DbParameter paramFirstname = cmdup.CreateParameter();
            paramFirstname.ParameterName = "firstname";
            paramFirstname.Value = newUserData.Firstname;
            paramFirstname.DbType = DbType.String;


            cmdup.Parameters.Add(paramFirstname);

            DbParameter paramLastname = cmdup.CreateParameter();
            paramLastname.ParameterName = "lastname";
            paramLastname.Value = newUserData.Lastname;
            paramLastname.DbType = DbType.String;

            cmdup.Parameters.Add(paramLastname);

            DbParameter paramGedner = cmdup.CreateParameter();
            paramGedner.ParameterName = "gender";
            paramGedner.Value = newUserData.Gender;
            paramGedner.DbType = DbType.String;

            cmdup.Parameters.Add(paramGedner);


            return cmdup.ExecuteNonQuery() == 1;
        }

        public User Login(UserLogin user)
        {
            DbCommand cmdLogin = this._connection.CreateCommand();
            cmdLogin.CommandText = "SELECT * FROM users WHERE username=@username AND password=sha2(@password, 512)";

            DbParameter paramUsername = cmdLogin.CreateParameter();
            paramUsername.ParameterName = "username";
            paramUsername.Value = user.Username;
            paramUsername.DbType = DbType.String;

            DbParameter paramPwd = cmdLogin.CreateParameter();
            paramPwd.ParameterName = "password";
            paramPwd.Value = user.Password;
            paramPwd.DbType = DbType.String;

            cmdLogin.Parameters.Add(paramUsername);
            cmdLogin.Parameters.Add(paramPwd);

            using (DbDataReader reader = cmdLogin.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return null;
                }
                reader.Read();
                return new User
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Firstname = Convert.ToString(reader["firstname"]),
                    Lastname = Convert.ToString(reader["lastname"]),
                    Gender = (Gender)Convert.ToInt32(reader["gender"]),
                    Birthdate = Convert.ToDateTime(reader["birthdate"]),
                    Username = Convert.ToString(reader["username"]),
                    Password = ""
                };

            }
        }
    }
}
