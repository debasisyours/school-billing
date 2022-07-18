using SchoolBilling.Common;
using SchoolBilling.Data.DataSets;
using SchoolBilling.Data.Entities;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;

namespace SchoolBilling.Data.Repositories
{
    public class InvoiceHelper : IDisposable
    {
        private readonly BillingContext _context;
        private readonly string _connectionString= string.Empty;

        public InvoiceHelper(BillingContext context)
        {
            _context = context;
        }

        public InvoiceHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region For Entity Framework
        //public InvoiceDataSet GetAllInvoicesDataSet(DateTime startDate, DateTime endDate)
        //{
        //    InvoiceDataSet invoiceDataSet = new InvoiceDataSet();
        //    Client? client = null;
        //    Route? route = null;

        //    try
        //    {
        //        DateTime fromDate = DateTime.ParseExact($"{startDate.Year}-{startDate.Month.ToString().PadLeft(2, '0')}-{startDate.Day.ToString().PadLeft(2, '0')} 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
        //        DateTime toDate = DateTime.ParseExact($"{endDate.Year}-{endDate.Month.ToString().PadLeft(2, '0')}-{endDate.Day.ToString().PadLeft(2, '0')} 23:59:59", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
        //        var invoiceList = _context.Invoices.Where(s => s.InvoiceDate >= fromDate && s.InvoiceDate <= toDate).ToList();
        //        if(invoiceList!=null && invoiceList.Count > 0)
        //        {
        //            foreach(var invoice in invoiceList)
        //            {
        //                DataRow row = invoiceDataSet.Tables[InvoiceDataSet.TableInvoice].NewRow();
        //                row[InvoiceDataSet.IdColumn] = invoice.Id;
        //                row[InvoiceDataSet.SelectedColumn] = false;
        //                client = _context.Clients.FirstOrDefault(s => s.Id == invoice.ClientId);
        //                route = _context.Routes.FirstOrDefault(s => s.Id == invoice.RouteId);
        //                row[InvoiceDataSet.ClientIdColumn] = invoice.ClientId;
        //                row[InvoiceDataSet.ClientNameColumn] = client!=null ? client.Name: String.Empty;
        //                row[InvoiceDataSet.RouteIdColumn] = invoice.RouteId;
        //                row[InvoiceDataSet.RouteNameColumn] = route!=null? route.Name : String.Empty;
        //                row[InvoiceDataSet.EndDateColumn] = invoice.EndDate.ToString("dd/MMM/yyyy");
        //                row[InvoiceDataSet.InvoiceDateColumn] = invoice.InvoiceDate.ToString("dd/MMM/yyyy");
        //                row[InvoiceDataSet.StartDateColumn] = invoice.StartDate.ToString("dd/MMM/yyyy");
        //                row[InvoiceDataSet.RouteCostColumn] = invoice.RouteCost;
        //                row[InvoiceDataSet.AideCostColumn] = invoice.AidCost;
        //                row[InvoiceDataSet.PerdiemColumn] = invoice.Perdiem;
        //                row[InvoiceDataSet.DayCountColumn] = invoice.DayCount;
        //                row[InvoiceDataSet.CovidDayCountColumn] = invoice.CovidDayCount;
        //                row[InvoiceDataSet.CovidNotesColumn] = invoice.Notes;
        //                row[InvoiceDataSet.TotalCostColumn] = invoice.TotalCost;
        //                invoiceDataSet.Tables[InvoiceDataSet.TableInvoice].Rows.Add(row);
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return invoiceDataSet;
        //}

        //public Invoice GetInvoiceById(int invoiceId)
        //{
        //    Invoice? invoice = null;

        //    try
        //    {
        //        invoice = _context.Invoices.FirstOrDefault(s => s.Id == invoiceId);
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return invoice;
        //}

        //public bool UpdateInvoice(Invoice invoice)
        //{
        //    bool success = false;

        //    try
        //    {
        //        var invoiceDetail = _context.Invoices.FirstOrDefault(s => s.Id == invoice.Id);

