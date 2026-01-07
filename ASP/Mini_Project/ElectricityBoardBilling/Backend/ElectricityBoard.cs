using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ElectricityBoardBilling.Backend
{
    public class ElectricityBoard
    {
       
        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount = 0;

            if (units > 100)
                amount += Math.Min(units - 100, 200) * 1.5;

            if (units > 300)
                amount += Math.Min(units - 300, 300) * 3.5;

            if (units > 600)
                amount += Math.Min(units - 600, 400) * 5.5;

            if (units > 1000)
                amount += (units - 1000) * 7.5;

            ebill.BillAmount = amount;
        }


        public bool AddBill(ElectricityBill ebill)
        {
            using (SqlConnection con = DBHandler.GetConnection())
            {
                string query =
                    "INSERT INTO ElectricityBill " +
                    "(consumer_number, consumer_name, units_consumed, bill_amount, bill_month) " +
                    "VALUES (@cno, @cname, @units, @amount, @month)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@cno", ebill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@cname", ebill.ConsumerName);
                cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);
                cmd.Parameters.AddWithValue("@month", ebill.BillMonth);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }



        public List<ElectricityBill> Generate_N_BillDetails(int n)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();

            using (SqlConnection con = DBHandler.GetConnection())
            {
                string query =
                    "SELECT TOP (@n) consumer_number, consumer_name, units_consumed, bill_amount " +
                    "FROM ElectricityBill ORDER BY consumer_number DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", n);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ElectricityBill ebill = new ElectricityBill
                    {
                        ConsumerNumber = reader["consumer_number"].ToString(),
                        ConsumerName = reader["consumer_name"].ToString(),
                        UnitsConsumed = int.Parse(reader["units_consumed"].ToString()),
                        BillAmount = double.Parse(reader["bill_amount"].ToString())
                    };

                    bills.Add(ebill);
                }
            }

            return bills;
        }

        public List<ElectricityBill> GetBillsByConsumer(string consumerNumber)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();
            using (SqlConnection con = DBHandler.GetConnection())
            {
                string query =
            "SELECT consumer_number, consumer_name, bill_month, units_consumed, bill_amount " +
            "FROM ElectricityBill " +
            "WHERE consumer_number = @cno " +
            "ORDER BY bill_month";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@cno", consumerNumber);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    bills.Add(new ElectricityBill
                    {
                        ConsumerNumber = dr["consumer_number"].ToString(),
                        ConsumerName = dr["consumer_name"].ToString(),
                        BillMonth = dr["bill_month"].ToString(),
                        UnitsConsumed = Convert.ToInt32(dr["units_consumed"]),
                        BillAmount = Convert.ToDouble(dr["bill_amount"])
                    });
                }
            }
            return bills;
        }

    }
}
