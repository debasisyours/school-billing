using SchoolBilling.Common;
using SchoolBilling.Data.DataSets;
using SchoolBilling.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace SchoolBilling.Data.Repositories
{
    public class ClientHelper : IDisposable
    {
        private readonly BillingContext _context;
        private readonly string _connectionString = string.Empty;

        public ClientHelper(BillingContext context)
        {
            _context = context;
        }

        public ClientHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region For Entity Framework
        //public List<Client> GetAllClients()
        //{
        //    var clientList = new List<Client>();

        //    try
        //    {
        //        clientList = _context.Clients.Where(s => s.IsActive).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return clientList;
        //}

        //public List<Client> GetClientOrderedList()
        //{
        //    List<Client> clients = new List<Client>();

        //    try
        //    {
        //        clients = _context.Clients.Where(s => s.IsActive).OrderBy(s => s.Name).ToList();
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return clients;
        //}

        //public ClientDataSet GetAllClientsDataSet()
        //{
        //    ClientDataSet clientList = new ClientDataSet();

        //    try
        //    {
        //        var clients = _context.Clients.Where(s => s.IsActive).ToList();
        //        if(clients!=null && clients.Count > 0)
        //        {
        //            foreach(var client in clients)
        //            {
        //                DataRow row = clientList.Tables[ClientDataSet.TableClient].NewRow();
        //                row[ClientDataSet.IdColumn] = client.Id;
        //                row[ClientDataSet.NameColumn] = client.Name;
        //                row[ClientDataSet.CreatedOnColumn] = client.CreatedOn.ToString("dd-MMM-yyyy");
        //                row[ClientDataSet.IsActiveColumn]= client.IsActive;
        //                clientList.Tables[ClientDataSet.TableClient].Rows.Add(row);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return clientList;
        //}

        //public Client GetClientById(int clientId)
        //{
        //    Client? client = null;

        //    try
        //    {
        //        client = _context.Clients.FirstOrDefault(s => s.Id == clientId);
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return client;
        //}

        //public bool UpdateClient(Client client)
        //{
        //    bool success = false;

        //    try
        //    {
        //        var clientDetail = _context.Clients.FirstOrDefault(s => s.Id == client.Id);

        //        if(clientDetail != null)
        //        {
        //            clientDetail.IsActive = client.IsActive;
        //            clientDetail.ModifiedOn = DateTime.Now;
        //            clientDetail.Name = client.Name;
        //        }
        //        else
        //        {
        //            client.CreatedOn = DateTime.Now;
        //            client.ModifiedOn = DateTime.Now;
        //            _context.Clients.Add(client);
        //        }
        //        _context.SaveChanges();
        //        success = true;
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return success;
        //}

        #endregion

        #region For MS Access

        public List<Client> GetAllClients()
        {
            var clientList = new List<Client>();
            string selectQuery = $"SELECT * FROM Client ORDER BY Name";
            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.Text;
                        command.CommandText = selectQuery;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientList.Add(new Client
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = Convert.ToString(reader["Name"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                    CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                                    ModifiedOn = Convert.ToDateTime(reader["ModifiedOn"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return clientList;
        }

        public List<Client> GetClientOrderedList()
        {
            List<Client> clients = new List<Client>();
            string selectQuery = $"SELECT * FROM Client WHERE IsActive = YES ORDER BY Name";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.Text;
                        command.CommandText = selectQuery;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clients.Add(new Client
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = Convert.ToString(reader["Name"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                    CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                                    ModifiedOn = Convert.ToDateTime(reader["ModifiedOn"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return clients;
        }

        public ClientDataSet GetAllClientsDataSet()
        {
            ClientDataSet clientList = new ClientDataSet();
            string selectQuery = $"SELECT * FROM Client WHERE IsActive = YES ORDER BY Name";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.Text;
                        command.CommandText = selectQuery;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DataRow row = clientList.Tables[ClientDataSet.TableClient].NewRow();
                                row[ClientDataSet.IdColumn] = Convert.ToInt32(reader["Id"]);
                                row[ClientDataSet.NameColumn] = Convert.ToString(reader["Name"]);
                                row[ClientDataSet.IsActiveColumn] = Convert.ToBoolean(reader["IsActive"]);
                                row[ClientDataSet.CreatedOnColumn] = Convert.ToDateTime(reader["CreatedOn"]);
                                clientList.Tables[ClientDataSet.TableClient].Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return clientList;
        }

        public Client GetClientById(int clientId)
        {
            Client? client = null;
            string selectQuery = $"SELECT * FROM Client WHERE Id = {clientId}";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.Text;
                        command.CommandText = selectQuery;

                        using (var reader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            if (reader.Read())
                            {
                                client = new Client
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = Convert.ToString(reader["Name"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                    CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                                    ModifiedOn = Convert.ToDateTime(reader["ModifiedOn"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return client;
        }

        public bool UpdateClient(Client client)
        {
            bool success = false;
            bool recordExists = false;
            string selectQuery = $"SELECT COUNT(1) FROM Client WHERE Id = {client.Id}";
            string insertQuery = $"INSERT INTO Client(Name, IsActive, CreatedOn, ModifiedOn) VALUES(?,?,?,?)";
            string updateQuery = $"UPDATE Client SET Name = ?, IsActive = ?, ModifiedOn = ? WHERE Id = ?";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString)) 
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.Text;
                        command.CommandText = selectQuery;

                        using (var reader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            if (reader.Read())
                            {
                                recordExists = Convert.ToInt32(reader[0]) > 0;
                            }
                        }
                    }

                    if (recordExists)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandTimeout = 0;
                            command.CommandType = CommandType.Text;
                            command.CommandText = updateQuery;

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Name",
                                OleDbType = OleDbType.LongVarChar,
                                Direction = ParameterDirection.Input,
                                Value = client.Name
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "IsActive",
                                OleDbType = OleDbType.Boolean,
                                Direction = ParameterDirection.Input,
                                Value = client.IsActive
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "ModifiedOn",
                                OleDbType = OleDbType.Date,
                                Direction = ParameterDirection.Input,
                                Value = DateTime.Now
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Id",
                                OleDbType = OleDbType.BigInt,
                                Direction = ParameterDirection.Input,
                                Value = client.Id
                            });

                            command.ExecuteNonQuery();
                            success = true;
                        }
                    }
                    else
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandTimeout = 0;
                            command.CommandType = CommandType.Text;
                            command.CommandText = insertQuery;

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Name",
                                OleDbType = OleDbType.LongVarChar,
                                Direction = ParameterDirection.Input,
                                Value = client.Name
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "IsActive",
                                OleDbType = OleDbType.Boolean,
                                Direction = ParameterDirection.Input,
                                Value = client.IsActive
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "CreatedOn",
                                OleDbType = OleDbType.Date,
                                Direction = ParameterDirection.Input,
                                Value = DateTime.Now
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "ModifiedOn",
                                OleDbType = OleDbType.Date,
                                Direction = ParameterDirection.Input,
                                Value = DateTime.Now
                            });

                            command.ExecuteNonQuery();
                            success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return success;
        }

        #endregion

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