        //        if (invoiceDetail != null)
        //        {
        //            invoiceDetail.AidCost = invoice.AidCost;
        //            invoiceDetail.CovidDayCount = invoice.CovidDayCount;
        //            invoiceDetail.DayCount = invoice.DayCount;
        //            invoiceDetail.EndDate = invoice.EndDate;
        //            invoiceDetail.InvoiceDate = invoice.InvoiceDate;
        //            invoiceDetail.ModifiedOn = DateTime.Now;
        //            invoiceDetail.Notes = invoice.Notes;
        //            invoiceDetail.Perdiem = invoice.Perdiem;
        //            invoiceDetail.RouteCost = invoice.RouteCost;
        //            invoiceDetail.StartDate = invoice.StartDate;
        //            invoiceDetail.TotalCost = invoice.TotalCost;
        //        }
        //        else
        //        {
        //            invoice.CreatedOn = DateTime.Now;
        //            invoice.ModifiedOn = DateTime.Now;
        //            _context.Invoices.Add(invoice);
        //        }

        //        _context.SaveChanges();
        //        success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return success;
        //}

        #endregion

        #region For MS Access

        public int GenerateInvoiceNumber()
        {
            int invoiceNumber = 0;
            bool invoiceExists = false;
            string invoiceCountQuery = $"SELECT COUNT(1) FROM Invoice";
            string maxInvoiceQuery = $"SELECT MAX(InvoiceNumber) FROM Invoice";
            string startInvoiceQuery = $"SELECT StartingInvoiceNumber FROM Company";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.Text;
                        command.CommandText = invoiceCountQuery;

                        using (var reader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            if (reader.Read())
                            {
                                invoiceExists = Convert.ToInt32(reader[0]) > 0;
                            }
                        }
                    }

                    if (invoiceExists)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandTimeout = 0;
                            command.CommandType = CommandType.Text;
                            command.CommandText = maxInvoiceQuery;

