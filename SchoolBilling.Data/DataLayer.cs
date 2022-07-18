using SchoolBilling.Data.DataSets;
using SchoolBilling.Data.Entities;
using SchoolBilling.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SchoolBilling.Data
{
    public sealed class DataLayer
    {
        private DataLayer()
        {
            // Left blank intentionally
        }

        public static bool UpdateDatabase()
        {
            using (var companyHelper = new CompanyHelper(GetConnectionString()))
            {
                return companyHelper.UpdateDatabase();
            }
        }

        public static Company GetCompanyDetail()
        {
            using (var companyHelper = new CompanyHelper(GetConnectionString()))
            {
                return companyHelper.GetCompanyDetail();
            }
        }

        public static bool SaveCompanyDetail(Company company)
        {
            using (var companyHelper = new CompanyHelper(GetConnectionString()))
            {
                return companyHelper.UpdateCompanyDetail(company);
            }
        }

        public static bool SaveClient(Client client)
        {
            using (var clientHelper = new ClientHelper(GetConnectionString()))
            {
                return clientHelper.UpdateClient(client);
            }
        }

        public static Client GetClientDetail(int clientId)
        {
            using (var clientHelper = new ClientHelper(GetConnectionString()))
            {
                return clientHelper.GetClientById(clientId);
            }
        }

        public static ClientDataSet GetAllClientDataSet()
        {
            using (var clientHelper = new ClientHelper(GetConnectionString()))
            {
                return clientHelper.GetAllClientsDataSet();
            }
        }

        public static List<Client> GetOrderedClients()
        {
            using (var clientHelper = new ClientHelper(GetConnectionString()))
            {
                return clientHelper.GetClientOrderedList();
            }
        }

        public static bool SaveRoute(Route route)
        {
            using (var routeHelper = new RouteHelper(GetConnectionString()))
            {
                return routeHelper.UpdateRouteDetail(route);
            }
        }

        public static bool IsRouteValid(string routeName)
        {
            using (var routeHelper = new RouteHelper(GetConnectionString()))
            {
                return routeHelper.IsRouteValid(routeName);
            }
        }

        public static Route GetRouteDetail(int routeId)
        {
            using (var routeHelper = new RouteHelper(GetConnectionString()))
            {
                return routeHelper.GetRouteById(routeId);
            }
        }

        public static RouteDataSet GetAllRoutesDataSet()
        {
            using (var routeHelper = new RouteHelper(GetConnectionString()))
            {
                return routeHelper.GetAllRoutesDataSet();
            }
        }

        public static List<Route> GetOrderedRoutes()
        {
            using (var routeHelper = new RouteHelper(GetConnectionString()))
            {
                return routeHelper.GetRouteListOrdered();
            }
        }

        public static bool DeleteRoute(int routeId)
        {
            using (var routeHelper = new RouteHelper(GetConnectionString()))
            {
                return routeHelper.MarkAsDeleted(routeId);
            }
        }

        public static bool SaveInvoice(Invoice invoice)
        {
            using (var invoiceHelper = new InvoiceHelper(GetConnectionString()))
            {
                return invoiceHelper.UpdateInvoice(invoice);
            }
        }

        public static InvoiceDataSet GetInvoicesDataSet(DateTime startDate, DateTime endDate)
        {
            using (var invoiceHelper = new InvoiceHelper(GetConnectionString()))
            {
                return invoiceHelper.GetAllInvoicesDataSet(startDate, endDate);
            }
        }

        public static Invoice GetInvoiceById(int invoiceId)
        {
            using (var invoiceHelper = new InvoiceHelper(GetConnectionString()))
            {
                return invoiceHelper.GetInvoiceById(invoiceId);
            }
        }

        public static int GenerateInvoiceNumber()
        {
            using (var invoiceHelper = new InvoiceHelper(GetConnectionString()))
            {
                return invoiceHelper.GenerateInvoiceNumber();
            }
        }

        public static bool IsInvoiceNumberValid(int invoiceId, int invoiceNumber)
        {
            using (var invoiceHelper = new InvoiceHelper(GetConnectionString()))
            {
                return invoiceHelper.IsInvoiceNumberValid(invoiceId, invoiceNumber);
            }
        }

        public static bool IsPasswordSet()
        {
            using (var companyHelper = new CompanyHelper(GetConnectionString()))
            {
                return companyHelper.IsPasswordSet();
            }
        }

        public static string GetPassword()
        {
            using (var companyHelper = new CompanyHelper(GetConnectionString()))
            {
                return companyHelper.GetPassword();
            }
        }

        public static bool SetPassword(string password)
        {
            using (var companyHelper = new CompanyHelper(GetConnectionString()))
            {
                return companyHelper.SetPassword(password);
            }
        }

        private static BillingContext GetContext()
        {
            return new BillingContext();
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
    }
}
