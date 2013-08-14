using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

    public class DataManager
    {
        #region ConnectionString
        //Connections String;
        static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //
        #endregion

        #region parameters
        /// <summary>
        /// Create a paramter for DataManager Class
        /// </summary>
        /// <param name="prmName">name of the param</param>
        /// <param name="type">type of the param</param>
        /// <param name="prmValue">Value of the param</param>
        /// <returns>SqlParameter</returns>
        public static SqlParameter CreateParameter(string prmName,SqlDbType type,object prmValue)
        {
            SqlParameter prm = new SqlParameter(prmName,type);
            prm.Value = prmValue;
            return prm;
        }
        /// <summary>
        /// Create a paramter for DataManager Class
        /// </summary>
        /// <param name="prmName">name of the param</param>
        /// <param name="type">type of the param</param>
        /// <param name="dirction">The Dircton |output Or Input|</param>
        /// <returns>SqlParameter</returns>
        public static SqlParameter CreateParameter(string prmName, SqlDbType type, ParameterDirection dirction)
        {
            SqlParameter prm = new SqlParameter(prmName, type);
            prm.Direction = dirction;
            return prm;

        }

        #endregion

        #region DisConnected



        /// <summary>
        /// Return the Data Set, for selecting and filling controls in the Disconnectuing Model
        /// </summary>
        /// <param name="stordName">name of the stored procedure</param>
        /// <param name="tableName">name of the table that located in the memory</param>
        /// <param name="prmArray">paramter array for set the paramters if included</param>
        /// <returns>dataset</returns>
        public static DataSet GetDataSet(string stordName, string tableName, params SqlParameter[] prmArray)
        {
            SqlConnection con = new SqlConnection(DataManager.constr);
            SqlCommand comm = new SqlCommand(stordName, con);
            comm.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter par in prmArray)
            {
                comm.Parameters.Add(par);
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds, tableName);
            return ds;

        }
        #endregion

        #region Connected
        
        /// <summary>
        /// Return the Data Set, for selecting and filling controls in the Connected Model
        /// </summary>
        /// <param name="storedName">name of the stored procedure</param>
        /// <param name="conOut">the connection status thrower</param>
        /// <param name="prmArray">paramter array for set the paramters if included</param>
        /// <returns>datarow</returns>
        public static SqlDataReader GetDataReader(string storedName,out SqlConnection conOut,params SqlParameter [] prmArray)
        {
            SqlConnection con = new SqlConnection(DataManager.constr);
            SqlCommand comm = new SqlCommand(storedName, con);
            comm.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter par in prmArray)
            {
                comm.Parameters.Add(par);
            }
            con.Open();
            SqlDataReader dr = comm.ExecuteReader();
            conOut = con;
            return dr;

        }
        /// <summary>
        /// Used for Insert,Update or Delete in the data base and it's define
        /// its usage by the type of the stored procedure.
        /// </summary>
        /// <param name="storedName">stored procedure name</param>
        /// <param name="prmArray">paramter array for set the paramters if included</param>
        /// <returns>int</returns>
        public static int ExecuteNonQuery(string storedName,params SqlParameter[] prmArray )
        {
            SqlConnection con = new SqlConnection(DataManager.constr);
            SqlCommand comm = new SqlCommand(storedName, con);
            comm.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter par in prmArray)
            {
                comm.Parameters.Add(par);
            }
            con.Open();
            int x = comm.ExecuteNonQuery();
            return x;
            con.Close();
        }

        /// <summary>
        /// Used for Insert,Update or Delete and returns multiple output 
        /// </summary>
        /// <param name="storedName">name of stored procedure</param>
        /// <param name="prmArray">paramter array for set the paramters if included</param>
        /// <returns>Hashtable</returns>
        public static Hashtable ExecuteNonQueryOutput(string storedName, params SqlParameter[] prmArray)
        {
            SqlConnection con = new SqlConnection(DataManager.constr);
            SqlCommand comm = new SqlCommand(storedName, con);
            comm.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter par in prmArray)
            {
                comm.Parameters.Add(par);
            }
            con.Open();
            comm.ExecuteNonQuery();
            Hashtable ht = new Hashtable();
            foreach (SqlParameter prm in prmArray)
            {
                if (prm.Direction == ParameterDirection.Output)
                {
                    ht.Add(prm.ParameterName, prm.Value);
                }
            }

            return ht;
            con.Close();
        }



        /// <summary>
        /// Used for Insert,Update or Delete in the data base and it's define
        /// its usage by the type of the stored procedure Plus its return with one affected vataible
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="prmArray"></param>
        /// <returns>Object</returns>
        public static object ExecuteScalar(string storedName, params SqlParameter[] prmArray)
        {
            SqlConnection con = new SqlConnection(DataManager.constr);
            SqlCommand comm = new SqlCommand(storedName, con);
            comm.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter par in prmArray)
            {
                comm.Parameters.Add(par);
            }
            con.Open();
            object o = comm.ExecuteScalar();
            return o;
            con.Close();
        }
        #endregion

        #region Menu
        /// <summary>
        /// Menu Population
        /// </summary>
        /// <param name="tb1Name"></param>
        /// <param name="tb1procedure"></param>
        /// <param name="tb2Name"></param>
        /// <param name="tb2procedure"></param>
        /// <param name="tb1Column"></param>
        /// <param name="tb2Column"></param>
        /// <param name="relationName"></param>
        /// <returns></returns>


        public static DataSet GetMenuOut(string tb1Name, string tb1procedure, string tb1Column, string tb2Name, string tb2procedure,
            string tb2Column,string relationName)
        {
            SqlConnection conn = new SqlConnection(DataManager.constr);

            SqlDataAdapter admenu = new SqlDataAdapter(tb1procedure, conn);

            SqlDataAdapter adcat = new SqlDataAdapter(tb2procedure, conn);

            DataSet ds = new DataSet();

            admenu.Fill(ds, tb1Name);

            adcat.Fill(ds, tb2Name);

            ds.Relations.Add(relationName, ds.Tables[tb1Name].Columns[tb1Column], ds.Tables[tb2Name].Columns[tb2Column]);

            return ds;
        }
        #endregion



    }