                            using (var reader = command.ExecuteReader(CommandBehavior.SingleRow))
                            {
                                if (reader.Read())
                                {
                                    invoiceNumber = Convert.ToInt32(reader[0]) + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandTimeout = 0;
                            command.CommandType = CommandType.Text;
                            command.CommandText = startInvoiceQuery;

                            using (var reader = command.ExecuteReader(CommandBehavior.SingleRow))
                            {
                                if (reader.Read())
                                {
                                    invoiceNumber = Convert.ToInt32(reader[0]);
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            return invoiceNumber;
        }

        public bool IsInvoiceNumberValid(int invoiceId, int invoiceNumber)
        {
            bool valid = true;
            string selectQuery = $"SELECT COUNT(1) FROM Invoice WHERE Id!={invoiceId} AND InvoiceNumber={invoiceNumber}";

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
                                valid = Convert.ToInt32(reader[0]) == 0;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }

            return valid;
        }

        public InvoiceDataSet GetAllInvoicesDataSet(DateTime startDate, DateTime endDate)
        {
            InvoiceDataSet invoiceDataSet = new InvoiceDataSet();
            
            try
            {
                DateTime fromDate = DateTime.ParseExact($"{startDate.Year}-{startDate.Month.ToString().PadLeft(2, '0')}-{startDate.Day.ToString().PadLeft(2, '0')} 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
                DateTime toDate = DateTime.ParseExact($"{endDate.Year}-{endDate.Month.ToString().PadLeft(2, '0')}-{endDate.Day.ToString().PadLeft(2, '0')} 23:59:59", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
                string selectQuery = $"SELECT I.Id, C.Id AS ClientId, C.Name AS ClientName, R.Id As RouteId, R.Name AS RouteName, I.InvoiceDate, I.StartDate, I.EndDate, I.RouteCost, I.AidCost, I.Perdiem, I.DayCount, I.TotalCost, I.CovidDayCount, I.Notes, I.InvoiceNumber FROM Invoice I, Client C, Route R WHERE I.RouteId = R.Id AND I.ClientId = C.Id AND I.InvoiceDate >=? AND I.InvoiceDate<=?";

                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = selectQuery;
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.Text;

                        command.Parameters.Add(new OleDbParameter
                        {
                            ParameterName = "FromDate",
                            OleDbType = OleDbType.Date,
                            Direction = ParameterDirection.Input,
                            Value = fromDate
                        });

                        command.Parameters.Add(new OleDbParameter
                        {
                            ParameterName = "ToDate",
                            OleDbType = OleDbType.Date,
                            Direction = ParameterDirection.Input,
                            Value = toDate
                        });

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DataRow row = invoiceDataSet.Tables[InvoiceDataSet.TableInvoice].NewRow();
                                row[InvoiceDataSet.IdColumn] = Convert.ToInt32(reader["Id"]);
                                row[InvoiceDataSet.SelectedColumn] = false;
                                row[InvoiceDataSet.ClientIdColumn] = Convert.ToInt32(reader["ClientId"]);
                                row[InvoiceDataSet.ClientNameColumn] = Convert.ToString(reader["ClientName"]);
                                row[InvoiceDataSet.RouteIdColumn] = Convert.ToInt32(reader["RouteId"]);
                                row[InvoiceDataSet.RouteNameColumn] = Convert.ToString(reader["RouteName"]);
                                row[InvoiceDataSet.EndDateColumn] = Convert.ToDateTime(reader["EndDate"]).ToString("MM/dd/yyyy");
                                row[InvoiceDataSet.InvoiceDateColumn] = Convert.ToDateTime(reader["InvoiceDate"]).ToString("MM/dd/yyyy");
                                row[InvoiceDataSet.StartDateColumn] = Convert.ToDateTime(reader["StartDate"]).ToString("MM/dd/yyyy");
                                row[InvoiceDataSet.RouteCostColumn] = Convert.ToDecimal(reader["RouteCost"]);
                                row[InvoiceDataSet.AideCostColumn] = Convert.ToDecimal(reader["AidCost"]);
                                row[InvoiceDataSet.PerdiemColumn] = Convert.ToDecimal(reader["Perdiem"]);
                                row[InvoiceDataSet.DayCountColumn] = Convert.ToInt32(reader["DayCount"]);
                                row[InvoiceDataSet.CovidDayCountColumn] = Convert.ToInt32(reader["CovidDayCount"]);
                                row[InvoiceDataSet.CovidNotesColumn] = Convert.ToString(reader["Notes"]);
                                row[InvoiceDataSet.TotalCostColumn] = Convert.ToDecimal(reader["TotalCost"]);
                                row[InvoiceDataSet.InvoiceNumberColumn] = Convert.ToInt32(reader["InvoiceNumber"]);
                                invoiceDataSet.Tables[InvoiceDataSet.TableInvoice].Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return invoiceDataSet;
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            Invoice? invoice = null;
            string selectQuery = $"SELECT * FROM Invoice WHERE Id = {invoiceId}";

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
                                invoice = new Invoice
                                {
                                    Id = invoiceId,
                                    AidCost = reader["AidCost"] == null ? 0 : Convert.ToDecimal(reader["AidCost"]),
                                    ClientId = Convert.ToInt32(reader["ClientId"]),
                                    CovidDayCount = Convert.ToInt32(reader["CovidDayCount"]),
                                    CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                                    DayCount = Convert.ToInt32(reader["DayCount"]),
                                    EndDate = Convert.ToDateTime(reader["EndDate"]),
                                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]),
                                    ModifiedOn = Convert.ToDateTime(reader["ModifiedOn"]),
                                    Notes = Convert.ToString(reader["Notes"]),
                                    Perdiem = Convert.ToDecimal(reader["Perdiem"]),
                                    RouteCost = Convert.ToDecimal(reader["RouteCost"]),
                                    TotalCost = Convert.ToDecimal(reader["TotalCost"]),
                                    RouteId = Convert.ToInt32(reader["RouteId"]),
                                    StartDate = Convert.ToDateTime(reader["StartDate"]),
                                    InvoiceNumber = Convert.ToInt32(reader["InvoiceNumber"])
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

            return invoice;
        }

        public bool UpdateInvoice(Invoice invoice)
        {
            bool success = false;
            bool recordExists = false;
            string selectQuery = $"SELECT COUNT(1) FROM Invoice WHERE Id = {invoice.Id}";
            string insertQuery = $"INSERT INTO Invoice(ClientId, RouteId, InvoiceDate, StartDate, EndDate, RouteCost, AidCost, Perdiem, DayCount, TotalCost, CovidDayCount, Notes, CreatedOn, ModifiedOn, InvoiceNumber) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            string updateQuery = $"UPDATE Invoice SET ClientId = ?, RouteId = ?, InvoiceDate = ?, StartDate = ?, EndDate = ?, RouteCost = ?, AidCost = ?, Perdiem = ?, DayCount = ?, TotalCost = ?, CovidDayCount = ?, Notes = ?, ModifiedOn = ? WHERE Id = ?";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = selectQuery;
                        command.CommandType = CommandType.Text;
                        command.CommandTimeout = 0;

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
                                ParameterName = "ClientId",
                                OleDbType = OleDbType.Integer,
                                Direction = ParameterDirection.Input,
                                Value = invoice.ClientId
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "RouteId",
                                OleDbType = OleDbType.Integer,
                                Direction = ParameterDirection.Input,
                                Value = invoice.RouteId
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "InvoiceDate",
                                OleDbType = OleDbType.Date,
                                Direction = ParameterDirection.Input,
                                Value = invoice.InvoiceDate
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "StartDate",
                                OleDbType = OleDbType.Date,
                                Direction = ParameterDirection.Input,
                                Value = invoice.StartDate
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "EndDate",
                                OleDbType = OleDbType.Date,
                                Direction = ParameterDirection.Input,
                                Value = invoice.EndDate
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "RouteCost",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = invoice.RouteCost
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "AidCost",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = invoice.AidCost
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Perdiem",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = invoice.Perdiem
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "DayCount",
                                OleDbType = OleDbType.Integer,
                                Direction = ParameterDirection.Input,
                                Value = invoice.DayCount
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "TotalCost",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = invoice.TotalCost
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "CovidDayCount",
                                OleDbType = OleDbType.Integer,
                                Direction = ParameterDirection.Input,
                                Value = invoice.CovidDayCount
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Notes",
                                OleDbType = OleDbType.LongVarChar,
                                Direction = ParameterDirection.Input,
                                Value = invoice.Notes
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
                                OleDbType = OleDbType.Integer,
                                Direction = ParameterDirection.Input,
                                Value = invoice.Id
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
                                ParameterName = "ClientId",
                                OleDbType = OleDbType.Integer,
                                Direction = ParameterDirection.Input,
                                Value = invoice.ClientId
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "RouteId",
                                OleDbType = OleDbType.Integer,
                                Direction = ParameterDirection.Input,
                                Value = invoice.RouteId
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "InvoiceDate",
                                OleDbType = OleDbType.Date,
                                Direction = ParameterDirection.Input,
                                Value = invoice.InvoiceDate
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "StartDate",
                                OleDbType = OleDbType.Date,
                                Direction = ParameterDirection.Input,
                                Value = invoice.StartDate
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "EndDate",
                                OleDbType = OleDbType.Date,
                                Direction = ParameterDirection.Input,
                                Value = invoice.EndDate
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "RouteCost",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = invoice.RouteCost
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "AidCost",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = invoice.AidCost
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Perdiem",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = invoice.Perdiem
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "DayCount",
                                OleDbType = OleDbType.Integer,
                                Direction = ParameterDirection.Input,
                                Value = invoice.DayCount
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "TotalCost",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = invoice.TotalCost
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "CovidDayCount",
                                OleDbType = OleDbType.Integer,
                                Direction = ParameterDirection.Input,
                                Value = invoice.CovidDayCount
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "Notes",
                                OleDbType = OleDbType.LongVarChar,
                                Direction = ParameterDirection.Input,
                                Value = invoice.Notes
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

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "InvoiceNumber",
                                OleDbType = OleDbType.Integer,
                                Direction = ParameterDirection.Input,
                                Value = invoice.InvoiceNumber
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
