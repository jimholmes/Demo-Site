using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace SupportApi
{
    public static class DataHelpers
    {
        private static SqlConnection conn;

        private static string conn_str =
            "Integrated Security=true;Initial Catalog=demos;Server=(local);";
            //"Integrated Security=true;Initial Catalog=demos;Server=s12r2\\sqlexpress;";
        public static int get_high_contact_id()
        {
            int id;
            using (conn = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("select max(id) from contacts");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Connection.Open();
                id = (Int32)cmd.ExecuteScalar();
                cmd.Connection.Close();
            }
            return id;
        }

        public static Contact get_contact_by_id(int id)
        {
            ContactRepository repos = new ContactRepository();
            return repos.GetOneContact(id);
        }
        public static int create_new_contact()
        {
            Contact contact = new Contact();
            contact.Company = random_string(8);
            contact.FName = random_string(6);
            contact.LName = random_string(10);
            contact.Region = random_string(4);

            ContactRepository repos = new ContactRepository();
            return repos.SaveContact(contact).Id;
        }

        // http://stackoverflow.com/questions/1122483/random-string-generator-returning-same-string
        private static Random random = 
            new Random((int)DateTime.Now.Ticks);
        private static string random_string(int size)
        {
            StringBuilder builder = new StringBuilder();
            char letter;
            for (int i = 0; i < size; i++)
            {
                letter = Convert.ToChar(Convert.ToInt32(
                    Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(letter);
            }

            return builder.ToString();
        }

    }
}
