using HospitalManagementSystem2025.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HospitalManagementSystem2025.Repositories
{
    public class PatientRepositoryImpl : IPatientRepository
    {
        private readonly string connectionString;

        public PatientRepositoryImpl(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MVCConnectionString");
        }

        #region GetAllPatients
        public IEnumerable<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPatientList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    patients.Add(new Patient
                    {
                        PatientId = (int)reader["PatientId"],
                        RegistrationNo = reader["RegistrationNo"].ToString(),
                        PatientName = reader["PatientName"].ToString(),
                        Dob = reader["Dob"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Dob"]),
                        Gender = reader["Gender"].ToString(),
                        Address = reader["Address"].ToString(),
                        PhoneNo = reader["PhoneNo"].ToString(),
                        MembershipId = reader["MembershipId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MembershipId"]),
                        MemberDescription = reader["MemberDescription"].ToString(),
                        InsuredAmount = reader["InsuredAmount"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["InsuredAmount"])
                    });
                }
                con.Close();
            }

            return patients;
        }
        #endregion

        #region GetAllMemberships
        public List<Membership> GetAllMemberships()
        {
            var list = new List<Membership>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllMemberships", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Membership
                    {
                        MembershipId = (int)reader["MembershipId"],
                        MemberDescription = reader["MemberDescription"].ToString(),
                        InsuredAmount = reader["InsuredAmount"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["InsuredAmount"])
                    });
                }
                con.Close();
            }

            return list;
        }
        #endregion

        #region InsertPatient
        public void InsertPatient(Patient patient)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RegistrationNo", patient.RegistrationNo);
                cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                cmd.Parameters.AddWithValue("@Dob", patient.Dob ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);
                cmd.Parameters.AddWithValue("@MembershipId", patient.MembershipId ?? (object)DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        #endregion

        #region UpdatePatient
        public void UpdatePatient(Patient patient)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EditPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", patient.PatientId);
                cmd.Parameters.AddWithValue("@RegistrationNo", patient.RegistrationNo);
                cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
                cmd.Parameters.AddWithValue("@Dob", patient.Dob ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", patient.PhoneNo);
                cmd.Parameters.AddWithValue("@MembershipId", patient.MembershipId ?? (object)DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        #endregion

        #region GetPatientById
        public Patient GetPatientById(int id)
        {
            Patient patient = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPatientById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    patient = new Patient
                    {
                        PatientId = (int)reader["PatientId"],
                        RegistrationNo = reader["RegistrationNo"].ToString(),
                        PatientName = reader["PatientName"].ToString(),
                        Dob = reader["Dob"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Dob"]),
                        Gender = reader["Gender"].ToString(),
                        Address = reader["Address"].ToString(),
                        PhoneNo = reader["PhoneNo"].ToString(),
                        MembershipId = reader["MembershipId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MembershipId"]),
                        MemberDescription = reader["MemberDescription"].ToString(),
                        InsuredAmount = reader["InsuredAmount"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["InsuredAmount"])
                    };
                }
                con.Close();
            }

            return patient;
        }
        #endregion
    }
}
