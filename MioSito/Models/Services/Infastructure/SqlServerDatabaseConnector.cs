using MioSito.Controllers;
using MioSito.Models.ViewModels;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models.Services.Infastructure
{
    public class SqlServerDatabaseConnector : IDataBaseConnector
    {
        public DataSet Query(string query)
        {
            using (SqlConnection conn = new SqlConnection("Server=superdatabaseditest.database.windows.net;Database=Superdatabase;User Id=SuperUser;Password=MarcoGraziottiRegna33;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataSet dataSet = new DataSet();
                        DataTable dataTable = new DataTable();
                        dataSet.Tables.Add(dataTable);
                        dataTable.Load(reader);
                        return dataSet;
                    }
                }
            }
        }
        public bool Insert(AddCourseViewModel course)
        {
            using (SqlConnection conn = new SqlConnection("Server=superdatabaseditest.database.windows.net;Database=Superdatabase;User Id=SuperUser;Password=MarcoGraziottiRegna33;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand($"INSERT INTO Courses(Title, Author, Rating, FullPrice_Amount, FullPrice_Currency, CurrentPrice_Amount, CurrentPrice_Currency) VALUES (@Title, @Author, @Rating, @FullPrice, @ValutaFullPrice, @CurrentPrice, @ValutaCurrentPrice)", conn))
                {
                    
                    cmd.Parameters.AddWithValue("@Title",course.Title);
                    cmd.Parameters.AddWithValue("@Author", course.Author);
                    cmd.Parameters.AddWithValue("@Rating", course.Rating);
                    cmd.Parameters.AddWithValue("@FullPrice", course.FullPrice);
                    cmd.Parameters.AddWithValue("@ValutaFullPrice", course.ValutaFullPrice);
                    cmd.Parameters.AddWithValue("@CurrentPrice", course.CurrentPrice);
                    cmd.Parameters.AddWithValue("@ValutaCurrentPrice", course.ValutaCurrentPrice);

                    int p = cmd.ExecuteNonQuery();

                    return true;

                    
                }

            }
        }
    }
}
