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
    public class RouteHelper : IDisposable
    {
        private readonly BillingContext _context;
        private readonly string _connectionString = string.Empty;

        public RouteHelper(BillingContext context)
        {
            _context = context;
        }

        public RouteHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region For Entity Framework

        //public List<Route> GetAllRoutes()
        //{
        //    var routes = new List<Route>();

        //    try
        //    {
        //        routes = _context.Routes.ToList();
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return routes;
        //}

        //public List<Route> GetRouteListOrdered()
        //{
        //    List<Route> routes = new List<Route>();

        //    try
        //    {
        //        _context.Configuration.LazyLoadingEnabled = false;
        //        routes = _context.Routes.Where(s=> s.IsActive).ToList();
        //        _context.Configuration.LazyLoadingEnabled = true;
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return routes;
        //}

        //public Route GetRouteById(int routeId)
        //{
        //    Route? route = null;

        //    try
        //    {
        //        route = _context.Routes.FirstOrDefault(s => s.Id == routeId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return route;
        //}

        //public bool IsRouteValid(string routeName)
        //{
        //    bool success = false;

        //    try
        //    {
        //        var route = _context.Routes.FirstOrDefault(s => s.Name == routeName);
        //        success = route != null;
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return success;
        //}

        //public RouteDataSet GetAllRoutesDataSet()
        //{
        //    RouteDataSet routes = new RouteDataSet();

        //    try
        //    {
        //        var routeList = _context.Routes.Where(s => s.IsActive).ToList();
        //        if(routeList!=null && routeList.Count > 0)
        //        {
        //            foreach(var route in routeList)
        //            {
        //                DataRow row = routes.Tables[RouteDataSet.TableRoute].NewRow();
        //                row[RouteDataSet.IdColumn] = route.Id;
        //                row[RouteDataSet.NameColumn] = route.Name;
        //                row[RouteDataSet.RouteCostColumn] = route.RouteCost;
        //                row[RouteDataSet.AidCostColumn] = route.AidCost;
        //                routes.Tables[RouteDataSet.TableRoute].Rows.Add(row);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return routes;
        //}

        //public bool UpdateRouteDetail(Route route)
        //{
        //    bool success = false;

        //    try
        //    {
        //        var routeDetail = _context.Routes.FirstOrDefault(s => s.Id == route.Id);

        //        if (routeDetail != null)
        //        {
        //            routeDetail.ModifiedOn = DateTime.Now;
        //            routeDetail.AidCost = route.AidCost;
        //            routeDetail.Name = route.Name;
        //            routeDetail.RouteCost = route.RouteCost;
        //            routeDetail.IsActive = true;
        //        }
        //        else
        //        {
        //            route.CreatedOn = DateTime.Now;
        //            route.ModifiedOn = DateTime.Now;
        //            _context.Routes.Add(route);
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

        //public bool MarkAsDeleted(int routeId)
        //{
        //    bool success = false;

        //    try
        //    {
        //        var route = _context.Routes.FirstOrDefault(r => r.Id == routeId);
        //        if (route != null)
        //        {
        //            route.IsActive = false;
        //            route.ModifiedOn = DateTime.Now;
        //            _context.SaveChanges();
        //            success = true;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogException(ex);
        //    }

        //    return success;
        //}

        #endregion

        #region For MS Access

        public List<Route> GetAllRoutes()
        {
            var routes = new List<Route>();
            string selectQuery = $"SELECT * FROM Route ORDER BY Name";

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
                                routes.Add(new Route
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = Convert.ToString(reader["Name"]),
                                    RouteCost = Convert.ToDecimal(reader["RouteCost"]),
                                    AidCost = Convert.ToDecimal(reader["AidCost"]),
                                    CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
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

            return routes;
        }

        public List<Route> GetRouteListOrdered()
        {
            List<Route> routes = new List<Route>();
            string selectQuery = $"SELECT * FROM Route WHERE IsActive = YES ORDER BY Name";

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
                                routes.Add(new Route
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = Convert.ToString(reader["Name"]),
                                    RouteCost = Convert.ToDecimal(reader["RouteCost"]),
                                    AidCost = Convert.ToDecimal(reader["AidCost"]),
                                    CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
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

            return routes;
        }

        public Route GetRouteById(int routeId)
        {
            Route? route = null;
            string selectQuery = $"SELECT * FROM Route WHERE Id = {routeId}";

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
                                route = new Route
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = Convert.ToString(reader["Name"]),
                                    RouteCost = Convert.ToDecimal(reader["RouteCost"]),
                                    AidCost = Convert.ToDecimal(reader["AidCost"]),
                                    CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
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

            return route;
        }

        public bool IsRouteValid(string routeName)
        {
            bool success = false;
            string selectQuery = $"SELECT COUNT(1) FROM Route WHERE Name = '{routeName}'";

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
                                success = Convert.ToInt32(reader[0]) > 0;
                            }
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

        public RouteDataSet GetAllRoutesDataSet()
        {
            RouteDataSet routes = new RouteDataSet();
            string selectQuery = $"SELECT * FROM Route WHERE IsActive = YES ORDER BY Name";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.Text;
                        command.CommandText= selectQuery;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DataRow row = routes.Tables[RouteDataSet.TableRoute].NewRow();
                                row[RouteDataSet.IdColumn] = Convert.ToInt32(reader["Id"]);
                                row[RouteDataSet.NameColumn] = Convert.ToString(reader["Name"]);
                                row[RouteDataSet.RouteCostColumn] = Convert.ToDecimal(reader["RouteCost"]);
                                row[RouteDataSet.AidCostColumn] = Convert.ToDecimal(reader["AidCost"]);
                                routes.Tables[RouteDataSet.TableRoute].Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return routes;
        }

        public bool UpdateRouteDetail(Route route)
        {
            bool success = false;
            bool recordExists = false;
            string selectQuery=$"SELECT COUNT(1) FROM Route WHERE Id = {route.Id}";
            string insertQuery = $"INSERT INTO Route(Name, RouteCost, AidCost, IsActive, CreatedOn, ModifiedOn) VALUES(?,?,?,?,?,?)";
            string updateQuery = $"UPDATE Route SET Name = ?, RouteCost = ?, AidCost = ?, IsActive = ?, ModifiedOn = ? WHERE Id = ?";

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
                                Value = route.Name
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "RouteCost",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = route.RouteCost
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "AidCost",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = route.AidCost
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "IsActive",
                                OleDbType = OleDbType.Boolean,
                                Direction = ParameterDirection.Input,
                                Value = route.IsActive
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
                                Value = route.Id
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
                                Value = route.Name
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "RouteCost",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = route.RouteCost
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "AidCost",
                                OleDbType = OleDbType.Decimal,
                                Direction = ParameterDirection.Input,
                                Value = route.AidCost
                            });

                            command.Parameters.Add(new OleDbParameter
                            {
                                ParameterName = "IsActive",
                                OleDbType = OleDbType.Boolean,
                                Direction = ParameterDirection.Input,
                                Value = route.IsActive
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

        public bool MarkAsDeleted(int routeId)
        {
            bool success = false;
            string updateQuery = $"UPDATE Route SET IsActive = NO WHERE Id = {routeId}";

            try
            {
                using (var connection = new OleDbConnection(this._connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = updateQuery;
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.Text;

                        command.ExecuteNonQuery();
                        success = true;
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
