using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tutorial7ADO.Models;

namespace Tutorial7ADO.DataAccess
{
    public class DataAccessLayer
    {
        public int InsertData(CustomerDBModel objcust)
        {
            SqlConnection con = null;
            try
            {
                con = DBConnection.GetConnection();
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", 0);
                cmd.Parameters.AddWithValue("@Name", objcust.Name);
                cmd.Parameters.AddWithValue("@Address", objcust.Address);
                cmd.Parameters.AddWithValue("@Mobileno", objcust.Mobileno);
                cmd.Parameters.AddWithValue("@Birthdate", objcust.Birthdate);
                cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);

                if (objcust.CustomerID > 0)
                    cmd.Parameters.AddWithValue("@Query", 2);
                else
                    cmd.Parameters.AddWithValue("@Query", 1);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConnection.Dispose(con);
            }
        }        
        public List<CustomerDBModel> SelectAllData()
        {
            SqlConnection con = null;
            DataTable dt = new DataTable();
            List<CustomerDBModel> _DBModelList = new List<CustomerDBModel>();
            try
            {
                con = DBConnection.GetConnection();
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Query", 4);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CustomerDBModel _DBModel = new CustomerDBModel();
                        _DBModel.CustomerID = Convert.ToInt32(dr["CustomerID"].ToString());
                        _DBModel.Name = dr["Name"].ToString();
                        _DBModel.Address = dr["Address"].ToString();
                        _DBModel.Mobileno = dr["Mobileno"].ToString();
                        _DBModel.EmailID = dr["EmailID"].ToString();
                        _DBModel.Birthdate = Convert.ToDateTime(dr["Birthdate"].ToString());
                        _DBModelList.Add(_DBModel);
                    }
                }

                return _DBModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConnection.Dispose(con);
            }
        }
        public CustomerDBModel SelectDatabyID(CustomerDBModel objcust)
        {
            SqlConnection con = null;
            DataTable dt = new DataTable();
            CustomerDBModel _DBModelList = new CustomerDBModel();
            try
            {
                con = DBConnection.GetConnection();
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", objcust.CustomerID);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    _DBModelList.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                    _DBModelList.Name = dt.Rows[0]["Name"].ToString();
                    _DBModelList.Address = dt.Rows[0]["Address"].ToString();
                    _DBModelList.Mobileno = dt.Rows[0]["Mobileno"].ToString();
                    _DBModelList.EmailID = dt.Rows[0]["EmailID"].ToString();
                    _DBModelList.Birthdate = Convert.ToDateTime(dt.Rows[0]["Birthdate"].ToString());
                }
                return _DBModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConnection.Dispose(con);
            }
        }
        public int DeleteData(CustomerDBModel objcust)
        {
            SqlConnection con = null;
            try
            {
                con = DBConnection.GetConnection();
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", objcust.CustomerID);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Mobileno", null);
                cmd.Parameters.AddWithValue("@Birthdate", null);
                cmd.Parameters.AddWithValue("@EmailID", null);
                cmd.Parameters.AddWithValue("@Query", 3);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConnection.Dispose(con);
            }
        }
    }
}