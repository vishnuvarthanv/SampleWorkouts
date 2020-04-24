using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using StoreApp.BusinessLogicLayer;

namespace StoreApp.RepositoryLayer
{
        public class SqliteDataProvider : IDataProvider
        {
            #region Constants

            public const string FileName = "storeapp.db";

            #endregion Constants

            #region Constructors

            public SqliteDataProvider()
            {
                DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

                SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
                builder.DataSource = DataPath;
                ConnectionString = builder.ToString() + ";Version=3;Pooling=False;Max Pool Size=100;";
            }

            #endregion Constructors

            #region Properties

            /// <summary>
            /// The full data path of the sqlite database file
            /// </summary>
            public string DataPath { get; private set; }

            /// <summary>
            /// The connection string
            /// </summary>
            protected string ConnectionString { get; set; }

            #endregion Properties

            #region Methods

            public bool Delete(Items Item)
            {
                string sqlDelete = $@"DELETE FROM Friend WHERE Id='{Item.Item_Id}'";
                return ExeNonQueryCommand(sqlDelete);
            }

            public List<Items> GetAllItems()
            {
                var list = new List<Items>();
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    string sqlInsert = $@"SELECT * FROM item_mstr";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlInsert, conn))
                    {
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            var dataTable = new DataTable();
                            da.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                var Item = new Items();
                                Item.Item_Id = row["item_id"].ToString();
                                Item.Item_Name = row["item_name"].ToString();
                                Item.Cat_Id = row["cat_id"] != null ? row["Cat_Id"].ToString() : string.Empty;
                                Item.Unit_Id = row["unit_id"] != null ? row["unit_id"].ToString() : string.Empty;
                                Item.Price = row["Price"] != null ? float.Parse( row["Price"].ToString()) : 0;
                                Item.Start_Date = row["start_dt"] != null ? row["start_dt"].ToString() : string.Empty; ;
                                Item.End_Date = row["end_dt"] != null ? row["end_dt"].ToString() : string.Empty; ;
                                Item.Active = row["active"] != null ? row["active"].ToString() : string.Empty; ;

                                list.Add(Item);
                            }
                        }
                    }
                }

                return list;
            }

        public List<Categories> GetCategories()
        {
            var list = new List<Categories>();
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sqlInsert = $@"SELECT * FROM category_mstr";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlInsert, conn))
                {
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        var dataTable = new DataTable();
                        da.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            var Item = new Categories();
                            Item.CategoryId = row["cat_id"].ToString();
                            Item.CategoryName = row["cat_name"].ToString();

                            list.Add(Item);
                        }
                    }
                }
            }
            return list;
        }

        public List<Units> GetUnits()
        {
            var list = new List<Units>();
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sqlInsert = $@"SELECT * FROM unit_mstr";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlInsert, conn))
                {
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        var dataTable = new DataTable();
                        da.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            var Item = new Units();
                            Item.UnitId = row["unit_id"].ToString();
                            Item.UnitName = row["unit_name"].ToString();

                            list.Add(Item);
                        }
                    }
                }
            }
            return list;
        }

            public Items GetItemById(string id)
            {
                Items Item = null;
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    string sqlInsert = $@"SELECT * FROM Friend WHERE Id='{id}'";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlInsert, conn))
                    {
                        SQLiteDataReader row = cmd.ExecuteReader();
                        if (row.Read())
                        {
                            Item = new Items();
                            Item.Item_Id = row["item_id"].ToString();
                            Item.Item_Name = row["item_name"].ToString();
                            Item.Cat_Id = row["cat_id"] != null ? row["cat_id"].ToString() : string.Empty;
                            Item.Unit_Id = row["unit_id"] != null ? row["unit_id"].ToString() : string.Empty;
                            Item.Price = row["price"] != null ? float.Parse(row["Price"].ToString()) : 0;
                            Item.Start_Date = row["start_dt"] != null ? row["start_dt"].ToString() : string.Empty; ;
                            Item.End_Date = row["end_dt"] != null ? row["end_dt"].ToString() : string.Empty; ;
                            Item.Active = row["active"] != null ? row["active"].ToString() : string.Empty; ;

                        }
                    }
                }

                return Item;
            }

            public bool Insert(Items Item)
            {
                string sqlInsert = $@"INSERT INTO Friend VALUES('{Item.Item_Id}','{Item.Item_Name}','{Item.Cat_Id}','{Item.Unit_Id}','{Item.Price}','{Item.Start_Date}','{Item.End_Date}','{Item.Active}')";
                return ExeNonQueryCommand(sqlInsert);
            }

            public bool Update(Items Item)
            {
                string sqlUpdate = $@"UPDATE Friend SET item_name='{Item.Item_Name}', cat_id='{Item.Cat_Id}', unit_id='{Item.Unit_Id}', price='{Item.Price}', start_dt='{Item.Start_Date}', end_date='{Item.End_Date}', active='{Item.Active}' WHERE item_id='{Item.Item_Id}'";
                return ExeNonQueryCommand(sqlUpdate);
            }

            private bool ExeNonQueryCommand(string sqlCommandText)
            {
                bool isSuccess = false;

                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommandText, conn))
                    {
                        isSuccess = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }

                return isSuccess;
            }

            #endregion Methods
        }
}
